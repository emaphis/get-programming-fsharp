// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.Windows.Forms

//open RecordsAsObjectsWithDrawing
//open ObjectExpressions
open ShapesWithDrawing


[<EntryPoint>]
[<STAThread>]
let main argv =
    Application.Run(mainForm)
    0
