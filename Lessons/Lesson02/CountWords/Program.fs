// Try this  pg 33
// Enhance the application to print out the length of the array as well as the items that 
// were supplied by using a combination of printfn and the Length property on the array 
// (use dot notation, as you’re used to).

open System



[<EntryPoint>]
let main argv =
    let len = argv.Length
    printfn "Length: %d itmes: %A" len argv
    0 // return an integer exit code