using System;
using System.IO;

namespace C24
{
    class Program
    {

        static void Maindf(string[] args)
        {
            try
            {
                int id = int.Parse(Console.ReadLine());
                string name = Console.ReadLine();
                Student s = new Student(name, id);
            }
            catch(InvalidStudentDataException e)
            {
                Console.WriteLine(e.Message);
                if (e.Id > 0 || e.Name == "Ali")
                    throw;
            }
        }


        static void Main555(string[] args)
        {
            int x = int.MaxValue;
            System.Console.WriteLine(x);
            checked
            {
                x++;
            }
            System.Console.WriteLine(x);
        }

        static int FinallyTest()
        {
            try
            {
                int n = int.Parse("sd");
            }
            catch(FormatException fe)
            {
                if (!fe.Message.Contains("sxx"))
                    throw fe;
            }
            finally
            {

            }
            return 5;
        }

        static void TestA()
        {
            Console.WriteLine("In Test A - Before");
            try
            {
                FinallyTest();
            }
            finally{}
            Console.WriteLine("In Test A - After");
        }

        static void TestB()
        {
            Console.WriteLine("In Test B - Before");
            TestA();
            Console.WriteLine("In Test B - After");
        }


        static void Main5(string[] args)
        {

            try
            {
                TestB();
            }
            catch(FormatException fe)
            {
                if (!fe.Message.Contains("asdf"))
                    throw;
            }
            // using (StreamReader reader = new StreamReader("file.txt"))
            // {}

            StreamReader reader = null;
            try
            {
                reader = new StreamReader("file.txt");
                string w = reader.ReadToEnd();
            }
            // catch(Exception e)
            // {
            //     Console.WriteLine(e.Message);
            // }
            finally
            {
                if (reader != null)
                    reader.Dispose();
            }    
        }

        static void Main1(string[] args)
        {
            try
            {
                int id = int.Parse(Console.ReadLine());
                string name = Console.ReadLine();
                Student s = new Student(name, id);
            }
            catch(FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch(InvalidDataException nre) when (nre.Message.Contains("Name"))
            {
                System.Console.WriteLine("Invalid Name");
            }
            catch(InvalidDataException nre) when (nre.Message.Contains("Id"))
            {
                System.Console.WriteLine("Invalid Id");
            }
            catch(NullReferenceException ide)
            {   
                System.Console.WriteLine("nre");             
            }
            catch(Exception e) when (e is InvalidDataException || e is NullReferenceException)
            {
                System.Console.WriteLine("ide");
            }
        }
    }
}
