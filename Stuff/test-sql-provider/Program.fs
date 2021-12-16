
open System

open FSharp.Data.Sql


let ver = Environment.Version
Console.WriteLine("Version = " + ver.ToString())

open FSharp.Data.Sql

let [<Literal>] connString =
    "Server=localhost;Database=test;User=root;Password=abc123"
//    @"server=(localdb)\mssqllocaldb;database=HR;Trusted_Connection=True;Integrated Security=SSPI;TrustServerCertificate=True";
//@"server=(localdb)\mssqllocaldb;database=AdventureWorksLT;Trusted_Connection=True;Integrated Security=SSPI;TrustServerCertificate=True";

[<Literal>]
let dbVendor = Common.DatabaseProviderTypes.MYSQL

[<Literal>]
let resPath = "C:/Users/emaph/.nuget/packages/mysql.data/8.0.27/lib/netstandard2.0"

[<Literal>]
let indivAmount = 1000

[<Literal>]
let useOptTypes = true

type sql = SqlDataProvider<
                dbVendor,
                connString,
                ResolutionPath = resPath,
                IndividualsAmount = indivAmount,
                UseOptionTypes = useOptTypes,
                Owner = "root"
            >
let ctx = sql.GetDataContext()


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
