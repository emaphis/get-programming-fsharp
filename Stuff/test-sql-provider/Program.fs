
//open FSharp.Data.Sql

let [<Literal>] Conn = @"Server=(localdb)\MSSQLLocalDb;Database=AdventureWorksLT;Integrated Security=SSPI"
//type GetCustomers = SqlCommandProvider<"SELECT * FROM SalesLT.Customer", Conn>
//let customers = GetCustomers.Create(Conn).Execute() |> Seq.toArray
//let customer = customers.[0]

open FSharp.Data.Sql

module Database =

    [<Literal>]
    let dbVendor = Common.DatabaseProviderTypes.MSSQLSERVER


   // [<Literal>]
    //let connString =
      //  "Data Source=localhost;Database=MyDatabase;User Id=user;Password='my-password-here'"

    [<Literal>]
    let indivAmount = 1000

    [<Literal>]
    let useOptTypes = true

    type sql = SqlDataProvider<dbVendor, Conn, IndividualsAmount=indivAmount, UseOptionTypes=useOptTypes>

    // The type provider 'FSharp.Data.Sql.SqlTypeProvider' reported an error: System.Data.SqlClient is not supported on this platform.