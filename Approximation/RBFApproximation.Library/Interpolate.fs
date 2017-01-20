namespace RBFApproximation.Library

open System
open MathNet.Numerics.LinearAlgebra
open Functions
open Geometry
open RadialFunctions

module Interpolate =

    let interpolate2D dsites (f:Vector<float>) n rbf =
        let epoints = generateEvaluationGrid n

        let dm_data = distanceMatrix dsites dsites
        let dm_eval = distanceMatrix epoints dsites 

        let im = dm_data |> Matrix.map rbf
        let em = dm_eval |> Matrix.map rbf
        
        let Pf = em * im.Solve(f)
        
        let toRows s = 
            let rec loop rows remain =
                if Seq.isEmpty remain 
                    then 
                        rows
                else
                    let (row, skipped) = (remain |> Seq.take n, remain |> Seq.skip n)
                    loop (row::rows) skipped
            loop [] s |> List.rev 

        DenseMatrix.ofColumnSeq ( toRows (Pf |> Vector.toSeq) )

