/// Chapter 5  - Object Oriented Programming
/// Records as objects
/// pg 94

#r "System.Drawing.dll"

open System.Drawing

// A Shape record that will act as out object:
type Shape =
    { Reposition: Point -> unit;
      Draw: unit -> unit  }

// Create a new instance of Shape:
let makeShape initPos draw =
    // currPos is the internal state of the object:
    let currPos = ref initPos
    { Reposition =
        // the Repostion member updates the internal state
        ( fun newPos -> currPos := newPos )
      Draw =
        // draw the shape passing the current postion
        // to given draw function
        ( fun () -> draw !currPos ) }    


// "draws" a shape, prints out the shapes name and position
let draw shape (pos: Point) =
    printfn "%s, with x = %i and y = %i"
        shape pos.X pos.Y

// creates a new circle shape
let circle initPos =
    makeShape initPos (draw "Circle")

// creates a new square shape
let square initPos =
    makeShape initPos (draw "Square")

// list of shapes in their intial postions
let shapes =
    [ circle (new Point (10, 10))
      square (new Point (30,30))]

// draw all the shapes
let drawShapes() =
    shapes |> List.iter (fun s -> s.Draw())


let main() =
    drawShapes()  // draw the shapes
    // over all the shapes
    shapes |> List.iter (fun s -> s.Reposition (new Point (40,40)))
    drawShapes()  // redraw the shapes

do main()

