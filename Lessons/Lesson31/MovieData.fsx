
// Example from
// https://techcommunity.microsoft.com/t5/educator-developer-blog/exploring-data-with-f-type-providers/ba-p/378900


#I @"C:\users\emaph\.nuget\packages\"
#r @"fsharp.data\4.2.6\lib\netstandard2.0\FSharp.Data.dll"

open FSharp.Data

type AccoladeData = HtmlProvider< @"https://en.wikipedia.org/wiki/List_of_accolades_received_by_Spotlight#Accolades">

let awardNumbers (accolades: AccoladeData) =
    accolades.Tables.Table2.Rows
    |> Seq.skip 1
    |> Seq.filter (fun row ->  (int row.``Awards and nominations 2``) > 0)
    |> Seq.sortByDescending (fun row -> row.``Awards and nominations 2``)


let urls = [
    @"https://en.wikipedia.org/wiki/List_of_accolades_received_by_Spotlight#Accolades"
//    @"https://en.wikipedia.org/wiki/List_of_accolades_received_by_Moonlight_(2016_film)"
    @"https://en.wikipedia.org/wiki/List_of_accolades_received_by_La_La_Land"
]

let allMovies =
    urls
    |> Seq.map AccoladeData.AsyncLoad
    |> Async.Parallel
    |> Async.RunSynchronously
    |> Seq.map awardNumbers 
    


allMovies
//|> Seq.map (fun movies -> movies)
|> Seq.collect(fun row -> row)
|> Seq.map(fun x -> printfn "%A" x)


for movies in allMovies do
    printfn "----------------------------------"
    for row in movies do
        printfn "Row: %-40s %s %s" row.``Awards and nominations`` row.``Awards and nominations 3`` row.``Awards and nominations 2``
    printfn "----------------------------------"
