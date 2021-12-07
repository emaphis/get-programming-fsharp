// Lesson 21 - Modeling Relationships in F#
// pg. 244

// 21.1 Composition in F#

// Listing 21.1 Composition with records in F#  - pg. 245
type Disk' = { SizeGb: int }

type Computer' =
  { Manufacturer : string
    Disks : Disk' list }

let myPC' =
  { Manufacturer = "Computer Inc."
    Disks =
      [ { SizeGb = 100 }
        { SizeGb = 250 }
        { SizeGb = 500 } ] }



///////////////////////////////////
// 21.2 Discriminated unions in F#  - pg. 246

/// Listing 21.2 Discriminated unions in F#
type Disk =
    | HardDisk of RPM:int * Platters:int
    | SolidState
    | MMC of NumberOfPins: int


// Creating discrimated unions in F#  - pg. 247

// Listing 21.3
let myHardDisk = HardDisk(RPM = 250, Platters = 7)
let myHardDiskShort = HardDisk(250, 7)
let args = 250, 9
let myHardDiskTupled = HardDisk args
let myMMC = MMC 5
let myMMC3 = MMC 3
let myMMC1 = MMC 1
let mySsd = SolidState
let oldDrive = HardDisk(5400, 5)


// 21.2.2 Accessing an instance of a DU  - pg. 428

/// Listing 21.4 Writing functions for a discriminated union
let seek disk =
    match disk with
    | HardDisk _ -> "Seeking loudly at a reasonable speed!"
    | MMC _ -> "Seeking quitely but slowly"
    | SolidState -> "Already found it!"

seek mySsd
seek myHardDisk


/// Listing 21.5 Pattern matching on values  - pg. 249
let whatDisk disk =
    match disk with
    | HardDisk(5400, 5) -> "Seeking very slowly!"
    | HardDisk(rpm, 7) -> sprintf "I have 7 spindles and RPM %d!" rpm
    | MMC 3 -> "Seeking. I have 3 pins!"
    | _  -> "Seeking. Whatever dist"

whatDisk myHardDisk
whatDisk oldDrive
whatDisk myMMC


// Now you try  - pg. 249
(*
Now you try
Let’s now see how to write a function that performs pattern matching over a discriminated union:

1 Create a function, describe, that takes in a hard disk.

2 The function should return texts as follows:
    a If an SSD, say, “I’m a newfangled SSD.”

    b If an MMC with one pin, say, “I have only 1 pin.”

    c If an MMC with fewer than five pins, say, “I’m an MMC with a few pins.”

    d Otherwise, if an MMC, say, “I’m an MMC with <pin> pins.”

    e If a hard disk with 5400 RPM, say, “I’m a slow hard disk.”

    f If the hard disk has seven spindles, say, “I have 7 spindles!”

    g For any other hard disk, state, “I’m a hard disk.”

3 Remember to use the wildcard character (_) to help make partial matches for
  example, (5400 RPM + any number of spindles), and guard clauses with the when
  keyword.
 *)

// 1.
let describe disk =
    match disk with
    | SolidState  -> "I’m a newfangled SSD"  // a.
    | MMC 1   -> "I have only 1 pin."   // b.
    | MMC pins when pins < 5 -> "I’m an MMC with a few pins." // c.
    | MMC pins  -> sprintf "I’m an MMC with %d pins." pins  // d.
    | HardDisk (5400, _) -> "I’m a slow hard disk."  // e.
    | HardDisk (_, 7)  -> "I have 7 spindles!"   // f.
    | HardDisk _  -> "I’m a hard disk."   // g. 3.

// testing
let disks = [ myHardDisk; myHardDiskShort; myHardDiskTupled; myMMC; myMMC3; myMMC1; mySsd; oldDrive]
disks |> List.iter (fun disk -> printfn "%s" (describe disk))



///////////////////////////////////////////////////////
// 21.3 Tips for working with discriminated unions  - pg. 251

// 21.3.1 Nested DUs

// Listing 21.6 Nested discriminated union

type MMCDisk =
| RsMmc
| MmcPlus
| SecureMMC

type DiskWithMmcData =
| MMC of MMCDisk * NumberOfPins: int

let describeMMC disk =
    match disk with
    | MMC(MmcPlus, 3)  -> "Seeking quietly but slowly"
    | MMC(SecureMMC, 6) -> "Seeking quietly with 6 pins."
    | MMC(RsMmc, _)  -> "Seeking with a RsMsc"
    | MMC _ ->  "What ever"

let disk = MMC(MmcPlus, 3)
printfn "%s" (describeMMC disk)


// 21.3.2 Shared fields - pg. 251

/// Listing 21.7 NShared fields using a combination of records and discriminated unions
type DiskInfo =
    { Manufacturer : string
      SizeGb : int
      DiskData : Disk }  // defined earlier

type FullComputer = { Manufacturer : string;  Disks : DiskInfo list }

let myFullPc =
    { Manufacturer = "Computers Inc."
      Disks =
        [ { Manufacturer = "HardDisks Inc."
            SizeGb = 100
            DiskData = HardDisk(5400, 7) }
          { Manufacturer = "SuperDisks Corp."
            SizeGb = 250
            DiskData = SolidState } ] }

// 21.3.3 Printing out DUs
// Print using "%A"

printfn "%A" myFullPc


// 21.4.2 Creating enums  - pg. 255

/// Listing 21.8  Listing 21.8 Creating an enum in F#  - pg. 255
type Printer =
| Injket = 0
| Laserjet = 1
| DotMatrix = 2
