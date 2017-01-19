open RBFApproximation.Library.RadialFunctions
open RBFApproximation.Library.Functions
open RBFApproximation.Library.Geometry
open RBFApproximation.Library.Interpolate
open MathNet.Numerics.LinearAlgebra
open MathNet.Numerics.Data.Text

open System.IO
open System


[<EntryPoint>]
let main argv = 

    let N = 1089

    let source = @"C:\src\RBFApproximation\Approximation\RBFApproximation.Library\bin\Debug\dsites.csv"
    let ctrs = DelimitedReader.Read<double>(source, false, ",", false)

    let epointSource = @"C:\src\RBFApproximation\Approximation\RBFApproximation.Harness\bin\Debug\epoints.csv"
    let epoints = DelimitedReader.Read<double>(epointSource, false, ",", false)

    let ep = meshgrid

    let neval = 20

    let rhs = Vector.Build.DenseOfEnumerable( ctrs.EnumerateRows() |> Seq.map ( fun r -> franke r.[0] r.[1] ) )
    
    let Pf = interpolate2D ctrs rhs epoints

    0