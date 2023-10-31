--------------Exercise 8.1--------------
(i)
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

(ii)
See Exercise8_1_ii.txt for the Micro-C bytecode, and ex3Trace.txt for the machine trace from 
the java file, where the relevant lines are commented.

First the argument(4) is pushed to the stack.
The bp gets updated and stores the value of i(0) at index 3.
It then goes to the condition of the while-loop and checks what is stored in the index.
If it matches it ends, and if it doesn't it goes to inside the body of the while-loop.
Here it prints i, as well as update the index 3 with the incremented value, and checks the condition again.

--------------Exercise 8.3--------------
See Comp.fs and exercise_8_3.c for solution
Our changed are marked with
//Start - Exercise 8.3
...
//End - Exercises 8.3

--------------Exercise 8.4--------------
compileToFile (fromFile "ex8.c") "ex8.out";;
val it: Machine.instr list =
  [LDARGS; CALL (0, "L1"); STOP; 
  Label "L1"; INCSP 1; GETBP; CSTI 0; ADD;
   CSTI 20000000; STI; INCSP -1; GOTO "L3"; 
  Label "L2"; GETBP; CSTI 0; ADD;
   GETBP; CSTI 0; ADD; LDI; CSTI 1; SUB; STI; INCSP -1; INCSP 0; 
  Label "L3";
   GETBP; CSTI 0; ADD; LDI; IFNZRO "L2"; INCSP -1; RET -1]
The above symbolic bytecode performs many jumps and loads per iteration of the while loop.
These operations contribute to the significantly slower runtime.

compileToFile (fromFile "ex13.c") "ex13.out";;
val it: Machine.instr list =
  [LDARGS; CALL (1, "L1"); STOP; 
  Label "L1"; INCSP 1; GETBP; CSTI 1; ADD;
   CSTI 1889; STI; INCSP -1; GOTO "L3"; 
  Label "L2"; 
   GETBP; CSTI 1; ADD; 
   GETBP; CSTI 1; ADD; 
   LDI; CSTI 1; ADD; STI; 
   INCSP -1; 
   GETBP; CSTI 1; ADD; 
   LDI; CSTI 4; MOD; CSTI 0; EQ; IFZERO "L7"; GETBP; CSTI 1; ADD; LDI; CSTI 100;
   MOD; CSTI 0; EQ; NOT; IFNZRO "L9"; GETBP; CSTI 1; ADD; LDI; CSTI 400; MOD;
   CSTI 0; EQ; GOTO "L8"; 
  Label "L9"; CSTI 1; 
  Label "L8"; GOTO "L6";
  Label "L7"; CSTI 0; 
  Label "L6"; IFZERO "L4"; GETBP; CSTI 1; ADD; LDI;
   PRINTI; INCSP -1; GOTO "L5"; 
  Label "L4"; INCSP 0; 
  Label "L5"; INCSP 0;
  Label "L3"; GETBP; CSTI 1; ADD; LDI; GETBP; CSTI 0; ADD; LDI; LT;
   IFNZRO "L2"; INCSP -1; RET 0]
There are many labels, each one resulting from different logical operations. 
There are also chains of GOTO operations, the could be eliminated.
It seems like a few of the labels "house" code that does nothing eg. L4 & L5 
--------------Exercise 8.5--------------
See Absyn.fs, Comp.fs, CLex.fsl, and CPar.fsy for solution
An example of a Ternary can be seen in exercise_8_5.c
Our changes are marked with //Exercise 8.5 or
//Start - Exercise 8.5
...
//End - Exercises 8.5


--------------Exercise 8.6--------------
See Absyn.fs, CLex.fsl, CPar.fsy and Interp.fs for solution.
An example of a switch case can be seen in exercise_8_6.c
Our changed are marked with either //Exercise 8.6 or
//Start - Exercise 8.6
...
//End - Exercises 8.6