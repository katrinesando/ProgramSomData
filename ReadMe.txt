##ReadMe

###Exercise 13.1

13.1.1

Result = 4

13.1.2 

Int 4 (int)

13.1.3

Program with tailcalls:
fun f x = if (x < 0) then g_tail 4 else f_tail (x - 1)
and g x = x
begin
  print(f 2)
end

Since this is a if-else condition, we know that either of the functions are called, but not both. In both branches a function is called as the last execution. Therefore they are tailcalls.

13.1.4

g:(int -> int) and f:(int -> int).

They are both determined at the compile time, to be int -> int.

13.1.5

Used: Elapsed 60ms, CPU 31ms

Evaluator: CPU 30ms Byte code: CPU 0ms
The difference is, that the bytecode is already compiled, while the evaulator must first compile it, then run it.

13.1.6 

With -opt: (58 lines)

LABEL G_ExnVar_L2
     0: CSTI 0
     2: CSTI 0
     4: STI
LABEL G_Valdecs_L3
     5: ACLOS 1
     7: ACLOS 1
     9: PUSHLAB LabFunc_f_L4
    11: CSTI 1
    13: LDI
    14: HEAPSTI 1
    16: INCSP -1
    18: PUSHLAB LabFunc_g_L5
    20: CSTI 2
    22: LDI
    23: HEAPSTI 1
    25: INCSP -1
    27: GETSP
    28: CSTI 2
    30: SUB
    31: CALL 0 L1
    34: STI
    35: INCSP -3
    37: STOP
LABEL LabFunc_f_L4
    38: GETBP
    39: CSTI 1
    41: ADD
    42: LDI
    43: CSTI 0
    45: LT
    46: IFZERO L6
    48: CSTI 2
    50: LDI
    51: CSTI 4
    53: TCLOSCALL 1
LABEL L6
    55: GETBP
    56: LDI
    57: GETBP
    58: CSTI 1
    60: ADD
    61: LDI
    62: CSTI 1
    64: SUB
    65: TCLOSCALL 1
LABEL LabFunc_g_L5
    67: GETBP
    68: CSTI 1
    70: ADD
    71: LDI
    72: RET 2
LABEL L1
    74: CSTI 1
    76: LDI
    77: CSTI 2
    79: CLOSCALL 1
    81: PRINTI
    82: RET 0

without -opt: (64 lines)

LABEL G_ExnVar_L2
     0: CSTI 0
     2: CSTI 0
     4: STI
LABEL G_Valdecs_L3
     5: ACLOS 1
     7: ACLOS 1
     9: PUSHLAB LabFunc_f_L4
    11: CSTI 1
    13: LDI
    14: HEAPSTI 1
    16: INCSP -1
    18: PUSHLAB LabFunc_g_L5
    20: CSTI 2
    22: LDI
    23: HEAPSTI 1
    25: INCSP -1
    27: GETSP
    28: CSTI 2
    30: SUB
    31: CALL 0 L1
    34: STI
    35: INCSP -3
    37: STOP
LABEL LabFunc_f_L4
    38: GETBP
    39: CSTI 1
    41: ADD
    42: LDI
    43: CSTI 0
    45: LT
    46: IFZERO L7
    48: CSTI 2
    50: LDI
    51: CSTI 4
    53: CLOSCALL 1
    55: GOTO L6
LABEL L7
    57: GETBP
    58: CSTI 0
    60: ADD
    61: LDI
    62: GETBP
    63: CSTI 1
    65: ADD
    66: LDI
    67: CSTI 1
    69: SUB
    70: CLOSCALL 1
LABEL L6
    72: RET 2
LABEL LabFunc_g_L5
    74: GETBP
    75: CSTI 1
    77: ADD
    78: LDI
    79: RET 2
LABEL L1
    81: CSTI 1
    83: LDI
    84: CSTI 2
    86: CLOSCALL 1
    88: PRINTI
    89: RET 0

Optimizations is faster, and saves 7-6 lines of code.

### Exercise 13.3



