/// Chapter 3  - Functional Programming
/// Exceptions
/// pg 60


// define a custom exception type
exception WrongSecond of int

// list of prines
let primes =
    [ 2; 3; 5; 7; 11; 13; 17; 19; 23; 29; 31; 37; 41; 43; 47; 53; 59 ]

// function throws an exception if second is prime
let testSecond() =
    try
        let currentSecond = System.DateTime.Now.Second in
        // test if current second is in the list of primes
        if List.exists (fun sec -> sec = currentSecond) primes then
            failwith "A prime second"
        else
            // raise the WrongSecond exception
            raise (WrongSecond currentSecond)


    with
    // catch the wrong second exception
    WrongSecond ex ->
        printf "The current second was %i, which is not prime" ex


// call the function
testSecond()


// fucntion to write to a file
let writeToFile() =
    // open a file
    let file = System.IO.File.CreateText("test.txt")
    try
        // write to it
        file.WriteLine("Hello F# users")
    finally
        // close the file, this will happen even if
        // an exception occurs writing to the file
        file.Dispose()

// call the function
writeToFile()
