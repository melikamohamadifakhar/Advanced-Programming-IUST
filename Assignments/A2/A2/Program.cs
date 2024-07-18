using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2
{
    public class Program
    {
        static void Main(string[] args)
        {}

        public static int GetObjectType(object o)
        {
            if (o is string)
            {
                return 0;
            }
            else if (o is int[])
            {
                return 1;
            }
            else if (o is int)
            {
                return 2;
            }
            else
            {
                return 12;
            }

        
        }

        public static bool IdealHusband(FutureHusbandType fht)
        {
            if (fht == FutureHusbandType.HasBigNose )
            {
                return false;
            }
            else if (fht == FutureHusbandType.IsShort)
            {
                return false;
            }
            else if (fht == (FutureHusbandType.IsBald | FutureHusbandType.IsShort))
            {
                return true;
            }
            else if (fht == (FutureHusbandType.IsBald | FutureHusbandType.HasBigNose))
            {
                return true;
            }
            else if (fht == (FutureHusbandType.IsShort | FutureHusbandType.HasBigNose))
            {
                return true;
            }
            else if (fht == (FutureHusbandType.IsShort | FutureHusbandType.HasBigNose | FutureHusbandType.IsBald))
            {
                return false;
            }
            return false;
        }
    }
}
