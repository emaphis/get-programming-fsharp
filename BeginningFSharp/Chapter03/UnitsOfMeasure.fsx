/// Chapter 3  - Functional Programming
/// Units of Measure
/// pg. 58


// Units of measure for meter:
[<Measure>]type m
// A distance in meters
let meters = 1.0<m>

// Units of measure for volume:
[<Measure>]type liter
[<Measure>]type pint

// Some volumes
let vol1 = 2.5<liter>
let vol2 = 2.5<pint>


//error
//let newVol = vol1 + vol2

// Define the ratio of pints to liters:
let ratio = 1.0<liter> / 1.76056338<pint>


// A function to convert pints to liters
let convertPintToLiter pints =
    pints * ratio


// Perform the conversion and add the values
let newVol2 = vol1 + (convertPintToLiter vol2)

printfn "The volume is %f" newVol2

// stripping off the unit of measure
printfn "The volume is  %f" (float vol1)

// > F# 4.0
printf "The volume is %f" vol2
