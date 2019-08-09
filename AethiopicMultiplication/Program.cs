using System;

namespace AethiopicMultiplication
{
    class Program
    {
        // Create an array for the table of the aethiopic multiplication
        static int[,] table;
        static int amountOfRowsInArray = 0;

        static void Main(string[] args)
        {
            //Console.Write("Bitte Multiplikator eingeben: ");
            //int multiplier = Convert.ToInt32(Console.ReadLine());

            //table = new int[DetectRowsForArray(multiplier), 2];

            table = new int[1000, 1000];

            //Console.Write("Bitte Multiplikand eingeben: ");
            //int multiplicand = Convert.ToInt32(Console.ReadLine());

            //table[0, 0] = multiplier;
            //table[0, 1] = multiplicand;

           

            VerifyResults();

            DoAethiopicMultiplication(table[0, 0], table[0, 1]);

            Console.ReadKey(); // Press key to quit program
        }

        public static int Multiply(int multiplicator, int multiplicand)
        {
            int result = multiplicator * multiplicand;
            Console.WriteLine("Ergebnis Multiplikation aus {0} und {1} = {2}", multiplicator, multiplicand, result);
            return result;
        }

        public static bool VerifyResults()
        {
            table[0, 0] = 0;
            table[0, 1] = 1;
            bool verificationResult = false;
            for (int i = 0; i < 300; i++)
            {
                if (Multiply(i, 1) == DoAethiopicMultiplication(i, 1))
                {
                    verificationResult = true;
                    Console.WriteLine("Richtig");
                }
                else
                    Console.WriteLine("Falsch");
                    verificationResult = false;
            }
            return verificationResult;
        }
        
        public static int DetectRowsForArray(int multiplier)
        {
            double roundedResultOfSquareroot = Math.Floor(Math.Sqrt(multiplier));
            Console.WriteLine(roundedResultOfSquareroot);
            amountOfRowsInArray = Convert.ToInt32(roundedResultOfSquareroot) + 1;
            return amountOfRowsInArray;
        }

        public static int DoAethiopicMultiplication(int multiplier, int multiplicand)
        {
            int row = 0;
            while (row < amountOfRowsInArray)
            { 
                multiplier = multiplier / 2;
                multiplicand = multiplicand * 2;
                if (multiplier % 2 == 0)
                    table[row, 1] = 0;
                else
                    table[row, 1] = multiplicand;
                row++;
            }
            int sum = 0;
            for (int i = 0; i < amountOfRowsInArray; i++)
            {
                sum = sum + table[i, 1];
            }
            Console.WriteLine("Ergebnis äthiopische Multiplikation aus {0} * {1} = {2}", table[0, 0], table[0, 1] / 2, sum);
            return sum;
        }
    }
}