module Assignment01.Cont.exercise_11_2


//11.2 i
let rec revc xs c =
    match xs with
    |[] -> c xs
    |x::xr -> revc xr (fun v -> c (v @ [x]))
(*11.2 ii
revc [1;2;3] (fun v -> v @ v);;
val it: int list = [3; 2; 1; 3; 2; 1]

11.2 ii*)
let rec revi xs acc =
    match xs with
    |[] -> acc
    |x ::xr -> revi xr (acc @ [x])
