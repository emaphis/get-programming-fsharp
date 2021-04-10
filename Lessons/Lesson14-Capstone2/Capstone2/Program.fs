// Main banking app

open System
open Capstone2.Domain
open Capstone2.Operations
open Capstone2.Auditing

// User interface functions
let getAccountInfo(argv: string[]) =
    let customer = { Name = argv.[0] }
    let balance = decimal(argv.[1])
    { AccountId = Guid.NewGuid(); Owner = customer; Balance = balance;  }

let getAction(account) =
    printfn "\nCurrent balance is $%M" account.Balance
    printfn "(d)eposit, (w)ithdraw or e(x)it"
    Console.ReadLine()

let getAmount() =
    printf "\nAmount: "
    decimal(Console.ReadLine())


/// Custom decorated auditing functions
let withdrawC  = withdraw |> auditAs "withdraw" consoleAudit
let depositC  = deposit |> auditAs "deposit" consoleAudit


[<EntryPoint>]
let main argv =
    let mutable account = getAccountInfo(argv)

    while true do
        let action = getAction(account)
        if action = "x" then Environment.Exit 0
        let amount = getAmount()
        
        account <-
            if action = "d" then account |> depositC amount
            elif action = "w" then account |> withdrawC amount
            else account

    printfn "Final amount: $%O" account.Balance

    0 // return an integer exit code