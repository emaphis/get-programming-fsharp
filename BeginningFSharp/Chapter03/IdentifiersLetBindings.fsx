/// Chapter 3  -  Functional Programming
/// Identifiers and let bindings
///  pg 21

let var = 42

// binding an anonymous function
let myAdd = fun x y -> x + y

let y = myAdd 3 4


// binding, declaring a functiong
let raisePowerTwo x = x ** 2.0

let z = raisePowerTwo 3.0

// names
let x = 42
let x' = 42

// unitcode
let 标识符 = 42 

let ``an integer`` = 42

// indenting defines scope

let halfway a b =
    let dif = b - a
    let mid = dif / 2
    mid + a

printfn "(halfway 5 11) = %i" (halfway 5 11)
printfn "(halfway 11 5) = %i" (halfway 11 5)

// you can use OCaml's `in`
let halfway2 a b =
    let dif = b - a in
    let mid = dif / 2 in
    mid + a


// out of scope identifiers are compiler errprs
let printMessage() =
    let message = "Help me"
    printfn "%s" message

printMessage()

// error....
//printfn "%s" message

// rebinding a value in the scope of a function
let SafeUpperCase (s : string) =
    let s = if s = null then "" else s
    s.ToUpperInvariant()

SafeUpperCase "Hello"
SafeUpperCase null


// rebinding a an identifier with a different type
let changeType () =
    let x = 1
    let x = "change me"
    printfn "%s" x

changeType()


// old scope become active again when new scope quits
let printMessages() =
    // Define message and print it:
    let message = "Important"
    printfn "%s" message;
    // Define an inner function that redefines value of message:
    let innerFun () =
        let message = "Very Important"
        printfn "%s" message
    // Call the inner function:
    innerFun ()
    // Finally print the first message again:
    printfn "%s" message
    
printMessages()


/// Capturing identifiers - pg 27

// functions can return functions
let calculatePrefixFunction prefix =
    // caculate prefic:
    let prefix' = Printf.sprintf "[%s]: " prefix
    // define function to perform prefixing
    let prefixFunction appendee =
        Printf.sprintf "%s%s" prefix' appendee
    // return function
    prefixFunction

let prefixer = calculatePrefixFunction "DEBUG"

printfn "%s" (prefixer "My message")
