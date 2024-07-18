using System;
using System.Collections.Generic;
using System.Linq;

namespace E2
{
    class Program
    {
        public static double Q03StringDistance(string s1, string s2){
        List<char> s1w = new List<char>(); s1w = s1.ToList();
        List<char> s2e = new List<char>(); s2e = s2.ToList();
        for(int j=0; j<s2e.Count(); j++)
            for(int i=0; i<s1w.Count(); i++)
                if (s1w[i]== s2e[j]){
                    s1w.Remove(s1w[i]);
                    i--;}
        return s1w.Count();
    }
        static void Main(string[] args)
        {
            Console.WriteLine(Q03StringDistance("aabbc", "c"));
        }
    }
}
