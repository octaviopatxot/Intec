using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intec.Helpers
{
    static public class Routines
    {
        static public int CalculateAge(DateTime Dob)
        {
            return new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
        }

        static public int CalculateAge(int Dob)
        {
            return DateTime.Now.Year - Dob;
        }
    }
}
