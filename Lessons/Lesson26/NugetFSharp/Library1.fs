// Lesson 26  - Working with Nuget Packages

module Library1

open Newtonsoft.Json

// Defining an F# record
type Person = { Name  : string; Age : int }


let getPerson() =
    let text = """{ "Nme" : "Sam", "Age" : 18 }"""

    // Using     Newtonsoft.Json to deserialize the object
    let person = JsonConvert.DeserializeObject<Person>(text)
    printfn "Name is %s with age %d." person.Name person.Age
    person
