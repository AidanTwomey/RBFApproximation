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
        let primes = [2; 3; 5; 7; 11; 13; 17; 19; 23; 29; 31;]
                
        let rec createPoint i f (b:int) (result:double) =
            if i > 0 
              then 
                let updatef = (double)f / (double)b
                let updateResult = result + updatef * (double)(i % b)
                createPoint ((int)(floor ((double)i/(double)b))) updatef b updateResult
              else
                result
        let  enumerated = 1 |> List.unfold (fun i -> if (i > n) then None else Some(i, i+1))           

        let create1D points = 
            points |> List.map ( fun i -> Geometry.Point1D(createPoint i 1.0 2 0.0))     

        let create2D points =
            points |> List.map ( fun i -> Geometry.Point2D((createPoint i 1.0 2 0.0), createPoint i 1.0 3 0.0))

        match dimension with
        | 1 -> create1D enumerated
        | 2 -> create2D enumerated
        | _ -> []
            

