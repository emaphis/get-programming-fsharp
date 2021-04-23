/// Chapter 4
/// Imperative Programming
/// pg 65

// unit () is similar to the void type

// a do nothing function
let aFunction() = ()

aFunction()
let () = aFunction()
do aFunction()

// chaining do nothing functions using a let
let poem() =
    printfn "I wandered lonely as a cloud"
    printfn "That floats on high o'er vales and hills,"
    printfn "When all at once I saw a crowd,"
    printfn "A host, of golden daffodils"

poem()

// ignoring values returned by .NET functions

let getShorty() = "shorty"
let _ = getShorty()
// ... or ...
ignore(getShorty())
// ... or ...
getShorty() |> ignore
