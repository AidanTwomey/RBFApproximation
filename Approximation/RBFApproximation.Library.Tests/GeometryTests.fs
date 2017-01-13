module GeometryTests

module ``Function Tests`` =
    open NUnit.Framework
    open FsUnit
    open RBFApproximation.Library
    open RBFApproximation.Library.Functions

    [<Test>]
    let ``Franke is correct`` () =
        ((franke 0.5 0.666) - -0.039517) |> should be  (lessThan 0.00001) 


module ``Geometry Tests`` =
    open NUnit.Framework
    open FsUnit
    open RBFApproximation.Library
    open RBFApproximation.Library.Geometry
    open MathNet.Numerics.LinearAlgebra

    let norm2 = (norm 2)

    [<Test>]
    let ``1D sequence is correct`` () =
        let grid1 =  matrix [[-1.0; -1.0; -1.0; -1.0; -1.0]
                             [-0.25; -0.25; -0.25; -0.25; -0.25]
                             [0.5; 0.5; 0.5; 0.5; 0.5]]

        let grid2 =  matrix [[-1.0; -0.5; 0.0; 0.5; 1.0]
                             [-1.0; -0.5; 0.0; 0.5; 1.0]
                             [-1.0; -0.5; 0.0; 0.5; 1.0]]

        let (X1,X2) = Geometry.ngrid (vector [-1.0; -0.25; 0.5]) (vector [-1.0; -0.5; 0.0; 0.5; 1.0;]) 
        
        X1 |> should equal grid1
        X2 |> should equal grid2