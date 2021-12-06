// Now you try- pg. 26
// First App for Lesson1  pg 31.

open System

// Listing 2.1 Console application entry point
// Listing 2.2 An enhanced console application
// Try this  - pg. 33

[<EntryPoint>]      // An attribute that tells F# that this is the function to call when starting the application
let main argv =     // The declaration of the function
    let items = argv.Length
    printfn "Passed %d items: %A" items argv
    0 // return an integer exit code