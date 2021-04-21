/// Chapter 3
/// Literals
/// pg 19


// strings
let message = "Hello
World\r\n\t!"
// backslaxhes are interpreted litterally.
let dir = @"c:\Apps"

// byte array
let byteStr = "bytesbytesbytes"B
let chr1 = 'c'
let bool1 = true
let i32h = 0x22
let i32o = 0o42


// numeric types
let xA = 0xFFy
let xB = 0o777un
let xC = 0b10010UL


// Print the results
let main() =
    printfn "%A" message
    printfn "%A" dir
    printfn "%A" byteStr
    printfn "%A" xA
    printfn "%A" xB
    printfn "%A" xC


main()


