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
    let ``ndgrid is correct`` () =
        let grid1 =  matrix [[-1.0; -1.0; -1.0; -1.0; -1.0]
                             [-0.25; -0.25; -0.25; -0.25; -0.25]
                             [0.5; 0.5; 0.5; 0.5; 0.5]]

        let grid2 =  matrix [[-1.0; -0.5; 0.0; 0.5; 1.0]
                             [-1.0; -0.5; 0.0; 0.5; 1.0]
                             [-1.0; -0.5; 0.0; 0.5; 1.0]]

        let (X1,X2) = Geometry.ngrid (vector [-1.0; -0.25; 0.5]) (vector [-1.0; -0.5; 0.0; 0.5; 1.0;]) 
        
        X1 |> should equal grid1
        X2 |> should equal grid2


    [<Test>]
    let ``linspace is correct`` () =

        let lspace = (Geometry.linspace 0.0 1.0 6) 
        lspace |> should equal (vector [0.0;0.2;0.4;0.6;0.8;1.0])

    [<Test>]
    let ``distance matrix calculates correctly``() =
        let dsites = matrix [[0.50000;0.33333]
                             [0.25000;0.66667]
                             [0.75000;0.11111]
                             [0.12500;0.44444]
                             [0.62500;0.77778]
                             [0.37500;0.22222]]

        let expected = matrix [[0.00000;0.41667;0.33449;0.39111;0.46169;0.16724]
                               [0.41667;0.00000;0.74742;0.25497;0.39111;0.46169]
                               [0.33449;0.74742;0.00000;0.70833;0.67828;0.39111]
                               [0.39111;0.25497;0.70833;0.00000;0.60093;0.33449]
                               [0.46169;0.39111;0.67828;0.60093;0.00000;0.60921]
                               [0.16724;0.46169;0.39111;0.33449;0.60921;0.00000]]

        let dm = distanceMatrix dsites dsites

        let dm_norm = dm.L2Norm()
        let expected_norm = expected.L2Norm()

        dm_norm - expected_norm |> should be (lessThan 0.0001)