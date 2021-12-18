module ContactGridView

// Data Binding and the DataGridView Control   - pg. 185

open System.Configuration
open System.Collections.Generic
open System.Data
open System.Data.SqlClient
open System.Windows.Forms


/// creates a connections then executes the given command on it
let createDataSet commandString =
    let connSetting = ConfigurationManager.ConnectionStrings["MyConnection"]

    // create a data adapter fo fill the dataset
    //let adapter = new SqlDataAdapter(commandString, connectionSetting.ConnectionString)
    let adapter = new SqlDataAdapter(commandString, connSetting.ConnectionString)

    // create a new data set that and fill it
    let ds = new DataSet()
    adapter.Fill(ds) |> ignore
    ds


// create the data set that will be bound to the form
let dataSet = createDataSet "select top 10 * from Person.Person"

     
let form =
    let frm = new Form()
    let grid = new DataGridView(Dock = DockStyle.Fill)
    frm.Controls.Add(grid)
    grid.DataSource <- dataSet.Tables[0]
    frm
