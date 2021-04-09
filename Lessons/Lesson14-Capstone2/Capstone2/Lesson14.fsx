
/// Lesson24 - Capstone 2 - pg 160
///

/// 14.3 Getting started - pg 162
//  create the Capstone2 project, create this file.

/// 14.4 Creating a domain

open System

//  Customer—A named customer of the bank.
type Customer =
    { Name : string }

// Account - current blance, unique id, Customer
type Account =
    { AccountId : Guid
      Owner : Customer
      Balance : decimal }


/// 14.5 Creating behaviors

open System 

// Listing 14.1 Sample function signature for deposit functionality - pg 163

/// Deposits an amount into an account
let deposit (amount: decimal) (account: Account) : Account =
    let newBalance = account.Balance + amount
    { account with Balance = newBalance }

/// Withdraws an amount from and account
let withdraw (amount: decimal) (account: Account) : Account =
    if amount > account.Balance then account
    else
        let newBalance = account.Balance - amount
        { account with Balance = newBalance }


// test

let customer = { Name = "Matt"}
let account =
    { AccountId = Guid.Empty 
      Owner = customer
      Balance = 100M }

let newAccount = account |> deposit 50M |> withdraw 25M |> deposit 10M
135M = newAccount.Balance


/// Listing 14.3 Creating pluggable audit functions - pg 164

open System.IO

// s C:\temp\learnfs\capstone2\{customerName}\{accountId}.txt

//let home = @"C:\\tmp\\learnfs\\capstone2"

/// Make directory given Account Owner's name
let makeDir (account: Account) =
    let home = @"C:\tmp\learnfs\capstone2"
    let dir = sprintf @"%s\%s\" home account.Owner.Name
    Directory.CreateDirectory(dir)

// test
//let dir = makeDir account
//let path = dir.FullName 

/// Auditor that writes to filesystem
let fileSystemAudit account message =
    let dir = makeDir account
    let path = sprintf "%s%O.txt" dir.FullName account.AccountId
    File.AppendAllLines(path, [message])


/// Auditor that prints to console
let consoleAudit account message =
    printfn "Account: %O - %s" account.AccountId message


// test
fileSystemAudit account "Account balance: #100"
fileSystemAudit account "Don't forget to sepend your money"

let customer2 = { Name = "Edward" }
let account2 = { AccountId = Guid.Empty; Owner = customer2; Balance = 90M }

let newAccount2 = account2 |> withdraw 10M
newAccount2.Balance = 80M

//consoleAudit account2 "Testing console audit"


/// 14.6.1 Adapting code with higher-order functions  - pg 164

let auditAs (operationName: string) (auditFn: Account -> string -> unit)
    (operaton: decimal -> Account -> Account) (amount: decimal)
    (account: Account) : Account = 
    let newAccount =(operaton amount account)
    let message = operationName + " new balance: " + newAccount.Balance.ToString()
    auditFn newAccount message
    newAccount


let newAccount3 = auditAs "deposit" consoleAudit deposit 10M account2

let withdrawWithConsoleAudit = auditAs "withdraw" consoleAudit withdraw
let depositWithConsoleAudit = auditAs "deposit" consoleAudit deposit

let withdrawWithFileAudit = auditAs "withdraw" fileSystemAudit withdraw
let depositWithFileAudit = auditAs "deposit" fileSystemAudit deposit
