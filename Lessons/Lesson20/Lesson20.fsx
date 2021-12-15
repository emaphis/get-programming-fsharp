// Lesson 20 - Program Flow in F#
// Pg. 231

////////////////////////////////////
// 20.1 A tour arund loops in F#

// 20.1.1 for loops - pg. 232
// modaling for and for-each loops

// Listing 20.1 for .. in loops in F

// Upward counting loop
for number in 1 .. 10 do
    printfn "%d Hello!" number

for chr in 'a' .. 'f' do
    printfn "%c" chr

// Downward-counting for loop
for number in 10 .. -1 .. 1 do
    printfn "%d Hello!" number

// Typical for-each-style loop
let customerIds = [ 45 .. 99]
for customerId in customerIds do
    printfn "%d bought something!" customerId

// Range with custom stepping
for even in 2 .. 2 .. 10 do
    printfn "%d is an even integer!" even


// 20.1.2 while loops

// Listing 20.2 while loops in F#

open System.IO

let reader = new StreamReader(File.OpenRead @"Lesson20\File.txt")
while (not reader.EndOfStream) do
    printfn "%s" (reader.ReadLine())

reader.Close()


// 20.1.3 Comprehensions  - pg. 233

// Listing 20.3 Comprehensions in F
open System

// Generating an array of the letters of the alphabet in uppercase
let arrayOfChars = [| for c in 'a' .. 'z' -> Char.ToUpper c |]

// Generating the squares of the numbers 1 to 10
let listOfSquares = [ for i in 1 .. 10 -> i * i ]

// Generating arbitrary strings based on every fourth number between 2 and 20
let seqOfStrings = seq { for i in 2 .. 4 .. 20 -> sprintf "Number %d" i }
printfn "%A" seqOfStrings


////////////////////////////////////
/// 20.2 2 Branching logic in F# - pg. 234

// 20.2.1 Priming exercise—customer credit limits

// Listing 20.4 If/then expressions for complex logic  - pg. 235
let getLimit1 customer =
    let score, years = customer
    let limit =
        if score = "medium" && years = 1 then 500
        elif score = "good" && (years = 0 || years = 1) then 750
        elif score = "good" && years = 2 then 1000
        elif score = "good" then 2000
        else 250
    limit

let cust1 = ("good", 1)
let cred0 = getLimit1 cust1


// 20.2.2 Say hello to pattern matching

// Listing 20.5 Our first pattern-matching example  - pg. 236
let getLimit2 customer =
    let limit =
        match customer with
        | "medium", 1 -> 500
        | "good", 0 | "good", 1 -> 750
        | "good", 2 -> 2000
        | _ -> 250
    limit

let cred1 = getLimit2 cust1


// 20.2.3 Exhaustive checking

// Now you try  - pg. 237

(*
Let’s work through a simple example that illustrates how exhaustive pattern matching
works:
    1 Open a new script file.

    2 Create a function getCreditLimit that takes in a customer value. Don’t specify the
      type of the customer; let the compiler infer it for you.

    3 Copy across the pattern-matching code from this sample that calculates the limit
      and return the limit from the function. Ensure that this compiles and that you can
      call it with a sample tuple; for example, ("medium", 1).

    4 Remove the final (catchall) pattern (| _ -> 250).

    5 Check the warning highlighted at the top of the match clause, as shown in figure 20.1
      The warning indicates that you haven’t considered the case of a customer with an
      arbitrary credit score and zero years’ history.

    6 Call the function with a value that won’t be matched—for example, ("bad", 0)—
      and see in FSI that a MatchFailureException is raised.

    7 Fill in a new pattern at the bottom of (_, 0) and set the output for this case to 250.

    8 Notice that the warning has now changed to say you need to fill in a case for
      (_, 2), and so forth.

*)

/// 2. 3.
let getCreditLimit1 customer =
    let limit =
        match customer with
        | "medium", 1 -> 500
        | "good", 0 | "good", 1 -> 750
        | "good", 2 -> 1000
        | "good", _ -> 2000
        | _, 0  -> 250   // 7.
        | _  -> 300
    limit

// 4., 5.  FS0025: Incomplete pattern matches on this expression.

// 6.`
let credit1 = getCreditLimit1 ("bad", 2)
// val credit1: int = 250


// 20.2.4 Guards  - pg. 238

/// Listing 20.6 Using the when guard clause
let getLimit3 customer =
    match customer with
    | "medium", 1 -> 500
    | "good", years when years < 2 -> 750
    | "good", 2 -> 1000
    | "good", _ -> 2000
    | _  -> 250

let cred4 = getLimit3 cust1


// 20.2.5 Nested matches  - pg. 139

/// Listing 20.7 Nesting matches inside one another
let getLimit4 customer =
    match customer with
    | "medium", 1 -> 500
    | "good", years ->
        match years with
        | 0 | 1 -> 759
        | 2 -> 100
        | _ -> 200
    | _  -> 250

let cred5 = getLimit4 cust1


// 20.3 Flexible pattern matching - pg. 239

// 20.3.1 Collections

// Now you try  - pg. 240
(*
Let’s work through the preceding logic to see pattern matching over lists in action:
    1 Create a Customer record type that has fields Balance : int and Name : string.

    2 Create a function called handleCustomers that takes in a list of Customer records.

    3 Implement the preceding logic by using standard if/then logic. You can use
      List.length to calculate the length of customers, or explicitly type-annotate the
      Customer argument as Customer list and get the Length property on the list.

    4 Use failwith to raise an exception (for example, failwith "No customers supplied!").

    5 Now enter the following pattern match version for comparison.
*)

// 1.
type Customer =
 { Name : string;
   Balance : int  }

let list1 = [ ]
let list2 = { Name = "Fred";   Balance = 50 } :: list1
let list3 = { Name = "Tawnya"; Balance = 30 } :: list2
let list4 = { Name = "Chuck";  Balance =  0 } :: list3

list4 |> List.iter (fun cust -> printfn "%A" cust.Balance)

/// 2.
let handleCustomers1 customers =
    let length = List.length customers
    if length = 0 then failwith "No ustomers supplied!"
    elif length = 1 then printfn "Single customer, name is %s" (List.head customers).Name
    elif length = 2 then printfn "Two customers, balance = %d" (customers.Head.Balance +  customers.Tail.Head.Balance)
    else printfn "Customers supplied: %d" customers.Length

//handleCustomers1 list1
handleCustomers1 list2
handleCustomers1 list3
handleCustomers1 list4

/// Listing 20.8 Matching against lists
let handleCustomers customers =
    match customers with
    | [] -> failwith "No customers supplied!"
    | [ customer ] -> printfn "Single customer, name is %s" customer.Name
    | [ first; second ] ->
        printfn "Two customers, balance = %d" (first.Balance + second.Balance)
    | customers -> printfn "Customers supplied: %d" customers.Length

//handleCustomer list1
handleCustomers list2
handleCustomers list3
handleCustomers list4

// 20.3.2 Records  - pg. 241

/// Listing 20.9 Pattern matching with records
let getStatus customer =
    match customer with
    | { Balance = 0 } -> "Customer has empty balance!"
    | { Name = "Isaac" } -> "This is a great customer!"
    | { Name = name; Balance = 50 } -> sprintf "%s has a large balance!" name
    | { Name = name } -> sprintf "%s is a normal customer" name

// test all cases
let list5 = { Name = "Isaac"; Balance = 130 } :: list4
list5 |> List.iter (fun cust -> printfn "%s" (getStatus cust))

/// Listing 20.10 Combining multiple patterns
let checkCustomers customers =
    match customers with
    | [ { Name = "Tanya" }; { Balance = 25 }; _ ] -> "It's a match!"
    | _ -> "No match!"

list5 |> checkCustomers


////////////////////////////////
// 20.4 To match or not to match  - pg. 141

// Listing 20.11 When to use if/then over match
let customer = list5.Head

// if it's simpler of one case selections
if customer.Name = "Isaac" then printfn "Hello!"

match customer.Name with
| "Isaac" ->  printfn "Hello!"
| _ -> ()
