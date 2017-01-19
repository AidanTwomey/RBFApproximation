namespace RBFApproximation.Library

open System
open MathNet.Numerics.LinearAlgebra
open Functions
open Geometry
open RadialFunctions

module Interpolate =

    let interpolate2D dsites (f:Vector<float>) epoints =
        let dm_data = distanceMatrix dsites dsites
        let dm_eval = distanceMatrix epoints dsites 

        let im = dm_data |> Matrix.map (gaussian 21.1)
        let em = dm_eval |> Matrix.map (gaussian 21.1)
        em * im.Solve(f)
        

