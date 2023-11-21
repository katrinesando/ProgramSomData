(* File Cont/Icon.fs 

   Abstract syntax and interpreter for micro-Icon, a language where an 
   expression can produce more than one result.  

   sestoft@itu.dk * 2010-05-18

   ---

   For a description of micro-Icon, see Chapter 11: Continuations, in
   Programming Language Concepts for Software Developers.

   As described there, the interpreter (eval e cont econt) has two
   continuations:

      * a success continuation cont, that is called on the result v of
        the expression e, in case it has one;

      * a failure continuation econt, that is called on () in case the
        expression e has no result.
 *)

//module Icon

(* Micro-Icon abstract syntax *)

type expr = 
  | CstI of int
  | CstS of string
  | FromTo of int * int
  | Write of expr
  | If of expr * expr * expr
  | Prim of string * expr * expr 
  | Prim1 of string * expr //Exercise 11.8(iii)
  | And of expr * expr
  | Or  of expr * expr
  | Seq of expr * expr
  | Every of expr 
  | Fail;;

(* Runtime values and runtime continuations *)

type value = 
  | Int of int
  | Str of string;;

type econt = unit -> value;;

type cont = value -> econt -> value;;

(* Print to console *)

let write v =
    match v with 
    | Int i -> printf "%d " i
    | Str s -> printf "%s " s;;

(* Expression evaluation with backtracking *)

let rec eval (e : expr) (cont : cont) (econt : econt) = 
    match e with
    | CstI i -> cont (Int i) econt
    | CstS s  -> cont (Str s) econt
    | FromTo(i1, i2) -> 
      let rec loop i = 
          if i <= i2 then 
              cont (Int i) (fun () -> loop (i+1))
          else 
              econt ()
      loop i1
    | Write e -> 
      eval e (fun v -> fun econt1 -> (write v; cont v econt1)) econt
    | If(e1, e2, e3) -> 
      eval e1 (fun _ -> fun _ -> eval e2 cont econt)
              (fun () -> eval e3 cont econt)
    | Prim(ope, e1, e2) -> 
      eval e1 (fun v1 -> fun econt1 ->
          eval e2 (fun v2 -> fun econt2 -> 
              match (ope, v1, v2) with
              | ("+", Int i1, Int i2) -> 
                  cont (Int(i1+i2)) econt2 
              | ("*", Int i1, Int i2) -> 
                  cont (Int(i1*i2)) econt2
              | ("<", Int i1, Int i2) -> 
                  if i1<i2 then 
                      cont (Int i2) econt2
                  else
                      econt2 ()
              | _ -> Str "unknown prim2")
              econt1)
          econt
//Start - Exercise 11.8 (iii)
    | Prim1 (ope, e) ->
        eval e (fun v1 -> fun econt1 ->
            match (ope, v1) with
            | "square", Int i1 ->
                cont (Int(i1*i1)) econt1
            | "even", Int i1 ->
                if i1%2 = 0 then
                    cont (Int i1) econt1
                else
                    econt1()
             //Start - Exercise 11.8 (iv)
            | "multiples", Int i1 ->
                let rec infinite res = //infinite loop to produce multiples
                    if i1 = res then
                        cont (Int i1) (fun () -> infinite (res+i1)) //handles first case to make sure it gets written
                    else
                        cont (Int (res+i1)) (fun () -> infinite (res+i1))
                infinite i1
             //End - Exercise 11.8 (iv)
            ) econt
//End - Exercise 11.8 (iii)
    | And(e1, e2) -> 
      eval e1 (fun _ -> fun econt1 -> eval e2 cont econt1) econt
    | Or(e1, e2) -> 
      eval e1 cont (fun () -> eval e2 cont econt)
    | Seq(e1, e2) -> 
      eval e1 (fun _ -> fun econt1 -> eval e2 cont econt)
              (fun () -> eval e2 cont econt)
    | Every e -> 
      eval e (fun _ -> fun econt1 -> econt1 ())
             (fun () -> cont (Int 0) econt)
    | Fail -> econt ()

let run e = eval e (fun v -> fun _ -> v) (fun () -> (printfn "Failed"; Int 0));


(* Examples in abstract syntax *)

// (write(1 to 3)) ; fail
let ex1 = Seq(Write (FromTo(1, 3)), Fail);

// (write(1 to 3)) & fail
let ex2 = And(Write (FromTo(1, 3)), Fail);

// (write((1 to 3) & (4 to 6))) & fail
let ex3and = And(Write(And(FromTo(1, 3), FromTo(4, 6))), Fail);

// (write((1 to 3) | (4 to 6))) & fail
let ex3or  = And(Write(Or(FromTo(1, 3), FromTo(4, 6))), Fail);

// (write((1 to 3) ; (4 to 6))) & fail
let ex3seq = And(Write(Seq(FromTo(1, 3), FromTo(4, 6))), Fail);

// write((1 to 3) & ((4 to 6) & "found"))
let ex4 = Write(And(FromTo(1, 3), And(FromTo(4, 6), CstS "found")));

// every(write(1 to 3))
let ex5 = Every (Write (FromTo(1, 3)));

// (every(write(1 to 3)) & (4 to 6))
let ex6 = And(Every (Write (FromTo(1, 3))), FromTo(4, 6));

// every(write((1 to 3) + (4 to 6)))
let ex7 = Every(Write(Prim("+", FromTo(1,3), FromTo(4, 6))));

// write(4 < (1 to 10))
let ex8 = Write(Prim("<", CstI 4, FromTo(1, 10)));

// every(write(4 < (1 to 10)))
let ex9 = Every(Write(Prim("<", CstI 4, FromTo(1, 10))));

//Exercise 11.8 (i)
let ex11_8i = (Seq(Seq(Write(CstI 3), Write(CstI 5)),Seq(Write(CstI 7), Write(CstI 9))));;
//3 5 7 9 val it: value = 9

let ex11_8i1 = (Every(Write(Prim("+",Prim("*",FromTo(1,4),CstI 2),CstI 1))))
//3 5 7 9 val it: value = Int 0

let ex11_8i2_2 = (Seq(Seq(Write(CstI 21),Write(CstI 22)),(Seq(Seq(Write(CstI 31), Write(CstI 32)),Seq(Write(CstI 41), Write(CstI 42))))));;
//21 22 31 32 41 42 val it: value = Int 42

//11.8 ii
let over50 = Write(Prim("<",CstI 50, Prim("*",CstI 7, FromTo(1,10))))
(*
run over50;;
56 val it: value = Int 56
*)

//11.8 iii
let exsqrt = Every(Write (Prim1("square", FromTo(3,6))));
let exeven= Every(Write (Prim1("even", FromTo(1,7))))
//11.8 iv
let exmulti = Every(Write (Prim1("multiples", FromTo(3,4))))


