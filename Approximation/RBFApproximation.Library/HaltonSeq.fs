namespace RBFApproximation.Library

open System

module Geometry =

    type Point =
       | Point1D of double
       | Point2D of double * double

    let norm (p:int) (point:Point) = 
        match point with
        | Point1D(x)   -> x
        | Point2D(x,y) -> Math.Sqrt( Math.Pow( x, (double)p) + Math.Pow( y, double(p)) )

module Sequences =

    let halton n dimension =
        
        let rec createPoint index (factor:double) basePrime result =
            if index > 0 
              then 
                let updatef = factor / basePrime
                createPoint ((int)(floor ((double)index/basePrime))) updatef basePrime (result + updatef * (double)(index % (int)basePrime))
              else
                result

        let  naturalNumbers = 1 |> List.unfold (fun i -> if (i > n) then None else Some(i, i+1))           

        let create1D = 
            naturalNumbers |> List.map ( fun i -> Geometry.Point1D(createPoint i 1.0 2.0 0.0))     

        let create2D =
            naturalNumbers |> List.map ( fun i -> Geometry.Point2D((createPoint i 1.0 2.0 0.0), createPoint i 1.0 3.0 0.0))

        match dimension with
        | 1 -> create1D
        | 2 -> create2D
        | _ -> []
            

