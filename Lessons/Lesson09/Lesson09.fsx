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


/// 9.2.1  When should I use tuples?  - pg 105



