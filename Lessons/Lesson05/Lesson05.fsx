/// Lesson 5 - Trusting the compiler - pg 62

/// 5.2 - F# type-inference basics

// Listing 5.5 Explicit type annotations in F#
let add0 (a:int, b:int) : int =
    let answer:int = a + b
    answer

// Listing 5.6 Omitting the return type from a function in F#
let add1 (a:int, b:int) =
    let answer = a + b
    answer

// remove all type annotations
let add2 (a, b) =
    let answer = a + b
    answer


// Now your try

// 1.
// let add3 (a:int, b:string) =
//     let answer = a + b
//     answer
//- Nope, doesn't work

// 2.
// let add4 (a:int, b:int) =
//     let answer = a + b + "hello"
//     answer
//- nope, doesn't work

// 5.2.1 - Limitations of type inference.
// Listing 5.7 Type inference when working with BCL types in F#
// Type inference doesn't work as will with BCL types

//let getLength name = sprintf "Name is %d letters." name.Length
// FS0072: Lookup on object of indeterminate type

let getLength (name: string) = sprintf "Name is %d letters." name.Length

// call to getLength infers string
let foo(name) = "Hello! " + getLength(name)

// Classes and overloaded methods can't be created in F#

/// 5.2.2 Type-inferred generics

// Listing 5.8 Inferred type arguements in F#
open System.Collections.Generic

let numbers = List<_>() // creating a generic List, but omitting the type argument
numbers.Add(10)  // type of numbers inferred here.
numbers.Add(20)

let otherNumbers = List()
otherNumbers.Add(10)
otherNumbers.Add(30)


// Listing 5.9 Automatic generalization of a function - pg 66
// type is left generic to increase flexibility
let createList(first, second) =
    let output = List()
    output.Add(first)
    output.Add(second)
    output
// val createList : first:a' * seconde:'a -> List<'a>


/// 5.3. - Following the breadcrumbs - pg 66
// F# can trace types acoss function boundries

// Listing 5.10 Complex type-inference example

let sayHello(someValue) = 
    let innerFunction(number) = 
        if number > 10 then "Isaac"
        elif number > 20 then "Fred"
        else "Sara"
    
    let resultOfInner =
        if someValue < 10.0 then innerFunction(5)
        else innerFunction(15)
    
    "Hello " + resultOfInner

let result = sayHello(10.5)
