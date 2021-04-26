/// Chapter 4 - Imperative programms
/// Control Flow
/// pg. 77

open System

// if doesn't have to have and else if the expression has a unit return
if DateTime.Now.DayOfWeek = DayOfWeek.Sunday then
    printfn "Sunday Playlist: Lazy On A Sunday Afternoon - Queen"

// but you can have one.
if System.DateTime.Now.DayOfWeek = System.DayOfWeek.Monday then
    printfn "Monday Playlist: Blue Monday - New Order"
else
    printfn "Alt Playlist: Fell In Love With A Girl - White Stripes"

// multiple statements should be indented the same
if System.DateTime.Now.DayOfWeek = System.DayOfWeek.Friday then
    printfn "Friday Playlist: Friday I'm In Love - The Cure"
    printfn "Friday Playlist: View From The Afternoon - Arctic Monkeys"


// imperative for loops.  pg. 78

// and array for words
let words = [| "Red"; "Lorry"; "Yellow"; "Lorry" |]

// for loop to print each element of array.
for word in words do
    printfn "%s" word

 
// for range loop
// a Ryunosuke Akutagawa haiku array
let ryunosukeAkutagawa = [| "Green "; "frog,";
    "Is"; "your"; "body"; "also";
    "freshly"; "painted?" |]

// for loop over the array printing each element
for index = 0 to Array.length ryunosukeAkutagawa - 1 do
    printf "%s " ryunosukeAkutagawa.[index]


// downto loop.

// a Shuson Kato hiaku array (backwards)
let shusonKato = [| "watching."; "been"; "have";
    "children"; "three"; "my"; "realize"; "and";
    "ant"; "an"; "kill"; "I";
    |]

// loop over the array backwards printing each word
for index = Array.length shusonKato - 1 downto 0 do
    printf "%s " shusonKato.[index]

// range notation

// Count upwards:
for i in 0..10 do
    printfn "%i green bottles" i

// Count downwards:
for i in 10..-1..0 do
    printfn "%i green bottles" i

// Count upwards in tens
for i in 0..10..100 do
    printfn "%i green bottles" i



    // while loop  pg. 80

    // a Matsuo Basho hiaku in a mutable list
    let mutable matsuoBasho = [ "An"; "old"; "pond!";
        "A"; "frog"; "jumps"; "in-";
        "The"; "sound"; "of"; "water" ]
    
    while (List.length matsuoBasho > 0) do
        printf "%s " (List.head matsuoBasho)
        matsuoBasho <- List.tail matsuoBasho
