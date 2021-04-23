/// Chapter 4  - Imperative Programming
/// The Reference Type
/// pg. 70


// creating a ref
let phrase = ref "Inconsistency"

printfn "%s" phrase.contents

printfn "%s" !phrase


// ref to keep track of an array
let totalArray () =
    // define an array literal
    let array = [| 1; 2; 3 |]
    // define a counter
    let total = ref 0

    // loop over the array
    for x in array do
        // keep a running total
        total := !total + x

    // print the total
    printfn "total: %i" !total

totalArray()


// Use a hidden reference value to implement an
// incrementable/decrementable counter:

// Define inc, dec and show functions that share
// a ref value that is hidden from outside:
let inc, dec, show =
    // Define the shared state:
    let n = ref 0
    // A function to increment:
    let inc () =
        n := !n + 1
    // A function to decrement:
    let dec () =
        n := !n - 1
    // A function to show the current state
    let show () =
        printfn "%i" !n

    // Return the functions to the top level:
    inc, dec, show

// Test the functions:
inc()
inc()
dec()
show()



// Use a hidden mutable value to implement an
// incrementable/decrementable counter (from F# 4.0):

// Define inc, dec and show functions that share
// a mutable value that is hidden from outside:
let inc2, dec2, show2 =
    // Define the shared state:
    let mutable n = 0
    // A function to increment:
    let inc2 () =
        n <- n + 1
    // A function to decrement:
    let dec2 () =
        n <- n - 1
    // A function to show the current state:
    let show2 () =
        printfn "%i" n

    // return the functions to the top level:
    inc2, dec2, show2

// test the functions
inc2()
inc2()
dec2()
show2()
