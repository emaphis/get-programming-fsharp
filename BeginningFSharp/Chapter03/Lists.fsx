/// Chapter 3 - Functional Programming
/// Lists
/// pg 38

let emptyList = []
let oneItem = "one " :: []
let twoItems = "one " :: "two " :: []

// shorthand list notations
let shorthand = [ "apples"; "pears"]

// concatenation
let twoLists = ["one, "; "two, "] @ ["buckle "; "my "; "shoe "] 

// list of objects
let objList = [ box 1; box 2.0; box "three" ]


// print the lists
let main() =
    printfn "%A" emptyList
    printfn "%A" oneItem
    printfn "%A" twoItems
    printfn "%A" shorthand
    printfn "%A" twoLists
    printfn "%A" objList


main()


// lists are immutable

let one = [ "one " ]
let two = "two " :: one
let three = "three " :: two

// reverse the list
let rightWayRound = List.rev three


// function to print the results
let main1() =
    printfn "%A" one
    printfn "%A" two
    printfn "%A" three
    printfn "%A" rightWayRound

main1()

