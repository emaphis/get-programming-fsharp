

open System.IO

// pg. 170

// List all the files in the root of C: drive:
let files = Directory.GetFiles(@"c:\")

//printfn "%A" files

// Write out various information about each file:
for filepath in files do
    let file = new FileInfo(filepath)
    printfn "%s\t%d\t%O"
        file.Name
        file.Length
        file.CreationTime

      
// pg. 171
// Open a test file and print the contents:
let readFile() =
    let lines = File.ReadAllLines(__SOURCE_DIRECTORY__ + "/test.csv")
    let printLine (line: string) =
        let items = line.Split([|','|])
        printfn "%O %O %O"
            items.[0]
            items.[1]
            items.[2]
    Seq.iter printLine lines

do readFile()

