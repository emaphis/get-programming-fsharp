
open System
open SystemOfSequnces

[<EntryPoint>] 
let main argv = 
    wordCount () 
    Console.ReadKey() |> ignore 
    0