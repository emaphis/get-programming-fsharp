

// Now try me  - pg. 312

// Change this to where your packages folder is located!
#I @"C:\users\emaph\.nuget\packages\"

#r @"humanizer.core\2.13.14\lib\net6.0\Humanizer.dll"
#r @"newtonsoft.json\13.0.1\lib\net45\Newtonsoft.Json.dll"
#load "Library1.fs"


open Humanizer

"ScriptsAreAGreatWayToExplorePackages".Humanize()
// val it: string = "Scripts are a great way to explore packages"

"ScriptsAreAGreatWayToExplorePackages".Humanize(LetterCasing.AllCaps)
// val it: string = "SCRIPTS ARE A GREAT WAY TO EXPLORE PACKAGES"

Library1.getPerson()

