// Implementation file for parser generated by fsyacc
module ExprPar
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open FSharp.Text.Lexing
open FSharp.Text.Parsing.ParseHelpers
# 1 "ExprPar.fsy"

  (* File Expr/ExprPar.fsy
     Parser specification for the simple expression language.
   *)

  open Absyn

# 14 "ExprPar.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | LPAR
  | RPAR
  | END
  | IN
  | LET
  | IF
  | THEN
  | ELSE
  | PLUS
  | MINUS
  | TIMES
  | DIVIDE
  | EQ
  | NAME of (string)
  | CSTINT of (int)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_LPAR
    | TOKEN_RPAR
    | TOKEN_END
    | TOKEN_IN
    | TOKEN_LET
    | TOKEN_IF
    | TOKEN_THEN
    | TOKEN_ELSE
    | TOKEN_PLUS
    | TOKEN_MINUS
    | TOKEN_TIMES
    | TOKEN_DIVIDE
    | TOKEN_EQ
    | TOKEN_NAME
    | TOKEN_CSTINT
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startMain
    | NONTERM_Main
    | NONTERM_Expr

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | LPAR  -> 1 
  | RPAR  -> 2 
  | END  -> 3 
  | IN  -> 4 
  | LET  -> 5 
  | IF  -> 6 
  | THEN  -> 7 
  | ELSE  -> 8 
  | PLUS  -> 9 
  | MINUS  -> 10 
  | TIMES  -> 11 
  | DIVIDE  -> 12 
  | EQ  -> 13 
  | NAME _ -> 14 
  | CSTINT _ -> 15 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_LPAR 
  | 2 -> TOKEN_RPAR 
  | 3 -> TOKEN_END 
  | 4 -> TOKEN_IN 
  | 5 -> TOKEN_LET 
  | 6 -> TOKEN_IF 
  | 7 -> TOKEN_THEN 
  | 8 -> TOKEN_ELSE 
  | 9 -> TOKEN_PLUS 
  | 10 -> TOKEN_MINUS 
  | 11 -> TOKEN_TIMES 
  | 12 -> TOKEN_DIVIDE 
  | 13 -> TOKEN_EQ 
  | 14 -> TOKEN_NAME 
  | 15 -> TOKEN_CSTINT 
  | 18 -> TOKEN_end_of_input
  | 16 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startMain 
    | 1 -> NONTERM_Main 
    | 2 -> NONTERM_Expr 
    | 3 -> NONTERM_Expr 
    | 4 -> NONTERM_Expr 
    | 5 -> NONTERM_Expr 
    | 6 -> NONTERM_Expr 
    | 7 -> NONTERM_Expr 
    | 8 -> NONTERM_Expr 
    | 9 -> NONTERM_Expr 
    | 10 -> NONTERM_Expr 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 18 
let _fsyacc_tagOfErrorTerminal = 16

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | LPAR  -> "LPAR" 
  | RPAR  -> "RPAR" 
  | END  -> "END" 
  | IN  -> "IN" 
  | LET  -> "LET" 
  | IF  -> "IF" 
  | THEN  -> "THEN" 
  | ELSE  -> "ELSE" 
  | PLUS  -> "PLUS" 
  | MINUS  -> "MINUS" 
  | TIMES  -> "TIMES" 
  | DIVIDE  -> "DIVIDE" 
  | EQ  -> "EQ" 
  | NAME _ -> "NAME" 
  | CSTINT _ -> "CSTINT" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | LPAR  -> (null : System.Object) 
  | RPAR  -> (null : System.Object) 
  | END  -> (null : System.Object) 
  | IN  -> (null : System.Object) 
  | LET  -> (null : System.Object) 
  | IF  -> (null : System.Object) 
  | THEN  -> (null : System.Object) 
  | ELSE  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
  | MINUS  -> (null : System.Object) 
  | TIMES  -> (null : System.Object) 
  | DIVIDE  -> (null : System.Object) 
  | EQ  -> (null : System.Object) 
  | NAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | CSTINT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 10us; 65535us; 0us; 2us; 8us; 9us; 13us; 14us; 15us; 16us; 24us; 18us; 25us; 19us; 26us; 20us; 27us; 21us; 28us; 22us; 29us; 23us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 4us; 1us; 7us; 8us; 9us; 1us; 1us; 1us; 2us; 1us; 3us; 1us; 4us; 1us; 4us; 1us; 5us; 4us; 5us; 7us; 8us; 9us; 1us; 5us; 1us; 6us; 1us; 6us; 1us; 6us; 4us; 6us; 7us; 8us; 9us; 1us; 6us; 4us; 6us; 7us; 8us; 9us; 1us; 6us; 4us; 7us; 7us; 8us; 9us; 4us; 7us; 8us; 8us; 9us; 4us; 7us; 8us; 9us; 9us; 4us; 7us; 8us; 9us; 10us; 4us; 7us; 8us; 9us; 10us; 4us; 7us; 8us; 9us; 10us; 1us; 7us; 1us; 8us; 1us; 9us; 1us; 10us; 1us; 10us; 1us; 10us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 9us; 11us; 13us; 15us; 17us; 19us; 21us; 26us; 28us; 30us; 32us; 34us; 39us; 41us; 46us; 48us; 53us; 58us; 63us; 68us; 73us; 78us; 80us; 82us; 84us; 86us; 88us; |]
let _fsyacc_action_rows = 30
let _fsyacc_actionTableElements = [|6us; 32768us; 1us; 8us; 5us; 11us; 6us; 27us; 10us; 6us; 14us; 4us; 15us; 5us; 0us; 49152us; 4us; 32768us; 0us; 3us; 9us; 25us; 10us; 26us; 11us; 24us; 0us; 16385us; 0us; 16386us; 0us; 16387us; 1us; 32768us; 15us; 7us; 0us; 16388us; 6us; 32768us; 1us; 8us; 5us; 11us; 6us; 27us; 10us; 6us; 14us; 4us; 15us; 5us; 4us; 32768us; 2us; 10us; 9us; 25us; 10us; 26us; 11us; 24us; 0us; 16389us; 1us; 32768us; 14us; 12us; 1us; 32768us; 13us; 13us; 6us; 32768us; 1us; 8us; 5us; 11us; 6us; 27us; 10us; 6us; 14us; 4us; 15us; 5us; 4us; 32768us; 4us; 15us; 9us; 25us; 10us; 26us; 11us; 24us; 6us; 32768us; 1us; 8us; 5us; 11us; 6us; 27us; 10us; 6us; 14us; 4us; 15us; 5us; 4us; 32768us; 3us; 17us; 9us; 25us; 10us; 26us; 11us; 24us; 0us; 16390us; 0us; 16391us; 1us; 16392us; 11us; 24us; 1us; 16393us; 11us; 24us; 4us; 32768us; 7us; 28us; 9us; 25us; 10us; 26us; 11us; 24us; 4us; 32768us; 8us; 29us; 9us; 25us; 10us; 26us; 11us; 24us; 3us; 16394us; 9us; 25us; 10us; 26us; 11us; 24us; 6us; 32768us; 1us; 8us; 5us; 11us; 6us; 27us; 10us; 6us; 14us; 4us; 15us; 5us; 6us; 32768us; 1us; 8us; 5us; 11us; 6us; 27us; 10us; 6us; 14us; 4us; 15us; 5us; 6us; 32768us; 1us; 8us; 5us; 11us; 6us; 27us; 10us; 6us; 14us; 4us; 15us; 5us; 6us; 32768us; 1us; 8us; 5us; 11us; 6us; 27us; 10us; 6us; 14us; 4us; 15us; 5us; 6us; 32768us; 1us; 8us; 5us; 11us; 6us; 27us; 10us; 6us; 14us; 4us; 15us; 5us; 6us; 32768us; 1us; 8us; 5us; 11us; 6us; 27us; 10us; 6us; 14us; 4us; 15us; 5us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 7us; 8us; 13us; 14us; 15us; 16us; 18us; 19us; 26us; 31us; 32us; 34us; 36us; 43us; 48us; 55us; 60us; 61us; 62us; 64us; 66us; 71us; 76us; 80us; 87us; 94us; 101us; 108us; 115us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 2us; 1us; 1us; 2us; 3us; 7us; 3us; 3us; 3us; 6us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 65535us; 16385us; 16386us; 16387us; 65535us; 16388us; 65535us; 65535us; 16389us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 16390us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; |]
let _fsyacc_reductions ()  =    [| 
# 171 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startMain));
# 180 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 26 "ExprPar.fsy"
                                                               _1                
                   )
# 26 "ExprPar.fsy"
                 : Absyn.expr));
# 191 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 30 "ExprPar.fsy"
                                                               Var _1            
                   )
# 30 "ExprPar.fsy"
                 : 'Expr));
# 202 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 31 "ExprPar.fsy"
                                                               CstI _1           
                   )
# 31 "ExprPar.fsy"
                 : 'Expr));
# 213 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 32 "ExprPar.fsy"
                                                               CstI (- _2)       
                   )
# 32 "ExprPar.fsy"
                 : 'Expr));
# 224 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 33 "ExprPar.fsy"
                                                               _2                
                   )
# 33 "ExprPar.fsy"
                 : 'Expr));
# 235 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 34 "ExprPar.fsy"
                                                               Let(_2, _4, _6)   
                   )
# 34 "ExprPar.fsy"
                 : 'Expr));
# 248 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 35 "ExprPar.fsy"
                                                               Prim("*", _1, _3) 
                   )
# 35 "ExprPar.fsy"
                 : 'Expr));
# 260 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 36 "ExprPar.fsy"
                                                               Prim("+", _1, _3) 
                   )
# 36 "ExprPar.fsy"
                 : 'Expr));
# 272 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 37 "ExprPar.fsy"
                                                               Prim("-", _1, _3) 
                   )
# 37 "ExprPar.fsy"
                 : 'Expr));
# 284 "ExprPar.fs"
        (fun (parseState : FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 38 "ExprPar.fsy"
                                                               If(_2, _4, _6)    
                   )
# 38 "ExprPar.fsy"
                 : 'Expr));
|]
# 298 "ExprPar.fs"
let tables () : FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 19;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let Main lexer lexbuf : Absyn.expr =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))
