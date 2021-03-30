// First App for Lesson1  pg 31.

open System

[<EntryPoint>]
let main argv =
    let items = argv.Length
    printfn "Passed %d items: %A" items argv
    0 // return an integer exit code