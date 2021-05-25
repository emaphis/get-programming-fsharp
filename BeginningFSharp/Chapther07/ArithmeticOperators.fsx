/// Chapter 7  - F# Libraries
/// Arithmetic Operators  - pg. 147

// basics  - pg 148
let x1 = 1 + 1
let x2 = 1 - 1

// operators checked for size
open FSharp.Core.Operators.Checked
let x = System.Int32.MaxValue + 1

// structural equality

type person = { name : string; favoriteColor : string }

let robert1 = { name = "Robert"; favoriteColor = "Red" }
let robert2 = { name = "Robert" ; favoriteColor = "Red" }
let robert3 = { name = "Robert" ; favoriteColor = "Green" }

printfn "(robert1 = robert2): %b" (robert1 = robert2)
printfn "(robert1 <> robert3): %b" (robert1 <> robert3)

printfn "(robert2 > robert3): %b" (robert2 > robert3)

// physcally equal

printfn "(LanguagePrimatives.PhysicalEqualiy robert1 robert2): %b"
    (LanguagePrimitives.PhysicalEquality robert1 robert2)

// override structural equality
//open FSharp.Core.Operators.NonStructuralComparison

//printfn "(robert1 = robert2): %b" (robert1 = robert2)
//printfn "(robert1 <> robert3): %b" (robert1 <> robert3)
