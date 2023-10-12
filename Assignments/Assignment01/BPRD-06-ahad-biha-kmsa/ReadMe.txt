--------------Exercise 7.1--------------
   fromFile "ex1.c";;
        val it: Absyn.program =
          Prog
            [Fundec 
               (None, "main", [(TypI, "n")],
                Block
                  [Stmt
                     (While
                        (Prim2 (">", Access (AccVar "n"), CstI 0),
                         Block
                           [Stmt (Expr (Prim1 ("printi", Access (AccVar "n"))));
                            Stmt
                              (Expr
                                 (Assign
                                    (AccVar "n",
                                     Prim2 ("-", Access (AccVar "n"), CstI 1))))]));
                   Stmt (Expr (Prim1 ("printc", CstI 10)))])]
                   
declarations: There is only 1 declaration(FunDec)
statements: There is 3 statement (while, print, println - stmt)
types: There is only 1 type (TypI)
expressions: There is 11 expressions(Prim1, Prim2, Access, AccVar, Assign, CstI)

--------------Exercise 7.2--------------


--------------Exercise 7.3--------------


--------------Exercise 7.4--------------
 

--------------Exercise 7.5--------------

