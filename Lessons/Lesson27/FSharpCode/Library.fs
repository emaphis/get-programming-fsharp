// Lesson 27  - Exposing F# Types and Functions to C#

// Listing 27.1 An F# record to be accessed from C#  - pg.323 
namespace Model

/// A standard F# record of a Car
type Car =
  { /// The number of wheels on the Car.
    Wheels : int
    /// The brand of the car.
    Brand : string
    /// The x/y of the car in meters
    Dimensions : float * float }


// Listing 27.2 Creating tuples and discriminated unions in F#  - pg. 325

/// A vehicle of some sort.
type Vehicle =
  /// A car is a type of vehicle.  
| Motorcar of Car
  /// A bike is also a type of vehicle.
| Motorbike of Name : string * EngineSize : float




// 27.2.2 Using F# functions in C#  - pg  327

// Listing 27.3 Exposing a module of functions to C#

module Functions =
    /// Creates a car
    let CreateCar wheels brand x y =
        { Wheels = wheels; Brand = brand; Dimensions = x, y}

    /// Creates a car with four wheels.
    let CreateFourWheeledCar = CreateCar 4


