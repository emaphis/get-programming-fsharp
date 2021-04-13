/// Lesson 16 - Useful Colletion Functions.  - pg 186


/// 16.1 Mapping functions 
// takes a collection and returns a collection.


/// 16.1.1 map
// mapping:('T -> 'U) -> list:'T list -> 'U list

type Person = { Name : string; Town : string }

let persons = 
    [ { Name = "Isaac"; Town = "London"}
      { Name = "Sara"; Town = "Birmingham" }
      { Name = "Tim"; Town = "London" }
      { Name = "Michelle"; Town = "Manchester" } ]

persons |> List.map(fun person -> person.Town)


/// Listing 16.1 map  pg 187
let numbers = [ 1 .. 10 ]
let timesTwo n = n * 2

let outputImperative = ResizeArray()

// imperative example
for number in numbers do
    outputImperative.Add(number |> timesTwo)

// functional example
let outputFunctional = numbers |> List.map timesTwo

// See also: map2, map3, mapi, mapi2, indexed



/// 16.1.2 iter - pg 88
// like map but doesn't return anything - side effects

// action:('T -> 'unit) -> list:'T list -> unit

persons |> List.iter (fun person -> printfn "Hello, %s!" person.Name)

numbers |> List.iter (fun num -> printf ":%d " num)

// See also: iter2, iter3, iteri, iteri2


/// 16.1.3 collect  - pg 198
// flatmap flatten selectmany

// mapping:('T -> 'U list) -> list:'T list -> 'U list

type Order = { OrderId : int }
type Customer = { CustomerId : int; Orders : Order list; Town : string }
let customers : Customer list =
    [{ CustomerId = 10
       Orders = [ { OrderId = 55 }; { OrderId = 30 }; { OrderId = 78 } ]
       Town = "Manchester" }
     { CustomerId = 18
       Orders = [ { OrderId = 46 }; { OrderId = 22 } ]
       Town = "London" }
     { CustomerId = 14
       Orders = [ { OrderId = 11 }; { OrderId = 34 }; { OrderId = 47 }; { OrderId = 88 } ]
       Town = "Birmingham" }]

let orders : Order list = customers |> List.collect(fun c -> c.Orders)


/// 16.1.4 pairwise  - pg 190

// list:'T list -> ('T * 'T) list

[ 1; 2; 3; 4; 5] |> List.pairwise


open System

[ DateTime(2010,5,1)
  DateTime(2010,6,1)
  DateTime(2010,6,12)
  DateTime(2010,7,3) ]
|> List.pairwise
|> List.map(fun (a,b) -> b - a)
|> List.map(fun time -> time.TotalDays)

// See also: windowed



/// 6.2 Grouping functions  - pg 192

/// 16.2.1 groupBy

// projection: ('T -> 'Key) -> list: 'T list -> ('Key * 'T list) list

persons |> List.groupBy (fun person -> person.Town)


/// 16.2.2 countBy  - pg 192

// projection: ('T -> 'Key) -> list: 'T list -> ('Key * int) list

persons |> List.countBy (fun person -> person.Town)


/// 16.2.3 partition

// predicate: ('T -> bool) -> list: 'T list -> ('T list * 'T list)

/// Listing 16.4 Splitting a collection in two based on a predicate 

let londonCustomers, otherCustomers =
    customers |> List.partition (fun c -> c.Town = "London")

// See also: chunkBySize, splitInto, splitAt


/// 16.3 More on collections  - pg 194

/// 16.3.1 Aggregates

/// Listing 16.5 Simple aggregation functions in F#
let numbers1 = [ 1.0 .. 10.0 ]
let total = numbers1 |> List.sum
let average = numbers1 |> List.average
let max = numbers1 |> List.max
let min = numbers1 |> List.min 


/// 16.3.2 Miscellaneous functions  - pg 194
// find heat item take exists forall contains filter length distinct sortBy


/// 16.3.3 Converting between collections  - pg 195

/// isting 16.6 Converting between lists, arrays, and sequences
let numberOne =
    [ 1 .. 5 ]
    |> List.toArray
    |> Seq.ofArray
    |> Seq.head


/// Try this  pg 196
// See lesson16Try.fsx
