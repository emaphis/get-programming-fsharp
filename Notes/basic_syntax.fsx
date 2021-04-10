///
/// Basic F# syntax, types, and functions.

// Define module MyCode in namespace Company.Rules (lesson 12)
module Company.Rules.Basic_syntax

// Open System namespace
open System

// Define a simple value (lesson 4)
let playerName = "Joe"

// Create and unwrap a tuple (lesson 9)
let playerTuple = playerName, 21
let name, age = playerTuple

// Define and create a record (lesson 10)
type Player = 
    { Name : string; Score : int; Country : string }

let player =
    { Name = playerName
      Score = 0
      Country = "GB" }

// Function definition with copy-and-update record syntax (lessons 10, 11)
let increaseScoreBy score p = { p with Score = p.Score + score }

// Piping functions (lesson 11)
player |> increaseScoreBy 50 |> printfn "%A"

// Function with basic pattern matching and nested expressions (lesson 7, 20)
type GreetingStyle =
    | Friendly
    | Normal

let greet style player =
    let greeting =
        match style with
        | Friendly -> "Have a nice day!"
        | Normal -> "Good luck."
    sprintf "Hello, player %s! %s" player.Name greeting

// Partial function application (lesson 11)
let friendlyGreeting = greet Friendly

// Composing functions together (lesson 11)
let printToConsole text = printfn "%s" text
let greetAndPrint = friendlyGreeting >> printToConsole


///
/// Discriminated unions, pattern matching, and lists

// Define, create, and unwrap a single-case discriminated union (lesson 23)
type PlayerId = PlayerId of Guid
let playerId = PlayerId(Guid.NewGuid())
let (PlayerId unwrapped) = playerId

// Define and create a multicase discriminated union (lesson 22)
type ClassifiedPlayer =
    | Beginner of Player
    | Standard of Player * PlayerId * GamesPlayed: int
    | Experienced of Player * GamesPlayed: int * DateStarted: DateTime

let experiencedPlayer =
    Experienced(player, 24, DateTime(2015, 1, 1))

// Pattern matching over a discriminated union (lessons 20, 21)
let describe player =
    match player with
    | Beginner player ->
        sprintf "%s is a beginner" player.Name
    | Standard (player, (PlayerId playerId), games) -> 
        sprintf "%s has ID %O and played %d games" player.Name playerId games
    | Experienced (player, games, date) ->
        sprintf "%s has played %d games since %O" player.Name games date

// Create a list of players (lesson 15)
let players = [ player; player; player ]

// Get the names of all three players (lesson 16)
let playerNames = players |> List.map(fun p -> p.Name)

// Pattern matching over a list (lessons 16, 21)
let summary =
    match playerNames with
    | [ "Joe"; _ ] -> "Two items, first is Joe"
    | first :: _ when first.Length = 2 -> "The first entry has a two-letter name!"
    | [ "Joe"; "Joe"; "Joe" ] -> "All Joe!"
    | _ -> "Other people!"
