/// Chapter 5  - Opject Oriented Programming
/// Object Expressions
/// Pg 101

module ObjectExpressions

open System
open System.Drawing
open System.Windows.Forms


/// create a new instace of a number control
let makeNumberControl (n: int) =
    { new TextBox(Tag = n, Width = 32, Height = 16, Text = n.ToString())
        // implement the IComparable interface so the cntrols
        // can be compared
        interface IComparable with
            member x.CompareTo(other) =
                let otherControl = other :?> Control in
                let n1 = otherControl.Tag :?> int in
                n.CompareTo(n1) }


// a sorted array of the numbered controls
let numbers =
    // initialize the collection
    let temp = new ResizeArray<Control>()
    let rand = new Random()
    
    // add the controls collection
    for index = 1 to 10 do
        temp.Add(makeNumberControl(rand.Next(100)))
    
    // sort the collection
    temp.Sort()
    
    // layout the controls correctly
    let height = ref 0
    temp |> Seq.iter
        (fun c ->
            c.Top <- !height
            height := c.Height + !height )
    
    // return collection as an array
    temp.ToArray()

// create a form to show the number controls
let mainForm =
    let temp = new Form() in
    temp.Controls.AddRange(numbers)
    temp
