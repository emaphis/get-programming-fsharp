// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System

open SomeOtherModule
open SignatureFiles
open PrivateAndInternal

let useFunkyFunction name =
    let str = Functions.funkyFunction name
    printfn "%s" str

let usePrAndInt () =
    //printfn "%s" aPrivateBinding
    printfn "%s" aInternalBinding
    let mu : MyUnion = String "Keep this a string"
    match mu with
    | String x -> printfn "%s" x
    | TwoStrngs (x,y) -> printfn "%s %s" x y


[<EntryPoint>]
let main argv =
    printfn "xyz =  %i" (x + y + z)
    useFunkyFunction "steadman"
    usePrAndInt()
    ModuleTwo.run()
    0
