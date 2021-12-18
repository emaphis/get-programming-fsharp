

open System.Configuration

// read an application setting
let setting = ConfigurationManager.AppSettings.["MySetting"]

// print the setting
printfn "%s" setting

let connStr = ConfigurationManager.ConnectionStrings.["MyConnectionString"]
printfn "%A" connStr