/// Chapter 5  - Object Oriented Programming
/// Properties and Indexers.fsx  - pg. 115


/// a class with properties
type Properties() =
    let mutable rand = new System.Random()

    // a property definition
    member x.MyProp
        with get () = rand.Next()
        and  set y = rand <- new System.Random(y)


// create a neew instance of our class
let prop1 = new Properties()

// test our new object
prop1.MyProp <- 12
printfn "%d" prop1.MyProp
printfn "%d" prop1.MyProp
printfn "%d" prop1.MyProp


// abrtract properties  - pg 116

/// an interface with an abstract property
type IAbstractProperties =
    abstract MyProp : int
        with get, set

/// a class that implements out interface
type ConcreteProperties() =
    let mutable rand = new System.Random()

    interface IAbstractProperties with
        member x.MyProp
            with get()  = rand.Next()
            and  set(y) = rand <- new System.Random(y)


// create a neew instance of our class
let prop2 = new ConcreteProperties()

// test our new object
//prop2.MyProp <- 12
// printfn "%d" prop2.MyProp
// printfn "%d" prop2.MyProp
// printfn "%d" prop2.MyProp


/// a class with indexers  - pg. 116
type Indexers(vals: string[]) =
    
    // a normal indexer
    member x.Item
        with get y = vals.[y]
        and  set y z = vals.[y] <- z

    // an indexer with a strange name
    member x.MyString
        with get y = vals.[y]
        and  set y z = vals.[y] <- z


// create a new instance of the indexer class:
let index = new Indexers [| "One"; "Two"; "Three"; "Four" |]

// test the set of indexers
index.[0] <- "Five"
index.Item(2) <- "Six"
index.MyString(3)  <- "Seven"

// test the get of indexers
printfn "%s" index.[0]
printfn "%s" (index.Item(1))
printfn "%s" (index.MyString(2))
printfn "%s" (index.MyString(3))
