module GeometryTests

module ``Geometry Tests`` =
    open NUnit.Framework
    open FsUnit
    open RBFApproximation.Library
    open RBFApproximation.Library.Geometry
    open MathNet.Numerics.LinearAlgebra

    let norm2 = (norm 2)

    [<Test>]
    let ``1D sequence is correct`` () =
        let grid =  matrix [[-1.0; -1.0; -1.0; -1.0; -1.0]
                            [-0.25; -0.25; -0.25; -0.25; -0.25]
                            [0.5; 0.5; 0.5; 0.5; 0.5]]
        Geometry.ngrid (vector [-1.0; -0.25; 0.5]) (vector [-1.0; -0.5; 0.0; 0.5; 1.0;]) |> should equal grid