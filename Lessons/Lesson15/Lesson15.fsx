/// Lesson 15  Working with collections  - pg 173


/// 15.1 F# collection basics  - pg 174
// Football examples

/// Listing 15.1 A sample dataset of football results

type FootballResult =
    { HomeTeam : string
      AwayTeam : string
      HomeGoals : int
      AwayGoals : int }

let create(ht, hg) (at, ag) =
    { HomeTeam = ht; AwayTeam = at; HomeGoals = hg; AwayGoals = ag }

let results =
    [ create ("Messiville", 1)   ("Ronaldo City", 2) // w
      create ("Messiville", 1)   ("Bale Town", 3)    // w
      create ("Bale Town", 3)    ("Ronaldo City", 1)
      create ("Bale Town", 2)    ("Messiville", 1)
      create ("Ronaldo Ciry", 4) ("Messiville", 2)
      create ("Ronaldo City", 1) ("Bale Town", 2) ]  //w



/// Now you try - pg 175

for result in results do
    if result.AwayGoals > result.HomeGoals then
        printfn "%s - %d" result.AwayTeam result.AwayGoals


/// 15.1.1 In-place collection modifications  - pg 175


/// Listing 15.2 An imperative solution to a calculation over data

open System.Collections.Generic

type TeamSummary = { Name : string; mutable AwayWins : int }
let summary = ResizeArray()

for result in results do
    if result.AwayGoals > result.HomeGoals then
        let mutable found = false
        for entry in summary do
            if entry.Name = result.AwayTeam then
                found <- true
                entry.AwayWins <- entry.AwayWins + 1
        if not found then
            summary.Add { Name = result.AwayTeam; AwayWins = 1 }
            
let comparer =
    { new IComparer<TeamSummary> with
        member this.Compare(x,y) =
            if x.AwayWins > y.AwayWins then -1
            elif x.AwayWins < y.AwayWins then 1
            else 0 }

summary.Sort(comparer)

summary.Count

for team in summary do
    printfn "%s - %d" team.Name team.AwayWins

 
/// 15.1.2 The collection modules  - pg 176

/// 15.1.3 Transformation pipelines -  178

/// Listing 15.4 A declarative solution to a calculation over data

let isAwayWin result = result.AwayGoals > result.HomeGoals

results
|> List.filter isAwayWin
|> List.countBy(fun result -> result.AwayTeam)
|> List.sortByDescending(fun (_, awayWins) -> awayWins)


/// 15.1.4 Debugging pipelines  - pg 180

/// Now you try 
// highlighting and evaluating each succesive stage in the pipeline


/// 15.2 Collection types in F#  - pg 182

/// 15.2.1 Working with sequences
// Sequences are effectively an alias for the IEnumerable<T>
// seq functiona can be applied to all the collections because they implement a common interface.

/// 15.2.2 Using .NET arrays

/// Listing 15.5 Working with .NET arrays in F#
let numbersArray = [| 1; 2; 3; 4; 6 |]
let firstNumber = numbersArray.[0]
let firstThreeNumbers = numbersArray.[0 .. 2]
numbersArray.[0] <- 99
// use Array module to treat arrays immutably


/// 15.2.3 Immutable lists  - pg 183

/// Listing 15.6 Working with F# lists
let numbers = [ 1; 2; 3; 4; 5; 5]
let numbersQuick = [ 1 .. 6 ]
let head :: tail = numbers
let moreNumbers = 0 :: numbers
let evenMoreNumbers = moreNumbers @ [ 7 .. 9 ]
