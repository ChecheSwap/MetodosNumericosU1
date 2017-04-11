using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos
{
   public static class RAPHSON
    {
        public static double getFunctionDerivate(double x)
        {
            return (-Math.Sin(x) - 4);
            //return (-5 * Math.Pow(x, 4) + 3 * Math.Pow(x, 2));
            return (4 * x);
            //return (2 * x - 2);
            
        }

        public static double getFunctionSecDerivate(double x)
        {
            return (-Math.Cos(x));
            //return (-20 * Math.Pow(x, 3) + 6*x);
            //return (4);
            //return (2 * x - 2);
            //return 2;

        }
    }
}
