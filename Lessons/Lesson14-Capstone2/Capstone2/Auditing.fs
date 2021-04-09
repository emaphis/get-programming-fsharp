module Capstone2.Auditing

open System.IO
open Capstone2.Domain


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
