/// Chapter 6  - Program Organization
/// Custom Attributes  - pg. 141

module CustomAttributes

open System

[<Obsolete>]
let functionOne () = ()

[<Obsolete("it is a pointless function anyway!")>]
let functionTwo() = ()

// Setting a property fr an attribute
//open System
//open System.Drawing.Printing
//open System.Security.Permissions

//[<PrintintingPermission(SecurityAction.Demand, Unrestricted = true)>]
//let functionThree () = ()


// pg. 142
[<Obsolete>]
type OOThing = class
    [<Obsolete>]
    val stringThing :string
    [<Obsolete>]
    new() = { stringThing = "" }
    [<Obsolete>]
    member x.GetTheString () = x.stringThing
end

