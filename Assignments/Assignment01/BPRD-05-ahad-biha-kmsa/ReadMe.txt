--------------Exercise 5.1--------------


--------------Exercise 5.7--------------


--------------Exercise 6.1--------------


--------------Exercise 6.2--------------


--------------Exercise 6.3--------------


--------------Exercise 6.4--------------
 

--------------Exercise 6.5--------------
(1) 
let f x = 1
in f f end
inferType (fromString "let f x = 1 in f f end");;
val it: string = "int"

let f g = g g
in f end
inferType (fromString "let f g = g g in f end");;
System.Exception: type error: circularity
....
Stopped due to error
parameters are not polymorphic inside the body of a function

let f x =
    let g y = y
    in g false end
in f 42 end
inferType (fromString "let f x = let g y = y in g false end in f 42 end");;
val it: string = "bool"

let f x =
    let g y = if true then y else x
    in g false end
in f 42 end
inferType (fromString "let f x = let g y = if true then y else x in g false end in f 42 end");;
System.Exception: type error: bool and int
Stopped due to error
Since all branches in an if-then-else expression must return 
expressions of the same type, y is forced to be of the same type as x. 
However, f is passed 42 and g is passed false 

let f x =
    let g y = if true then y else x
    in g false end
in f true end
inferType (fromString "let f x = let g y = if true then y else x in g false end in f true end");;
val it: string = "bool"