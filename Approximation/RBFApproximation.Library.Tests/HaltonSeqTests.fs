module HaltonSeqTests

module ``Halton Sequence Tests`` =
    open NUnit.Framework
    open FsUnit
    open RBFApproximation.Library
    open RBFApproximation.Library.Geometry

    let norm2 = (norm 2)

    [<Test>]
    let ``1D sequence is correct`` () =
        let halton1D = [0.5;  0.25; 0.75; 0.125; 0.625; 0.375; 0.875; 0.0625; 0.5625; 0.312500] |> List.map ( fun v -> Point1D(v) )
        (Sequences.halton 10 1) |> should equal halton1D

    [<Test>]
    let ``2D sequence is correct``() =
        let halton2D = [
            (0.500000, 0.333333);
            (0.250000, 0.666667);
            (0.750000, 0.111111);
            (0.125000, 0.444444);
            (0.625000, 0.777778);
            (0.375000, 0.222222);
            (0.875000, 0.555556);
            (0.062500, 0.888889);
            (0.562500, 0.037037);
            (0.312500, 0.370370);] |> List.map ( fun (x,y) -> Point2D(x,y) )
        
        (Sequences.halton 10 2) 
            |> Seq.zip halton2D 
            |> Seq.map ( fun (p1,p2) -> (norm2 p1 - norm2 p2 ) ) 
            |> Seq.map abs 
            |> Seq.sum 
            |> should be (lessThan 0.00001)
