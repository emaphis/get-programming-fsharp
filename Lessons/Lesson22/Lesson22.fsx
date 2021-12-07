// Lesson 22 - Fixing the Billion-Dollar Mistake
// pg. 257

// 22.1 Working with missing values

//////////////////////////////////////////////////////////
// 22.2 Improving matters with the F# type system pg. 261

// 22.2.1 Mandatory data in F#  - pg. 262


// 22.2.2 The option type  - pg 261

// Listing 22.5 Sample code to calculate a premium

let aNumber : int = 10
let maybeANumber : int option = Some 10

let calculateAnnualPremiumUsd' score =
    match score with
    | Some 0 -> 250
    | Some score when score < 0 -> 400
    | Some score when score > 0 -> 150
    | None ->
        printfn "No score supplied! Using temporary premium."
        300

calculateAnnualPremiumUsd' (Some 250)
calculateAnnualPremiumUsd' None


// Now you try  - pg. 264
(*
Let’s see how to model the dataset from listing 22.1:

1 Create a record type to match the structure of the customer.

2 For the optional field’s type, use an option (either int option or Option<int>).

3 Create a list that contains both customers, using [ a; b ] syntax.

4 Change the function in listing 22.5 to take in a full customer object and match the
  SafetyScore field on it.
*)

// Listin 22.1
//{ "Drivers" :
//  [ { "Name" : "Fred Smith", "SafetyScore": 550, "YearPassed" : 1980 },
//    { "Name" : "Jane Dunn", "YearPassed" : 1980 } ] }

type Driver =
  { Name: string
    SafetyScore: int option
    YearPassed: int }


let drivers =
  [ { Name = "Fred Smith"; SafetyScore = Some 550; YearPassed = 1980 }
    { Name = "Jane Dunn"; SafetyScore = None;  YearPassed = 1980 } ]


let calculateAnnualPremiumUsd customer =
    match customer.SafetyScore with
    | Some 0 -> 250
    | Some score when score < 0 -> 400
    | Some score when score > 0 -> 150
    | None ->
        printfn "No score supplied! Using temporary premium."
        300

calculateAnnualPremiumUsd drivers[0]
calculateAnnualPremiumUsd drivers[1]


////////////////////////////////////////////////
// 22.3 Using the Option module  - pg. 264

// 22.3.1 Mapping  - pg. 265
// mapping:('T -> 'U) -> option:'T option -> 'U option

// Listing 22.6 Matching and mapping
let customer = drivers[0]
//let customer = drivers[1]

let describe safetyScore =
    if safetyScore > 200 then "Safe"
    else "High Risk"

let description =
    match customer.SafetyScore with
    | Some score -> Some(describe score)  // A standard match over an option
    | None -> None

let descriptionTwo =
    customer.SafetyScore
    |> Option.map (fun score -> describe score)


let shorthand = customer.SafetyScore |> Option.map describe
let optionalDescribe = Option.map describe

optionalDescribe customer.SafetyScore


// 22.3.2 Binding  - pg. 266
// binder:('T -> 'U option) -> option:'T option -> 'U option
// List.collect

// Listing 22.7 Chaining functions that return an option with Option.bind
let tryFindCustomer cId = if cId = 10 then Some drivers[0] else None
let getSafetyScore customer = customer.SafetyScore
let score = tryFindCustomer 10 |> Option.bind getSafetyScore


// 22.3.3 Filtering  - pg. 267
// predicate:('T -> bool) -> option:'T option -> 'T option

// Listing 22.8 Filtering on options
let test1 = Some 5 |> Option.filter(fun x -> x > 5)
let test2 = Some 5 |> Option.filter(fun x -> x = 5)


// 22.4 Collections and options  - pg. 268

// 22.4.1 Option.toList,  Option.toArray

// 22.4.2 List.choose


// Now you try  - pg. 268

(*
Let’s imagine you have a database of customers with associated IDs, and a list of customer IDs. You want to load the names of those customers from the database, but you’re 
not sure whether all of your customer IDs are valid. How can you easily get back only
those customers that exist? Follow these steps:

1 Create a function tryLoadCustomer that takes in a customer ID. If the ID is between 2
  and 7, return an optional string "Customer <id>" (for example, "Customer 4"). Otherwise, return None.

2 Create a list of customer IDs from 0 to 10.

3 Pipe those customer IDs through List.choose, using the tryLoadCustomer as the
  higher-order function.

4 Observe that you have a new list of strings, but only for existing customers.
*)

// 1.
let tryLoadCustomer custID =
    match custID with
    | custID when custID >= 2 && custID <= 7  ->
        Some (sprintf "Customer %i" custID)
    | _ -> None

// 2.
let custIDs = [ 0; 5; 3; 6; 8; 2; 7; 1; 4 ]

//3.
let filtIDs = custIDs |> List.choose tryLoadCustomer

// 4.
// ["Customer 5"; "Customer 3"; "Customer 6"; "Customer 2"; "Customer 7";  "Customer 4"]


// 22.4.3 “Try” functions
// Collection functions that return Opetions instead of nulls
