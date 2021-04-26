/// Chatper 4 - Imperative Programming
/// Mutable values
/// pg 67

// The mutable keyword

// a mutable idendifier
let mutable phrase = "How can I be sure, "

// print the phrase
printfn "%s" phrase
// update the phrase
phrase <- "In a world that's constatntly changing"
// reprint the phrase
printfn "%s" phrase

// updating a variable can't change it's type
//phrase <- 10


// demonstration of redefining X
let redefineX() =
    let x = "One"
    printfn "Redefining:\r\nx = %s" x
    if true then
        let x = "Two"
        printfn "x = %s" x
    printfn "x = %s" x

// demonstration of mutating X
let mutableX() =
    let mutable x = "One"
    printfn "Mutating:\r\nx = %s" x
    if true then
        x <- "Two"
        printfn "x = %s" x
    printfn "x = %s" x


// run the demos
redefineX()
mutableX()


// mutating variables in an inner functions
// error < 4.0
let mutableY() =
    let mutable y = "One"
    printfn "Mutating:\r\nx = %s" y
    let f() =
        // this causes an error as
        // mutables can't be capturee
        y <- "Two"
        printfn "X = %s" y
    f()
    printfn "x = %s" y

mutableY()
