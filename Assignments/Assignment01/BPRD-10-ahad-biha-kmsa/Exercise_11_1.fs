module Assignment01.BPRD_10_ahad_biha_kmsa.Exercise_11_1

//Exercise 11.1
let rec len xs =
match xs with
| [] -> 0
| x::xr -> 1 + len xr;;

//(i)
let rec lenc xs con =
    match xs with
    | [] -> con 0
    | x::xr -> lenc xr (fun a ->con(1+a));;
    
//(ii)
(*
    Calling leni with lenc xs (fun v -> 2*v) would result in returning twice the size of the list
*)


//(iii)
let rec leni xs acc =
    match xs with
    | [] -> acc
    | x::xr -> leni xr (acc+1);;

(*
 Where lenc make use of iteration, leni make use of tail-recursion.
 This means that leni occurs when a statement in a function calls itself repeatly.
 Meanwhile the continuation(iteration) occours when a loop repeatedly executes until the controlling condition becomes false.
*)

//Testing
//lenc [2; 5; 7] id
//lenc [2; 5; 7] (fun v -> 2*v)
//leni [2; 5; 7] 0