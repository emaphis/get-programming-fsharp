/// Lesson 6 - Working with immutable data - pg. 70

/// 6.2.1 Mutability basics in F#
 
// isting 6.1 Creating immutable values in F#
let name = "Isaac"
name = "kate"  // equality operator

// Listing 6.2 Trying to mutate an immutable value
// name <- "kate"  // error

// Listing 6.3 Creating a mutable variable
let mutable name2 = "Isaac"
name2 <- "kate"


/// 6.2.2 Working with mutable objects  - pg 73

// #r "path/to/MyAssembly.dll"
#I @"C:\\Program Files\\dotnet\\shared\\Microsoft.WindowsDesktop.App\\3.1.13\\"
#r "System.Windows.Forms.dll"

open System.Windows.Forms

// Form is inherently mutable.
let form = new Form()
form.Show()
form.Width <- 400
form.Height <- 400
form.Text <- "Hello form F#"


// Listing 6.5 Shorthand for creating mutable objects
//open System.Windows.Forms
//let form = new Form(Text = "Hello from F#!", Width = 300, Height = 300)
//form.Show()


/// 6.3 Modeling state  - pg 75

// 6.3.1 Working with mutalbe data.

// Now you try 
// Let’s put this into practice with a simple example: driving a car. You want to be able to 
// write code that allows you to drive() a car, tracking the amount of petrol (gas) used. 
// Depending on the distance you drive, you should use up a different amount of petrol

// Listing 6.6 Managing state with mutable variables

let mutable petrol = 100.0

let drive(distance) =
    if distance = "far" then petrol <- petrol / 2.0
    elif distance = "medium" then petrol <- petrol - 10.0
    else petrol <- petrol - 1.0

drive("far")
drive("medium")
drive("short")
petrol


// 6.3.2 Working with immutable data  - pg 77

// Listing 6.7 Managing state with immutable values
// Rewrite the code with immutable values

let driveI(petrol, distance) =
    if distance = "far"  then petrol / 2.0
    elif distance = "medium" then petrol - 10.0
    else petrol - 1.0
 
let petrolI = 100.0
let firstState = driveI(petrolI, "far")
let secondState = driveI(firstState, "medium")
let finalState = driveI(secondState, "short")
finalState

// Now you try  - pg 79

// Let’s see how to make some changes to your drive code:
// 1 Instead of using a string to represent how far you’ve driven, use an integer.
// 2 Instead of far, check whether the distance is more than 50.
// 3 Instead of medium, check whether the distance is more than 25.
// 4 If the distance is > 0, reduce petrol by 1.
// 5 If the distance is 0, make no change to the petrol consumption. In other words, 
//   return the same state that was provided.

let far = 50  // 1.
let medium = 25
let home = 0

let driveI2(petrol, distance) =
    if distance > far  then petrol / 2.0       // 2.
    elif distance > medium then petrol - 10.0  // 3.
    elif distance > home then petrol - 1.0     // 4.
    else petrol                                // 5.
 
let petrolI2 = 100.0
let firstState2 = driveI2(petrolI2, 51)
let secondState2 = driveI2(firstState2, 35)
let finalState2 = driveI2(secondState2, 5)
finalState2


// 6.3.3 Other benefits of immutable data  - pg 79
