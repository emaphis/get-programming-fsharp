module SystemOfSequnces

// pg. 172

open System
open System.IO
open System.Diagnostics


let wordCount() =
    // Get the "Private Bytes" performance counter
    let proc = Process.GetCurrentProcess()
    let counter = new PerformanceCounter("Process", "Private Bytes", proc.ProcessName)
   
    // Read the file
    //let lines = File.ReadAllLines(@"C:\temp\TomJones.txt")
    let lines = File.ReadLines(@"C:\temp\TomJones.txt")

    // Do a very naive unique-word count (to prove we get
    // the same results whichever way we access the file)
    let wordCount =
        lines
        |> Seq.map (fun line -> line.Split([| ' ' |]))
        |> Seq.concat
        |> Seq.distinct
        |> Seq.length
    
    printfn "Private bytes:%f" (counter.NextValue())
    printfn "Word count: %i" wordCount

// ReadAllLines
// Private bytes:28901376.000000
// Word count: 27770

// ReadLines
// Private bytes:23339008.000000
// Word count: 27770