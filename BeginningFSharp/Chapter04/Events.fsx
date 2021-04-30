/// Chapter 4  - Imperative programming
/// Dot NET events
/// pg 85.


open System.Timers

let timedMessages() =
    // define the timer
    let timer = new Timer(Interval = 3000.0, Enabled = true)

    // a counter to hold the current message
    let mutable messageNo = 0

    // the message to be shown
    let messages = [ "bet"; "this"; "gets";
                     "really"; "annoying";
                     "very"; "quickly" ]

    // add an event to the timer
    timer.Elapsed.Add(fun _ ->
        // print a message
        printfn "%s" messages.[messageNo]
        messageNo <- messageNo + 1
        if messageNo = messages.Length then
            timer.Enabled <- false)

//timedMessages()


// using a delegate

open System.Timers

let timedMessagesViaDelegate() =
    // define the timer
    let timer = new Timer(Interval = 3000.0, Enabled = true)

    // a counter to hold the current message
    let mutable messageNo = 0

    // the message to be shown
    let messages = [ "bet"; "this"; "gets";
                     "really"; "annoying";
                     "very"; "quickly" ]

    // function to print a message
    let printMessage = fun _ _ ->
        // print a message
        printfn "%s" messages.[messageNo]
        messageNo <- (messageNo + 1) % messages.Length

    // wrap the function in a delegate
    let del = new ElapsedEventHandler(printMessage)

    // add the delegate to the timer
    timer.Elapsed.AddHandler(del) |> ignore

    // returns the time and the delegate so we can
    // remove one from the other later
    (timer, del)

// Run this first
let timer , del = timedMessagesViaDelegate()

// Run this timer
timer.Elapsed.RemoveHandler(del)
