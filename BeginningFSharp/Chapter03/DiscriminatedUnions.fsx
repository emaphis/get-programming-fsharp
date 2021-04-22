/// Chapter 3  - Functional Programming
/// DiscriminatedUnions.fsx
/// pg 49

type Volume =
    | Liter of float
    | UsPint of float
    | ImperialPint of float

let vol1 = Liter 2.5
let vol2 = UsPint 2.5
let vol3 = ImperialPint 2.5


// optional names for fields
type Shape =
    | Square of side:float
    | Rectangle of width:float * height:float
    | Circle of radius:float

let sq1 = Square 1.2
let sq2 = Square(side=1.2)
let rect2 = Rectangle (1.2, 3.4)
let rect3 = Rectangle(height=3.4, width=1.2)


// use pattern matching do decompose unions

/// functions to convert between volumes
let convertVolumeToLiter x =
    match x with
    | Liter x -> x
    | UsPint x -> x * 0.473
    | ImperialPint x -> x * 0.568

let convertVolumeUsPint x =
    match x with
    | Liter x -> x * 2.113
    | UsPint x -> x
    | ImperialPint x -> x * 1.201

let convertVolumeImperialPint x =
    match x with
    | Liter x -> x * 1.760
    | UsPint x -> x * 0.833
    | ImperialPint x -> x


/// a function to print a volume
let printVolumes x =
    printfn "Volume in liters         = %f" (convertVolumeToLiter x)
    printfn "       in us pints       = %f" (convertVolumeUsPint x)
    printfn "       in imperial pints = %f" (convertVolumeImperialPint x)

printVolumes vol1
printVolumes vol2
printVolumes vol3


/// Type definitions with type parameters
//  - two versions of type parameterization

// one
type 'a BinaryTree =
| BinaryNode of 'a BinaryTree * 'a BinaryTree
| BinaryValue of 'a

let tree1 =
    BinaryNode (
        BinaryNode (BinaryValue 1, BinaryValue 2),
        BinaryNode (BinaryValue 3, BinaryValue 4)  )

// two
type Tree<'a> =
| Node of Tree<'a> list
| Value of 'a

let tree2 =
    Node( [ Node ( [Value "one"; Value "two"] ) ;
        Node( [Value "three"; Value "four"] ) ] )

/// function to print the binary tree
let rec printBinaryTreeValues tree =
    match tree with
    | BinaryNode (node1, node2) ->
        printBinaryTreeValues node1
        printBinaryTreeValues node2
    | BinaryValue tree ->
        printf "%A " tree

printBinaryTreeValues tree1


/// function to print the tree
let rec printTreeValues tree =
    match tree with
    | Node lst -> List.iter printTreeValues lst
    | Value tree ->  printf "%A, " tree

printTreeValues tree2


