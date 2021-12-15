
open System

open FSharp.Data.Sql


let ver = Environment.Version
Console.WriteLine("Version = " + ver.ToString())

open FSharp.Data.Sql

let [<Literal>] dbVendor = Common.DatabaseProviderTypes.MSSQLSERVER

let [<Literal>] connStr =
    @"server=(localdb)\mssqllocaldb;database=HR;Trusted_Connection=True;Integrated Security=SSPI;TrustServerCertificate=True";
//@"server=(localdb)\mssqllocaldb;database=AdventureWorksLT;Trusted_Connection=True;Integrated Security=SSPI;TrustServerCertificate=True";


type hr = FSharp.Data.Sql.SqlDataProvider<Common.DatabaseProviderTypes.MSSQLSERVER, connStr>
let dc = hr.GetDataContext()

type HR = SqlDataProvider<Common.DatabaseProviderTypes.MSSQLSERVER, connStr>

(*
[<EntryPoint>]
let main argv =
    let ctx = HR.GetDataContext()
    let employeesFirstName = 
        query {
            for emp in ctx.Dbo.Employees do
            select emp.FirstName
        } |> Seq.head

    printfn "Hello %s!" employeesFirstName
    0 // return an integer exit code

    
*)
