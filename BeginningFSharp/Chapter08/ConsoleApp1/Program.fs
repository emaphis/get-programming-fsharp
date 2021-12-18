
open System.Configuration
open System.Data
open System.Data.SqlClient
open ListPerson
open PrintRows

// gwt the connection string
let connectionString =
    let connectionSetting =
        ConfigurationManager.ConnectionStrings.["MyConnection"]
    connectionSetting.ConnectionString



[<EntryPoint>]
let main argv =
    // creat a connecion
    //use connection = new SqlConnection(connectionString)
    //connection.Open()
    //listPerson(connection)
    printRows()
    0
        