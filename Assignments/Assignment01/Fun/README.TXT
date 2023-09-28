Compiling and loading the micro-ML evaluator and parser (Fun/README.TXT)
------------------------------------------------------------------------

A. Loading the micro-ML evaluator, with abstract syntax only

   fsharpi Absyn.fs Fun.fs

   open Absyn;;
   open Fun;;
   let res = run (Prim("+", CstI 5, CstI 7));;
   #q;;


B. Generating and compiling the lexer and parser, and loading them:

   fsyacc --module FunPar FunPar.fsy
   fslex --unicode FunLex.fsl
   fsharpi -r ~/fsharp/FsLexYacc.Runtime.dll Absyn.fs FunPar.fs FunLex.fs Parse.fs   

   open Parse;;
   let e1 = fromString "5+7";;
   let e2 = fromString "let y = 7 in y + 2 end";;
   let e3 = fromString "let f x = x + 7 in f 2 end";;


C. Using the lexer, parser and first-order evaluator together:

   fsyacc --module FunPar FunPar.fsy
   fslex --unicode FunLex.fsl
   fsharpi -r ~/fsharp/FsLexYacc.Runtime.dll Absyn.fs FunPar.fs FunLex.fs Parse.fs Fun.fs ParseAndRun.fs

   open ParseAndRun;;
   run (fromString "5+7");;
   run (fromString "let y = 7 in y + 2 end");;
   run (fromString "let f x = x + 7 in f 2 end");;
   
   run (fromString "let sum n = if n=1 then 1 else n+(sum (n-1)) in sum 1000 end");;
   run (fromString "let pow x = if x = 0 then 1 else 3*(pow (x-1)) in pow 8 end");;
   run (fromString "let sumPow x = if x = 0 then 1 else (let pow exp = if exp = 0 then 1 else 3*(pow (exp-1)) in pow x end) + (sumPow (x-1))  in sumPow 11 end");;
   run (fromString "let sumPow x = if x = 0 then 0 else (x*x*x*x*x*x*x*x) + (sumPow (x-1))  in sumPow 10 end");;
   


