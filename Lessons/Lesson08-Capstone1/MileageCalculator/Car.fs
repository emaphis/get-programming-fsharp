module Car

open System


/// Gets the distance to a a given destination
let getDistance (destination) =
    if destination = "Home" then 25
    elif destination = "Office" then 50
    elif destination = "Stadium" then 25
    elif destination = "Gas" then 10
    else failwith "Unknown destination!"


// Calculates remaining petrol given current pertrol and distance traveled
let calculateRemainingPetrol(currentPetrol:int, distance:int) : int =
    let newPetrol = currentPetrol - distance
    if newPetrol < 0 then failwith "Out of gas!"
    else newPetrol


/// Return new Petrol amount given a destination
let driveTo (petrol:int, destination:string) : int =
    let distance = getDistance destination
    let remaining = calculateRemainingPetrol(petrol, distance)
    if destination = "Gas" then remaining + 50
    else remaining
