using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosNumericos
{
    public static class FUNCTIONS
    {
        public const double e = Math.E;
        public static double getImage(double xn)
        {
           //return (Math.Log(5) - Math.Pow(xn,5) + Math.Pow(xn, 3));            
            //return (Math.Pow(xn,2) - 2*xn -8);
            //return (2 * Math.Pow(xn, 2) - Math.Pow(e, 2) + 3);
            return (1 + Math.Cos(xn) - 4*(xn));
            //return (Math.Pow(xn, 3) - 2 *Math.Pow(xn, 2)-10);            
        }
    }
}
