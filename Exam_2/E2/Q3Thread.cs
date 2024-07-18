using System;
using System.Threading;

namespace E2
{
    public class Q3Thread
    {
        public static object obj = new Object();
        public static object obj1 = new Object();
        public static object obj3 = new Object();
        private Random RndGen = new Random(1);
        private static int _InstanceCount = 0;
        public static int InstanceCount => _InstanceCount;

        private static Q3Thread _Instance = null;

        public static void ResetInstanceToNull() 
        {
            lock (obj1)
            _Instance = null;

                _InstanceCount = 0;

        }
        public static Q3Thread Instance()
        {

            lock (obj)
            {
            if (_Instance == null)
            {
                _Instance = new Q3Thread();
            }
            return _Instance;
            }
            

        }

        public int GetSomeRandomNumber() => RndGen.Next();

        private Q3Thread()
        {
            Interlocked.Increment(ref _InstanceCount);
        }
    }
}