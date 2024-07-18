using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3
{
	public interface IHasAge{
		int GetAge();
	}
		public class Human : IHasAge
		{
			public string Name;
			public int Age;
			public Human(string Name, int Age){
				this.Name = Name;
				this.Age = Age;
			}
			public int GetAge(){
				return Age;
			}
		}

	public class BasicQuestions
	{
		public static void AssignPi(out double x){
			x = Math.PI;
		}
		public static void Square(ref int x){
			x = x*x;
		}
		public static void Append(ref int[] array, int x){
			int Length = array.Length;
			int[] new_array = new int[Length+1];
			for(int i=0; i<Length; i++)
				new_array[i] = array[i];
			new_array[Length] = x;
			array = new_array;
		}
		public static void AbsArray(int[] nums){
			for(int i=0; i<nums.Length; i++){
				if(nums[i]<0)
					nums [i] *= -1;
			}
		}
		public static void ArrayElementSwap(int[] array1, int[] array2){
			for(int i=0; i<array1.Length; i++)
				Swap(ref array1[i], ref array2[i]);
		}
		public static void ArraySwap(ref int[] array1,ref int[] array2){
			int l = array1.Length;
			Array.Resize(ref array1, array2.Length);
			for (int i = 0; i < array2.Length; i++)
				Swap(ref array1[i], ref array2[i]);
			Array.Resize(ref array2, l);
		}
		
		public static int OddSum(int[] nums)
		{
			int sum=0;
			foreach (var num in nums)
			{
				if(num % 2 == 1)
					sum+=num;
			}
			return sum;
		}
		public static void Swap<_Type>(ref _Type a, ref _Type b){
			_Type temp = a;
			a = b;
			b = temp;
		}

		
	}
}
