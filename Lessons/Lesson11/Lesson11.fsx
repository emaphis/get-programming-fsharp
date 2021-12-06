/// Lesson 11  building composable functios - pg 126

/// 11.1   Partial function application

/// Listing 11.1  Passing arguments wiyh and without brackets

let tupledAdd(a, b) = a + b
let ans1 = tupledAdd (5, 10)

let curriedAdd a b = a + b
let ans2 = curriedAdd 5 10

15 = tupledAdd(5, 10)
15 = curriedAdd 5 10


// Listing 11.2 Calling a curried function in steps - pg 127

 // Creating a curried function
let add first second = first + second 
// Partial application
let addFive = add 5
let fifeteen = addFive 10

15 = add 5 10
15 = addFive 10


/// 11.2 Constraining functions - pg 128
// creating a more constraned function

/// Listing 11.3 Explicitly creating wrapper functions in F#
open System
let buildDt year month day = DateTime(year, month, day)
let buildDtThisYear month day = buildDt DateTime.UtcNow.Year month day
let buildDtThisMonth day = buildDtThisYear DateTime.UtcNow.Month day


/// Listing 11.4 Creating wrapper functions by currying
let buildDtThisYear1 = buildDt DateTime.UtcNow.Year
let buildDtThisMonth1 = buildDtThisYear1 DateTime.UtcNow.Month


/// Now you try  - pg 129
// Create a simple wrapper function, writeToFile, for writing data to a text file:
//  1 The function should take in three arguments in this specific order:
//    a date—the current date
//    b filename—a filename
//    c text—the text to write out
//  2 The function signature should be written in curried form (with spaces separating
//    the arguments).
//  3 The body should create a filename in the form {date}-{filename}.txt. Use the System
// .  IO.File.WriteAllText function to save the contents of the file.
//    4 You can either manually construct the path by using basic string concatenation,
//    or use the sprintf function.
//  5 You should construct the date part of the filename explicitly by using the ToString
//    override—for example, ToString("yyMMdd"). You need to explicitly annotate the type 
//    of date as System.DateTime.

open System
open System.IO
// 1 -> 5
let writeToFile (date: DateTime) filename text = 
    let path = sprintf "%s-%s.txt" (date.ToString "yyMMdd") filename 
    File.WriteAllText(path, text)

writeToFile DateTime.Now "outfile" "Output text"

// 6.

let writToFileNow filename text =
    writeToFile DateTime.Now filename text

let writeToLogFile text =
    writToFileNow "logfile" text

writToFileNow "compilefile"  "Compile is finished"
writeToLogFile "Error 112 is logged"

// curried functions can be used for dependency injection


/// 11.2.1 Pipelines  - pg 131
// curried functions are useful in  pipelines

/// Listing 11.7 Calling functions arbitrarily

/// Check time, if it's older than 7 days list as Old
let checkCreation (time : DateTime) =
    if (DateTime.UtcNow - time).TotalDays > 7.0 then "Old"
    else "New"


// Example
//  1 Get the current directory.
//  2 Get the creation time of the directory.
//  3 Pass that time to the function checkCreation. If the folder is older than seven days, 
//    the function prints Old to the console and otherwise prints New.

let time =  // temp value
    let directory = Directory.GetCurrentDirectory()  // temp value
    Directory.GetCreationTime directory

let status = checkCreation time


/// Listing 11.8 Simplistic chaining of functions
//  eliminating temp values with chaining functions
let status2 = 
    checkCreation(Directory.GetCreationTime(
                                Directory.GetCurrentDirectory()))

/// Listing 11.9 Chaining three functions together using the pipeline operator - pg 132
let status3 =
    Directory.GetCurrentDirectory()
    |> Directory.GetCreationTime
    |> checkCreation


/// 11.2.2 Custom fonts - pg 133
// https://github.com/ryanoasis/nerd-fonts

/// Fonts with ligatures
// Fira Code,      https://github.com/tonsky/FiraCode
// JetBrains Mono, https://github.com/JetBrains/JetBrainsMono
// Cascadia C0de   https://github.com/microsoft/cascadia-code
// Iosevka         https://github.com/be5invis/Iosevka
// Moniod          https://larsenwork.com/monoid/
// Victor Mono     https://rubjo.github.io/victor-mono/
// Fantasque Sans Mono  https://github.com/belluzj/fantasque-sans
// Inconsolata (Ligconsolata)https://github.com/googlefonts/inconsolata


// o0O  iIlL1
// ( ͡° ͜ʖ ͡°)   ¯\_(ツ)_/¯
// arithmetic:   ++ -- /= && || ||=
// scope         -> => :: __
// equality      == === != =/= !==
// comparisons   <= >= <=>
// comments      /* */ // ///
// escaped chars \n \\ \b
// bit operators << <<< <<= >> >>= |= ^=
// hexadecimal    0xFF 1930x1070


/// Now you trye  - pg 134

// revise petrol exmple from lesson 6 to use a pipeline

// parameters were reversed
let drive distance petrol =
    if distance = "far" then petrol / 2.0
    elif distance = "medium" then petrol - 10.0
    else petrol - 1.0
 
/// Listing 11.11 Review of existing petrol sample  - pg 134
let startingPetrol = 100.0
let petrol1 = drive "far" startingPetrol
let petrol2 = drive "medium" petrol1
let petrol3 = drive "short" petrol2
39.0 = petrol3

// using implied 'do'
let finalPetrol =
    let petrol = startingPetrol
    let petrol = drive "far" petrol
    let petrol = drive "medium" petrol
    let petrol = drive "short" petrol
    petrol

39.0 = finalPetrol


/// Listing 11.12 Using pipelines to implicitly pass chained state - pg 134

// let drive disatance ....
// let startPetrol ....

let finalPetrol2 =
    startingPetrol
    |> drive "far"
    |> drive "medium"
    |> drive "short"

39.0 = finalPetrol2


/// 11.3 Composing functions together  - pg 134
//  >> 

/// Listing 11.13 Automatically composing functions
let checkCurrentDirectoryAge =
    Directory.GetCurrentDirectory
    >> Directory.GetCreationTime
    >> checkCreation

let description = checkCurrentDirectoryAge()
