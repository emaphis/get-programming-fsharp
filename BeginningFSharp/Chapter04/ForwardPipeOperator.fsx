/// Chapter 4  - imperative programming
/// Forward Pipe Operato
/// pg 90

// definition of operator
let (|>) x f = f x

// pipe the parameter 0.5 to the sin function
let result = 0.5 |> System.Math.Sin

// first parameter of iter is the function of type int -> unit
let intList = [ 1; 2; 3; ] 

let printInt = printf "%i"

List.iter printInt intList 
printfn ""


// Iterating over a list of DateTimes printing the year:

open System

// a date list
let importantDates = [ new DateTime(1066, 10, 14)
                       new DateTime(1999, 01, 01)
                       new DateTime(2999, 12, 31) ]

// printing function
let printInt2 = printf "%i "

// type annottion is required
List.iter (fun (d: DateTime) -> printInt2 d.Year) importantDates

// no type annotation required
importantDates |> List.iter (fun d -> printInt2 d.Year)



// chaining function.pg 91

// grab a list ofa ll methods in memory
let methods =
    System.AppDomain.CurrentDomain.GetAssemblies()
    |> List.ofArray
    |> List.map ( fun assm -> assm.GetTypes() )
    |> Array.concat
    |> List.ofArray
    |> List.map ( fun t -> t.GetMethods() )
    |> Array.concat

// print the list
printfn "%A" methods
