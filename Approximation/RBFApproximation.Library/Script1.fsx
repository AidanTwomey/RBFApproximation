#r @"bin\Debug\RBFApproximation.Library.dll"
#r @"bin\Debug\MathNet.Numerics.FSharp.dll"
#r @"bin\Debug\MathNet.Numerics.dll"
#r @"bin\Debug\MathNet.Numerics.Data.Text.dll"


open RBFApproximation.Library.RadialFunctions
open RBFApproximation.Library.Functions
open RBFApproximation.Library.Geometry
open MathNet.Numerics.LinearAlgebra
open MathNet.Numerics.Data.Text

open System.IO
open System

let N = 1089

//let source = @"C:\src\RBFApproximation\Approximation\RBFApproximation.Library\bin\Debug\dsites.csv"
//let ctrs = DelimitedReader.Read<double>(source, false, ",", false)

let neval = 20

let grid = linspace 0.0 1.0 40

//
//let rhs = Vector.Build.DenseOfEnumerable( ctrs.EnumerateRows() |> Seq.map ( fun r -> franke r.[0] r.[1] ) )
//let dm_data = distanceMatrix ctrs ctrs
//let im = dm_data |> Matrix.map (gaussian 2.1)
//
//let Pf = im.Solve(rhs)
//
//Pf.ToString()

//let none = s |> Seq.skip 3 |> Seq.skip 3 |> Seq.skip 3 |> Seq.isEmpty

let toRows s = 
    let rec loop rows remain =
        if Seq.isEmpty remain 
            then 
                rows
            else
                let (row, skipped) = (remain |> Seq.take 3, remain |> Seq.skip 3)
                loop (row::rows) skipped
    loop [] s |> List.rev

let squareMatrix = toRows [1;2;3;4;5;6;7;8;9;]
