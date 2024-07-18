
// using System;
// using System.Collections.Generic;
// using System.IO;
// using System.Linq;
// public class mortality
// {
//     public mortality(string c, int y, double b)
//     {
//         country = c;
//         Year = y;
//         Both = b;
//     }

//     public string country{get; set;}
//     public int Year{get; set;}
//     public double Both{get; set;}
// }
// public class Q2ChildMortailityStats
// {
//     string path;
//     public Q2ChildMortailityStats(string filePath)
//     {   
//         path = filePath;     
//     }

//     public int Q21_HighestNeoNatalMortalityYear{
//         get{
//             var item = File.ReadLines(path)
//                 .Skip(2)
//                 .Select(s => {
//                     var toks = s.Split(',').Select(t => t.Trim(new char[]{'\"', ' '})).ToArray();
//                     if(toks[2]== "")
//                         toks[2] = "0";
//                     return new mortality(toks[0], int.Parse(toks[1].Split(' ')[0]), double.Parse(toks[2].Split(' ')[0]));
//                 })
//                 .Where(o => o.Both != 0)
//                 .GroupBy(x => x.Year)
//                 .Select(g => new {year= g.Key, av = g.Select(d => d.Both)})
//                 .Aggregate( (d1, d2) => d1.av.Average() > d2.av.Average() ? d1 : d2)
//                 .year;

//                 return item;
//             }}

//     public (string country, int year) Q22_HighestDifferenceBetweenMaleAndFemale{
//             get{
//             var item = File.ReadLines(path)
//                 .Skip(2)
//                 .Select(s => {
//                     var toks = s.Split(',').Select(t => t.Trim(new char[]{'\"', ' '})).ToArray();
//                     if(toks[2]== "")
//                         toks[2] = "0";
//                     return new mortality(toks[0], int.Parse(toks[1].Split(' ')[0]), Math.Abs(double.Parse(toks[3].Split(' ')[0]) - double.Parse(toks[4].Split(' ')[0])));
//                 })
//                 .GroupBy(x => x.Year)
//                 .Select(g => new {year= g.Key, av = g.Select(d => d.Both)})
//                 .Aggregate( (d1, d2) => d1.av.Average() > d2.av.Average() ? ) : d2)
//                 .year;
//             }
//     }
//     public string Q23_CountryWithHighestNeoNatalImprovement => throw new NotImplementedException();
// }
