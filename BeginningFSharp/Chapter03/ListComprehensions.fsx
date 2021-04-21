/// Chapter 3
/// List Comprehensions
/// pg. 42


// create some list comprehensions
let numericList = [ 0 .. 9 ]
let alpherSeq = seq { 'A' .. 'Z' }

// print them
printfn "%A" numericList
printfn "%A" alpherSeq


// list comprehensions with define intervals
let multiplesOf3 = [ 0 .. 3 .. 30 ]
let revNumericSeq = [ 9 .. -1 .. 0 ]

printfn "%A" multiplesOf3
printfn "%A" revNumericSeq



// a sequence of squares
let squares =
    seq { for x in 1 .. 10 -> x * x }

printfn "%A" squares


// yield provides flexabitity
// even numbers
let evens n =
    seq { for x in 1 .. n do
            if x % 2 = 0 then yield x }

printfn "%A" (evens 10)


// two demensions
let squarePoints n =
    seq { for x in 1 .. n do
            for y in 1 .. n do
                yield x, y }

printfn "%A" (squarePoints 3)
