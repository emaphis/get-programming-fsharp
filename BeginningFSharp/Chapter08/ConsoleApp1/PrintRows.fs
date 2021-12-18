module PrintRows

open System.Configuration
open System.Collections.Generic
open System.Data
open System.Data.SqlClient


/// create and open an SqlConnection object using the connection string
/// found in the configuration file for the given connection name
let openSQLConnection (connName: string) =
    let connSetting = ConfigurationManager.ConnectionStrings[connName]
    let conn = new SqlConnection(connSetting.ConnectionString)
    conn.Open()
    conn


/// create and execute a read command for a connection using 
/// the connection string found in the configuration file 
/// for the given connection name 
let openConnectionReader connName cmdString =
    let conn = openSQLConnection(connName)
    let cmd = conn.CreateCommand(CommandText = cmdString,
                                 CommandType = CommandType.Text)
    let reader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
    reader


/// read a row from the data reader
let readOneRow (reader: SqlDataReader) =
    if reader.Read() then
        let dict = new Dictionary<string, obj>()
        for x in [ 0 .. (reader.FieldCount - 1) ] do
            dict.Add(reader.GetName(x), reader[x])
        Some dict
    else
        None


/// execute a query using a recursive list comprehension
let execQuery (connName: string) (cmdString: string) = 
    use reader = openConnectionReader connName cmdString
    let rec read() =
        [
            let row = readOneRow reader
            match row with
            | Some r ->
                yield r
                // call same function recursively and add
                // all the elementsreturned, one-by-one
                // to the list
                yield! read()
            | None -> ()
        ]
    read()


let printRows() =
    /// open the persons table
    let peopleTable =
        execQuery "MyConnection"
                  "select top 100 * from Person.Person"

    /// print out the data retieved from the database
    for row in peopleTable do
        for col in row.Keys do
            printfn "%s = %O" col (row.Item(col))
                  