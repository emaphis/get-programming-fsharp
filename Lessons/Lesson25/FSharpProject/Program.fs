//Lesson 25  - Consuming C# From F#

// Listing 25.2 Consuming C# code from F#  - pg. 301
[<EntryPoint>]
let main argv =
    let tony = CSharpProject.Person "Tony"
    tony.PrinName()
    0
