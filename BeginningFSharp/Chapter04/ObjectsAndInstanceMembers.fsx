/// Chatper 4  - Imperative Programming
/// Objects and Instance Members
/// pg. 82
 
// calling methods on a FileInfo object.

open System.IO

// create a FileInfo object
let file = new FileInfo("test1.txt")

// test if the file exists.
// if not creat a file
if not file.Exists then
    use stream = file.CreateText()
    stream.WriteLine("Hello world!")
    file.Attributes <- FileAttributes.ReadOnly

printfn "%s" file.FullName


// setting properties in a cnstructor call.

// file nate to test.
let fileName = "test.txt"

// bind the file to an option type, depending on whether
// the file exist or not
let file2 =
    if File.Exists(fileName) then
        Some(new FileInfo(fileName, Attributes = FileAttributes.ReadOnly))
    else
        None


// type parameters in a constructor  pg 83

open System

// and integer list
let intList =
    let temp = new ResizeArray<int>()
    temp.AddRange( [| 1; 2; 3 |] )
    temp

// print each int using the ForEach memver method
intList.ForEach(fun i -> Console.WriteLine(i))  // passed as a NET delogate object.


// passing unknow types to type parameters

// how to wrao a netgid tgat taje a dekegte with an F# function
let findIndex f arr = Array.FindIndex(arr, new Predicate<_>(f))

// an array literal
let rhyme = [| "The"; "cat"; "sat"; "on"; "the"; "mat" |]

// print index of the first word ending in 'at'
printfn "First word in in 'at' in the array: %i"
    (rhyme |> findIndex (fun w -> w.EndsWith("at")))
