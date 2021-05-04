/// Chapter 5  - Object Oriented Programming
/// Classes and Static Methods    - pg. 119 


/// a crode hasher
let hash (s : string) =
    s.GetHashCode()


/// pretend to get a user from a database
let getUserFromDB id =
    ((sprintf "someusername%i" id), 1234)


/// a class that represents a user
/// it's constructor takes two parameters, the user's
/// name and a hash of thier passowrd.
type User(name, passwordHash) =

    // hashes the user's passord and checks it against
    // the known hash
    member x.Authenticate(password) =
        let hashResult = hash password
        passwordHash = hashResult

    // gets the users logon message
    member x.LogonMessage() =
        Printf.sprintf "Hello, %s" name

    // a static member that provide an alternative way
    // of creating the object
    static member FromDB id =
        let name, ph = getUserFromDB id
        new User(name, ph)


// create a user using the primary constructor
let user1 = User("kiteason", 1234)
// create a user using the static method
let user2 = User.FromDB 999


// operators as static methods

type MyInt(state: int) =
    member x.State = state
    static member ( + ) (x:MyInt, y:MyInt) : MyInt = new MyInt(x.State + y.State)
    override x.ToString() = string state

let x = new MyInt(1)
let y = new MyInt(1)

printfn "(x + y) = %A" (x + y)
