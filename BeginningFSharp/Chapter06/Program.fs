// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

open SomeOtherModule
open SignatureFiles

[<EntryPoint>]
let main argv =
    printfn "xyz =  %i" (x + y + z)
    let str = Functions.funkyFunction "steadman"
    printfn "%s" str
    0 // return an integer exit code