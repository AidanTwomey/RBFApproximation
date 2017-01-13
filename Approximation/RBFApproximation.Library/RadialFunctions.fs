namespace RBFApproximation.Library

open System

module Functions =

    let square x = x ** 2.0

    let exp x = Math.Exp(x)

    let franke x y = 
        let f1 = 0.75* exp(-( square (9.0*x-2.0) + (square (9.0*y-2.0)))/4.0)
        let f2 = 0.75* exp(-( ((square (9.0*x+1.0)) / 49.0 ) + (square (9.0*y+1.0))/10.0) )
        let f3 = 0.5 * exp(-( (square(9.0*x-7.0)) + (square (9.0*y-3.0)) )/4.0)
        let f4 = 0.2 * exp(-( (square(9.0*x-4.0)) + (square (9.0*y-7.0)) ))

        f1 + f2 + f3 - f4

module RadialFunctions =

    open Functions

    let gaussian epsilon r =
        Math.Exp( - (square (epsilon * r)) )

