/// Lesson 13  Achieving code reuse in F#  - pg 149



/// 13.2 Implementing higher-order functions in F#  - pg 154

/// 13.2.1 Basics of higher-order functions


/// Now you try  - pg 154
// implementing filter

type Customer = { Age : int }

let where filter customers =
    seq {
        for customer in  customers do
            if filter customer then
                yield customer }

let customers = [ { Age = 21 }; { Age = 35 }; { Age = 36 } ]

let isOver35 customer = customer.Age > 35

customers |> where isOver35

customers |> where (fun customer -> customer.Age > 35)


/// 13.2.2 When to pass functions as arguments - pg 155

/// Refactoring code into higher order functions.
//  - Start by creating a normal function with the varying element hardcoded into the
//   algorithm.
// - Then, identify all occurrences of that section, replace them with a simple named
//   value that’s added as an argument to the function.

// Figure 13.4  
//  A hardcoded function that can be converted into a higher-order function

let whereCustomersAreOver35 customers =
    seq {
        for customer in customers do
            if customer.Age > 35 then
                yield customer }

// `customer.Age > 35`  is the varying code.

customers |> whereCustomersAreOver35


/// 13.3 Dependencies as functions  - pg 156
//  Always pass the dependency as the first parameter.


/// Now you try - pg 157

// 2 Create a function, printCustomerAge, that takes in a Customer and, depending on the 
//   Customer’s age, prints out Child, Teenager, or Adult, using Console.WriteLine to output 
//   text to FSI. The signature should read as let printCustomerAge customer =.

open System

// let Customer = ...

let printCustomerAge customer =
    if customer.Age < 13 then Console.WriteLine("Child")
    elif customer.Age < 20 then Console.WriteLine("Teenager")
    else Console.WriteLine("Adult")

// 3 Try calling the function, and ensure that it behaves as expected.

printCustomerAge { Age = 7 }
printCustomerAge { Age = 16 }
printCustomerAge { Age = 45 }

// generalize...

// 4 Identify the varying element of code. For us, this is the call to Console.WriteLine.
// 5 Replace all occurrences with the value writer. Initially, your code won’t compile, 
//   as there’s no value called writer.
// 6 Insert writer as the first argument to the function, so it now reads let printCustomerAge writer customer =.

let printCustomerAgeTo writer customer =
    if customer.Age < 13 then writer "Child"
    elif customer.Age < 20 then writer "Teenager"
    else writer "Adult"

// 7 You’ll see that writer has been correctly identified as a function that takes in a 
//   string and returns ‘a. Now, any function that takes in a string can be used in place 
//   of Console.WriteLine.

printCustomerAgeTo Console.WriteLine { Age = 21 }

let printToConsole = printCustomerAgeTo Console.WriteLine

printToConsole { Age = 7 }
printToConsole { Age = 16 }
printToConsole { Age = 45 }

// 8 Now create a function that can act as the dependency, in order to print to the 
//   filesystem instead. You’ll use System.IO.File.WriteAllText as the basis for your 
//   dependency (if the temp folder doesn’t exist, create it first!).

open System.IO

let writeToFile text = File.WriteAllText(@".\output.txt", text)

let printToFile = printCustomerAgeTo writeToFile
printToFile { Age = 21 }

// 9 Read back from the file by using System.IO.File.ReadAllText to prove that the content 
//   was correctly written out

let text = File.ReadAllText(@".\output.txt")
"Adult" = text

