/// Chapter 5  - Object Oriented Programming
/// Accesing Base Class Members - pg. 114

module ShapesWithDrawing

open System
open System.Drawing
open System.Windows.Forms


//  a class that inherits from `Form`
type MySquareForm(color) =
    inherit Form()
  
    // override the OnPaint method to draw on the form
    override x.OnPaint(e) =
        e.Graphics.DrawRectangle(color,
                                 10, 10,
                                 x.Width - 30,
                                 x.Height - 50)
        base.OnPaint(e)
    
    // override the OnResize method to respond to resizing
    override x.OnResize(e) =
        x.Invalidate()
        base.OnResize(e)

// create a new instance of the form
let mainForm = new MySquareForm(Pens.Blue)
