open RBFApproximation.Library.RadialFunctions
open RBFApproximation.Library.Functions
open RBFApproximation.Library.Geometry
open RBFApproximation.Library.Interpolate
open MathNet.Numerics.LinearAlgebra
open MathNet.Numerics.Data.Text

open System.IO
open System


[<EntryPoint>]
let main argv = 

    let ctrs = DelimitedReader.Read<double>( @"C:\data\swaption\20170119\swaptionpoints_strike_ctrs.csv", false, ",", false)

    let neval = 40

    let rhs = DelimitedReader.Read<double>( @"C:\data\swaption\20170119\swaptionpoints_strike_ctrs.csv", false, ",", false).Column(0)
    
    let Pf = interpolate2D ctrs rhs neval (gaussian 21.1)

    DelimitedWriter.Write(@"C:\data\surface.csv", Pf, ",")
    0