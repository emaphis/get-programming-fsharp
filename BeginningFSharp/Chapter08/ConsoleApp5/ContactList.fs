module ContactList

// Data Binding  - pg. 182

open System.Configuration
open System.Collections.Generic
open System.Data
open System.Data.SqlClient
open System.Windows.Forms


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
                yield! read()
            | None -> ()
        ]
    read()

/// get the contents of the person table 
let peopleTable = 
    execQuery "MyConnection" 
        "select top 10 * from Person.Person"

/// create an array of first and last names 
let contacts = 
     [| for row in peopleTable -> 
         Printf.sprintf "%O %O" 
             (row.["FirstName"]) 
             (row.["LastName"]) |]


/// create form containing a ComboBox with results list 
let form = 
     let frm = new Form() 
     let combo = new ComboBox(Top=8, Left=8, DataSource=contacts) 
     frm.Controls.Add(combo) 
     frm 
                  