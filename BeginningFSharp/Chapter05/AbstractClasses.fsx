/// Chapter 5  - Object Oriented Programming
/// Abstract Classes  - pg. 118


/// a abstract class that represents a user
/// its constructor takes one parameeter
/// the user's name

[<AbstractClass>]
type User(name) =
    // the implementation of this method should hashes the
    // user's password and checks it against the know hash
    abstract Authenticate: evidence: string -> bool

    // gets the users logon message
    member x.LogonMessage() =
        Printf.sprintf "Hello, %s" name

