﻿#r @"bin\Debug\RBFApproximation.Library.dll"
#r @"bin\Debug\MathNet.Numerics.dll"
#r @"bin\Debug\MathNet.Numerics.FSharp.dll"

//RBFApproximation.Library.Sequences.halton 10 1 

open System
open RBFApproximation.Library
open RBFApproximation.Library.Geometry

//[1;2;3] |> Seq.iter Console.WriteLine
//
//1 |> List.unfold (fun i -> if (i > 10) then None else Some(i, i+1)) |> Seq.iter Console.WriteLine
//
//
//[1.0;2.0;3.0;4.0] |> Seq.map ( fun i -> i ** 2.0) |> Seq.iter System.Console.WriteLine

//Functions.franke 0.5 0.666


let grid = linspace 0.0 1.0 40