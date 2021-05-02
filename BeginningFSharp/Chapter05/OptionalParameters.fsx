/// Chapter 5  - Object Oriented Programming
/// Optional Parameters
/// pg. 107


/// Optional Parameters -  pg. 108
/// ?someState, ?postfix are Option containers.
type AClass(?someState : int) =
    let state =
        match someState with
        | Some x -> string x
        | None -> "<no input>"
    
    member x.PrintState (prefix, ?postfix) =
        match postfix with
        | Some x -> printfn "%s %s %s" prefix state x
        | None -> printfn "%s %s" prefix state


let aClass1 = new AClass()
let aClass2 = new AClass(108)

aClass1.PrintState("There was ")
aClass2.PrintState("Input was: ", ", which was nice.")
