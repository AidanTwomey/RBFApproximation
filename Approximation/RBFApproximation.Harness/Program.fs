open RBFApproximation.Library.RadialFunctions
open RBFApproximation.Library.Functions
open RBFApproximation.Library.Geometry
open MathNet.Numerics.LinearAlgebra
open MathNet.Numerics.Data.Text

open System.IO
open System


[<EntryPoint>]
let main argv = 

    let N = 1089

    let source = @"C:\src\RBFApproximation\Approximation\RBFApproximation.Library\bin\Debug\dsites.csv"
    let ctrs = DelimitedReader.Read<double>(source, false, ",", false)

    let epointSource = @"C:\src\RBFApproximation\Approximation\RBFApproximation.Harness\bin\Debug\epoints.csv"
    let epoints = DelimitedReader.Read<double>(epointSource, false, ",", false)

    let neval = 20

    let rhs = Vector.Build.DenseOfEnumerable( ctrs.EnumerateRows() |> Seq.map ( fun r -> franke r.[0] r.[1] ) )
    
    let dm_data = distanceMatrix ctrs ctrs
    let dm_eval = distanceMatrix epoints ctrs 

    let im = dm_data |> Matrix.map (gaussian 21.1)
    let em = dm_eval |> Matrix.map (gaussian 21.1)
    let Pf = im.Solve(rhs)

    0 // return an integer exit code
