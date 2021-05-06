/// Chapter 6  -  Program organization
/// Signature files  - pg. 131
namespace SignatureFiles

module Functions =

    /// define a function to be exposed
    let funkyFunction x =
        x + ": keep it funky"

    // define a function that will be hidden
    let notSoFunkyFunction x = x + 1

