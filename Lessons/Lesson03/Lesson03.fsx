/// Lesson 3 - Enter the REPL - pg 39

let text = "Hello, world"
text.Length


// Listing 3.2 A simple function definition  - pg 43.

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
