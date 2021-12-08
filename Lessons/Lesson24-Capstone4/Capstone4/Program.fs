// Lesson 24 - Capstone 4

module Capstone4.Program

open System
open Capstone4.Domain
open Capstone4.Operations



let withdrawWithAudit = auditAs "withdraw" Auditing.composedLogger withdraw
let depositWithAudit = auditAs "deposit" Auditing.composedLogger deposit
let loadAccountFromDisk = FileRepository.findTransactionsOnDisk >> Operations.loadAccount


module CommandParsing =
    /// Checks whether the command is one of (d)eposit, (w)ithdraw, or e(x)it
    let isValidCommand command =
        command = 'd' || command = 'w' || command = 'x'

    /// Checks whether the command is the exit command.
    let isStopCommand commamd = commamd = 'x'


module UserInput =
    ///  A lazy list of commandd to process
    let commands = seq {
        while true do
            Console.Write "(d)eposit, (w)ithdraw or e(x)it: "
            yield Console.ReadKey().KeyChar
            Console.WriteLine() }


    /// Takes in a command and converts it to a tuple of the command and also an amount
    let getAmount command =
        Console.WriteLine()
        Console.Write "Enter Amount: "
        command, Console.ReadLine() |> Decimal.Parse


/// Takes in an account and a (command, amount) tuple. It should then apply
/// the appropriate action on the account and return the new account back out again
let processCommand account (command, amount) =
    printfn ""
    let account =
        if   command = 'd' then depositWithAudit amount account
        elif command = 'w' then withdrawWithAudit  amount account
        else account
    printfn "Current balance is $%M" account.Balance
    account


[<EntryPoint>]
let main _ =

    let openingAccount =
        Console.Write "Please enter your name: "
        Console.ReadLine() |> loadAccountFromDisk

    printfn "Current balance is $%M" openingAccount.Balance

    let closingAccount =
        UserInput.commands   // lazzy list of commands
        |> Seq.filter CommandParsing.isValidCommand
        |> Seq.takeWhile (not << CommandParsing.isStopCommand)
        |> Seq.map UserInput.getAmount
        |> Seq.fold processCommand openingAccount

 
    printfn ""
    printfn "Closing Balance:\r\n %A" closingAccount
    Console.ReadKey() |> ignore

    0
