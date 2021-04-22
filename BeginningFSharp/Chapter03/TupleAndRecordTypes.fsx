/// Chapter 3  - Functional Programming
/// Tuple and Record Types
/// pg 47

let pair = true, false
let b1, b2 = pair
let b3, _ = pair
let _, b4 = pair


// using tuples as type constraints

type Name = string
type Fullname = string * string

let fullNameToString (x: Fullname) =
    let first, second = x in
    first + " " + second


// Record types

// define an organization with unique fields
type Organization1 = { boss: string; lackeys: string list }

// create an instance of this organization
let rainbow =
    { boss = "Jeffrey"
      lackeys = [ "Zippy"; "George"; "Bungle" ] }

// define two organizations with overlapping fields
type Organization2 = { chief: string; underlings: string list }
type Organization3 = { chief: string; indians: string list }

// create an instance of Organization2
let (thePlayers: Organization2) =
    { chief = "Peter Quince"
      underlings =
          [ "Francis Flute"
            "Robin Starveling"
            "Tom Snout"
            "Snug"
            "Nick Bottom" ] }



// create an instance of Organization3
let (wayneManor: Organization3) =
    { chief = "Batman"
      indians = [ "Robin"; "Alfred" ] }

// accesing fields
printfn "wayneManor.cheif = %s" wayneManor.chief

// create an updated wayneManor
let wayneManor' =
    { wayneManor with
          indians = [ "Alfred" ] }

// print out the two organizations
printfn "wayneManor = %A" wayneManor
printfn "wayneManor' = %A" wayneManor'


// pattern matching

// type representing a couptl
type Couple = { him: string; her: string }

// list of couples
let couples =
    [ { him = "Brad"; her = "Angelina" }
      { him = "Becks"; her = "Posh" }
      { him = "Chris"; her = "Gwyneth" }
      { him = "Michael"; her = "Catherine" } ]

// a function to find "David" from a list of Couples
let rec findDavid lst =
    match lst with
    | {him = x; her = "Posh"} :: tail -> x
    | _ :: tail -> findDavid tail
    | [] -> failwith "Couldn't find David"

// test
printfn "%A" (findDavid couples)


// pattern matching only works with hardcoded values
// use guards to match  variables
let rec findPartner soughtHer l =
    match l with
    | { him = x ; her = her } :: tail when her = soughtHer -> x
    | _ :: tail -> findPartner soughtHer tail
    | [] -> failwith "Couldn't find him"
