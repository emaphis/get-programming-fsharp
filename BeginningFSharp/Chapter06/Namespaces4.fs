/// Chapter 6  - Organizing Programms
/// Namespaces - pg.128

module Namepspaces4

// call a method using it's full name:
System.Console.WriteLine("Hello world")

// Open a namespaces and call a method
// usint its short name

open System
Console.WriteLine("Hello world")

// Open a namsepace to a certain level
open System.Collections

// call a method using the rest of the namespace
let wordCountDict =
    new Generic.Dictionary<string, int>()
