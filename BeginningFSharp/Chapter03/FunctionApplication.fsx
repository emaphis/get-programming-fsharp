/// Chapter 3  - Functional Progamming
/// Function application
///  pg 31

let add x y = x + y
let result = add 4 5  // application
printfn "%i" result

// avoiding intermediate values
let result1 = add 4 5
let result2 = add 6 7
let finalResult = add result1 result2

// short version
let result3 = add (add 4 5) (add 6 7)

// `|>` operator for application

let result4 = 0.5 |> System.Math.Cos

let result5 = add 6 7 |> add 4 |> add 5
