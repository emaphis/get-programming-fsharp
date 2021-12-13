
open System

#r  "nuget: FSharp.Data.SqlClient"
open FSharp.Data

let [<Literal>] Conn = "Persist Security Info=False;Trusted_Connection=True; database=AutoLot; server = (localdb)\\mssqllocaldb";
  

let getInventory = SqlCommandProvider< @"SELECT * FROM Inventory", Conn>







