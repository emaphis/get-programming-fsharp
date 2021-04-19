/// Lesson 18  - Folding your way to success  - pg 206


/// 18.1 Understanding aggregations and accumulators  - pg 207

/// Sum, Average, Cont

// type Sum = int seq -> int
// type Average = float seq -> float
// type Count<'T> = 'T seq -> int


/// 18.1.1 Creating your first aggregation function 

/// Listing 18.2 Imperative implementation of sum - pg 208

let sumI inputs =
    let mutable accumulator = 0
    for input in inputs do
        accumulator <- accumulator + input
    accumulator

[ 1; 2; 3; 4 ] |> sumI = 10


/// Now you try  - pg 209

// Try to create aggregation functions by using the preceding style for a couple of other 
// aggregation functions:

// 1 Create a new .fsx script.
// 2 Copy the code from listing 18.2.
// 3 Create a function to calculate the length of a list (take any list from the previous 
//   lessons as a starting point!). The only thing that should change is the line that 
//   updates the accumulator.
// 4 Now do the same to calculate the maximum value of a list.


let lengthI inputs =
    let mutable accumulator = 0
    for input in inputs do
        accumulator <- accumulator + 1
    accumulator

0 = ([ ] |> lengthI)
1 = ([ 1 ] |> lengthI)
6 = ([ 1; 2; 3; 4; 5; 6 ] |> lengthI)
3 = ([ "one"; "two"; "three" ] |> lengthI)



/// 18.2 Saying hello to fold  - pg 209

// folder:( 'State -> 'T -> 'State) -> state:'State -> source:seq<'T> -> 'State

// folder function - passed to fold that handles the accumulation
// start state - initial state
// input collection - colloection to operate over


/// Listing 18.3 Implementing sum through fold  - pg 210

let sum inputs =
    Seq.fold (fun state input -> state + input)
             0
             inputs

[ 1; 2; 3; 4 ] |> sum  = 10


/// Listing 18.4 Looking at fold with logging  - pg 210
let sumL inputs =
    Seq.fold
        (fun state input ->
            let newState = state + input
            printfn "Current state %d, input is is %d, new state value is %d"
                    state
                    input
                    newState
            newState)
        0
        inputs

sumL [ 1 .. 5 ]

// Current state 0, input is is 1, new state value is 1
// Current state 1, input is is 2, new state value is 3
// Current state 3, input is is 3, new state value is 6
// Current state 6, input is is 4, new state value is 10
// Current state 10, input is is 5, new state value is 15
// val it : int = 15



/// Now you try  - pg 211

// Next you’ll create a few aggregations of your own to improve your familiarity with fold:

//  1 Open your script from earlier.
//  2 Implement a length function by using fold.
//  3 Implement a max function by using fold.

// 2.
let lengthF inputs =
    Seq.fold (fun state _ -> state + 1)
             0
             inputs

[ ] |> lengthF  = 0
[ 1 ] |> lengthF = 1
[ 1; 2; 3 ] |> lengthF = 3

// 3.
let maxF inputs =
    Seq.fold (fun state input ->
                if input > state then input
                else state)
             //(Seq.head inputs)
             -99999
             inputs

[ ] |> maxF   = -99999
[ 1 ] |> maxF = 1
[ 5; 4; 1; 3; ] |> maxF  = 5
[ 1; -9999; 3; 100; 4 ] |> maxF = 100



/// 18.2.1 Making fold more readable  - pg 212

/// Listing 18.5 Making fold read in a more logical way
let sum1 inputs = 
    Seq.fold (fun state input -> state + input) 0 inputs

let sum2 inputs =
    inputs |> Seq.fold (fun state input -> state + input) 0

let sum3 inputs =
    (0, inputs) ||> Seq.fold (fun state input -> state + input)

sum3 [ 1; 2; 3 ] = 6


/// 18.2.2 Using related fold functions  - pg 212

//  foldBack—Same as fold, but goes backward from the last element in the collection.
List.fold (fun acc x -> x :: acc) [] [ 1; 2; 3; 4; 5 ]
// => int list = [5; 4; 3; 2; 1]

List.foldBack (fun x acc -> x :: acc) [] [ 1; 2; 3; 4; 5]
// => int list = [1; 2; 3; 4; 5]


//  mapFold—Combines map and fold, emitting a sequence of mapped results and a final state
// ('State -> 'T -> 'U * 'State) -> 'State -> C<'T> -> C<'U> * 'State
let what = List.mapFold (fun x y ->  ("k", y) ) 0 [ 1; 2; 3; 4; 5 ]
// string list * int = (["k"; "k"; "k"; "k"; "k"], 5)

let poof = List.mapFold (fun x y -> (x, x+1)) 0 [ 1; 2; 3; 4 ]
// nt list * int = ([0; 1; 2; 3], 4)

//  reduce—A simplified version of fold, using the first element in the collection as the 
//   initial state, so you don’t have to explicitly supply one. Perfect for simple folds 
//   such as sum (although it’ll throw an exception on an empty input—beware!)
List.reduce (fun acc x -> acc + x) [ 1; 2; 3; 4 ]
// => 10

//  scan—Similar to fold, but generates the intermediate results as well as the final 
//   state. Great for calculating running totals.
List.scan (fun acc x -> acc + x) 0 [ 1; 2; 3; 4; 5 ]
// => int list = [0; 1; 3; 6; 10; 15]

//  unfold—Generates a sequence from a single starting state. Similar to the yield keyword.
let sumUpTo (stop) = 
    List.unfold (fun x ->
                     if ( x >= stop) then None
                     else Some(x+1, x+1))
                0
sumUpTo(10)
// => int list = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]


/// 8.2.3 Folding instead of while loops  - pg 213

/// Listing 18.6 Accumulating through a while loop
//  mutable solution

open System.IO

//Directory.GetCurrentDirectory()
// "C:\src\get-programming-fsharp\Lessons\Lesson18"

let mutable totalChars = 0
let sr = new StreamReader(File.OpenRead @"book.txt")

while (not sr.EndOfStream) do
    let line = sr.ReadLine()
    totalChars <- totalChars + line.ToCharArray().Length 

printfn "total chars: %d" totalChars


/// Listing 18.7 Simulating a collection through sequence expressions
//  immutable solution

open System.IO

let lines : string seq =
    seq {
        use sr = new StreamReader(File.OpenRead @"book.txt")
        while (not sr.EndOfStream) do
            yield sr.ReadLine() }  // yield a row from StreamReader

let len = (0, lines) ||> Seq.fold(fun total line -> total + line.Length)

printfn "total chars: %d" len


/// 8.3 Composing functions with fold  - pg 214
//  using fold to dynamically compose function

// A rules engine
//  Every string should contain three words.
//  The string must be no longer than 30 characters.
//  All characters in the string must be uppercase.

// type Rule = string -> bool * string



/// Listing 18.8 Creating a list of rules  - pg 216

open System

type Rule = string -> bool * string

let rules : Rule list =
    [ fun text -> (text.Split ' ').Length = 3, "Must be three words"
      fun text -> text.Length <= 30, "Max length is 30 characters"
      fun text -> text
                  |> Seq.filter Char.IsLetter
                  |> Seq.forall Char.IsUpper, "All letters must be caps"  ]

/// 18.3.1 Composing rules manually - pg 215

/// Listing 18.9 Manually building a super rule
let validateManual (rules: Rule list) word =
    let passed, error = rules.[0] word
    if not passed then false, error
    else
        let passed, error = rules.[1] word
        if not passed then false, error
        else
            let passed, error = rules.[2] word
            if not passed then false, error
            else true, ""

let validateM = validateManual rules

validateM "ONE TWO THREE"
validateM "one two three"
validateM "one two three four five six seven"
validateM "oneoneone twotwotow threethreethree"


/// 18.3.2 Folding functions together  - pg 217
let buildValidator1 (rules : Rule list) =
    rules
    |> List.reduce (fun firstRule secondRule ->
        fun word ->
            let passed, error = firstRule word
            if passed then
                let passed, error = secondRule word
                if passed then true, "" else false, error
            else false, error )

let validate = buildValidator1 rules

validate "ONE TWO THREE"
validate "one two three"
validate "one two three four five six seven"
validate "oneoneone twotwotow threethreethree"

// Rule seq -> Rule
// (string -> bool * string) seq -> (string -> bool * string)


/// Now you try  - pg 217
// see  Lesson18Parse.fsx  for implementation.

#load "Parse.fs"
open Parse

let validate2 =
     Parse.buildValidator [ Parse.threeWordsRule;
                            Parse.maxLength30Rule;
                            Parse.allCapsRule
                            Parse.allDigitsRule ]


validate2 "ONE TWO THREE"
validate2 "one two three"
validate2 "one two three four five six seven"
validate2 "oneoneone twotwotow threethreethree"
validate2 "ONE1 TWO2 THREE3"


