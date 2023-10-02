--------------Exercise 5.1--------------


--------------Exercise 5.7--------------


--------------Exercise 6.1--------------
let add x = let f y = x+y in f end
in add 2 5 end

run(fromString @"let add x = let f y = x+y in f end
                 in add 2 5 end");;
     val it: HigherFun.value = Int 7



run (fromString @"let add x = let f y = x+y in f end
                    in let addtwo = add 2
                        in addtwo 5 end
                    end");;
    val it: HigherFun.value = Int 7

run (fromString "let add x = let f y = x+y in f end
                    in let addtwo = add 2
                        in let x = 77 in addtwo 5 end
                        end
                    end");;
    val it: HigherFun.value = Int 7
- Because closures the first x is already filled out in addtwo and there it just takes 5+2 and disregards the 77


run (fromString @"let add x = let f y = x+y in f end
                in add 2 end");;
val it: HigherFun.value =
  Closure
    ("f", "y", Prim ("+", Var "x", Var "y"),
     [("x", Int 2);
      ("add",
       Closure
         ("add", "x", Letfun ("f", "y", Prim ("+", Var "x", Var "y"), Var "f"),
          []))])

Closures are needed it doesn't enclose the value of f’s free variable x.

--------------Exercise 6.2--------------
See HigherFun.fs.
What we changed is marked with comment 
//#region Exercise 6.2
//#endregion

--------------Exercise 6.3--------------
See FunPar.fsy and FunLex.fsl
The lines we changed are marked with comment //Exercise 6.3


--------------Exercise 6.4--------------
 

--------------Exercise 6.5--------------
(1) 
let f x = 1
in f f end
inferType (fromString "let f x = 1 in f f end");;
val it: string = "int"

let f g = g g
in f end
inferType (fromString "let f g = g g in f end");;
System.Exception: type error: circularity
....
Stopped due to error
parameters are not polymorphic inside the body of a function

let f x =
    let g y = y
    in g false end
in f 42 end
inferType (fromString "let f x = let g y = y in g false end in f 42 end");;
val it: string = "bool"

let f x =
    let g y = if true then y else x
    in g false end
in f 42 end
inferType (fromString "let f x = let g y = if true then y else x in g false end in f 42 end");;
System.Exception: type error: bool and int
Stopped due to error
Since all branches in an if-then-else expression must return 
expressions of the same type, y is forced to be of the same type as x. 
However, f is passed 42 and g is passed false 

let f x =
    let g y = if true then y else x
    in g false end
in f true end
inferType (fromString "let f x = let g y = if true then y else x in g false end in f true end");;
val it: string = "bool"

(2)
bool -> bool 
inferType (fromString "let f a = if a then true else false in f end");;
val it: string = "(bool -> bool)"

int -> int
inferType (fromString "let f x = x + 3 in f end");;
val it: string = "(int -> int)"

int -> int -> int
inferType (fromString "let f x = let g y = x + y in g end in f end");;
val it: string = "(int -> (int -> int))"

’a -> ’b -> ’a
inferType (fromString "let f x = let g y = x in g end in f end");;
val it: string = "('h -> ('g -> 'h))"

’a -> ’b -> ’b
inferType (fromString "let f x = let g y = y in g end in f end");;
val it: string = "('g -> ('h -> 'h))"

(’a -> ’b) -> (’b -> ’c) -> (’a -> ’c)


’a -> ’b
inferType (fromString "let f x = f x in f end ");;
val it: string = "('e -> 'f)"

'a
