/// Chapter 4  - Iperative Programming
/// Calling Static Methods and Properties from .NET Libraries
/// pg. 80

// static method calls

open System.IO

//Directory.GetCurrentDirectory()

// test whether a file "test.txt" exist
// File.Exists is static.
if File.Exists("test1.txt") then
    printfn @"Text file test1.txt is present"
else
    printfn @"Text file test1.txt does not exist"


// you can treat static methods as values just like functions

open System.IO

// list of files to test
let files1 = [ "test1.txt"; "test2.txt"; "test3.txt" ]

// test if each file exists
let results1 = List.map File.Exists files1

// print the results
printfn "%A" results1


// static methods that take multiple parameters can still be treated as values

open System.IO

// list of files names and desired contents
let files2 = [ "test1.bin", [| 0uy |];
               "test2.bin", [| 1uy |];
               "test3.bin", [| 1uy; 2uy |]]

// iterate over the list of files creating each one
List.iter File.WriteAllBytes files2



// curring built in methods using a wrapper method

open System.IO

// import the File.Create function
let create size name =
    File.Create(name, size, FileOptions.Encrypted)

// files to be created
let names = [ "test1.bin"; "text2.bin"; "test3.bin" ]

// open the files crate a list of streams
let streams = List.map (create 1024) names


// Open a file using named arguments:
let file = File.Open(path = "test1.txt",
                        mode = FileMode.Append,
                        access = FileAccess.Write,
                        share = FileShare.None)

// Close it:
file.Close()
