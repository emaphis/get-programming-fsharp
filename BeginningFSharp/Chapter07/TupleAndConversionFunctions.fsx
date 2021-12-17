/// Chapter 7  - F# Libraries
/// Tuple Functions  - pg 150

printfn "(fst (1, 2): %i" (fst (1, 2))
printfn "(snd (1, 2): %i" (snd (1, 2))


// conversion functions - pg. 151
// converting primative types

open System

let dayInt = int DateTime.Now.DayOfWeek
let (dayEnum : DayOfWeek) = enum dayInt

printfn "%i" dayInt
printfn "%A" dayEnum

// The Bitwise Or and And Operators  - pg. 152
