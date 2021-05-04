/// Chapter 5  - Object Oriented Programming
/// Delegates  - pg. 122


type MyDelegate = delegate of int -> unit

let inst = new MyDelegate (fun i -> printf "%i" i)
let ints = [ 1; 2; 3; ]

ints |> List.iter (fun i -> inst.Invoke(i))
printfn "\n"
