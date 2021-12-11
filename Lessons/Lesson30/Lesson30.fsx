// Lesson 30  - Introducing Type Providers  - pg. 355

////////////////////////////////////////////////
// 30.1 Understanding type providers

// 30.2 Working with your first type provider pg. 357

// 30.2.1 Working with CSV files today
// FSharp.Data

// 30.2.2 Introducing FSharp.Data

// Now you try  - pg  359
(*
You’ll start by doing some simple data analysis over a CSV file:

1 Create a new standalone script in Visual Studio by choosing File > New. You 
  don’t need a solution here; remember that a script can work standalone.

2 Save the newly created file into an appropriate location as described in “Scripts 
  for the win.”

3 Enter the following code.

*)

// Listing 30.1 Working with CSV files using FSharp.Data

#I @"C:\users\emaph\.nuget\packages\"
#r @"fsharp.data\4.2.6\lib\netstandard2.0\FSharp.Data.dll"


open System.IO

Directory.SetCurrentDirectory(@"C:\src\get-programming-fsharp\Lessons")

(*
let dir = Directory.GetCurrentDirectory()
let ok = File.Exists(@"data\FootballResults.csv")
let file = File.Open( @".\data\FootballResults.csv", FileMode.Open)
let len = file.Length
file.Close()
*)

open FSharp.Data

type Football = CsvProvider< @"C:\src\get-programming-fsharp\Lessons\data\FootballResults.csv">

let data = Football.GetSample().Rows |> Seq.toArray
//data[0].



//  Listing 30.2
#r @"C:\Apps\bin\Bin\netstandard2.0\Newtonsoft.Json.dll"
#r @"google.datatable.net.wrapper\4.1.0\lib\net5.0\Google.DataTable.Net.Wrapper.dll"
#r @"xplot.googlecharts\3.0.1\lib\netstandard2.0\XPlot.GoogleCharts.dll"


open XPlot.GoogleCharts

data
|> Seq.filter (fun row ->
    row.``Full Time Home Goals`` > row.``Full Time Away Goals``)
|> Seq.countBy(fun row -> row.``Home Team``)
|> Seq.sortByDescending snd
|> Seq.take 10
|> Chart.Column
|> Chart.Show


// wow.
let printSourceLocation() =
    printfn "Line: %s" __LINE__
    printfn "Source Directory: %s" __SOURCE_DIRECTORY__
    printfn "Source File: %s" __SOURCE_FILE__

printSourceLocation()
