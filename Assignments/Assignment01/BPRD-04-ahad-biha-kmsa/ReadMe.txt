-----------------4.1------------------
let res = run (Prim("+", CstI 5, CstI 7));;
	val res: int = 12

run (fromString "5+7");;
	val it: int = 12

run (fromString "let y = 7 in y + 2 end");;
	val it: int = 9

run (fromString "let f x = x + 7 in f 2 end");;
	val it: int = 9

----Our own examples----

run(fromString "let f x y = x + y in f 6 (let m = 3 in m+2 end) end");;
	ERROR


-----------------4.2------------------

Computation 1000 to 1
run (fromString "let sum n = if n=1 then 1 else n+(sum (n-1)) in sum 1000  end");;
	val it: int = 500500

Recursive of 3^8
run (fromString "let pow x = if x = 0 then 1 else 3*(pow (x-1)) in pow 8 end");;
	val it: int = 6561      

Recursive of 3^0 + 3^1 + · · · + 3^10 + 3^11
run (fromString "let sumPow x = if x = 0 then 1 else (let pow exp = if exp = 0 then 1 else 3*(pow (exp-1)) in pow x end) + (sumPow (x-1))  in sumPow 11 end");;
	val it: int = 265720

Recursive of 1^8 + 2^8 + · · · + 10^8
run (fromString "let sumPow x = if x = 0 then 0 else (x*x*x*x*x*x*x*x) + (sumPow (x-1))  in sumPow 10 end");;
   	val it: int = 167731333

--------------Exercise 4.3--------------
See Absyn.fs and Fun.fs our code is marked by a //Start & //End comment


--------------Exercise 4.4--------------
 
 
 
--------------Exercise4.5--------------
See FunPar.fsy & FunLex.fsl all added lines are marked with comments