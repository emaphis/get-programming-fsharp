/// Chapter 5  - Object Oriented Programming
/// Defining Interfaces
/// pg. 109 

// a very crude hasher  - pg. 110
let hash (s: string) =
    s.GetHashCode()


/// an interface "IUser"  - pg 109
type IUser =
    // hashes the user's password and checks it against
    // the know hash
    abstract Authenticate: evidence: string -> bool

    // gets the users logon message
    abstract LogonMessage: unit -> string


/// implement IUser  - pg 110
type User(name, passwordHash) =
    interface IUser with

        // Authenticate implementation
        member x.Authenticate(password) =
            let hashResult = hash (password)
            passwordHash = hashResult

        // LogonMessage implementation
        member x.LogonMessage() =
            Printf.sprintf "Hello, %s" name   



// create a new instane of the user
// 2085066187 is the hash of "mypassword"
let user1 = User("Robert", 2085066187)

// get the logon message by casting to IUser then calling LogonMessage
let LogonMessage = (user1 :> IUser).LogonMessage()
// necessary for upcast


// using an inteface  - pg. 111
let logon (user: IUser) (password: string) =
    // authenticate user and print appropriate messate
    if user.Authenticate(password) then
        printfn "%s" (user.LogonMessage())
    else
        printfn "Logon failed"

// try logon
logon user1 "mypassword"


///] class that actually implements the interfaces methods

/// a class that represents a user
/// its constructor takes two parameters, the user's
/// name and a hash of their password
type User2(name, passwordHash) =
    interface IUser with

        // Authenticate implementation
        member x.Authenticate(password) =
            let hashResult = hash (password)
            passwordHash = hashResult
        
        // LogonMessage implementation
        member x.LogonMessage() =
            Printf.sprintf "Hello, %s" name

    // Expose Authenticate implementation
    member x.Authenticate(password) = x.Authenticate(password)
    // Expose LogonMessage implementation
    member x.LogonMessage() = x.LogonMessage() 


// create a new instane of the user
// 2085066187 is the hash of "mypassword"
let user2 = User2("Robert", 2085066187)
