// Provides access to the banking API.
module Capstone5.Api

open Capstone5.Operations
open Capstone5.Domain
open System

/// Loads an account from disk. If no account exists, an empty one is automatically created.
let LoadAccount customer =
    customer.Name
    |> FileRepository.tryFindTransactionsOnDisk
    |> Option.map Operations.loadAccount
    |> defaultArg <|
        InCredit(CreditAccount { AccountId = Guid.NewGuid()
                                 Balance = 0M
                                 Owner = customer })

// val Deposit: amount: decimal -> customer: Customer -> RatedAccount
/// Deposits funds into an account.
let Deposit (amount:decimal) (customer:Customer) : RatedAccount =
    let ratedAccount = LoadAccount customer
    let accountId = ratedAccount.GetField (fun acc -> acc.AccountId)
    let owner = ratedAccount.GetField (fun acc -> acc.Owner)
    auditAs "deposit" Auditing.composedLogger deposit amount ratedAccount accountId owner

// val Withdraw: amount: decimal -> customer: Customer -> RatedAccount
/// Withdraws funds from an account that is in credit.
let Withdraw (amount:decimal) (customer:Customer) : RatedAccount =
    let ratedAccount = LoadAccount customer
    match ratedAccount with
    | InCredit ((CreditAccount account) as creditAccount) ->
        auditAs "withdraw" Auditing.composedLogger withdraw amount creditAccount account.AccountId account.Owner
    | Overdrawn _ -> ratedAccount

//val LoadTransactionHistory: customer: Customer -> seq<Transaction>
/// Loads the transaction history for an owner. If no transactions exist, returns an empty sequence.
let LoadTransactionHistory customer =
    let tuple = FileRepository.tryFindTransactionsOnDisk customer.Name
    match tuple with
    | Some (_, _, txns) -> txns
    | None -> Seq.empty
