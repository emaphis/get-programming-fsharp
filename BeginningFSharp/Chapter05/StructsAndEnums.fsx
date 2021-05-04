/// Chapter 5  - Object Oriented Programming
/// Structs and Enums  - pg. 123


// Structs

type IpAddress = struct
    val first : byte
    val second : byte
    val third : byte
    val fourth : byte

    new(first, second, third, fourth) =
        { first = first
          second = second
          third = third
          fourth = fourth }

    override x.ToString() =
        Printf.sprintf "%O.%O.%O.%O" x.first x.second x.third x.fourth
    
    member x.GetBytes() = x.first, x.second, x.third, x.fourth
end


// Enums

type Scale =
| C = 1
| D = 2
| E = 3
| F = 4
| G = 5
| A = 6
| B = 7

// Combine logically

[<System.Flags>]
type ChordScale =
| C = 0b0000000000000001
| D = 0b0000000000000010
| E = 0b0000000000000100
| F = 0b0000000000001000
| G = 0b0000000000010000
| A = 0b0000000000100000
| B = 0b0000000001000000
