/// Chapter 3
/// Control Flow
/// pg 37

// stronger notion of flow control than most functional language
// if ... then .. else ...

// if is an expression
let result =
    if System.DateTime.Now.Second % 2 = 0 then
        "heads"
    else
        "tails"

printfn "%A" result


// if is a shorthand  pattern matching
let result1 =
    match System.DateTime.Now.Second % 2 = 0 with
    | true  -> "heads"
    | false -> "tails"

printfn "%A" result1


// if you need to return different types
let result2 =
    if System.DateTime.Now.Second % 2 = 0 then
        box "heads"
    else
        box false

printfn "%A" result2
