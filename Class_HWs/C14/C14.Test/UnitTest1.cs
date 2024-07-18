using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
namespace C14.Test
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestMethod1()
        {
            int[] nums = new int[]{0,1,2,3,4};
            Func<int, int>[] op = new Func<int, int>[nums.Length];
            Func<bool>[] iff = new Func<bool>[nums.Length];
            Action<int>[] dof = new Action<int>[nums.Length];
            for (int i=0; i < nums.Length; i++)
            {
                if(nums[i] % 4 == 0)
                    op[i] = (x) => x+5;
                else if(nums[i] % 4 == 1)
                    op[i] = (x) => x*5;
                else if(nums[i] % 4 == 2)
                    op[i] = (x) => x-5;
                else
                    op[i] = (x) => x/5;
                
                iff[i] = () => true;

                if(i % 2 ==0){
                    dof[i] = (x) =>{
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        System.Console.WriteLine(x);
                    };
                }
                if (i % 2 ==1 )
                {
                    dof[i] = (x) =>{
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        System.Console.WriteLine(x);
                    };
                }
            }
            Program.TestAction(nums,op,iff,dof);
            int[] result = new int[]{5, 5, -3, 0, 9};
            for(int i=0; i<nums.Length; i++)
                Assert.AreEqual(result[i], nums[i]);
        }
    }
}
