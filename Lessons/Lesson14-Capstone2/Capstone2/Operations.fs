module Capstone2.Operations

open System
open Capstone2.Domain

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



let auditAs operationName auditFn operaton amount account =
    let now = DateTime.UtcNow
    auditFn account (sprintf "%O: Performing a %s operation for $%M..." now operationName amount)
    let newAccount = operaton amount account

    if newAccount = account then auditFn account (sprintf "%O: Transaction rejected!" now)
    else auditFn account (sprintf "%O: Transaction accepted! Balance is now $%M." now newAccount.Balance)

    let message = operationName + " new balance: " + newAccount.Balance.ToString()

    newAccount
