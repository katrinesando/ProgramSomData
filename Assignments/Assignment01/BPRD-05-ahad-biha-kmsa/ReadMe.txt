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
See HigherFun.fs and Absyn.fs
What we changed is marked with comment 
//#region Exercise 6.2
//#endregion

--------------Exercise 6.3--------------
See FunPar.fsy and FunLex.fsl
The lines we changed are marked with comment //Exercise 6.3


--------------Exercise 6.4--------------
 

--------------Exercise 6.5--------------