#r @"bin\Debug\RBFApproximation.Library.dll"

RBFApproximation.Library.Sequences.halton 10 1 

open System

[1;2;3] |> Seq.iter Console.WriteLine

1 |> List.unfold (fun i -> if (i > 10) then None else Some(i, i+1)) |> Seq.iter Console.WriteLine


