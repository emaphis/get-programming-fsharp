// The FSharp.Collections.Seq Module  - pg. 154

// The map and iter Functions

let myArray = [| 1; 2; 3 |]

let myNewCollection =
    myArray |>
    Seq.map (fun x -> x * 2)

printfn "%A" myArray

myNewCollection |> Seq.iter (fun x -> printf "%i ... " x)

// The concat Function  - pg. 155

open System.Collections.Generic

let myList =
     let temp = new List<int[]>()
     temp.Add([| 1; 2; 3 |])
     temp.Add([| 4; 5; 6 |])
     temp.Add([| 7; 8; 9 |])
     temp

let myCompleteList = Seq.concat myList

myCompleteList |> Seq.iter (fun x -> printf "%i ... " x)


// The fold Function  - pg. 156

let myPhrase = [|"How"; "do"; "you"; "do?"|]

let myCompletephrase =
    myPhrase |>
    Seq.fold (fun acc x -> acc + " " + x) ""

printfn "myCompletePhrase = %s" myCompletephrase


//  The exists and forall Functions  - pg. 156

let intArray = [|0; 1; 2; 3; 4; 5; 6; 7; 8; 9|]

let existsMultipleOfTwo =
    intArray |>
    Seq.exists (fun x -> x % 2 = 0)

let allMultipleOfTwo =
    intArray |>
    Seq.forall (fun x -> x % 2 = 0)

printfn "existsMultipleOfTwo: %b" existsMultipleOfTwo 
printfn "allMultipleOfTwo: %b" allMultipleOfTwo


// The filter, find, and tryFind Functions  - pg. 

let shortWordList = [| "hat"; "hot"; "bat"; "lot"; "mat"; "dot"; "rat" |]

let atWords =
    shortWordList
    |> Seq.filter (fun x -> x.EndsWith("at"))

let otWord =
    shortWordList
    |> Seq.find (fun x -> x.EndsWith("ot"))

let ttWord =
    shortWordList
    |> Seq.tryFind (fun x -> x.EndsWith("tt"))


atWords |> Seq.iter (fun x -> printf "%s ... " x) 
printfn "" 
printfn "%s" otWord 
printfn "%s" (match ttWord with | Some x -> x | None -> "Not found") 


// Teh choose Function  - pg. 158

let floatArray = [| 0.5; 0.75; 1.0; 1.25; 1.5; 1.75; 2.0 |]

let integers =
    floatArray |>
    Seq.choose
        (fun x ->
            let y = x * 2.0
            let z = floor y
            if y - z = 0.0 then
                Some (int z)
            else
                None)
      
integers |> Seq.iter (fun x -> printf "%i ... " x)


// The init and initInfinite Functions  - pg. 158

let tenOnes = Seq.init 10 (fun _ -> 1)
let allIntegers = Seq.initInfinite (fun x -> System.Int32.MinValue + x)
let firstTenInts = Seq.take 10 allIntegers

tenOnes |> Seq.iter (fun x -> printf "%i ... " x)
printfn ""
printfn "%A" firstTenInts


// The unfold Function  - pg. 159

let fibs = 
    (1,1) |> Seq.unfold 
        (fun (n0, n1) -> 
            Some(n0, (n1, n0 + n1)))


let first20 = Seq.take 20 fibs 
printfn "%A" first20



// Create a sequence which terminates at a threshold:
let decayPattern =
    Seq.unfold
        (fun x ->
            let limit = 0.01
            let n = x - (x / 2.0)
            if n > limit then
                Some(x, n)
            else
                None)
        10.0


decayPattern |> Seq.iter (fun x -> printf "%f .. " x)


// The cast Function  - pg. 160
open System.Collections

let floatArrayList =
    let temp = new ArrayList()
    temp.AddRange([| 1.0; 2.0; 3.0 |])
    temp

let (typedFloatSeq: seq<float>) = Seq.cast floatArrayList

typedFloatSeq |> Seq.iter (fun x -> printf "%f .. " x)
