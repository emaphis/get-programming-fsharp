/// Lesson 3 - Enter the REPL - pg 34

/// 3.2  Enter the REPL  - pg 37

/// 3.2.2 F# Interactive  - pg 39
//  FSI is the F# REPL


/// Now you try.
//  You can enter expressions on a file and eval in FSI

// 1 opening FSI
// dotnet fsi

// 2
printfn "Hello World"


// 4
System.DateTime.UtcNow.ToString()


/// 3.2.3 State in FSI  - pg 40

/// Listing 3.1 A simple let binding 
let currentTime = System.DateTime.UtcNow
currentTime.TimeOfDay.ToString()


/// 3.3 F# scripts in Visual Studio  - pg 41

/// 3.3.1 Creating scripts in F#
/// Now you try  - pg 43

let text = "Hello, world"
text.Length


/// 3.3.3 Working with functions in scripts

/// Listing 3.2 A simple function definition  - pg 43.
let greetPerson name age =
    sprintf "Hello, %s. You are %d years old" name age

let greeting = greetPerson "Fred" 25


// Try this
// Spend a little more time in the F# script; write a function, countWords, that can return 
// the number of words in a string by using standard .NET string split and array functionality. You'll need to provide a type hint for the input argument, such as 
//   let countWords (text:string) =...
//Then, save the string and number of words to disk as a plain-text file.

open System.IO

let countWords (text: string) =
    let array = text.Split(' ');
    sprintf "%d : %s" array.Length text

countWords "one two three"

let outTextFile text =
    File.WriteAllText("out.txt", countWords text)

outTextFile "one two three"
