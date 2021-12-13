
open System
open Microsoft.Data.SqlClient

let [<Literal>] Conn =
 //@"Persist Security Info=False;Trusted_Connection=True; database=AutoLot; server = (localdb)\\mssqllocaldb";
 // @"Server=localhost\SQLEXPRESS;Database=AdventureWorks2019;Trusted_Connection=True;TrustServerCertificate=True";
    @"server=(localdb)\mssqllocaldb;database=AdventureWorksLT;Trusted_Connection=True;Integrated Security=SSPI;TrustServerCertificate=True";

let connection = new SqlConnection() 

connection.ConnectionString <- Conn

connection.Open()
let state = connection.State;
Console.WriteLine("State = " + state.ToString());
//let getInventory = SqlCommandProvider< @"SELECT * FROM SalesLT.Product", Conn>
