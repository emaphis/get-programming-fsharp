
#r "C:/Users/emaph/.nuget/packages/sqlprovider/1.2.10/lib/netstandard2.0/FSharp.Data.SqlProvider.dll"

open FSharp.Data.Sql

let [<Literal>] connString = "Server=localhost;Database=test;User=root;Password=abc123"

let [<Literal>] DbVendor = Common.DatabaseProviderTypes.MYSQL

let [<Literal>] ResPath = "C:/Users/emaph/.nuget/packages/mysql.data/8.0.27/lib/netstandard2.0"

type DbProvider = SqlDataProvider<DbVendor,connString,ResolutionPath = ResPath>

