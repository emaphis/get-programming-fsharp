/// Chapter 6  - Organizing code
/// Namepspaces  - pg. 127

// put a file in a name space
namespace Strangelights.Beginning

// namespaces without modules can only contrain type definitions

type MyRecord = { Field : string }

// .. but not value definitions
// let n = 0
// let myFun x = x + 3


// create a module in a nmaespace
module FirstModule =
    let n = 1

// create a second module
module SecondModule =
    let n = 2
    // create a third, nested module
    module ThirdModule =
        let n = 3
