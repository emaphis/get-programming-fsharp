# dot net and F# project notes

- dotnet -version

## project commands

- mkdir DNCdemo

- cd DNCdemo

- dotnet new sln  // new solution

- dotnet new library -lang f# -o FSLib

- dotnet new xunit -lang F# -o FSTest

- dotnet sln add FSLib\FSLib.fsproj

- dotnet sln add FSTest\FSTest.fsproj

- cd FSTest

- dotnet add reference ..\FSLib\FSLib.fsproj

- dotnet build  // test if everything is right

- dotnet test   // to run test project

## project commands - part 2

- dotnet new sln -o FSNetCore

- cd FSNetCore

- // Writing a Class library

- dotnet new lib -lang F# -o src\library

- dotnet sln add src\Library\Library.fsproj

- dotnet add src\Library\Library.fsproj package Newtonsoft.Json

- // Writing a Console App to use the library

- dotnet new console -lang F# -o src\App

- // Add App to sln

- dotnet sln add src/App/App.fsproj

- // Add a reference to the App

- dotnet add src\App\App.fsproj reference src\Library\Library.fsproj

- Running the App

- cd src\App

- dotnet run Hello World
