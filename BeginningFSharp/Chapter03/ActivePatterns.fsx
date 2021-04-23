/// Chapter 3  - Functional programming
/// Active Patterns
/// pg. 56

// Complete active patterns

open System

// definition of the active pattern
let (|Bool|Int|Float|String|) (input: string) : Choice<bool,int,float,string> =
    // atempt to parse a bool
    let success, res = Boolean.TryParse input
    if success then Bool(res)
    else
        // attempt to parse an int
        let success, res = Double.TryParse input
        if success then Float(res)
        else String(input)

// A function to print the results by pattern
let printInputWithType input =
    match input with
    | Bool b -> printfn "Boolean: %b" b
    | Int i -> printfn "Integer: %i" i
    | Float f -> printfn "Floating point %f" f
    | String s -> printfn "String: %s" s

printInputWithType "true"
printInputWithType "12"
printInputWithType "-12.1"


// Partial active patterns

open System.Text.RegularExpressions

// the definition of the active pattern
let (|Regex|_|) regexPattern input =
    // create and attempt to match a regular expression
    let regex = new Regex(regexPattern)
    let regexMatch = regex.Match(input)
    // return either Some or None
    if regexMatch.Success then
        Some regexMatch.Value
    else
        None

    // function to print the results by pattern
    // matching over different instances of the
    // active pattern
let printInputWithType1 input =
    match input with
    | Regex "$true|false^" s -> printfn "Boolean: %s" s
    | Regex @"$-?\d+^" s -> printfn "Integer: %s" s
    | Regex @"$-?\d+\.\d*^" s -> printfn "Floating point: %s" s
    | _ -> printfn "String: %s" input

// print the results
printInputWithType1 "true"
printInputWithType1 "12"
printInputWithType1 "-12.1"
