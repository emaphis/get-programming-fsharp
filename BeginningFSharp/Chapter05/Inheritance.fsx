/// Chapter 5  - Object Oriented Programming
/// Classes and Inheritance
/// pg. 112

type Base() =
    member x.GetState() = 0

type Sub() =
    inherit Base()
    member x.getOtherState() = 0

let myObject = new Sub()

printfn "myObject.state = %i, myObject.otherState = %i"
    (myObject.GetState())
    (myObject.getOtherState())
