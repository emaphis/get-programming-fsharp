/// Lesson 17  - try1

///  Now you try  - pg 201

// Now you’re going to create a lookup for all the root folders on your hard disk and the
// times that they were created:
// 1 Open a blank script.
// 2 Get a list of all directories within the C:\ drive on your computer (you can use
//   System.IO.Directory.EnumerateDirectories). The result will be a sequence of strings.
// 3 Convert each string into a full DirectoryInfo object. Use Seq.map to perform the
//   conversion.
// 4 Convert each DirectoryInfo into a tuple of the Name of the folder and its Creation-
//   TimeUtc, again using Seq.map.
// 5 Convert the sequence into a Map of Map.ofSeq.
// 6 Convert the values of the Map into their age in days by using Map.map. You can sub-
//   tract the creation time from the current time to achieve this.

open System
open System.IO

let listDirectories path =
    Directory.EnumerateDirectories(path)            //2.
    |> Seq.map (fun dir -> DirectoryInfo(dir))      //3.
    |> Seq.map (fun dirInfo ->
        (dirInfo.Name, dirInfo.CreationTimeUtc))    //4.
    |> Map.ofSeq                                    //5.
    |> Map.map (fun dir time -> (DateTime.UtcNow - time).Days)  //6.


let out path =
    for dir in listDirectories path do
        printfn "%s - %d days old" dir.Key dir.Value

out @"C:\"
