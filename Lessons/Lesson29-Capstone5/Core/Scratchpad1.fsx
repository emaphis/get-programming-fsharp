// Lesson 29 - Capstone 5  - pg. 342

#I @"C:\users\emaph\.nuget\packages\"
#r @"newtonsoft.json\13.0.1\lib\net45\Newtonsoft.Json.dll"

#load "Domain.fs"
#load "Operations.fs"

open Capstone5.Operations
open Capstone5.Domain
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
