module Comments

// this is a single line comment

(* this is a commebnt *)

(* this
   is a
   comment
*)

/// This is a doc comment

/// <summary>
/// divides the given parameter by 10
/// </summayr>
/// <parame name="x"> the thing to be divided by 10</param>
let divTen x = x / 10

(*F#
printfn "His will be printed by an F# program"
F#*)

(*IF-OCAML*)
Format.printf "This will be printed by ans OCaml program"
(*ENDIF-OCAML*)
