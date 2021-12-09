// Lesson 25  - Consuming C# From F#  - pg. 291

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
#r @"..\CSharpProject\bin\Debug\net6.0\CSharpProject.dll"
open CSharpProject

let charley = Person "Charley"
charley.PrinName()
