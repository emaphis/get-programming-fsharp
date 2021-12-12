// Lesson 31  - Building Schemeas from Live Data
// Pg. 365


////////////////////////////////////////////
/// 31.1 Working with JSON

// 31.1.1 Live and local files


// Listing 31.1 Opening a remote JSON data source  - pg. 366

#I @"C:\users\emaph\.nuget\packages\"
#r @"fsharp.data\4.2.6\lib\netstandard2.0\FSharp.Data.dll"


open FSharp.Data

//type TvListing = JsonProvider<"https://www.bbc.co.uk/programmes/genres/comedy/schedules/upcoming.json">
//let tvListing = TvListing.GetSample()
// let title = tvListing.Broadcasts.[0].Programme.DisplayTitles.Title


type AListing =  JsonProvider<"https://www.bbc.co.uk/programmes/b01pp0cl.json">
let aSample =AListing.GetSample()
let title = aSample.Programme.DisplayTitle.Title
printfn "Title: %s" title


// Now you try  - pg. 367
(*
Next you’ll try use the HTML type provider to visualize some Wikipedia data, to show
the number of films acted in over time by Robert DeNiro. Given an HTML page, this
type provider can find most lists and tables within it and return a strongly typed dataset
for each of them. It handles all the HTTP marshaling as well as type inference and pars
ing (although given the inconsistent nature of HTML, it doesn’t work on all pages)
The HTML type provider is already included in the FSharp.Data package, so there’s nothing
more to download:

1 Within the script you already have opened, add references to the Google.DataTable.Net.Wrapper
  and GoogleCharts DLLs. You can find them in the packages
  folder.

2 Open the XPlot.GoogleCharts namespace.

3 Create a handle to a type based on a URL that contains an HTML document:
  type Films =
  HtmlProvider<"https://en.wikipedia.org/wiki/Robert_De_Niro_filmography">

4 Create an instance of Films called deNiro by calling Films.GetSample().

5 If you browse to the URL in your web browser, you’ll see tables in the document,
  such as Film, Producing, and Directing. These tables map directly to types gener
  ated by the provider, and each table has a Rows property that exposes an array of 
  data; each row is typed to represent a table row (see figure 31.2)

6 Write a query that will count the number of films per year and then chart it. First,
  use the Array.countBy function to count films by Year. This will give you a sequence
  of tuples, which are used by the chart as X and Y values. You’ll want to convert
  the Year property to a string (rather than an int) so that the chart will create the
  correct number of elements in the x-axis.

7 Pipe the result into the Chart.SteppedArea function, and then into Chart.Show.
*)

#r @"C:\Apps\bin\Bin\netstandard2.0\Newtonsoft.Json.dll"
#r @"google.datatable.net.wrapper\4.1.0\lib\net5.0\Google.DataTable.Net.Wrapper.dll"
#r @"xplot.googlecharts\3.0.1\lib\netstandard2.0\XPlot.GoogleCharts.dll"

open XPlot.GoogleCharts

type Films =
    HtmlProvider<"https://en.wikipedia.org/wiki/Robert_De_Niro_filmography">

let deNiro = Films.GetSample()

deNiro.Tables.FilmsEdit.Rows
|> Array.countBy(fun row -> string row.Year)
|> Chart.SteppedArea
|> Chart.Show


// 31.2 Avoiding problems with live schemas  -pg. 369

// 31.2.1 Large data sources  - pg. 370

// 31.2.2 Inferred schemas

// 31.2.3 Priced schemas

// 31.2.4 Connectivity


// 31.3 Mixing local and remote datasets  - pg. 371

// 31.3.1 Redirecting type providers to new data  pg. 372

// Now you try  pg. 373
(*
Let’s see how to use the NuGet website as a data source to work with NuGet package
statistics and the HTML type provider, which is able to parse the HTML tables that co-
tain per-package download statistics (see figure 31.5). You’ll use a local copy of a web
page to give you a schema—and enable you to develop offline—but then redirect it to a
live page to retrieve the data:

1 Create an instance of the HTML type provider that points to sample-package
  .html in the data folder (if you use a relative path, make sure it’s correct). If you
  open this, you’ll see it’s a sample of the NuGet package details page

2 Using the GetSample() method, you can interrogate the Tables property to discover
  that there’s a Version History property, which has members that reflect the equiva-
  lent table located in the HTML

3 Now, instead of using GetSample(), use the Load() method to load in data from a live
  URI. This takes in a string URI for the “real” data:
  letnunit=Package.Load "https://www.nuget.org/packages/nunit"

4 Repeat the process to download package statistics for the Entity Framework and
  Newtonsoft.Json packages. The URI is the same as in the preceding step, but use
  entityframework or newtonsoft.json in place of nunit.
  Now that you have package statistics for all three packages, you can find the
  most popular specific versions of all of three packages combined.

5 Retrieve the Version History rows for all three packages and combine them into a
  single sequence; use Seq.collect to combine a sequence-of-sequences into a flat-
  tened sequence. Notice that this is the exact same code you’d use with “normal”
  records or values; you can use provided types in exactly the same way.

6 Sort this combined sequence in descending order by using the Downloads property

7 Take the top 10 rows.

8 Map these rows into tuples of Version and Downloads.

9 Create a Chart.Column that’s then piped into Chart.Show; the results should look sim-
  ilar to figure 31.6.
*)

//type Package = HtmlProvider< @"C:\src\get-programming-fsharp\Lessons\data\sample-package.html">
type Package = HtmlProvider<"https://www.nuget.org/packages/entityframework">

let ef = Package.Load("https://www.nuget.org/packages/entityframework")
let nunit = Package.Load("https://www.nuget.org/packages/nunit")
let newtonsoft = Package.Load("https://www.nuget.org/packages/newtonsoft.json")

let htmlProviders = [ ef; nunit; newtonsoft ]

htmlProviders
|> Seq.collect(fun package -> package.Tables.Table3.Rows)
|> Seq.sortByDescending(fun verionHistory -> verionHistory.Version)
|> Seq.take 10
|> Seq.map (fun vh -> vh.Version, vh.Downloads)
|> Chart.Column
|> Chart.Show


