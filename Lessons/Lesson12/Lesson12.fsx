/// Lesson 12  Organizing code without classes  - pg 138

/// 12.1 Using namespaces and modules - pg 139

///  12.1.1 Namespaces in F#
//  namespaces work essentially the same as in C#


/// 12.1.2 Modules in F#
// namespaces can't hold functions only types and modules
// modules can hold functions

// - Modules are like static classes in C#
// - Modules are like namespaces but can also hold functions


/// 12.1.3 Visualizing namespaces and modules - pg 140


/// 12.1.4 Opening modules - pg 142

open System
open System.IO


/// 12.2 Moving from scripts to applications  pg 143.

/// Now you try   pg 143
//  create MyFirstFSharpApp using dotnet command

// create a new solution.
//> dotnet new solution

// create a new project
//> dotnet new console -lang F# -o MyFirstFSharpApp

// add app to solution
//> dotnet sln add .\MyFirstFSharpApp\MyFirstFSharpApp.fsproj

// run the app
//> cd MyFirstFSharpApp
//> dotnet run


/// 12.3 Tips for working with modules and namespaces  - pg 147

// 12.3.1 Access modifiers
// types and functions are public by default, the can be marked privare

// 12.3.2 The global namespace
// If you don’t supply a parent namespace when declaring namespaces or modules, it’ll 
// appear in the global namespace, which is always open. Both Domain and Operations live in 
// the global namespace.

// 12.3.3 Automatic opening of modules
// Adding [<AutoOpen>] to a module automatically opens it when it's parent namespace or
// module is opened.

// 12.3.4 Scripts
// many of the rules are relaxed for scripts
// let bound functions can be defined in the top level, directly in the scritp.
// script file is an implicit module


/// Try this - pg 148
//  see Calculator.fs and scratchpad.fsx
