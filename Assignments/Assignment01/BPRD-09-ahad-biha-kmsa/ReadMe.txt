--------------Exercise 10.1--------------

(i)

ADD: 
The operation untags what is at the stack pointer and the previous position, then adds the resulting numbers together.
The result is stored at the position before the stack pointer. The stack pointer is decremented.

CSTI i:
Tags the number after the program counter, and saves it into the position following the stack pointer. 
Then the stack pointer is incremented.

NIL:
Stores zero on the position following the stack pointer. Then the stack pointer is incremented.
 
What is the difference between NIL and CSTI 0?
The difference is that NIL is a pointer. As it does not tag the 0, where CSTI 0 would tag the zero.

IFZERO, which tests whether an integer is zero, or a reference is nil:
Saves whatever is at the top of stack into a word v. Then decrements the stack pointer.
Checks whether "v" is an int. If it is untag it and finally compare it to zero.
If the comparison is true, then jump to somewhere in the program. If it returns false then simply increment the stack pointer  
 
CONS:
Allocate memory in the heap, 

CAR
SETCAR

(ii)

(iii)

(iv)
--------------Exercise 10.2--------------

--------------Exercise 10.3--------------
