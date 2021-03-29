# Packet notes

<https://fsprojects.github.io/Paket/get-started.html#Install-the-Paket-bootstrapper-legacy>

See for an example: <https://github.com/cartermp/MinimalPaketAndFakeSample>

Using Packet from a FSI Interactive: <https://fsprojects.github.io/Paket/reference-from-repl.html>

## Getting started

* Install packet as a tool on the root of the codebase

>dotnet new tool-manifest
>dotnet tool install packet
>dotnet tool restore

Notes:

You can invoke the tool from this directory using the following commands: 

>'dotnet tool run paket' or 'dotnet paket'.

Tool 'paket' (version '5.257.0') was successfully installed. 

Entry is added to the manifest file c:\src\FSharp\get-programming-fsharp\.config\dotnet-tools.json.

* In a new project - Initialize packet by creating a dependency file.

>dotnet packet init

* If you have a build.sh/build.cmd build script, also make sure you add the last two commands before you execute your build:

>dotnet tool restore
>dotnet paket restore
-- Your call to build comes after the restore calls, possibly with FAKE: <https://fake.build/>

* Make sure to add the following entries to your `.gitignore`:

``` config
#Paket dependency manager
.paket/
paket-files/
```

## Using Packet

* Core concepts

-important files

-paket.dependencies, where you specify your dependencies and their versions for your entire codebase.

-paket.references, a file that specifies a subset of your dependencies for every project in a solution.

-paket.lock, a lock file that Paket generates when it runs. When you check it into source control, you get reproducible builds.

* important commands

-paket install - Run this after adding or removing packages from the paket.dependencies file. It will update any affected parts of the lock file that were affected by the changes in the paket.dependencies file, and then refresh all projects in your codebase that specify paket dependencies to import references.

-paket update - Run this to update your codebase to the latest versions of all dependent packages. It will update the paket.lock file to reference the most recent versions permitted by the restrictions in paket.dependencies, then apply these changes to all projects in your codebase.

-paket restore - Run this after cloning the repository or switching branches. It will take the current paket.lock file and update all projects in your codebase so that they are referencing the correct versions of NuGet packages. It should be called by your build script in your codebase, so you should not need to run it manually.
