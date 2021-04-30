/// Chapter 4  -  Imperative programming
/// Using Indexers from .NET Libraries
/// prg 82


open System.Collections.Generic

// create a ResizeArray
let stringList =
    let temp = new ResizeArray<string>()
    temp.AddRange( [| "one"; "two"; "three"  |] )
    temp

// unpack items from the resize array
let itemOne = stringList.Item(0)   // Item() sytnax
let itemTwo = stringList.[1]       // index syntax

// print the unpacked items
printfn "%s %s\n" itemOne itemTwo
