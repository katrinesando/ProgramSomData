    // method line 2
    .method public static hidebysig 
           default void SelectionSort (int32[] arr)  cil managed 
    {
        // Method begins at RVA 0x20b4
	// Code size 57 (0x39)
	.maxstack 4
	.locals init (
		int32	V_0,//int i
		int32	V_1, //least
		int32	V_2,//tmp
		int32	V_3) //j
		
	IL_0000:  ldc.i4.0 //push constant int 0
	IL_0001:  stloc.0 //Pop stack into local variable at index 0.
	IL_0002:  br.s IL_0032 //Unconditional jump to IL_0032 

	IL_0004:  ldloc.0 //Load local variable at index 0 //Load int i
	IL_0005:  stloc.1 //Pop stack into local variable at index 1 //int least = i;
	IL_0006:  ldloc.0 //Load local variable at index 0  //Load int i
	IL_0007:  ldc.i4.1 //Push int 1 onto stack, 
	IL_0008:  add //add two values, and keep result on stack. //i + 1
	IL_0009:  stloc.3 //Pop stack into local variable at index 3
	IL_000a:  br.s IL_001a //Unconditional jump to IL_001a

	IL_000c:  ldarg.0 //Load argument 0 to stack
	IL_000d:  ldloc.3 //Load variable at index 3, int j
	IL_000e:  ldelem.i4 //Load index j of the array, arr[j]
	IL_000f:  ldarg.0 //Load array, int[] arr
	IL_0010:  ldloc.1 //Load variable at index 1, least
	IL_0011:  ldelem.i4 //Get array element at index least, arr[least]
	IL_0012:  bge.s IL_0016 //Comparison if great than or eqaul, and jump to IL_0016

	IL_0014:  ldloc.3 
	IL_0015:  stloc.1 
	IL_0016:  ldloc.3 //Load ariable at index 3, int j
	IL_0017:  ldc.i4.1 //Load constant 1 
	IL_0018:  add //Add 1 to j
	IL_0019:  stloc.3 //Save result in j
	IL_001a:  ldloc.3 //load variable at index 3, int j
	IL_001b:  ldarg.0 //Load argument 0 to stack
	IL_001c:  ldlen  //Find length of array
	IL_001d:  conv.i4 //Convert to int32 
	IL_001e:  blt.s IL_000c //Jump if less than to IL_000c
    
    //This block is the outer loop ending on line 26 in Selsort.cs
	IL_0020:  ldarg.0 
	IL_0021:  ldloc.0 
	IL_0022:  ldelem.i4 
	IL_0023:  stloc.2 
	IL_0024:  ldarg.0 
	IL_0025:  ldloc.0 
	IL_0026:  ldarg.0 
	IL_0027:  ldloc.1 
	IL_0028:  ldelem.i4 
	IL_0029:  stelem.i4 
	IL_002a:  ldarg.0 
	IL_002b:  ldloc.1 
	IL_002c:  ldloc.2 
	IL_002d:  stelem.i4 
	IL_002e:  ldloc.0 //IL_0002e to IL_0031 is i++
	IL_002f:  ldc.i4.1 
	IL_0030:  add 
	IL_0031:  stloc.0 
	IL_0032:  ldloc.0 //Load local variable at index 0
	IL_0033:  ldarg.0 //Load argument 0 to stack
	IL_0034:  ldlen //push length of array to stack
	IL_0035:  conv.i4 //convert int32 and push to stack
	IL_0036:  blt.s IL_0004 //Brand to target if less than, first comparison in for-loop.

	IL_0038:  ret 
    } // end of method Selsort::SelectionSort


