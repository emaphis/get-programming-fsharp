/// Chapter 5  - Object Oriented Programming
/// Casting.fsx    - pg. 120

// up casting a string to an obj
let myObject = ("This is a string" :> obj)

// upcasting an int, boxing
let boxedInt = (1 :> obj)


// Type tests  - pg. 122

let anotherObject = ("This is a string" :> obj)

if (anotherObject :? string) then
    printfn "This object is a string"
else
    printfn "This object is not a string"

if (anotherObject :? string[]) then
    printfn "This object is a string array"
else
    printfn "This object is not a string array"

