/// 14.8 Referencing files from scripts
/// Listing 14.8 Accessing .fs files from a script - pg 168

// Script file to test application moduls

#load "Domain.fs"
#load "Operations.fs"
#load "Auditing.fs"

open Capstone2.Operations
open Capstone2.Domain
open Capstone2.Auditing
open System

let withdrawA  = withdraw |> auditAs "withdraw" consoleAudit
let depositA  = deposit |> auditAs "deposit" consoleAudit

let customer = { Name = "Edward" }

let account =
    { AccountId = Guid.NewGuid(); Owner = customer; Balance = 90M}

let final =
    account
    |> withdrawA 50M
    |> depositA 50M
    |> depositA 100M
    |> withdrawA 50M
    |> withdrawA 350M

final
