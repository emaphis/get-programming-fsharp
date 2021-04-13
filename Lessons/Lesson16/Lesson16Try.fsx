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

/// get a list of subdirectories given a path.
let listSubDirs path =
    Directory.GetDirectories path
    |> Array.toList

//testPath |> listSubDirs

/// given a dir get a list of fileInfos in the directory
let getFileList dir =
    Directory.GetFiles(dir)
    |> Array.toList
    |> List.map (fun file -> FileInfo(file))


// (testPath
// |> listSubDirs
// |> List.collect(fun dir -> getFileList dir))


