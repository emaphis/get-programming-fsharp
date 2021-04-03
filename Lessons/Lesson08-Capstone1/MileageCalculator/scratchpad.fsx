/// From lesson 6

/// specs
// 1 Your car starts with 100 units of petrol.
// 2 The user can drive to one of four destinations. Each destination will consume a
//   different amount of petrol: 
//   a Home—25 units
//   b Office—50 units
//   c Stadium—25 units
//   d Gas station—10 units
// 5 If the user tries to drive anywhere else, the system will reject the request.
// 6 If the user tries to drive somewhere and doesn’t have enough petrol, the system
//   will reject the request.
// 7 When the user travels to the gas station, the amount of petrol in the car should
//   increase by 50 units.


/// 8.4 Implementing core logic. pg 95

/// 8.4.1 Your first function—calculating distances
// How many units of petrol will be used by driving to a specific location?
// Input - destination to drive to
// Output - amount of petrol consumed.

// Listing 8.2 Creating a function to calculate distances - pg 96

/// Gets the distance to a a given destination
let getDistance (destination) =
    if destination = "Home" then 25
    elif destination = "Office" then 50
    elif destination = "Stadium" then 25
    elif destination = "Gas" then 10
    else failwith "Unknown destination!"


// testing
25 = getDistance "Home"
50 = getDistance "Office"
25 = getDistance "Stadium"
10 = getDistance "Gas"
-9999 = try getDistance "What?" with ex -> -9999


/// 8.4.2 Calculating petrol consumption  - pg 96

let calculateRemainingPetrol(currentPetrol:int, distance:int) : int =
    let newPetrol = currentPetrol - distance
    if (newPetrol < 0) then failwith "Oops! You've run out of petrol!"
    else newPetrol

// testing
let petrol1 = 100
let new1 = calculateRemainingPetrol(petrol1, 50)
50 = new1
let new2 = calculateRemainingPetrol(new1, 45)
5 = new2
-999 = try calculateRemainingPetrol(new2, 10) with ex -> -999
 

/// 8.4.3 Composing functions together  - pg 97
// build up higher level functions using composition

// Listing 8.3 Testing orchestration of several functions
let distanceToGas = getDistance("Gas")
15 = calculateRemainingPetrol(25, distanceToGas)
-9999 = try calculateRemainingPetrol(5, distanceToGas) with ex -> -9999


// driveTo is a composition of getDistance and calculateRemainingPetrol

/// Return new Petrol amount given a destination
let driveToT (petrol:int, destination:string) : int =
    let distance = getDistance destination
    calculateRemainingPetrol(petrol, distance)

15 = driveToT(25, "Gas")
-999 = try driveToT(5, "Gas") with ex -> -999


/// 8.4.4 Stopping at the gas station

// Listing 8.4 A test case in script

/// Return new Petrol amount given a destination
let driveTo (petrol:int, destination:string) : int =
    let distance = getDistance destination
    let remaining = calculateRemainingPetrol(petrol, distance)
    if destination = "Gas" then remaining + 50
    else remaining

// Testing
15 = driveTo(40, "Home")
-999 = try driveTo(5, "Gas") with ex -> -999
55 = driveTo(15, "Gas")



/// 8.5 Testing in scripts  - pg 97
/// Listing 8.4 A test case in script

let a = driveTo(100, "Office")
let b = driveTo(a, "Stadium")
let c = driveTo(b, "Gas")
let answer = driveTo(c, "Home")
40 = answer



/// 8.6 Moving to a full application  - pg 98
//  See Program.fs and Car.fs
