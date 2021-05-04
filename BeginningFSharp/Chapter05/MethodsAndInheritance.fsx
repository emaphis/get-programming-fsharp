/// Chapter 5  - Object Oriented Programming
/// Methods And Inheritance  
/// pg. 112


// member, override, abstract, default

/// a base class
type Base() =
    let mutable state = 0;

    // an ordinary member method
    member x.JiggleState y =  state <- y

    // an abrstract method
    abstract WiggleState: int -> unit

    // a default implementation for the abstract method
    default x.WiggleState y =
        state <- y + state

    member x.GetState() = state


/// a sub class
type Sub() =
    inherit Base()

    // override the abstract method
    default x.WiggleState y =
        x.JiggleState (x.GetState() &&& y)


// create instances of both classes
let myBase = new Base()
let mySub = new Sub()

// test for our classes
let testBehaviour (c: #Base) =
    c.JiggleState 1
    printfn "%i" (c.GetState())
    c.WiggleState 3
    printfn "%i" (c.GetState())

// run the test
let main() =
    printfn "base class: "
    testBehaviour myBase
    printfn "sub class: "
    testBehaviour mySub

do main()

