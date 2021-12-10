// Lesson 27  - Exposing F# Types and Functions to C#  - pg. 321


////////////////////////////////////
// 27.1 Using F# types in C#  pg. 322


// 27.1.1 Records
// Appear as regulat classes

// Now you try
(*
Now you try
Let’s see how to create a mixed solution, which you’ll use to create a number of F#
types and explore how they render in C#:

1 Create a new solution in Visual Studio, Interop.

2 Create an F# class library, FSharpCode.

3 Create a C# console application, CSharpApp.

4 Reference the FSharpCode project from the CSharpApp project so that
  you can access the F# types from the C# project, as shown in figure 27.1.

5 Open Library1.fs, remove the sample class definition, and rebuild the solution.

6 In Library1.fs, create a simple record type to model a car, taking care to change
  the namespace as shown in the following listing

7 Now that you’ve created the type, go to Program.cs and within the Main()
  method, try typing Model to get IntelliSense for the namespace. You’ll see that
  nothing appears! This is because C# and F# projects can (currently) see changes
  in code only after you’ve compiled the child project—in this case, the F# project.

8 Go ahead and rebuild the solution. You’ll see that you can now create an instance
  of the F# record type, although it appears as a class to C#, as shown in figure 27.2.

9 Notice that you can access getter-only properties on the car that map to the fields.
  Also observe that the triple-slash comments show in tooltips.
  10 Try to use Go To Definition (F12) from the C# project when the caret is over the
  Car type. Observe that a C# rendering of the F# type, based on its IL metadata, is
  shown. Also notice the interfaces that are implemented for structural equality
  (for example, IEquatable<T> and IComparable<T>), as well as override Equals and Get
  HashCode.
*)


// 27.1.2 Tuples  - pg. 323

// 27.1.3 Discriminated unions  - pg. 224

// Now you try
(*
Let’s see how to enhance your solution to illustrate tuples and discriminated unions:

1 Update Library1.fs as follows.

2 Rebuild the F# project, and then correct the C# to create a Car. You need to pass in
  a Tuple<Float, Float> for the new argument—for example, Tuple.Create(1.5, 3.5).

3 Notice that if you access the Dimensions property on the car, you’ll get Item1 and
  Item2 for X and Y.
  Let’s now look at discriminated unions. You created a discriminated union in listing 27.2 that has two cases: Motorcar and Motorbike.

4 In IntelliSense, navigating to Model.Vehicle is shown in figure 27.3.

5 Create an instance of a Motorbike.

6 The type of value returned will be Vehicle—not Motorbike! In order to test which 
  type the variable is, you need to use the IsMotorbike and IsMotorcar properties on
  the vehicle instance, and then cast it as appropriate. Only then will you be able to
  access the properties on the Motorbike itself
*)


//////////////////////////////
// 27.2  More on F# interoperability  - pg. 326


// 27.2.1 Using namespaces and modules

// F# namespaces the same as C# namespaces

// F# modules are similar to C# static classes


// 27.2.2 Using F# functions in C#  - pg. 327

// Now you try
(*
Next, experiment with F# functions firsthand to see how they render in C#:

1 Enter the following code at the bottom of Library1.fs

2 Rebuild the F# project.

3 Call the Model.Functions.CreateCar function from C#. It appears as a normal static
  method.

4 Call the Model.Functions.CreateFourWheeledCar function from C#. It appears as a property of type FSharpFunc, which has an Invoke method on it that takes in a single 
  argument. (You need to add a reference to FSharp.Core to see this. Take the newest 
  one you can find, which is 4.4.0.0 at the time of writing.)

5 Observe that calling Invoke will return another propety with another Invoke
  method! Each call relates to one constructor argument (except the first, which has 
  been supplied in the F# code already!).

*)





