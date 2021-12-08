// Lesson 24 - Capstone 4
// pg. 284


#load "Domain.fs"
#load "Operations.fs"

open Capstone4.Operations
open Capstone4.Domain
open System
open System.IO



/// Checks whether the command is one of (d)eposit, (w)ithdraw, or e(x)it
let isValidCommand command =
    command = 'd' || command = 'w' || command = 'x'


/// Checks whether the command is the exit command.
let isStopCommand commamd = commamd = 'x'


/// Takes in a command and converts it to a tuple of the command and also an amount
let getAmount command =
    Console.WriteLine()
    Console.Write "Enter Amount: "
    command, Console.ReadLine() |> Decimal.Parse

;;
/// Takes in an account and a (command, amount) tuple. It should then apply
/// the appropriate action on the account and return the new account back out again
let processCommand account (command, amount) =
    if   command = 'd' then deposit amount account
    elif command = 'w' then withdraw amount account
    else account


// Listing 19.1 Creating a functional pipeline for commands  - pg. 221

let openingAccount =
    { Owner = { Name = "Isaac" }; Balance = 0M; AccountId = Guid.Empty }


// Listing 19.3 Creating a sequence of user-generated inputs  - pg. 224
let consoleCommands = seq {
     while true do
         Console.Write "(d)eposit, (w)ithdraw or e(x)it: "
         yield Console.ReadKey().KeyChar
         Console.WriteLine() }

let account =
    //let commands = [ 'd'; 'w'; 'z'; 'f'; 'd'; 'x'; 'w' ]
    //commands
    consoleCommands
    |> Seq.filter isValidCommand
    |> Seq.takeWhile (not << isStopCommand)
    |> Seq.map getAmount
    |> Seq.fold processCommand openingAccount


