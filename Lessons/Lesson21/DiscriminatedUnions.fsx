// Now you try  - pg 247


type Disk =
    | HardDisk of RPM:int * Platters:int
    | SolidState
    | MMC of NumberOfPins: int


let disk1 = HardDisk(RPM = 150, Platters = 9)
let disk2 = HardDisk(300, 7)


// Creating discrimated unions in F#  - pg. 247
let myHardDisk = HardDisk(RPM = 250, Platters = 7)
let myHardDiskShort = HardDisk(250, 7)
let args = 250, 7
let myHardDiskTupled = HardDisk args
let myMMC = MMC 5
let mySsd = SolidState
