/// Chapter 3 - Functional Programming
/// Partial Application of functions
/// pg. 32

let sub (a, b) = a - b

//let subFour = sub 4

let sub' a b = a - b

let subFour = sub' 4

subFour 4 = 0
