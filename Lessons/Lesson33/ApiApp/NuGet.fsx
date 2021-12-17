// Lesson 33 - Creating Type Provider-Backed APIs
// Pg. 388

// 33.1.1 Building your first API


#I @"C:\users\emaph\.nuget\packages\"
#r @"fsharp.data\4.2.6\lib\netstandard2.0\FSharp.Data.dll"


open FSharp.Data
open System.IO
 
// Listing 33.1 Creating your first type provider–backed API function 390

//        C:\src\get-programming-fsharp\Lessons\data
File.Exists("C:/src/get-programming-fsharp/Lessons/data/sample-package2.html")



type Package = HtmlProvider< @"C:/src/get-programming-fsharp/Lessons/data/sample-package2.html">


let getDownLoadsForPackage packageName =
        let package = Package.Load(sprintf "https://www.nuget.org/packages/%s" packageName)
        package

        //package.Tables.Table2.Rows
        //|> Array.map (fun row -> row.ToString())


let package2 = getDownLoadsForPackage "System.Drawing.Common"
let lists = package2.Tables.``NuGet packages (9)``.Name


lists

printfn "what %A" lists


//let what = lists.``Converter interface``.Values






let package = Package.GetSample()
let what2 = package.Tables.Table2.Rows
let xx = what2 |> Array.map(fun x -> x.Downloads)
               |> Array.map (fun y -> y) |> Array.sum

printfn "what: %A" what2
//|> Array.sumBy (fun row -> row.Downloads)
//|> Array.map (fun row -> row.Downloads)


//let what = getDownloadsForFackage "Newtonsoft.Json"

