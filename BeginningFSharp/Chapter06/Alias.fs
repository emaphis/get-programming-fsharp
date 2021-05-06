/// Chapter 6 - Program Organization
/// Giving modules aliases  - pg 130

namespace alias

// give an alias to the Array3 module
module ArrayThreeD =  Microsoft.FSharp.Collections.Array3D

module AnotherModule =
    // create a matrix using the module alieas
    let matrix =
        ArrayThreeD.create 3 3 3 1
