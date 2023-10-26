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
the java file, where the relavent lines are commented.

First the argument(4) is pushed to the stack.
The bp gets updated and stores the value of i(0) at index 3.
It then goes to the condition of the while-loop and checks what is stored in the index.
If it matches it ends, and if it doesn't it goes to inside the body of the while-loop.
Here it prints i, as well as update the index 3 with the incremented value, and checks the condition again.


--------------Exercise 8.3--------------

--------------Exercise 8.4--------------

--------------Exercise 8.5--------------

--------------Exercise 8.6--------------
