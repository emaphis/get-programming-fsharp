/// Lesson 17  Maps, Dictionaries, and Sets  - pg 197

/// 7.1 Dictionaries

/// 17.1.1 Mutable dictionaries in F#

/// Listing 17.1 Standard dictionary functionality in F#

open System.Collections.Generic

let inventory = Dictionary<string, float>()
inventory.Add("Apples", 0.33)  // mutable
inventory.Add("Oranges", 0.23)
inventory.Add("Bananas", 0.45)

inventory.Remove "Oranges"

let bananas = inventory.["Bananas"]
//let oranges = inventory.["Oranges"]


/// Listing 17.2 Generic type inference with Dictionary - pg 198
do
    let inventory1 = Dictionary<_,_>()
    inventory1.Add("Apples", 0.33)
    let inventory2 = Dictionary()
    inventory2.Add("Apples", 0.33)


/// 17.1.2 Immutable dictionaries
// Immuable C# dictinary

/// Listing 17.3 Creating an immutable IDictionary  - pg 199
let inventory3 : IDictionary<string, float> =
    [ "Apples", 0.33; "Oranges", 0.23; "Bananas", 0.45 ]
    |> dict

inventory3.Count

let bananas2 = inventory3.["Bananas"]

// fails - inventory is immutable
// inventory3.Add("Pineapples", 0.85)
// inventory3.Remove("Bananas")

/// Creating full dictionary
[ "Apples", 10; "Bananas", 20; "Grapes", 15 ] 
|> dict
|> Dictionary



/// 7.2 The F# Map  - pg 200
//  Immutable key value lookup.

/// Listing 17.4 Using the F# Map lookup

let inventory4 =
    [ "Apples", 0.33; "Oranges", 0.23; "Bananas", 0.45 ]
    |> Map.ofList  // list to map


let apples = inventory4.["Apples"]
//let pineapples = inventory4.["Pineapples"]  // keyNotFound exception

let newInventory =
    inventory4
    |> Map.add "Pineapples" 0.87
    |> Map.remove "Apples"



/// 17.2.1 Useful Map functions  - pg 201
// add remove map filter iter partiion


/// Listing 17.5 Using the F# Map module functions
let cheapFruit, expensiveFruit =
    inventory4
    |> Map.partition(fun fruit cost -> cost < 0.3)

cheapFruit
expensiveFruit



/// Now you try - pg 201
/// see try1.fsx


/// 17.3 Sets  - 203

/// Listing 17.6 Creating a set from a sequence
let myBasket = [ "Apples"; "Apples"; "Apples"; "Bananas"; "Pineapples" ]
let fruitsILike = myBasket |> Set.ofList

fruitsILike.ToString()
myBasket.ToString()


/// Listing 17.7 Comparing List- and Set-based operations

let yourBasket = [ "Kiwi"; "Bananas"; "Grapes" ]
let allFiruitsList = (myBasket @ yourBasket) |> List.distinct

let fruitsYouLike = yourBasket |> Set.ofList
// summing sets
let allFruits = fruitsILike + fruitsYouLike


/// Listing 17.8 Sample Set-based operations  - pg 204

// Gets frutis in A thate not in B
let  fruitsJustForMe = allFruits - fruitsYouLike

// Gets fruits that exit in both A and B
let fruitsWeCanShare = Set.intersect fruitsILike fruitsJustForMe

// Are all fruits in A also in B
let doILikeAllYourFruits = Set.isSubset fruitsILike fruitsYouLike


/// Try this - pg 205.
// try2.fsx
