using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace A2
{ 
    public struct TypeOfSize5
    {
        char a;
        char b;
        char c;
        char d;
        char e;
    }
    public struct TypeOfSize22{
        TypeOfSize5 a;
        TypeOfSize5 a1;
        TypeOfSize5 a2;
        TypeOfSize5 a3;
        char s;
        char s2;
    }
    public struct TypeOfSize125{
        TypeOfSize22 x1;
        TypeOfSize22 x2;
        TypeOfSize22 x3;
        TypeOfSize22 x4;
        TypeOfSize22 x5;
        TypeOfSize5 f1;
        TypeOfSize5 f2;
        TypeOfSize5 f3;
    }
    public struct TypeOfSize1024{
        TypeOfSize125 n;
        TypeOfSize125 n1;
        TypeOfSize125 n2;
        TypeOfSize125 n3;
        TypeOfSize125 n4;
        TypeOfSize125 n5;
        TypeOfSize125 n6;
        TypeOfSize125 n7;
        TypeOfSize22 b;
        char c;
        char d; 
    }
    public struct TypeOfSize32768{
        TypeOfSize1024 r, r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15, r16, r17, r18, r19, r20, r21, r22, r23, r24, r25, r26, r27, r28, r29, r30, r31; 
    }
    public struct TypeForMaxStackOfDepth10{
        TypeOfSize32768 a;
        TypeOfSize1024 b, b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13, b14, b15, b16, b17, b18, b19, b20, b21;
    }
    public struct TypeForMaxStackOfDepth100{
        TypeOfSize1024 a, b, c, d, e, f, g;
    }
    public struct TypeForMaxStackOfDepth1000{
        TypeOfSize125 a,b,c,d,e;
    }
    public struct TypeForMaxStackOfDepth3000{
        TypeOfSize125 a;
        TypeOfSize22 b, c, d, e;
    }
//change to merge
    public struct TypeWithMemoryOnHeap{
        public TypeOfSize1024[] size; 
        public void Allocate(){
            size = new TypeOfSize1024[2000];
        }
        public void DeAllocate(){
            size = null;
        }
    }
    public struct StructOrClass1
    {
        public int X;
    }
    public class  StructOrClass2
    {
        public int X;
    }
    public class StructOrClass3{
        public StructOrClass2 X;
        // public StructOrClass2
    }
    public enum FutureHusbandType: int
{
    None = 1,
    HasBigNose = 1<<1,
    IsBald = 1<<2,
    IsShort = 1<<3
}
}
