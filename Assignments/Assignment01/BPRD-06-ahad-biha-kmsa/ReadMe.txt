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

Intepreter:
   run (fromFile "ex1.c") [17];;
        17 16 15 14 13 12 11 10 9 8 7 6 5 4 3 2 1 
        val it: Interp.store = map [(0, 0)]
   run (fromFile "ex11.c") [5];;
        1 3 5 2 4 
        1 4 2 5 3 
        2 4 1 3 5 
        2 5 3 1 4 
        3 1 4 2 5
        3 5 2 4 1
        4 1 3 5 2
        4 2 5 3 1 
        5 2 4 1 3
        5 3 1 4 2
        val it: Interp.store =
          map
            [(0, 5); (1, 0); (2, 6); (3, -999); (4, 0); (5, 0); (6, 0); (7, 0); (8, 0);
             ...]
             
--------------Exercise 7.2--------------
For all of the different sub-exercises see
exercise_7_2_i.c
exercise_7_2_ii.c
exercise_7_2_iii.c

--------------Exercise 7.3--------------
See CLex.fs, CPar.fsy, Interp.fs and Absyn.fs
All changes are marked with //Exercise 7.3 or /* exercise 7.3 */

For Micro-C exercise see:
exercise_7_3_i.c
exercise_7_3_ii.c
exercise_7_3_iii.c

--------------Exercise 7.4--------------
 See Absyn.fs and Interp.fs
 All changes are marked with either //Exercise 7.4 or
 //start exercise 7.4
    [code]
//end exercise 7.4

--------------Exercise 7.5--------------
See CPar.fsy 
All changes are marked with /* Exercise 7.5 */
