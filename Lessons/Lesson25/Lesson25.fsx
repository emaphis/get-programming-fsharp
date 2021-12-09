// Lesson 25  - Consuming C# From F#  - pg. 291


///////////////////////////////////////////////
// 25.1 Referencing C# code in F#

// 25.1.1 Creating a hybrid solution  - pg. 300

// Now you try
(*
Now you try

1 Open Visual Studio and create a new F# console application called FSharpProject

2 Add a new C# class library called CSharpProject to the solution. Add a reference 
  to the CSharpProject from the FSharpProject by using the standard Add Reference dialog box, shown in figure 25

3 Open the Class1.cs file and replace the contents with a Person class as follows

4 Build the CSharpProject.

5 Now let�s look at consuming this code from F#. First, replace the contents of the
  Program.fs file with the following

6 Run the application
*)


/////////////////////////////////////////////////////////////
// 25.2 The Visual Studio experience  - pg 302

// 25.2.1 Debugging

// Now you try
(*
1 Set a breakpoint inside the definition C# Person class constructor

2 Run the F# console application. Observe that the debugger hits with the name
  value set to Tony, as shown in figure 25.2. 

3 Also, observe that the call stack is correctly preserved across the two languages,
  as shown in figure 25.3.
*)

// 25.2.2 Navigating across projects  pg. 303

// 25.2.3 Projects and assemblies
// you must build a project before changes are seen in other projects.


//25.2.4 Referencing assemblies in scripts

(*
Directive   Description                                 Example usage
#r          References a DLL for use within a script    #r @"C:\source\app.dll"
#I          Adds a path to the #r search path           #I @"C:\source\"
#load       Loads and executes an F# .fsx or .fs file   #load @"C:\source\code.fsx"
*)

// Now you try  - pg. 304
(*
Now experiment with referencing an assembly within a script:

1 Create a new script as a new solution item called Scratchpad.fsx.

2 Open the script file and enter the following code.

3 Execute the code in the script by using the standard Send to F# Interactive
  behavior. Notice the first line that’s output in FSI
*)

// You use @ to treat backslashes as literals
#r @"CSharpProject\bin\Debug\net6.0\CSharpProject.dll"
open CSharpProject

let simon = Person "Simon"
simon.PrinName()


//25.2.5 Debugging scripts  - pg. 306

// Now you try
(*
Let’s debug the script that you already have open to see how it operates in VS2015:

1 With the script from listing 25.3 still open, right-click line 3 (the constructor call
  line) with your mouse.

2 From the pop-up menu, choose Debug with F# Interactive.

3 After a short delay, you’ll see the line highlighted, as shown in figure 25.5. From
  there, you can choose the regular Step Into code as usual.

4 You can also do the same by using the keyboard shortcut Ctrl-Alt-Enter.

5 When you’ve finished debugging, you c
  an click Stop from the toolbar, or press 
  Shift-F5 to stop the debugging session.

*)

let joan = Person "Jown"
joan.PrinName()


/////////////////////////////////////////////
// Working with OO constructs  - pg. 306

// Listing 25.4 Treating constructors as functions

open CSharpProject

let longhand =
    [ "Tony"; "Fred"; "Samantha"; "Brad"; "Sophie" ]
    |> List.map(fun name -> Person(name))

let shorthand =
    [ "Tony"; "Fred"; "Samantha"; "Brad"; "Sophie" ]
    |> List.map Person

shorthand |> List.map (fun person -> person.PrinName())


// 25.3.1 Working with interfaces

// Listing 25.5 Treating constructors as functions  - pg. 307

open System.Collections.Generic

// Class definition with default constructor
type PersonComparer() =
    interface IComparer<Person> with  // Interface header
        member this.Compare(x, y) = x.Name.CompareTo(y.Name)    // implementation

// Creating an instance of the interface
let pComparer = PersonComparer() :> IComparer<Person>
pComparer.Compare(simon, Person "Fred")

// Now you try
(*
F# Power Tools comes with a handy refactoring to implement an interface for you:

1 Enter the first three lines from listing 25.5

2 Remove the with keyword from the third line

3 Move the caret to the start of IComparer in the same line.

4 You’ll be presented with a smart tag (figure 25.6). Press Ctrl-period to open it

5 Try both forms of generation. The first (nonlightweight) will generate an implementation
  with fully annotated type signatures; the latter will omit type annotations if possible and
  place method declarations with stub implementations on a single line.
*)


// try code
// Ctrl - .  to activeate light bulb
type PersonComparer2() =
    interface IComparer<Person> with
        member this.Compare(x, y) = raise (System.NotImplementedException()) 



// 15.3.2  Object expressions  - pg. 308

// Listing 25.6 Using object expressions to create an instance of an interface

// interface definition
let pComparer3 =
    { new IComparer<Person> with
          member this.Compare(x, y) = x.Name.CompareTo(y.Name)  }


// 25.3.3 Nulls, nullables, and options

// Listing 25.7 Option combinators for classes and nullable types
open System

// Creating a selection of null and non-null strings and value types
let blank : string = null
let name = "Vera"
let number = Nullable 10

// Null maps to None
let blankAsOption = blank |> Option.ofObj

// Non-null maps to Some
let nameAsOption = name |> Option.ofObj

let numberAsOption = number |> Option.ofNullable

// Options can be mapped back to classes or Nullable types
let unsafeName = Some "Fred" |> Option.toObj
