// Lesson 26  - Working with Nuget Packages  - pg. 310


////////////////////////////////
// 26.1  Using NugGet with F#

// 26.1.1 Working with NuGet with F# projects

// Now you try  - pg. 311
(*
You’re going to download a NuGet package from the main public NuGet server and use 
it within an F# class library:

1 Create a new F# class library in Visual Studio called NugetFSharp.

2 Using the standard Manage NuGet Packages dialog box, add the Newtonsoft 
. Json package to the project.

3 You’ll see that the package is downloaded and added as a reference, as in your 
  C# project. You can now use it directly from your F# source files. 

4 Change the contents of the Library1.fs file to the following code.
*)

// 26.1.2 Experimenting with scripts

// Now you try  - pg. 312
(*
Next you’ll add another NuGet package to your project, and work with both this and
Newtonsoft.Json from within a script:

1 Add the Humanizer NuGet package to the project. This package can take arbitrary strings and try to make them more human-readable.

2 Open Script1.fsx, which was already added to the project on creation.

3 Reference the Humanizer assembly in your script by using the #r directive you
  saw earlier in this unit. The simplest option is to open the References node in
  Solution Explorer, shown in figure 26.1, get properties of the Humanizer DLL,
  copy the entire path into the clipboard, and then enter the following code

4 Execute the code; the output in FSI should be Scripts are a great way to explore
  packages.

5 Explore the overloads of the Humanize method in the REPL (for example, one
  takes in a LetterCasing argument)
*)


// 26.2 Working with Paket  - pg. 316

// 26.2.1 Issues with the NuGet client

// 26.2.2 Benefits of Paket  - pg. 317






