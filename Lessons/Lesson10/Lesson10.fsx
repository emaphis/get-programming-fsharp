/// Lesson 10  -  Shaping data with Records
/// pg 110


/// 10.1  Records in F#

/// 10.1.1  Record basice  - pg 114

type Address =
    { Street : string
      Town : string
      City : string }


/// 10.1.2  Creating records  - pg 115

/// Listing 10.5 Constructing a nested record in F#

type Customer =
    { Forename : string
      Surname : string
      Age : int
      Address : Address
      EmailAddress : string }


let customer =
    { Forename = "Joe"
      Surname = "Bloggs"
      Age = 30
      Address =
        { Street = "The Street"
          Town = "The Town"
          City = "The City" }
      EmailAddress = "joe@blogs.com"  }


customer.Address.City

/// Figure 10.4  - Tyoe inference - intellisence.



/// Now you try  - pg 117

// Let’s have a look at creating your own record type now:
//   1 Define a record type in F# to store data on a Car, such as manufacturer, engine 
//     size, number of doors, and so forth.
//   2 Create an instance of that record.
//   3 Experiment with formatting the record; use power tools to automatically format 
//     the record for you. 


type Car =
    { Manufacturer : string
      Model : string
      EngineSize : int
      NumOfDoors : int
      Color : string }

let chevy =
    { Manufacturer = "Chevrolete"
      Model = "Corvette"
      EngineSize = 8
      NumOfDoors = 2

      Color = "Red" }


// pretty print chevy
printfn "Manufacturer: %s Model: %s EngineSize %d Number of Doors %d Color %s" 
    chevy.Manufacturer
    chevy.Model
    chevy.EngineSize
    chevy.NumOfDoors
    chevy.Color


/// 10.2 Doing more with records  - pg 117

/// 10.2.1 Type inference with records

// Listing 10.6 Providing explicit types for constructing records  - pg 118
let addressExplicit1 : Address =
    { Street = "The Street"
      Town = "The Town"
      City = "The City" }

let addressExplicit2 = 
    { Address.Street = "The Street"
      Town = "The Town"
      City = "The City" }

// 10.4 - Type inference correctly identifies the type of the address object
let printAdress address =
    printfn "Address is %s, %s"
        address.Street
        address.City

printAdress addressExplicit1
printAdress addressExplicit2
printAdress customer.Address


/// 10.2.2  Working with immutable records  - pg 119

/// Listing 20.7  Copy and update record syntax.

customer
let updateCustomer =
    { customer with
        Age = 31
        EmailAddress = "joe@bloggs.co.uk" }


/// 10.2.3  Equality checking   - pg 120

/// Listing 10.8  Comparing two record in F# 

let isSameAddress1 = (addressExplicit1 = addressExplicit2)
let isSameAddress2 = (customer.Address = addressExplicit2)



// Now you try  - pg 120
// Let’s practically explore some of these features of records:
//   1 Define a record type, such as the Address type shown earlier.
//   2 Create two instances of the record that have the same values.
//   3 Compare the two objects by using =, .Equals, and System.Object.ReferenceEquals.
//   4 What are the results of all of them? Why?
//   5 Create a function that takes in a customer and, using copy-and-update syntax,
//     sets the customer’s Age to a random number between 18 and 45.
//   6 The function should then print the customer’s original and new age, before 
//     returning the updated customer record.

// 1. and 2.
type RecordType =
    { Name : string 
      Job : string 
      YearsEmployed : int }

let rctype1 =
    { Name = "Fred"
      Job = "Plumber"
      YearsEmployed = 10 }

let rctype2 =
    { Name = "Fred"
      Job = "Plumber"
      YearsEmployed = 10 }

// 3. and 4.
true = (rctype1 = rctype2)
true = (rctype1.Equals(rctype2))
false = System.Object.ReferenceEquals(rctype1, rctype2)

// 5. and 6. 
let updateCustomerAge customer  =
    let newAge = System.Random().Next(27) + 18
    printfn "Old age: %d :: New age %d" 10 20
    { customer with Age = newAge  }

let newCustomer1 = updateCustomerAge customer
let newCustomer2 = updateCustomerAge newCustomer1


/// 10.3  Tips and tricks with records  pg 121

/// 10.3.1  Refactoring
//  Cntrl + .


/// 10.3.2  Shadowing  - pg 122

// requires do notation for udating identity  - see page 1125
do
  let myHome = { Street = "The Street"; Town = "The Town"; City = "The City" }
  let myHome = { myHome with City = "The Other City" }
  let myHome = { myHome with City = "The Third City" }
  printAdress myHome

// FSI repl has an implied `do`

/// 
/// Try this  - pg 124.
// 1 Model the Car example from lesson 6, but use records to model the state of the Car.
// 2 Take an existing set of classes that you have in an existing C# project and map as
//   records in F#. Are there any cases that don’t map well?

// code originally from Lesson 6

type Car2 =
  { Model : string
    Color : string
    Petrol : float }

let far = 50  // 1.
let medium = 25
let home = 0

let drive(car, distance) =
  let newPetrol =
    if distance > far  then car.Petrol / 2.0
    elif distance > medium then car.Petrol - 10.0
    elif distance > home then car.Petrol - 1.0
    else car.Petrol
  { car with Petrol = newPetrol }
 
let car = 
  { Model = "Ford"
    Color = "blue"
    Petrol = 100.0 }

let petrolLeft =
    let car = drive(car, 51)
    let car = drive(car, 35)
    let car = drive(car, 5)
    car.Petrol

printfn "%f" petrolLeft
