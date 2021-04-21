/// Chapter 3  - Functional Programming
/// The use Binding
/// pg 28


// `use` binding drops an object when it goes out of scope

open System.IO

let readFirstLine filename =
    // opem file using a `use` binding
    use file = File.OpenText filename
    file.ReadLine()

printfn "First line was: %s"  (readFirstLine @"afile.txt")

// objects must implement IDisposable
// cannot be use at the top level
