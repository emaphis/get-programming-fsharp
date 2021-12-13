// Lesson 32  - Working with SQL
// pg. 376


///////////////////////////////
// 32.1 Creating a basic database

// Now you try  - pg. 377
(*
First you’ll deploy a sample database locally that you’ll use for the remainder of the
lesson:

1 In Visual Studio, navigate to the SQL Server Object Explorer (View menu).

1 Expand the SQL Server node.

2 You should see a node underneath that begins with (localdb). I can’t tell you
  which one it’ll be, as the SQL team keeps changing the format with each release,
  but it’ll look something like (localdb)\ProjectsV12 or (localdb)\MSSQLLocalDB.

3 If you don’t see any (localdb) nodes, you probably need to install SQL Server
  Data Tools (SSDT). This lightweight installer should be directly available from
  within Extensions and Updates in Visual Studio.

4 Now, import a database onto the server. Right-click the Databases node within
  the localdb server instance and choose Publish Data-Tier Application, as shown
  in figure 32.1.

5 In the dialog box that appears, set the File on Disk option to the adventureworks-
  lt.dacpac file from the data folder of the code repository, and set the Database
  Name to AdventureWorksLT.

6 Click Publish (ignore any warnings that may appear about overwriting data).
  Within a few seconds, Visual Studio will create a new database and populate it
  for you to test.
*)

// Ok.


/////////////////////////////////////////////////////////
// 32.2 Introducing the SqlClient project  - pg. 378

// 32.2.1 Querying data with the SqlCommandProvider

// Now you try.
(*
Start by connecting to the database that you just created and running a simple query to
retrieve some data from it:

1 Open a new script and add a reference to the assembly in the FSharp.Data.Sql-
  Client package. This is located in the packages folder, and you can manually #r
  the DLL. If using a full solution, you can opt to download the package from
  NuGet and generate a references script through VFPT (see lesson 25).

2 Open the FSharp.Data namespace.

3 Enter the following code.
*)

// Listing 32.1 Querying a database with the SqlCommandProvider type provider  - pg. 378


//#I @"C:\users\emaph\.nuget\packages\"
//#r @"FSharp.Data.SqlClient\2.0.7\lib\netstandard2.0\FSharp.Data.SqlClient.dll"

#r  "nuget: FSharp.Data.SqlClient"



open FSharp.Data
let [<Literal>] Conn = "Server=(localdb)\MSSQLLocalDb;Database=AdventureWorksLT;Integrated Security=SSPI"
type GetCostumers = SqlCommandProvider<"SELECT * FROM SalesLT.Customer", Conn>

 
let customers = GetCostumers.Create(Conn).Execute() |> Seq.toArray
let customer = customers.[0]
printfn "%s %s works for %s" customer.FirstName customer.LastName (Option.get customer.CompanyName) //Option.defaultValue seems to not been available... beware exceptions!
