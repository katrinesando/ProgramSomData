module Assignment01.Cont.Exercise_11_3

let rec prod xs =
    match xs with
    | [] -> 1
    | x::xr -> x * prod xr;;


let rec prodc xs c =
    match xs with
    | [] -> c 1
    | x::xr -> prodc xr (fun r -> c (x * r))

(*
prod [2;2;2];;
val it: int = 8

prodc [2;2;2] id;;
val it: int = 8

*)

let rec prodi xs c =
    match xs with
    | [] -> c 1
    | x::xr ->
        if x = 0 then
            c 0
            else
                prodc xr (fun r -> c (x * r))
    
   


