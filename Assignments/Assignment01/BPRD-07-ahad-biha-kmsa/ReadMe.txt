--------------Exercise 8.1--------------

--------------Exercise 8.3--------------

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

--------------Exercise 8.6--------------
