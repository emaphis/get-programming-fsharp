
    //<PackageReference Include="System.Configuration.ConfigurationManager" Version="6.0.0" />
#r "C:/Users/emaph/.nuget/packages/system.configuration.configurationmanager/6.0.0/lib/net6.0/System.Configuration.ConfigurationManager.dll"

open System.Configuration

// read an application setting 
let setting = ConfigurationManager.AppSettings.["MySetting"]

// print the setting
printfn "%s" setting


let connStr = ConfigurationManager.ConnectionStrings.["MyConnectionString"]

// print the details 
printfn "%s\r\n%s"
    connStr.ConnectionString
    connStr.ProviderName
