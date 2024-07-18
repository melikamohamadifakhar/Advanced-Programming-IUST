using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

public record Point(double x, double y);

public static class QExt
{    
    public static double Q01EuclideanDistance(Point p1, Point p2){
        return Math.Sqrt(Math.Pow((p1.x - p2.x), 2) + Math.Pow((p1.y - p2.y), 2));
    }

    public static double Q02ManhatanDistance(Point p1, Point p2){
        return Math.Abs(p1.x-p2.x) + Math.Abs(p1.y-p2.y);
    }

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

    public static (int min, int max) Q11GetRange(this int[] nums){
        int max = nums.Max();
        int min = nums.Min();
        if(nums == null)
            throw new InvalidOperationException();
        return (min, max);
    }

    public static int Q12GetRange(this int[] nums){
        int max = nums.Max();
        int min = nums.Min();
        return max-min;
    }

    public static (T min, T max) Q13GetRange<T>(this T[] vals) where T: IComparable<T>{
        T max = vals.Max(); T min = vals.Min();
        return (min, max);
    }

    public static (T min, T max) Q14GetRange<T>(this T[] vals, Func<T, T, double> diff){
        double maxdiff=0;
        T max=default; T min= default;
        foreach (var item in vals)
            foreach (var s in vals){
                if(diff(item, s) > maxdiff){
                    maxdiff = Math.Abs(diff(item, s)); 
                    max = item; min = s;
                }
            }
        return (min, max);
    }

    public static double Q15GetRange<T>(this T[] vals, Func<T, T, double> diff){
        double maxdiff =0;
        foreach (var item in vals)
            foreach (var s in vals)
                if(diff(item, s) > maxdiff)
                    maxdiff = Math.Abs(diff(item, s)); 
        return maxdiff;
    }
}