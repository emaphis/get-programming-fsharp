/// Chapter 3  - Functional Programming
/// Types and Type Inference
/// pg 44.


// value type are infered from their bound objects
let aString = "Spring time in Paris"
let anInt = 42

let makeMessage x = (Printf.sprintf "%i" x) + " days to spring time"
let half x = x / 2

// type of curried and tuple functions differ
let div1 x y = x / y
let div2 (x, y) = x / y

let divRemainder x y = x / y, x % y

// where possible, tupes are gemeralized

// take a parameter amd return it unchanged
let doNothing x = x

// types can be restrained
let doNothingToAnInt (x: int) = x

// List types are infered
let intList = [1; 2; 3]

// but can be specified
let (stringList: list<string>) = ["one"; "two"; "three"]
