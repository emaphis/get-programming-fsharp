// Lesson 24 - Capstone 4  - pg. 284


open System

////////////////////////////////////////////
// Domain


open System

type BankOperation = Deposit | Withdraw

type Customer = { Name : string }
type Account = { AccountId : Guid; Owner : Customer; Balance : decimal }
type Transaction = { Timestamp : DateTime; Operation : string; Amount : decimal }

/// Represents a bank account that is known to be in credit.
type CreditAccount = CreditAccount of Account

/// A bank account which can either be in credit or overdraw
type RatedAccount =
    | InCredit of CreditAccount
    | Overdrawn of Account
    member this.GetField getter =
        match this with
        | InCredit (CreditAccount accout) -> getter accout
        | Overdrawn account -> getter account


module Transaction =

    /// Serializes a transaction
    let serialized transaction =
        sprintf "%O***%s***%M"
            transaction.Timestamp
            transaction.Operation
            transaction.Amount

    /// Deserializes a transaction
    let deserialize (fileContents:string) =
        let parts = fileContents.Split([|"***"|], StringSplitOptions.None)
        { Timestamp = DateTime.Parse parts.[0]
          Operation = parts.[1]
          Amount = Decimal.Parse parts.[2] }


//////////////////////////////////////////////////
// operations

let private classifyAccount account =
    if account.Balance >= 0M then (InCredit(CreditAccount account))
    else Overdrawn account

/// Withdraws an amount of an account (if there are sufficient funds)
let withdraw amount (CreditAccount account) =
    { account with Balance = account.Balance - amount }
    |> classifyAccount

/// Deposits an amount into an account
let deposit amount account =
    let account =
        match account with
        | InCredit (CreditAccount account) -> account
        | Overdrawn account -> account
    { account with Balance = account.Balance + amount }
    |> classifyAccount



/// Runs some account operation such as withdraw or deposit with auditing.
let auditAs operationName audit operation amount account accountId owner =
    let updatedAccount = operation amount account
    let transaction = { Operation = operationName; Amount = amount; Timestamp = DateTime.UtcNow }
    audit accountId owner.Name transaction
    updatedAccount


let tryParseSerializedOperation operation =
    match operation with
    | "withdraw" -> Some Withdraw
    | "deposit"  -> Some Deposit
    | _  -> None


/// Creates an account from a historical set of transactions
let loadAccount (owner, accountId, transactions) =
    let openingAccount = classifyAccount { AccountId = accountId; Balance = 0M; Owner = { Name = owner } }

    transactions
    |> Seq.sortBy(fun txn -> txn.Timestamp)
    |> Seq.fold(fun account txn ->
        let operation = tryParseSerializedOperation txn.Operation
        match operation, account with
        | Some Deposit, _ -> account |> deposit txn.Amount
        | Some Withdraw, InCredit account -> account |> withdraw txn.Amount
        | Some Withdraw, Overdrawn _ -> account
        | None, _ -> account) openingAccount


////////////////////////////////////////
// FileRepository

open System.IO
open System

let private accountsPath =
    let path = @"C:\temp\accounts"
    Directory.CreateDirectory path |> ignore
    path

let private tryFindAccountFolder owner =
    let folders = Directory.EnumerateDirectories(accountsPath, sprintf "%s_*" owner) |> Seq.toList
    match folders with
    | [] ->  None
    | folder :: _ ->  Some (DirectoryInfo(folder).Name)

let private buildPath(owner, accountId:Guid) = sprintf @"%s\%s_%O" accountsPath owner accountId

let loadTransactions (folder:string) =
    let owner, accountId =
        let parts = folder.Split '_'
        parts.[0], Guid.Parse parts.[1]
    owner, accountId, buildPath(owner, accountId)
                      |> Directory.EnumerateFiles
                      |> Seq.map (File.ReadAllText >> Transaction.deserialize)


/// Finds all transactions from disk for specific owner.
let tryFindTransactionsOnDisk = tryFindAccountFolder >> Option.map loadTransactions


/// Logs to the file system
let writeTransaction accountId owner transaction =
    let path = buildPath(owner, accountId)
    path |> Directory.CreateDirectory |> ignore
    let filePath = sprintf "%s/%d.txt" path (DateTime.UtcNow.ToFileTimeUtc())
    let line = Transaction.serialized transaction
    File.WriteAllText(filePath, line)


//////////////////////////////////
// Auditing


/// Logs to the console
let printTransaction _ accountId transaction =
    printfn "Account %O: %s of %M" accountId transaction.Operation transaction.Amount


// Logs to both console and file system
let composedLogger =
    let loggers =
        [ writeTransaction
          printTransaction ]
    fun accountId owner transaction ->
        loggers
        |> List.iter(fun logger -> logger accountId owner transaction)


//////////////////////////////////////////////
// program

let withdrawWithAudit amount (CreditAccount account as creditAccount) =
    auditAs "withdraw" composedLogger withdraw amount creditAccount account.AccountId account.Owner

let depositWithAudit amount (ratedAccount:RatedAccount) =
    let accountId = ratedAccount.GetField (fun a -> a.AccountId)
    let owner = ratedAccount.GetField(fun a -> a.Owner)
    auditAs "deposit" composedLogger deposit amount ratedAccount accountId owner

let tryLoadAccountFromDisk = tryFindTransactionsOnDisk >> (Option.map loadAccount)


type Command = AccountCommand of BankOperation | Exit

// Strip the option
//let tryGetBankOperation cmd =
//     match cmd with
//     | Exit -> None
//     | AccountCommand cmd -> Some cmd

[<AutoOpen>]
module CommandParsing =
    /// Checks whether the command is one of (d)eposit, (w)ithdraw, or e(x)it
    /// returns a Command
    let tryParse command =
        match command with
        | 'd'  -> Some (AccountCommand Deposit)
        | 'w'  -> Some (AccountCommand Withdraw)
        | 'x'  -> Some Exit
        | _  -> None


[<AutoOpen>]
module UserInput =
    /// Creating a sequence of user-generated inputs  - pg. 224
    let commands =
         Seq.initInfinite (fun _ ->
             Console.Write "(d)eposit, (w)ithdraw or e(x)it: "
             let output = Console.ReadKey().KeyChar
             Console.WriteLine()
             output )

    /// Takes in a command and converts it to a tuple of the command and also an amount
    let getAmount command =
        let captureAmount _ =
            Console.Write "Enter Amount: "
            Console.ReadLine() |> Decimal.TryParse  // safely parse input
        Seq.initInfinite captureAmount
        |> Seq.choose(fun amount ->
            match amount with
            | true, amount when amount <= 0M -> None
            | false, _  -> None
            | true, amount -> Some (command, amount))
        |> Seq.head
;;
let main() =
    let openingAccount =
        Console.Write "Please enter your name: "
        let owner = Console.ReadLine()

        match tryLoadAccountFromDisk owner with
        | Some account -> account
        | None ->
            InCredit(CreditAccount { AccountId = Guid.NewGuid()
                                     Balance = 0M
                                     Owner = { Name = owner } })
    
    printfn "Current balance is £%M" (openingAccount.GetField(fun a -> a.Balance))
    
    /// Takes in an account and a (command, amount) tuple. It should then apply
    /// the appropriate action on the account and return the new account back out again
    let processCommand account (command, amount) =
        printfn ""
        let account =
            match command with
            | Deposit -> account |> depositWithAudit amount
            | Withdraw ->
                match account with
                | InCredit account -> account |> withdrawWithAudit amount
                | Overdrawn _ ->
                    printfn "You cannot withdraw funds as your account is overdrawn!"
                    account
        printfn "Current balance is £%M" (account.GetField(fun a -> a.Balance))
        match account with
        | InCredit _ -> ()
        | Overdrawn _ -> printfn "Your account is overdrawn!!"
        account


    let closingAccount =
        commands
        |> Seq.choose tryParse   // chose all but none
        |> Seq.takeWhile ((<>) Exit)
        |> Seq.choose (fun cmd ->
            match cmd with
            | Exit -> None
            | AccountCommand cmd -> Some cmd)
        |> Seq.map getAmount
        |> Seq.fold processCommand openingAccount

    printfn ""
    printfn "Closing Balance:\r\n %A" closingAccount
    Console.ReadKey() |> ignore
