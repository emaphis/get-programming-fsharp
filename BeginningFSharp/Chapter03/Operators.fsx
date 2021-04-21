/// Chapter 3
/// Operators
/// pg 29

// String concatinaation
let rhyme = "Jack " + "and " + "Jill"


// ... or add Dates and TimeSpans
open System 

let oneYearLater =
    DateTime.Now + new TimeSpan(365, 0, 0, 0, 0)

// brackets allow operators to be used as functions
let result = (+) 3 4
let add = (+)
let result2 = add 3 4

// you can redifine opereators,  use with care.
let (+) a b = a - b
printfn "%i" (1 + 1)

// define your own opeators
let (+*) a b = (a + b) * a * b
printfn "(1 +* 2) = %i" (1 +* 2)

