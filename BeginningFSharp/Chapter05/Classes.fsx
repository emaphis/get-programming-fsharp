/// Chapter 5  - Object Oriented Programming
/// Defining Classes
/// pg. 105

/// a very crude hasher
/// don't use thie method in real code
let hash (s : string) =
    s.GetHashCode()

/// a class that represents a user
/// it's constructor takes two parametes, the users's
/// name and a hash of thier password
type User(name, passwordHash) =
    // hashes the users password and checks it against
    // the known hash
    member x.Authenticate(password) =
        let hashResult = hash password
        passwordHash = hashResult
    
    // gets the users logon message
    member x.LogonMessage() =
        sprintf "Hello, %s" name


// Create a user using the primary construcor
let user1 = User("kiteason", 1234)
// Access a method of the User instance
printfn "*** %s" (user1.LogonMessage())


/// a class that represents a user  - pg 106
/// its constructor takes three parameters, the users
/// firt name, last name and a hash of their password
type User2(firstName, lastName, passwordHash) =
    // caculate the user's full name and store the later use.
    let fullName = Printf.sprintf "%s %s" firstName lastName
    // print users fullname as object is being constructed
    do printfn "User: %s" fullName

    // hashes the users password and checks it against
    // known hash
    member x.Authenticate(password) =
        let hashResult = hash password
        passwordHash = hashResult
    
    // retrieves the users full name
    member x.GetFullname() = fullName


// A class that represents a user;
// its constructor takes two parameters, the user's
// name and a hash of their password.
// This version can 'change' the password by
// returning a new instance with the new password:
type User3(name, passwordHash) =
    // Hashes the users password and checks it against
    // the known hash:
    member x.Authenticate(password) =
        let hashResult = hash password
        passwordHash = hashResult

    // Gets the user's logon message:
    member x.LogonMessage() =
        Printf.sprintf "Hello, %s" name

    // Creates a copy of the user with the password changed:
    member x.ChangePassword(password) =
        new User3(name, hash password)



/// a class that represents a user  - pg 106
/// its constructor takes two parameters, the user's
/// name and a hash of their password
/// This version can change the password
/// by updating a mutable field.
type User4(name, passwordHash) =
    // store the password hash in a mutable let
    // binding, so it can be changed later
    let mutable passwordHash = passwordHash
    
    // hashes the users password and checks it against
    // the known hash
    member x.Authenticate(password) =
        let hashResult = hash password
        passwordHash = hashResult
    
    // gets the users logon message
    member x.LogonMessage() =
        Printf.sprintf "Hello, %s" name
    
    // changes the users password
    member x.ChangePassword(password) =
        passwordHash <- hash password    
