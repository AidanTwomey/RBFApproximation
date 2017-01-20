module InterpolationTests

module ``Interpolation Tests`` =
    open NUnit.Framework
    open FsUnit
    open RBFApproximation.Library
    open RBFApproximation.Library.Geometry
    open MathNet.Numerics.LinearAlgebra
    open MathNet.Numerics.Data.Text
    open RBFApproximation.Library.Functions
    open RBFApproximation.Library.RadialFunctions
    open RBFApproximation.Library.Interpolate
    
    [<Test>]
    let ``interpolation with gaussian is correct`` () =
        let interpolatedSource = @"C:\src\RBFApproximation\Approximation\RBFApproximation.Library.Tests\bin\Debug\Pf.csv"
        let expected = DelimitedReader.Read<double>(interpolatedSource, false, ",", false)

        let source = @"C:\src\RBFApproximation\Approximation\RBFApproximation.Library.Tests\bin\Debug\dsites.csv"
        let ctrs = DelimitedReader.Read<double>(source, false, ",", false)

        let neval = 10

        let rhs = Vector.Build.DenseOfEnumerable( ctrs.EnumerateRows() |> Seq.map ( fun r -> franke r.[0] r.[1] ) )
    
        let interpolated = interpolate2D ctrs rhs neval (gaussian 21.1)

        (interpolated - expected).L2Norm() |> should be (lessThan 0.0001)
