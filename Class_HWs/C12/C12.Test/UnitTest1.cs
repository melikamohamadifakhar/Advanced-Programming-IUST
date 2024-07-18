// using System.Collections.Generic;
// using System.IO;
// using Microsoft.VisualStudio.TestTools.UnitTesting;

// namespace C12.Test
// {
//     [TestClass]
//     public class UnitTest1
//     {
//         [TestMethod]
//         public void TestMethod1()
//         {

//             string outfile = @"..\..\..\..\..\C12\file1.txt";
//             string infile = @"..\..\..\..\..\C12\file.txt";
//             homework.ReverseTextFile(infile, outfile);
//             using (StreamReader reader = new StreamReader(infile))
//             {
//                 using (StreamReader writer = new StreamReader(outfile))
//                 {
//                     string[] inLines = File.ReadAllLines(infile);
//                     string[] outLines = File.ReadAllLines(outfile);
//                     int j = outLines.Length-1;
//                     for (int i = 0; i < inLines.Length; i++)
//                     {
//                             Assert.AreEqual<string>(outLines[i], inLines[j]);
//                             j--;
//                     }
                    
//                 }
//             }
//             File.WriteAllText(@"..\..\..\..\..\C12\file1.txt", System.String.Empty);
//         }
//     }
// }
