module ListPerson

open System.Data.SqlClient
open System.Data



let listPerson (connection: SqlConnection) =
    // create a command
    let command =
        connection.CreateCommand(CommandText = "select * from Person.Person", CommandType = 
                                CommandType.Text)

    // open a reader to read data from the DB
    use reader = command.ExecuteReader()

    // fetch the comun-indexer of the required columns
    let title = reader.GetOrdinal("Title")
    let firsName = reader.GetOrdinal("FirstName")
    let lastName = reader.GetOrdinal("LastName")

    // function to read strings from the data reader
    let getString (r: #IDataReader) x =
        if r.IsDBNull(x) then ""
        else r.GetString(x)

    // read all the items
    while reader.Read() do
        printfn "%s %s %s"
            (getString reader title)
            (getString reader firsName)
            (getString reader lastName)


