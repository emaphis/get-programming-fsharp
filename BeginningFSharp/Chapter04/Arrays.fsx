/// Chapter 4  - Imperative Programming
/// Arrays
/// pg 73


// BCL arrays

///////////////////////////////////////////
// define an array literal  - pg 73
let rhymeArray =
    [| "Went to market"
       "Stayed home"
       "Had roast been"
       "Had none" |]

let firstPiggy = rhymeArray.[0]
let secondPiggy = rhymeArray.[1]
let thirdPiggy = rhymeArray.[2]
let fourthPiggy = rhymeArray.[3]

// update element of the array
rhymeArray.[0] <- "Wee,"
rhymeArray.[1] <- "wee,"
rhymeArray.[2] <- "wee,"
rhymeArray.[3] <- "all the way home"

// short alias
let nl = System.Environment.NewLine

// print out the identifiers & array
printfn "%s%s%s%s%s%s%s"
    firstPiggy nl
    secondPiggy nl
    thirdPiggy nl
    fourthPiggy

printfn "%A" rhymeArray
printfn "\n"


/////////////////////////////////
// multi dimensional arrays  - pg 74

// define a jagged array literal
let jagged = [| [| "one" |] ; [| "two" ; "three" |] |]

// unpack elements from the arrays
let singleDim = jagged.[0]
let itemOne = singleDim.[0]
let itemTwo = jagged.[1].[0]

// print some of the unpacked elements
printfn "%s %s\n" itemOne itemTwo


////////////////////////////
// Create a square array,  - pg 75
// initially populated with zeros.
let square = Array2D.create 2 2 0

// Populate the array.
square.[0,0] <- 1
square.[0,1] <- 2
square.[1,0] <- 3
square.[1,1] <- 4

// Print the array.
printf "%A\n" square


/////////////////////////////////////////
// Pascal's triangle as a jaggid array  - pg 75

// define Pascal's Triangle as an
// array literal
let pascalsTriangle =
    [| [|1|];
       [|1; 1|];
       [|1; 2; 1|];
       [|1; 3; 3; 1|];
       [|1; 4; 6; 4; 1|];
       [|1; 5; 10; 10; 5; 1|];
       [|1; 6; 15; 20; 15; 6; 1|];
       [|1; 7; 21; 35; 35; 21; 7; 1|];
       [|1; 8; 28; 56; 70; 56; 28; 8; 1|]; |]

// collect elements from the jagged array
// assigning them to a square array
let numbers =
    let length = (Array.length pascalsTriangle) in
    let temp = Array2D.create 3 length 0 in
    for index = 0 to length - 1 do
        let naturelIndex = index - 1 in
        if naturelIndex >= 0 then
            temp.[0, index] <- pascalsTriangle.[index].[naturelIndex]
            let triangularIndex = index - 2 in
            if triangularIndex >= 0 then
                temp.[1, index] <- pascalsTriangle.[index].[triangularIndex]
        let tetrahedralIndex = index - 3 in
        if tetrahedralIndex >= 0 then
            temp.[2, index] <- pascalsTriangle.[index].[tetrahedralIndex]
    done
    temp

// print the array
printfn "%A\n" numbers


///////////////////////////
///  Array Comprehensions  - pg 75 

// an array of characters
let chars = [| '1' .. '9' |]

// an array of tuples of numbers, square
let squares =
    [| for x in 1 .. 9 -> x, x*x |]

// print out both arrays
printfn "%A" chars
printfn "%A\n" squares


///////////////////////////
/// Array slicing  - pg 77

let arr = [| 1; 3; 5; 7; 11; 13 |]
let middle = arr.[ 1 .. 4 ]

let start = arr.[..3]
let tail = arr.[1..]


// slicing multi-dimensional arrays

let ocean = Array2D.create 100 100 0

// Create a ship:
for i in 3..4 do
    ocean.[1,5] <- 1

// Pull out an area hit by a 'shell'
let hitArea = ocean.[2..5, 2..5]

// We can see a rectangular area by 'radar':
let radarArea = ocean.[3..4, *]
