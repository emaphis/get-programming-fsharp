/// Chapter 3  - Functional Programming
/// Recursion
/// pg 28

// a function defined in terms of itself

// `let rec`

/// a function to generate the Fibonacci numbers
let rec fib x =
    match x with
    | 1 -> 1
    | 2 -> 1
    | x -> fib (x - 1) + fib (x - 2)

(fib 2)
(fib 6)
(fib 11)
//(fib 43)
