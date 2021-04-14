/// Try this  - pg 196

// Write a simple script that: 
//   given a folder path on the local filesystem, 
//   will return the name and size of each subfolder within it.
//   Use: groupBy to group files by folder,
//   Before using: an aggregation function such as sumBy to total
//                 the size of files in each folder
//   Then: sort the results by descending size.
//   Enhance the script to return a proper F# record that contains the
//   folder name, size, number of files, average file size,
//    and the distinct set of file extensions within the folder.

open System
open System.IO

let testPath = @"C:\src\get-programming-fsharp\Lessons"
let testDir  = @"C:\src\get-programming-fsharp\Lessons\Lesson02"
let fileName = @"C:\src\get-programming-fsharp\Lessons\Lesson08-Capstone1"

//Directory.GetFiles(testDir) |> Array.map FileInfo

type dirInfo = string * FileInfo[]

let getDirectories path =
    Directory.GetDirectories(path)
    |> Array.collect (fun dir -> [|FileInfo(dir)|])

getDirectories testPath

