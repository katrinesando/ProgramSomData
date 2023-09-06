module Assignment01.twoOneTest

type expr = 
  | CstI of int
  | Var of string
  | Let of (string * expr) list * expr
  | Prim of string * expr * expr;;

let rec mem x vs = 
    match vs with
    | []      -> false
    | v :: vr -> x=v || mem x vr;;
    
    
let rec union (xs, ys) = 
    match xs with 
    | []    -> ys
    | x::xr -> if mem x ys then union(xr, ys)
               else x :: union(xr, ys);;

(* minus xs ys  is the set of all elements in xs but not in ys *)

let rec minus (xs, ys) = 
    match xs with 
    | []    -> []
    | x::xr -> if mem x ys then minus(xr, ys)
               else x :: minus (xr, ys);;

(* Find all variables that occur free in expression e *)

let rec freevars e : string list =
    match e with
    | CstI i -> []
    | Var x  -> [x]
    | Let(erhs, ebody) ->
          let free = List.fold(fun acc (name, ex) -> union(freevars ex, acc)) [] erhs //Fold over the list and union with acc
          let assign = List.fold(fun acc (name, _) -> name::acc) [] erhs //Fold over the list and union with acc

          union (free, minus (freevars ebody, assign))
           
          // List.fold(fun acc (_, ex) -> union(freevars ex, acc)) [] erhs //Fold over the list and union with acc
          //
          // // union (freevars erhs, minus (freevars ebody, [x]))
          //
          
    | Prim(ope, e1, e2) -> union (freevars e1, freevars e2);;

let testExp = Let([("x1", Prim("+",Var "x1", CstI 7))],Prim("+",Var "x1", CstI 8));;
let e1 = Let([("z", CstI 17)], Prim("+", Var "z", Var "z"));;
