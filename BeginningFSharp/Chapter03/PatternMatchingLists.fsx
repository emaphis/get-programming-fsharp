/// Chapter 3 - Functional Programming
/// Pattern Matching Against Lists
/// pg 40

// list to be concatenated 
let listOfList = [[2; 3; 5]; [7; 11; 13]; [17; 19; 23; 29]] 
// int list list

/// definition of a concatenation function
let rec concatList l =
    match l with  // matching agains a list
    | head :: tail -> head @ (concatList tail)
    | []  -> []

// call the function
let primes = concatList listOfList

// print the results
printfn "%A" primes


// function that attempts to find various sequences
let rec findSequence lst =
    match lst with
    | [x; y; z] ->  // match a list with exactly three items
        printfn "Last three numbers in the list %i %i %i" x y z
    | 1 :: 2 :: 3 :: tail ->  // // match a list of 1, 2, 3 in a row
        printfn "Found sequence 1, 2, 3 within the list"
        findSequence tail
    // if neither case matches and items reamin
    // recursively call the function
    | head :: tail -> findSequence tail
    // if no items reamin terminate
    | [] -> ()

// some test data 
let testSequence = [1; 2; 3; 4; 5; 6; 7; 8; 9; 8; 7; 6; 5; 4; 3; 2; 1]

// call the function 
findSequence testSequence


// add one to every item in a list
let rec addOneAll lst =
    match lst with
    | head :: tail ->
        head + 1 :: addOneAll tail
    | [] -> []

printfn "(addOneAll [1; 2; 3]) = %A" (addOneAll [1; 2; 3])

// generalize the problem
let rec map func lst =
    match lst with
    | head :: tail ->
        func head :: map func tail
    | [] -> []


let result = map ((+) 1) [ 1; 2; 3 ]

printfn "((+) 1) [1; 2; 3] = %A" result



