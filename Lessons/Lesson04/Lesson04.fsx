/// Lesson 4 - Saying a little doing a lot. - pg 47

// 4.1 Binding values in F#  - pg 49

let age = 35
let websige = System.Uri "https://fsharp.org/"
let add (first, second) = first + second

// Now you try - pg 50

// 1 Create a new F# script file
// A- Is this file new?

// 2 Bind some values to symbols yourself: 

//  a A simple type (for example, string or int).
let num1 = 42
let str2 = "a string"

//  b An object from within the BCL (for example, System.Random).
let rnd3 = System.Random 123

//  c Create a simple one-line function that takes in no arguments and calls a function on the object that you created earlier (for example, random.Next())
let nextRand() = rnd3.Next 10
let num3 = nextRand()   // 1 -> 9
num3

// 3 Remember to execute each line in the REPL by using Alt-Enter.
// A-  Done!

// 4.1.1 let isn’t var!

/// Listing 4.2 Reusing let bindings
let foo() =
    let x = 10
    printfn "%d" (x + 20)
    let x = "test"  // replace previous 'x'
    let x = 50.0    // replace previous 'x'
    x + 200.00 ;;

 foo();;   // test foo()


open System

/// Listing 4.4 Scoping in F# - pg 52
let doStuffWithTwoNumbers(first, second) =
    let added = first + second
    Console.WriteLine("{0} + {1} = {2}", first, second, added)
    let doubled = added * 2
    doubled

doStuffWithTwoNumbers(2, 4)


// 4.2.1 Nested scopes - pg 53
// nesting scopes are a way of controling visibility

// Listing 4.5 Unmanaged scope

let year = DateTime.Now.Year
let age1 = year - 1979
let estimatedAge1 = sprintf "You are about %d years old!" age

estimatedAge1

// Listing 4.6 Tightly bound scope - pg 54

let estimatedAge2 =
    let age =
        let year = DateTime.Now.Year
        year - 1979
    sprintf "You are about %d years old!" age

estimatedAge2


// Listing 4.7 Nested (Inner) funtions.

let estimatedAges(familyName, year1, year2, year3) =
    let calculatedAge yearOfBirth =
        let year = System.DateTime.Now.Year
        year - yearOfBirth
    let estimatedAge1 = calculatedAge year1
    let estimatedAge2 = calculatedAge year2
    let estimatedAge3 = calculatedAge year3
    let averageAge = (estimatedAge1 + estimatedAge2 + estimatedAge3) / 3
    sprintf "Average ager for family %s is %d" familyName averageAge

// Listing 4.8 Creating a form to display a web page - pg 56
#I "C:/Program Files/dotnet/shared/Microsoft.WindowsDesktop.App/5.0.4"
#r "System.Windows.Forms.dll"
#r "System.Drawing.Common.dll"
open System
open System.Net
open System.Windows.Forms

let webClient = new WebClient()
let fsharpOrg = webClient.DownloadString(Uri "http://fsharp.org")
let browser = new WebBrowser(ScriptErrorsSuppressed = true, Dock = DockStyle.Fill, DocumentText = fsharpOrg)
