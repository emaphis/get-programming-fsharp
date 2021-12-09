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
  C# project. You can now use it directly from your F# source files.ds

4 Change the contents of the Library1.fs file to the following code.
*)

// 26.1.2 Experimenting with scripts

// Now you try  - pg. 312
(*
Next you’ll add another NuGet package to your project, and work with both this and
Newtonsoft.Json from within a script:

1 Add the Humanizer NuGet package to the project. This package can take arbitrary strings and try to make them more human-readable

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

// Now you try  - 318
(*
In this exercise, you’ll convert your existing package from NuGet to Paket:

1 In the existing solution, add the WindowsAzure.Storage NuGet package.

2 Open the packages.config file. Observe that it has approximately 50 NuGet packages. Which package is dependent on which? Why are you seeing 50 packages
  when you asked for only three (Humanizer, Newtonsoft.Json, and WindowsAzure.Storage)?

3 Navigate to the latest Paket release and download the Paket.exe application
  (https://github.com/fsprojects/Paket/releases/latest) to the root folder (alongside
  the solution file).

4 Delete the entire packages folder.

5 Open a command prompt and navigate to the root folder of the solution.

6 Run paket convert-from-nuget. Paket converts the solution from NuGet tooling to
  Paket. Observe the following:
a All packages are downloaded in the packages folder but without version numbers. Paket doesn’t include version numbers in paths. This makes referencing
NuGet packages much easier from F# scripts!
b Two new files have been created: paket.dependencies and paket.lock. The former file contains a list of all top-level dependencies and is designed to be
human readable and editable; the latter contains the tree of interdependencies.
c Your project is updated so all NuGet packages reference the new (version-free)
paths.
7 Run paket simplify. This parses the dependencies and strips out any packages
from the paket.dependencies file that aren’t top-level ones. Observe that the
dependencies file contains only two dependencies: Humanizer and WindowsAzure.Storage (Json is a dependency of WindowsAzure.Storage). The lock file
still maintains the full tree of dependencies.
Working with Paket 319
8 You can now open Script1.fsx; observe that the references are currently broken.
Rebuilding the solution regenerates the references script to point to the correct
locations. Notice that the paths no longer have the version numbers in them. In
the future, updating NuGet dependencies in Paket won’t break scripts that reference assemblies simply because the version changed.
*)





