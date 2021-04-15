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

[ 1; 2; 3; 4 ] |> sumI


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

[ 1; 2; 3; 4 ] |> sum


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

[ ] |> lengthF
[ 1 ] |> lengthF
[ 1; 2; 3 ] |> lengthF

// 2.
let maxF inputs =
    Seq.fold (fun state input ->
                if input > state then input
                else state)
             //(Seq.head inputs)
             -99999
             inputs

//[ ] |> maxF
[ 1 ] |> maxF
[ 5; 4; 1; 3; ] |> maxF
[ 1; 9; 3; 100; 4 ] |> maxF



/// 18.2.1 Making fold more readable  - pg 212

/// Listing 18.5 Making fold read in a more logical way
let sum1 inputs = 
    Seq.fold (fun state input -> state + input) 0 inputs

let sum2 inputs =
    inputs |> Seq.fold (fun state input -> state + input) 0

let sum3 inputs =
    (0, inputs) ||> Seq.fold (fun state input -> state + input)



/// 18.2.2 Using related fold functions

//  foldBack—Same as fold, but goes backward from the last element in the collection.
//  mapFold—Combines map and fold, emitting a sequence of mapped results and a final state
//  reduce—A simplified version of fold, using the first element in the collection as the 
//   initial state, so you don’t have to explicitly supply one. Perfect for simple folds 
//   such as sum (although it’ll throw an exception on an empty input—beware!)
//  scan—Similar to fold, but generates the intermediate results as well as the final 
//   state. Great for calculating running totals.
//  unfold—Generates a sequence from a single starting state. Similar to the yield
//   keyword.








