
open System
open Microsoft.Data.SqlClient
// Microsoft.Data.SqlClient
// System.Data.SqlClient

let [<Literal>] Conn =
 //@"Persist Security Info=False;Trusted_Connection=True; database=AutoLot; server = (localdb)\\mssqllocaldb";
 // @"Server=localhost\SQLEXPRESS;Database=AdventureWorks2019;Trusted_Connection=True;TrustServerCertificate=True";
    @"server=(localdb)\mssqllocaldb;database=AdventureWorksLT;Trusted_Connection=True;Integrated Security=SSPI;TrustServerCertificate=True";

let connection = new SqlConnection() 

connection.ConnectionString <- Conn
connection.Open()
printfn "State = %A" connection.State;
//let state = connection.State;
// create a SQL command object
let sql = @"SELECT * FROM SalesLT.Product"
//let getInventory = SqlCommandProvider< @"SELECT * FROM SalesLT.Product", Conn>

let myCommand = new SqlCommand(sql, connection)

let myReader = myCommand.ExecuteReader()
let record = myReader.Read();
printfn "read = %b" record

let productID = myReader["ProductID"]
printfn "%A" productID

