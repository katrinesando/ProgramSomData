Compiling and loading the micro-C evaluator and parser (MicroC/README.TXT)
--------------------------------------------------------------------------

Archive microc.zip contains the files used in points A, B and C below.


A. Generating and compiling the lexer and parser for micro-C, and
   loading the interpreter for micro-C.

   fslex --unicode CLex.fsl
   fsyacc --module CPar CPar.fsy
   dotnet fsi -r "C:\Users\sando\OneDrive\Dokumenter\1 Uni\5 semester\ProgrammerSomData\LexAndParse\FsLexYacc.Runtime.dll" Absyn.fs CPar.fs CLex.fs Parse.fs Interp.fs ParseAndRun.fs

   open ParseAndRun;;
   run (fromFile "exercise_8_6.c") [1];;
   
   
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

   run (fromFile "ex1.c") [17];;
        17 16 15 14 13 12 11 10 9 8 7 6 5 4 3 2 1 
        val it: Interp.store = map [(0, 0)]
   run (fromFile "ex5.c");;
        val it: (int list -> Interp.store) = <fun:Invoke@3624>
   run (fromFile "ex11.c") [8];;
        1 5 8 6 3 7 2 4 
        1 6 8 3 7 4 2 5
        1 7 4 6 8 2 5 3
        1 7 5 8 2 4 6 3
        2 4 6 8 3 1 7 5
        2 5 7 1 3 8 6 4 
        2 5 7 4 1 8 6 3
        2 6 1 7 4 8 3 5
        2 6 8 3 1 4 7 5
        2 7 3 6 8 5 1 4
        2 7 5 8 1 4 6 3 
        2 8 6 1 3 5 7 4
        3 1 7 5 8 2 4 6
        3 5 2 8 1 7 4 6
        3 5 2 8 6 4 7 1
        3 5 7 1 4 2 8 6
        3 5 8 4 1 7 2 6
        3 6 2 5 8 1 7 4 
        3 6 2 7 1 4 8 5
        3 6 2 7 5 1 8 4
        3 6 4 1 8 5 7 2
        3 6 4 2 8 5 7 1
        3 6 8 1 4 7 5 2
        3 6 8 1 5 7 2 4
        3 6 8 2 4 1 7 5
        3 7 2 8 5 1 4 6
        3 7 2 8 6 4 1 5
        3 8 4 7 1 6 2 5 
        4 1 5 8 2 7 3 6
        4 1 5 8 6 3 7 2
        4 2 5 8 6 1 3 7
        4 2 7 3 6 8 1 5
        4 2 7 3 6 8 5 1
        4 2 7 5 1 8 6 3
        4 2 8 5 7 1 3 6 
        4 2 8 6 1 3 5 7
        4 6 1 5 2 8 3 7
        4 6 8 2 7 1 3 5
        4 6 8 3 1 7 5 2
        4 7 1 8 5 2 6 3
        4 7 3 8 2 5 1 6
        4 7 5 2 6 1 3 8
        4 7 5 3 1 6 8 2 
        4 8 1 3 6 2 7 5
        4 8 1 5 7 2 6 3
        4 8 5 3 1 7 2 6
        5 1 4 6 8 2 7 3
        5 1 8 4 2 7 3 6
        5 1 8 6 3 7 2 4
        5 2 4 6 8 3 1 7
        5 2 4 7 3 8 6 1
        5 2 6 1 7 4 8 3 
        5 2 8 1 4 7 3 6
        5 3 1 6 8 2 4 7
        5 3 1 7 2 8 6 4
        5 3 8 4 7 1 6 2
        5 7 1 3 8 6 4 2
        5 7 1 4 2 8 6 3
        5 7 2 4 8 1 3 6 
        5 7 2 6 3 1 4 8
        5 7 2 6 3 1 8 4
        5 7 4 1 3 8 6 2
        5 8 4 1 3 6 2 7
        5 8 4 1 7 2 6 3
        6 1 5 2 8 3 7 4
        6 2 7 1 3 5 8 4 
        6 2 7 1 4 8 5 3
        6 3 1 7 5 8 2 4
        6 3 1 8 4 2 7 5
        6 3 1 8 5 2 4 7
        6 3 5 7 1 4 2 8
        6 3 5 8 1 4 2 7
        6 3 7 2 4 8 1 5
        6 3 7 2 8 5 1 4
        6 3 7 4 1 8 2 5 
        6 4 1 5 8 2 7 3
        6 4 2 8 5 7 1 3
        6 4 7 1 3 5 2 8
        6 4 7 1 8 2 5 3
        6 8 2 4 1 7 5 3
        7 1 3 8 6 4 2 5
        7 2 4 1 8 5 3 6 
        7 2 6 3 1 4 8 5
        7 3 1 6 8 5 2 4
        7 3 8 2 5 1 6 4
        7 4 2 5 8 1 3 6 
        7 4 2 8 6 1 3 5
        7 5 3 1 6 8 2 4
        8 2 4 1 7 5 3 6
        8 2 5 3 1 7 4 6
        8 3 1 6 2 5 7 4 
        8 4 1 3 6 2 7 5
        val it: Interp.store =
          map
            [(0, 8); (1, 0); (2, 9); (3, -999); (4, 0); (5, 0); (6, 0); (7, 0); (8, 0);
             ...]


B. To compile and use the micro-C compiler

   fslex --unicode CLex.fsl
   fsyacc --module CPar CPar.fsy
   fsharpi -r ~/fsharp/FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Comp.fs ParseAndComp.fs   

   dotnet fsi -r "C:\Users\sando\OneDrive\Dokumenter\1 Uni\5 semester\ProgrammerSomData\LexAndParse\FsLexYacc.Runtime.dll" Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Comp.fs ParseAndComp.fs


   open ParseAndComp;;
   compileToFile (fromFile "ex11.c") "ex11.out";;
        val it: Machine.instr list =
          [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; INCSP 1; INCSP 100;
           GETSP; CSTI 99; SUB; INCSP 100; GETSP; CSTI 99; SUB; INCSP 100; GETSP;
           CSTI 99; SUB; INCSP 100; GETSP; CSTI 99; SUB; GETBP; CSTI 2; ADD; CSTI 1;
           STI; INCSP -1; GOTO "L3"; Label "L2"; GETBP; CSTI 103; ADD; LDI; GETBP;
           CSTI 2; ADD; LDI; ADD; CSTI 0; STI; INCSP -1; GETBP; CSTI 2; ADD; GETBP;
           CSTI 2; ADD; LDI; CSTI 1; ADD; STI; INCSP -1; INCSP 0; Label "L3"; GETBP;
           CSTI 2; ADD; LDI; GETBP; CSTI 0; ADD; LDI; SWAP; LT; NOT; IFNZRO "L2";
           GETBP; CSTI 2; ADD; CSTI 1; STI; INCSP -1; GOTO "L5"; Label "L4"; GETBP;
           CSTI 204; ADD; LDI; GETBP; CSTI 2; ADD; LDI; ADD; GETBP; CSTI 305; ADD; LDI;
           GETBP; CSTI 2; ADD; LDI; ADD; CSTI 0; STI; STI; INCSP -1; GETBP; CSTI 2;
           ADD; ...]

   compile "ex11";;
        val it: Machine.instr list =
          [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; INCSP 1; INCSP 100;
           GETSP; CSTI 99; SUB; INCSP 100; GETSP; CSTI 99; SUB; INCSP 100; GETSP;
           CSTI 99; SUB; INCSP 100; GETSP; CSTI 99; SUB; GETBP; CSTI 2; ADD; CSTI 1;
           STI; INCSP -1; GOTO "L3"; Label "L2"; GETBP; CSTI 103; ADD; LDI; GETBP;
           CSTI 2; ADD; LDI; ADD; CSTI 0; STI; INCSP -1; GETBP; CSTI 2; ADD; GETBP;
           CSTI 2; ADD; LDI; CSTI 1; ADD; STI; INCSP -1; INCSP 0; Label "L3"; GETBP;
           CSTI 2; ADD; LDI; GETBP; CSTI 0; ADD; LDI; SWAP; LT; NOT; IFNZRO "L2";
           GETBP; CSTI 2; ADD; CSTI 1; STI; INCSP -1; GOTO "L5"; Label "L4"; GETBP;
           CSTI 204; ADD; LDI; GETBP; CSTI 2; ADD; LDI; ADD; GETBP; CSTI 305; ADD; LDI;
           GETBP; CSTI 2; ADD; LDI; ADD; CSTI 0; STI; STI; INCSP -1; GETBP; CSTI 2;
           ADD; ...] 
  
   #q;;

The Java stack machine:

   javac Machine.java
   java Machine ex11.out 8

The C stack machine
   gcc machine.c
   ./a.out ex11.out 8

C. To compile and use the backwards (continuation-based) micro-C compiler:

   fslex --unicode CLex.fsl
   fsyacc --module CPar CPar.fsy
   fsharpi -r ~/fsharp/FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Contcomp.fs ParseAndContcomp.fs   
   dotnet fsi -r "C:\Users\sando\OneDrive\Dokumenter\1 Uni\5 semester\ProgrammerSomData\LexAndParse\FsLexYacc.Runtime.dll" Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Contcomp.fs ParseAndContcomp.fs
   
   
   open ParseAndContcomp;;
   contCompileToFile (fromFile "ex11.c") "ex11.out";;
        val it: Machine.instr list =
          [LDARGS; CALL (1, "L1"); STOP; Label "L1"; INCSP 1; INCSP 1; INCSP 100;
           GETSP; CSTI 99; SUB; INCSP 100; GETSP; CSTI 99; SUB; INCSP 100; GETSP;
           CSTI 99; SUB; INCSP 100; GETSP; CSTI 99; SUB; GETBP; CSTI 2; ADD; CSTI 1;
           STI; INCSP -1; GOTO "L17"; Label "L16"; GETBP; CSTI 103; ADD; LDI; GETBP;
           CSTI 2; ADD; LDI; ADD; CSTI 0; STI; INCSP -1; GETBP; CSTI 2; ADD; GETBP;
           CSTI 2; ADD; LDI; CSTI 1; ADD; STI; INCSP -1; Label "L17"; GETBP; CSTI 2;
           ADD; LDI; GETBP; LDI; SWAP; LT; IFZERO "L16"; GETBP; CSTI 2; ADD; CSTI 1;
           STI; INCSP -1; GOTO "L15"; Label "L14"; GETBP; CSTI 204; ADD; LDI; GETBP;
           CSTI 2; ADD; LDI; ADD; GETBP; CSTI 305; ADD; LDI; GETBP; CSTI 2; ADD; LDI;
           ADD; CSTI 0; STI; STI; INCSP -1; GETBP; CSTI 2; ADD; GETBP; CSTI 2; ADD;
           LDI; ...]

   compile "ex11";;
   #q;;

   javac Machine.java
   java Machine ex11.out 8


D. Build the backwards micro-C compiler as a command-line program microcc

   fslex --unicode CLex.fsl
   fsyacc --module CPar CPar.fsy
   fsharpc --standalone -r ~/fsharp/FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Contcomp.fs MicroCC.fs -o microcc.exe

   mono microcc.exe ex11.c

   javac Machine.java
   java Machine ex11.out 8
