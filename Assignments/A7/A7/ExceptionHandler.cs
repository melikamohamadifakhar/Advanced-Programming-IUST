using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Collections.Generic;

namespace A7
{
    public class ExceptionHandler
    {
        public string ErrorMsg { get; set; }
        public readonly bool DoNotThrow;
        private string _Input;

        public string Input
        {
            get
            {
                try
                {
                    if (_Input == null)
                        throw new NullReferenceException();
                    if (_Input.Length < 50)
                        return _Input;
                }
                catch
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in GetMethod";
                }
                return null;
            }
            set
            {
                try
                {
                    if (value == null)
                        throw new NullReferenceException();
                    if (value.Length < 50)
                        _Input = value;
                }
                catch
                {
                    if (!DoNotThrow)
                        throw;
                    ErrorMsg = "Caught exception in SetMethod";
                }
            }
        }


        public ExceptionHandler(
            string input,
            bool causeExceptionInConstructor,
            bool doNotThrow=false)
        {
            DoNotThrow = doNotThrow;
            this._Input = input;
            try
            {
                if (causeExceptionInConstructor)
                {
                    string test = null;
                    if (test.Length > 0)
                        Console.WriteLine("test");
                }
            }
            catch
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = "Caught exception in constructor";
            }
        }

        public void OverflowExceptionMethod()
        {
            #region TODO
            try
            {
                string str = $"7576{Input}";
                int result = int.Parse(str);
            }
            catch(OverflowException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
            #endregion
        }

        public void FormatExceptionMethod()
        {
            try
            {
                int i = int.Parse(Input);
            }
            catch(FormatException e)
            {
                if (!DoNotThrow)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
        }

        public void FileNotFoundExceptionMethod()
        {
            #region TODO
            try{
                File.ReadAllLines($"..\\..\\..\\..\\..\\A7\\A7\\{Input}.txt");
            }
            catch(FileNotFoundException e){
                if (DoNotThrow==false)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
            #endregion
        }

        public void IndexOutOfRangeExceptionMethod()
        {
            #region TODO
            try{
                int[] nums = new int[]{1};
                nums[int.Parse(Input)] = 2;
            }
            catch(IndexOutOfRangeException e){
                if (DoNotThrow==false)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
            #endregion
        }

        public void OutOfMemoryExceptionMethod()
        {
            #region TODO
            try{
                StringBuilder sb = new StringBuilder(int.Parse(Input));
            }
            catch(OutOfMemoryException e){
                if (DoNotThrow==false)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
            #endregion
        }

        public void MultiExceptionMethod()
        {
            #region TODO
            try{
                StringBuilder sb = new StringBuilder(int.Parse(Input));
                int[] nums = new int[]{1};
                nums[int.Parse(Input)] = 2;
            }
            catch(OutOfMemoryException e){
                if (DoNotThrow==false)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
            catch(IndexOutOfRangeException e){
                if (DoNotThrow==false)
                    throw;
                ErrorMsg = $"Caught exception {e.GetType()}";
            }
            #endregion
        }

        public static void ThrowIfOdd(int n)
        {
            #region TODO
            if (n%2==1)
                throw new InvalidDataException();
            #endregion
        }

        public string FinallyBlockStringOut;

        public void FinallyBlockMethod(string s)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter swr = new StringWriter(sb);
            try
            {
                sb.Append($"InTryBlock:");
                if(s== null) throw new NullReferenceException();
                if(s.Length < 8) return;
                sb.Append($"{s}:{s.Length.ToString()}:DoneWriting");
            }
            catch (NullReferenceException nre)
            {
                sb.Append($":{nre.Message}");
                if (DoNotThrow==false)
                    throw;
            }
            finally
            {
                swr.Write(":InFinallyBlock");
                swr.Dispose();
                FinallyBlockStringOut = sb.ToString();
            }
            FinallyBlockStringOut += ":EndOfMethod";
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void NestedMethods()
        {
            #region TODO
            try{
                MethodA();
            }
            catch(NotImplementedException e){
                throw;
            }
                
            #endregion
        }
        public static void MethodA() => MethodB();
        public static void MethodB() => MethodC();
        public static void MethodC() => MethodD();
        public static void MethodD(){ throw new NotImplementedException();}


        #region TODO
        #endregion
    }
}
