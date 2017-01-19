namespace RBFApproximation.Library

open System
open MathNet.Numerics.LinearAlgebra
open Functions

module Geometry =

    type Point =
       | Point1D of double
       | Point2D of double * double

    let norm (p:int) (point:Point) = 
        match point with
        | Point1D(x)   -> x
        | Point2D(x,y) -> Math.Sqrt( Math.Pow( x, (double)p) + Math.Pow( y, double(p)) )

    let ngrid (X1:Vector<double>) (X2:Vector<double>) =
        (DenseMatrix.init X1.Count X2.Count (fun i j -> X1.[i]),DenseMatrix.init X1.Count X2.Count (fun i j -> X2.[j]))
    
    let meshgrid (X1:Vector<double>) (X2:Vector<double>) =
        let (x,y) = (ngrid X1 X2)
        (x.Transpose(), y.Transpose())

    let linspace a b n = 
        let stepSize = (b - a) / (double)(n-1)
        let nextStep (i:int) = a + (stepSize * (double)i)

        DenseVector.init n nextStep

    let generateEvaluationGrid n =
        let grid = linspace 0.0 1.0 n
        let (x,y) = meshgrid grid grid

        let xPoints = x |> Matrix.toSeq 
        let yPoints = y |> Matrix.toSeq

        let rows = Seq.zip xPoints yPoints |> Seq.map (fun (xp,yp) -> vector[ xp;yp ]) 

//        DenseMatrix.create (n*n) 2 (fun i j -> if ( i = 1) then (x.[i mod n, i mod n]) else (y.[i mod n, i mod n]))

        DenseMatrix.ofRowSeq rows

    let distanceMatrix (dsites:Matrix<double>) (ctrs:Matrix<double>) =
        
        let rec fill i dm =
                       
            if i < dsites.ColumnCount 
                then 
                    let (d,c) = ngrid (dsites.Column(i)) (ctrs.Column(i)) 
                    fill (i+1) (dm + ( (d - c) |> Matrix.map square )) 
                else 
                    dm

        let zero = DenseMatrix.zero<double> dsites.RowCount ctrs.RowCount
        (fill 0 zero) |> Matrix.map Math.Sqrt


module Sequences =

    let halton n dimension =
        
        let rec createPoint index (factor:double) basePrime result =
            if index > 0 
              then 
                let updatef = factor / basePrime
                createPoint ((int)(floor ((double)index/basePrime))) updatef basePrime (result + updatef * (double)(index % (int)basePrime))
              else
                result

        let  naturalNumbers = 1 |> Seq.unfold (fun i -> if (i > n) then None else Some(i, i+1)) |> Seq.toList      

        let create1D = 
            naturalNumbers |> List.map ( fun i -> Geometry.Point1D(createPoint i 1.0 2.0 0.0))     

        let create2D =
            naturalNumbers |> List.map ( fun i -> Geometry.Point2D((createPoint i 1.0 2.0 0.0), createPoint i 1.0 3.0 0.0))

        match dimension with
        | 1 -> create1D
        | 2 -> create2D
        | _ -> []
            

