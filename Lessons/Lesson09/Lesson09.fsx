/// Lesson 9 -  Shaping data with tuples  - pg 101
/// 

/// 9.1 the need for tuples

/// 9.2 Tuple basice. - pg. 103

///  Listing 9.3  Returning arbitrary data pairs
let parseName(name: string) =
    let parts = name.Split(' ')
    let forename = parts.[0]
    let surname = parts.[1]
    forename, surname

let name = parseName("Ed Maphis")
let forname, surname = name
let fname, sname = parseName("Ed Mapis")


// Now you try  - pg 104

// Let’s do a bit of hands-on work with tuples:
// 1 Open a blank .fsx file for experimenting.
// 2 Create a new function, parse, which takes in a string person that has the format
//   playername game score (for example, Mary Asteroids 2500).
// 3 Split the string into separate values.
// 4 Convert the third element to an integer. You can use either System.Convert.ToInt32(),
//   System.Int32.Parse(), or the F# alias function for it, int().
// 5 Return a three-part tuple of name, game, and score and assign it to a value.
// 6 Deconstruct all three parts into separate values by using let a,b,c = syntax.
// 7 Notice that you can choose arbitrary names for each element.

let parse (person: string) =
    let parts = person.Split(' ')
    let name = parts.[0]
    let game = parts.[1]
    let score = int(parts.[2])
    name, game, score

let player, game, score = parse "Mary Asteroids 2300"
;;;

/// 9.2.1  When should I use tuples?  - pg 105

/// 9.3 More complex tuples  - pg 106

/// 9.3.1  Tupe type signatures
 
 let nameAndAge0 = ("Joe", "Blogs"), 28
// val nameAndAge : (string * string) * int


/// 9.3.2  Nested tuples

/// Listing 9.4 Returning more-complex arbitrary data pairs in F#

let nameAndAge = ("Joe", "Blogs"), 28
let name1, age1 = nameAndAge
let (forename1, surname1), theAge = nameAndAge


/// 9.3.3 Wildcards  - pg 107
/// Listing 9.5  Using wildcars with tuples 

let nameAndAge1 = "Jane", "Smith", 25
let forename2, surname2, _ = nameAndAge1


/// 9.3.4  Type inference with tuples
/// Listing 9.6 
let explicit : int * int = 10, 5
let implicit = 10, 5  // type infered
;;
let addNumbers0 arguments =
    let a, b = arguments  // destructuring
    a + b

7 = addNumbers0(3, 4)


/// Listing 9.7  Generalized functions with tuples
let addNumbers2 arguments =
    let a, b, c, _ = arguments
    a + b


/// 9.4  Tuples best practices  - pg 108

/// 9.4.1  Tuples and the BCL

/// Listing 9.8 Implicit mapping of out parameters to tuples  - pg 109
// var number = "123";
// var result = 0;
// var parsed = Int32.TryParse(number, out, result)

let number = "456"
let result, parsed = System.Int32.TryParse(number)


/// 9.4.2  When not to use tuples
