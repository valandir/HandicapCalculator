using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandicapCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Handicap test = new Handicap(70);

            int h = test.CalculateHandicap(7.2);

            if (h < 0)
                {
                h = ~h;
            }

            Console.Write(100-h);
            Console.ReadKey();
        }
    }
}
