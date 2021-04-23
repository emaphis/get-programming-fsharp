/// Chapter 5  - Functional Programming
/// Lazy Evaluation
/// pg 62

// ;azy evaluation
let lazyValue = lazy ( 2 + 2 )
let actualValue = lazyValue.Force()

printfn "%i" actualValue


// lazy side effects
let lazySideEffect =
    lazy (
        let temp = 2 + 2
        printfn "Evaluate: %i" temp
        temp
    )

printfn "Force value the first time: "
let actualValue2  = lazySideEffect.Force()
printfn "Forced value the second time: "
let actualValue3 = lazySideEffect.Force()
printfn "%i" actualValue3



// lazy datastructures

/// the lazy list definition
let lazyList =
    Seq.unfold (fun x ->
                    if x < 13 then
                        // is smaller than the linit return
                        // the current and next value
                        Some(x, x + 1)
                    else
                        // if great than the linit
                        // terminge the sequence
                        None )
                10

// print the list
printfn "%A" lazyList


// nonterminating lazy Fibonacci number list
let fibs =
    Seq.unfold
        (fun (n0, n1) ->
            Some(n0, (n1, n0 + n1)) )
        (1I, 1I)

// take the first 20 fibonacci's
let first20 = Seq.take 20 fibs

printfn "%A" first20
