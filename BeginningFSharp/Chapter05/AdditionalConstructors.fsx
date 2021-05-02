/// Chapter 5 - Object Oriented Programming
/// Additionalv\ Constructors
/// pg. 108

/// A class that represents a user  - pg 108
/// its constructor takes two parameters, the user's
/// name and a hash of their password
type User(name, passwordHash) =
    // store the password hash in a mutable let
    // binding, so it can be changed latter
    let mutable passwordHash = passwordHash

    // additional constructor to create a user given the
    // raw password
    new(name : string, password : string) =
        User(name, (hash password))

    // hashes the users password and checks it against
    // the known hash
    member x.Authenticate(password) =
        let hashResult = hash password
        passwordHash = hashResult
    
    // gets the users logon message
    member x.LogonMessage() =
        Printf.sprintf "Hello, %s" name

    // changes the users passord
    member x.ChangePassword(password) =
        passwordHash <- hash password


let user1 = User("kiteason", 1234)
printfn "*** %s" (user1.LogonMessage())
