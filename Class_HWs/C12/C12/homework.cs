using System.Collections.Generic;
using System.IO;

namespace C12
{
    public class homework{
        public static void ReverseTextFile(string inFile, string outFile)
        {
            using (StreamReader reader = new StreamReader(inFile))
            {
                using (StreamWriter writer = new StreamWriter(outFile))
                {
                    List<string> m_lines = new List<string>();
                    string line;

                    while (null != (line = reader.ReadLine()))
                    {
                        m_lines.Add(line);
                    }
                    for (int i = m_lines.Count -1; i>=0; i--)
                    {
                        writer.WriteLine(m_lines[i]);
                    }
                }
            }
            // string[] lines = File.ReadAllLines(inFile);
            // File.WriteAllLines(outFile, lines);
        }
}
}