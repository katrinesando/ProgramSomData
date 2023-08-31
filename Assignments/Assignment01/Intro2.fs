(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)

module Intro2

(* Association lists map object language variables to their values *)

let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)];;

let emptyenv = []; (* the empty environment *)

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

let cvalue = lookup env "c";;


(* Object language expressions with variables *)

type expr = 
  | CstI of int
  | Var of string
  | Prim of string * expr * expr
  | If of expr* expr* expr;;

let e1 = CstI 17;;

let e2 = Prim("+", CstI 3, Var "a");;

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a");;

let e4 = If(Var "a", CstI 11, CstI 22);;
(* Evaluation within an environment *)

let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x
    | If(e1,e2,e3)      -> if (eval e1 env) <> 0 then (eval e2 env) else (eval e3 env)
    | Prim(ope, e1, e2) -> //eval e1 env + eval e2 env
            let i1 = eval e1 env
            let i2 = eval e2 env
            match ope with
            |"+"    -> i1 + i2
            |"*"    -> i1*i2
            |"-"    -> i1 - i2
            |"max"  -> if i1 > i2 then i1 else i2
            |"min"  -> if i1 < i2 then i1 else i2
            |"=="   -> if i1 = i2 then 1 else 0
    (*Udkommenteret kode til opgaven*)
    // | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    // | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    // | Prim("max", e1, e2) -> if (eval e1 env) > (eval e2 env) then (eval e1 env) else (eval e2 env)
    // | Prim("min", e1, e2) -> if (eval e1 env) < (eval e2 env) then (eval e1 env) else (eval e2 env)
    // | Prim("==", e1, e2) -> if (eval e1 env) = (eval e2 env) then 1 else 0
    // | Prim _            -> failwith "unknown primitive";;

(*ii*)
let e1v  = eval e1 env;;
let e2v1 = eval e2 env;;
let e2v2 = eval e2 [("a", 314)];;
let e3v  = eval e3 env;;

let e4v = eval e4 env;;

(*Exercise 1.2*)
type aExp =
    | CstI of int
    | Var of string 
    | Add of aExp * aExp
    | Sub of aExp * aExp
    | Mul of aExp * aExp

let ae1 = Sub(Var "v", Add(Var "w",Var "z"))

let ae2 = Mul(CstI 2, Sub(Var "v", Add(Var "w",Var "z")))

let ae3 = Add(Var "v", Add(Var "z", Add(Var "y", Var "x")))

let rec fmt (expr : aExp) : string = 
    match expr with 
    | CstI i -> string i 
    | Var str -> str
    | Add (ae1, ae2) -> 
        let res1 = fmt ae1 
        let res2 = fmt ae2
        sprintf "(%s + %s)" res1 res2
    | Sub (ae1, ae2) -> 
        let res1 = fmt ae1 
        let res2 = fmt ae2
        sprintf "(%s - %s)" res1 res2
    | Mul (ae1, ae2) -> 
        let res1 = fmt ae1 
        let res2 = fmt ae2
        sprintf "(%s * %s)" res1 res2

let rec simplify (expr : aExp) : aExp =
    match expr with 
    | CstI i -> expr
    | Var str -> expr
    | Add(ae1, ae2) ->
        match ae1, ae2 with 
        | CstI 0, _ -> simplify ae2
        | _, CstI 0 -> simplify ae1
        | _,_ -> Add(simplify ae1, simplify ae2)
    | Sub(ae1, ae2) ->
        match ae1, ae2 with 
        | _, CstI 0 -> simplify ae1
        | _,_ when ae1 = ae2 -> CstI 0
        | _,_ -> Sub(simplify ae1, simplify ae2)
    | Mul(ae1, ae2) -> 
        match ae1, ae2 with
        | CstI 1, _ -> simplify ae2
        | _, CstI 1 -> simplify ae1
        | CstI 0, _ -> CstI 0
        | _, CstI 0 -> CstI 0
        | _,_ -> Mul(simplify ae1, simplify ae2)
