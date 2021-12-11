// Lesson 29 - Capstone 5  - pg. 342

#I @"C:\users\emaph\.nuget\packages\"
#r @"newtonsoft.json\13.0.1\lib\net45\Newtonsoft.Json.dll"

#load "Domain.fs"
#load "Operations.fs"
#load "FileRepository.fs"
#load "Auditing.fs"

open Capstone5.Operations
open Capstone5.Domain
open Capstone5.FileRepository
open Capstone5.Auditing
open Newtonsoft.Json
open System


// 29.2 Plugging in a third-party NuGet package  pg. 343

// You try now
(*
    Use upgrade-assistent to update WpfClient to Net 6 before adding to Solution
    <https://dotnet.microsoft.com/en-us/platform/upgrade-assistant>
    >  upgrade-assistant upgrade .\WpfClient.csproj
    Then update  Fody and PropertyChanged.Fody
    Then add FSharp.Core to WpfClient
    Add Api.fs to Core project.

     Then add Newtonsoft.Json to Core project
*)


// Listing 29.1 Using JSON .NET with F# records pg. 344
let txn =
  { Transaction.Amount = 100M
    Timestamp = DateTime.UtcNow
    Operation = "withdraw" }


/// Serializes a transaction
let serialize transaction =
    JsonConvert.SerializeObject transaction

/// Deserializes a transaction
let deserialize (fileContents:string) =
    JsonConvert.DeserializeObject<Transaction> fileContents

let serialized = txn |> serialize
let deserialized = deserialize(serialized)

printfn "Should be true: %b" (txn = deserialized)


//////////////////////////////////////////////////
// 29.3 Connecting F# code to a WPF front end  - pg. 345

//29.3.1 Joining the dots

/// Loads an account from disk. If no account exists, an empty one is automatically created.
let LoadAccount (customer:Customer) : RatedAccount =
    let account = (tryFindTransactionsOnDisk >> Option.map loadAccount) customer.Name
    match account with
    | Some account  -> account
    | None ->
        InCredit(CreditAccount { AccountId = Guid.NewGuid()
                                 Balance = 0M
                                 Owner = customer })

// val Deposit: amount: decimal -> customer: Customer -> RatedAccount
/// Deposits funds into an account.
let Deposit (amount:decimal) (customer:Customer) : RatedAccount =
    let ratedAccount = LoadAccount customer
    let accountId = ratedAccount.GetField (fun acc -> acc.AccountId)
    let owner = ratedAccount.GetField (fun acc -> acc.Owner)
    auditAs "deposit" composedLogger deposit amount ratedAccount accountId owner

// val Withdraw: amount: decimal -> customer: Customer -> RatedAccount
/// Withdraws funds from an account that is in credit.
let Withdraw (amount:decimal) (customer:Customer) : RatedAccount =
    let ratedAccount = LoadAccount customer
    match ratedAccount with
    | InCredit ((CreditAccount account) as creditAccount) ->
        auditAs "withdraw" composedLogger withdraw amount creditAccount account.AccountId account.Owner
    | Overdrawn _ -> ratedAccount

//val LoadTransactionHistory: customer: Customer -> seq<Transaction>
/// Loads the transaction history for an owner. If no transactions exist, returns an empty sequence.
let LoadTransactionHistory(customer:Customer) : Transaction seq =
    let tuple = tryFindTransactionsOnDisk customer.Name
    match tuple with
    | Some (_, _, txns) -> txns
    | None -> Seq.empty
