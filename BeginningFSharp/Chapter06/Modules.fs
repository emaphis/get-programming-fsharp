/// Chapter 6 - Organizing Code
/// Modules  - pg 125.

// Create a top level mdoule
module ModuleDemo

// Create a first module:
module FirstModule =
    let n = 1

// Create a second module
module SecondModule =
    let n = 2

    // Create nested module
    module ThirdModule =
        let n = 3
