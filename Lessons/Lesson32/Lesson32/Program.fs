
open System
open System.Data.SqlClient
open FSharp.Data
// Microsoft.Data.SqlClient
// System.Data.SqlClient

let [<Literal>] Conn =
    @"server=(localdb)\mssqllocaldb;database=AdventureWorksLT;Trusted_Connection=True;Integrated Security=SSPI;TrustServerCertificate=True";

type GetDate = SqlCommandProvider<"SELECT GETDATE() AS Now", Conn>

//type GetCustomers = SqlCommandProvider<"SELECT * FROM SalesLT.Customer", Conn>
//let customers = GetCustomers.Create(Conn).Execute() |> Seq.toArray
//let customer = customers.[0]

