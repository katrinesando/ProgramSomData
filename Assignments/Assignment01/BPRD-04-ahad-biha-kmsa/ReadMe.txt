--------------Exercise 4.1--------------

--------------Exercise 4.2--------------
Sum of the numbers from 1000 down to 1
    run (fromString "let sum n = if n=1 then 1 else n+(sum (n-1)) in sum 1000 end");;

Recursive of 3^8
    run (fromString "let pow x = if x = 0 then 1 else 3*(pow (x-1)) in pow 8 end");;

Recursive of 3^0 + 3^1 + · · · + 3^10 + 3^11
    run (fromString "let sumPow x = if x = 0 then 1 else (let pow exp = if exp = 0 then 1 else 3*(pow (exp-1)) in pow x end) + (sumPow (x-1))  in sumPow 11 end");;

Recursive of 1^8 + 2^8 + · · · + 10^8 
    run (fromString "let sumPow x = if x = 0 then 0 else (x*x*x*x*x*x*x*x) + (sumPow (x-1))  in sumPow 10 end");;
   



--------------Exercise 4.3--------------
See Absyn.fs, 


--------------Exercise 4.4--------------
 
--------------Exercise4.5--------------