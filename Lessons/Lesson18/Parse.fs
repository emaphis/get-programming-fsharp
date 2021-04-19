/// Try this page  - pg 218

// 1 Put printfn statements inside the rules themselves (for example, printfn "Running 3-
//   word rule…") so you can see what’s happening here. You’ll have to make each rule a
//   multiline lambda to do this.

// 2 Move the rules into a separate module as let-bound functions.

// 3 Add a new rule to the collection of rules that fails if any numbers are in the text
//   (the System.Char class has helpful functions here!)

module Parse

open System

type ParsingRule = string -> bool * string

// 2.

let threeWordsRule (text: string) =
    printfn "Three word rule..."
    (text.Split ' ').Length = 3, "Must be three words"

let maxLength30Rule (text: string) =
    printfn "Under 30 char rule..."
    text.Length <= 30, "Max length is 30 characters"

let allCapsRule (text: string) =
    printfn "All caps rule..."
    text |> Seq.filter Char.IsLetter
         |> Seq.forall Char.IsUpper, "All letters must be caps"

// 3.
let allDigitsRule (text: string) =
    printf "Not-any digit rule..."
    text |> Seq.forall (fun char -> not (Char.IsDigit char)), "Must have no digits"


/// Folding functions together
let buildValidator (rules : ParsingRule list) =
    rules
    |> List.reduce(fun firstRule secondRule ->
        fun word ->                             // higher-order function
            let passed, error = firstRule word  // run first rule
            if passed then                      // passed, move to next rule
                let passed, error = secondRule word
                if passed then true, "" else false, error
            else false, error)                  // failed return error
