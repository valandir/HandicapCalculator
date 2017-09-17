using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HandicapCalculator
{
    class Handicap
    {
        double[] avTable = new double[100];




        public Handicap(float distance)
        {
            for (int i = 0; i < 100; i++)
            {
                avTable[99-i] = CalculateArrowValue(distance, i, 122);
            }

        }

        public int CalculateHandicap(double averageArrow)
        {
            int var = 0;

            var = Array.BinarySearch(avTable, averageArrow);

            return var;
        }

        // Works as expected
        private double CalculateRMSError(double distance, double handicap)
        {
            // Initialise Data for return value
            double data = 0;

            // Exponent math
            double partA = System.Math.Pow(1.036, (handicap + 12.9));
            double partB = System.Math.Pow(1.07, (handicap + 4.3));

            double distance2 = System.Math.Pow(distance, 2);




            // Calculate RMS error
            data = 100 * distance * partA * 5 * Math.Pow(10, -4) * (1 + 1.429 * Math.Pow(10, -6) * partB * distance2);


            // Reutrn as a square for use in the actual equations
            return Math.Pow(data, 2);
        }


        private double CalculateArrowValue(double distance, double handicap, double face)
        {
            // Initialise data for return
            //double data = 0;
            double scoreDelta = 0;


            // Matric 10 Zone loop.
            for (int i = 1; i < 10; i++)
            {
                scoreDelta += Math.Exp(((-Math.Pow((((i * face) / 20) + 0.357), 2)) / CalculateRMSError(distance, handicap)));

            }



            return 10 - scoreDelta;
            
        }





    }
}
