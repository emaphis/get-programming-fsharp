// Lesson 30  - Introducing Type Providers  - pg. 355


open System
open System.IO

Environment.CurrentDirectory <- __SOURCE_DIRECTORY__
Directory.GetCurrentDirectory()

//Directory.SetCurrentDirectory(@"C:\src\get-programming-fsharp\Lessons")



let file = @"..\data\FootballResults.csv"

type Result =
    { Date : DateTime
      Home : string
      Away : string
      HomeGoals : int
      AwayGoals : int }

let data =
    file
    |> File.ReadAllLines
    |> Seq.skip 1
    |> Seq.map(fun row ->
        let fields = row.Split ','
        { Date = DateTime.ParseExact(fields.[0], "MM/dd/yyyy", null)
          Home = fields.[1]
          Away = fields.[2]
          HomeGoals = int fields.[3]
          AwayGoals = int fields.[4] })

data
|> Seq.filter(fun row -> row.HomeGoals > row.AwayGoals)
|> Seq.countBy(fun row -> row.Home)
|> Seq.sortByDescending snd
|> Seq.take 3
