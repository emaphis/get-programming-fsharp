// Lesson 24 - Capstone 4
// pg. 284


#load "Domain.fs"
#load "Operations.fs"

open Capstone4.Operations
open Capstone4.Domain
open System
open System.IO


// 24.2.2 Adding a command handler with discriminated unions - pg. 286

type BankOperation = Deposit | Withdraw
type Command = AccountCommand of BankOperation | Exit

let tryGetBankOperation command =
    match command with
    | AccountCommand op -> Some op
    | Exit -> None


/// a simple function that can convert a char into a Command
let tryParseCommand command :Command option =
    match command with
    | 'd'  -> Some (AccountCommand Deposit)
    | 'w'  -> Some (AccountCommand Withdraw)
    | 'x'  -> Some Exit
    | _    -> None

/// Checks whether the command is the exit command.
let isStopCommand command = (command = Exit)


/// Takes in a command and converts it to a tuple of the command and also an amount
let getAmount command =
    Console.WriteLine()
    Console.Write "Enter Amount: "
    command, Console.ReadLine() |> Decimal.Parse


// Listing 24.2 Working with unbounded values  -pg. 286
(*
let processCommand account (command, amount) =
    if   command = 'd' then deposit amount account
    elif command = 'w' then withdraw amount account
    else account
*)

let processCommand account (command, amount) =
    match command with
    | Deposit -> deposit amount account
    | Withdraw -> withdraw amount account


// Listing 19.1 Creating a functional pipeline for commands  - pg. 221

let openingAccount =
    { Owner = { Name = "Isaac" }; Balance = 0M; AccountId = Guid.Empty }


// Listing 19.3 Creating a sequence of user-generated inputs  - pg. 224
let consoleCommands = seq {
     while true do
         Console.Write "(d)eposit, (w)ithdraw or e(x)it: "
         yield Console.ReadKey().KeyChar
         Console.WriteLine() }


// Listing 24.1 The existing command execution pipeline
(*
let account =
    consoleCommands
    |> Seq.filter isValidCommand
    |> Seq.takeWhile (not << isStopCommand)
    |> Seq.map getAmount
    |> Seq.fold processCommand openingAccount
*)

let account =
    consoleCommands
    |> Seq.choose tryParseCommand
    |> Seq.takeWhile (not << isStopCommand)
    |> Seq.choose tryGetBankOperation
    |> Seq.map getAmount
    |> Seq.fold processCommand openingAccount
