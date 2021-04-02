/// Lesson 7 - Expressions and Statements - pg 81

 /// 7.1 Comparing statements and expressons
 /// See LessonCS07 for C# code

/// 7.2 Using expressions in F#  - 85

/// 7.2.1 Working with expressions.
 
/// Listing 7.3 Working with expressions in F# - pg 86
open System 

let describeAge age =
    let ageDescription =
        if age < 18 then "Child!"
        elif age < 65 then "Adult!"
        else "OAP!"

    let greeting = "Hello"
    Console.WriteLine("{0}! You are a '{1}'.", greeting, ageDescription)


/// 7.2.2 Encouraging composability
/// 7.2.3 Introducing unit - pg 87

// Now you try
// Let’s quickly look at unit with a few practical examples:

// 1 Create an instance of unit by using standard let binding syntax; the right-hand 
//   side of the equals sign needs to be ().
// 2 Call the describeAge function and assign the result of the function call to a separate 
//   value.
// 3 Check whether the two values are equal to one another. What is the result?

let u = ()
let y = describeAge 20
u = y  // true

// unit isn't really an object
//u.Equals(y)
//u.GetHashCode()
//u.GetType()
//u.ToString()


/// 7.2.4 Discarding results  - pg 88
// F# complains about not using the result of a computation

// Listing 7.6 Discarding the result of an expression

let writeTextToDisk text =
    let path = System.IO.Path.GetTempFileName()
    System.IO.File.WriteAllText(path, text)
    path

let createManyFiles() = 
    ignore(writeTextToDisk "The quick brown fox jumped over the lazy dog")
    ignore(writeTextToDisk "The quick brown fox jumped over the lazy dog")
    writeTextToDisk "The quick brown fox jumped over the lazy dog"

createManyFiles()

///  Listing 7.8 Forcing statement-based code with unit  - pg 90

// Listing 7.8 Forcing statement-based code with unit
let now = System.DateTime.UtcNow.TimeOfDay.TotalHours

if now < 12.0 then System.Console.WriteLine "It's morning"
elif now < 18.0 then System.Console.WriteLine "It's afternoon"
elif now < 20.0 then ignore(5 + 5)
else ()


