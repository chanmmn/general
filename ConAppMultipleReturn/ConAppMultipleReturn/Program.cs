using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppMultipleReturn
{
    class Program
    {
        static void Main(string[] args)
        {
            (int x, int y, int z) = fun();
            Console.WriteLine("{0} {1} {2}",x,y,z);
            Console.ReadLine();
        }

        private static (int, int, int) fun()
        {
            return (4, 5, 3);
        }
    }
}
