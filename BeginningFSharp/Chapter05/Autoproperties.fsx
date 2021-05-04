/// Chapter 5  - Object Oriented Programming
/// Autoproperties  - pg 117

// autoproperties decreas the ceremony when using properties

type Circle() =
    let mutable radius = 0.0

    member x.Radius
        with get() = radius
        and set(r) = radius <- r

let c = Circle()
c.Radius <- 99.9
printfn "Radius: %f" c.Radius


/// autoproperty
type CircleA() =
    member val Radius = 0.0 with get, set

let ca = CircleA()
ca.Radius <- 99.9
printfn "Radius: %f" ca.Radius
