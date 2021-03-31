// Application from the Try Me.

open System
open System.Net
open System.Windows.Forms

let createWebForm(url) =
    let getWebText() =
        let webClient = new WebClient()
        let fsharpOrg = webClient.DownloadString(Uri url)
        fsharpOrg

    let createBrowser =
        new WebBrowser(ScriptErrorsSuppressed = true,
                       Dock = DockStyle.Fill,
                       DocumentText = getWebText())
        
    let form = new Form(Text = "Hello from F#!")
    form.Controls.Add createBrowser
    form


[<EntryPoint>]
[<STAThread>]
let main argv =
    let form = createWebForm("http://fsharp.org")
    Application.Run(form)
    0 // return an integer exit code
