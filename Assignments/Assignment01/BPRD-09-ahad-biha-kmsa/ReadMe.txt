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
Allocate a new cons object "p" in the heap. Then put the top two values of the stack into cons.
It then saves the pointer to "p" on the position before the stack pointer. The stack pointer is then decremented. 
 
CAR:
From the top of the stack, it loads a pointer into the variable "p", which points to a CONS on the heap. 
Checks whether "p" is a NIL pointer, then it pushes the value from the pointer onto the stack.

SETCAR:
From the top of the stack, it takes some value into "v" and then decrements the stack pointer.
Then it takes a pointer to a CONS from the top of the stack. and saves "v" into the first element of CONS.

(ii)

(iii)

(iv)
--------------Exercise 10.2--------------

--------------Exercise 10.3--------------
