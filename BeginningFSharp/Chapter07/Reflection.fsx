/// Chapter 7 - F# Libraries
/// The FSharp Reflection Module  - pg. 152

// The FSharp.Reflecton Module

// Reflecion Over Types.

open FSharp.Reflection

let printTupleTypes (x: obj) =
    let t = x.GetType()
    if FSharpType.IsTuple t then
        let types = FSharpType.GetTupleElements t
        printf "("
        types
        |> Seq.iteri (fun i t ->
            if i <> Seq.length types - 1 then
                printf " %s * " t.Name
            else
                printf "%s" t.Name)
        printfn " )"
    else
        printfn "not a tuple"


printTupleTypes ("Hello world", 1)

// Replection over Values  - pg. 153
let printTupleValues (x: obj) =
    if FSharpType.IsTuple(x.GetType()) then 
         let vals = FSharpValue.GetTupleFields x 
         printf "(" 
         vals 
         |> Seq.iteri 
             (fun i v -> 
             if i <> Seq.length vals - 1 then 
                printf " %A, " v 
             else 
                printf " %A" v) 
         printfn " )" 
     else 
        printfn "not a tuple" 


printTupleValues ("Hello world", 1)

