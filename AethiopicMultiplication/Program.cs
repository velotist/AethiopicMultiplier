using System;

/// <summary>
/// 
/// Author:     Marcus Greiner
/// Version:    1.0
/// 
/// 
/// Die äthiopische Mutlitplikation multipliziert zwei Zahlen mit einem bestimmten Algorithmus.
/// Zunächst haben sie die beiden Zahlen, die es zu multiplizieren galt, nebeneinander geschrieben, also z.B.:
/// 
///  5468   *   72
///  
/// Die linke Zahl wird nun für jede darunterliegende Zeile halbiert und Nachkommastellen werden abgeschnitten.
/// Die rechte Zahl hingegen wird Zeile für Zeile verdoppelt. Dies wird so lange betrieben, bis die linke Zahl gleich 1 ist.
/// 
///  5468   *   72
///  -------------
///  2734      144
///  1367      288
///   683      576
///   341     1152
///   170     2304
///    85     4608
///    42     9216
///    21    18432
///    10    38864
///     5    73728
///     2   147456
///     1   294912
///     
/// Nun werden alle Zeilen durchgestrichen, bei denen die linke Zahl gerade (also ohne Rest durch 2 teilbar) ist.
///
///  xxxx   *   xx
///  -------------
///  xxxx      xxx
///  1367      288
///   683      576
///   341     1152
///   xxx     xxxx
///    85     4608
///    xx     xxxx
///    21    18432
///    xx    xxxxx
///     5    73728
///     x   xxxxxx
///     1   294912
///     
/// Von den verbleibenden Zeilen werden die rechten Zahlen addiert, also:
///
///       288
///  +    576
///  +   1152
///  +   4608
///  +  18432
///  +  73728
///  + 294912
///  --------
///  = 393696
///  
/// Die Summe 393696 ist zugleich das Ergebnis des Produkts aus 5468 und 72.
/// 
/// </summary>

namespace AethiopicMultiplication
{
    class Program
    {
        // Create an array for the table of the aethiopic multiplication
        static int[,] table;

        // Initialize variable for the length of the array´s first dimension
        static int amountOfRowsInArray = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                int multiplier = ValidateInput("Bitte Multiplikator eingeben: ");
                Console.WriteLine();

                // Detect the length of the array´s first dimension with method DetectRowsForArray(int, int)
                table = new int[DetectRowsForArray(multiplier), 2];

                int multiplicand = ValidateInput("Bitte Multiplikand eingeben: ");

                Console.WriteLine();

                Multiply(multiplier, multiplicand);

                DoAethiopicMultiplication(multiplier, multiplicand);

                ShowContentOfArray(table);

                Console.WriteLine();
                Console.Write("Press q for quit or any other key for continuing...   ");
                if (Console.ReadLine() == "q")
                    break;
                Console.WriteLine();
            }
        }

        public static int ValidateInput(string questionText)
        {
            int number = 0;

            while (number == 0)
            {
                Console.Write(questionText);
                try
                {
                    number = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Eingabe war keine gültige Ganzzahl.");
                    Console.WriteLine();
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Wert außerhalb des Integer-Bereichs.");
                    Console.WriteLine();
                }
            }
            return number;
        }

        public static void ShowContentOfArray(int[,] array)
        {
            Console.WriteLine();
            for (int i = 0; i < amountOfRowsInArray; i++)
            {
                Console.Write(table[i, 0] + "     " + table[i,  1]);
                Console.WriteLine();
            }
        }

        public static int Multiply(int multiplicator, int multiplicand)
        {
            int result = multiplicator * multiplicand;
            Console.WriteLine("Ergebnis Multiplikation             aus {0} * {1} = {2}", multiplicator, multiplicand, result);
            return result;
        }
        
        public static int DetectRowsForArray(int multiplier)
        {
           amountOfRowsInArray = 0;
           while(multiplier > 0)
            {
                multiplier = multiplier / 2;
                amountOfRowsInArray++;
            }
            return amountOfRowsInArray;
        }

        public static int DoAethiopicMultiplication(int multiplier, int multiplicand)
        {
            table[0, 0] = multiplier;
            table[0, 1] = multiplicand;
            int firstMultiplicand = multiplicand;
            // without this condition the first row wouldn't be added, when the multiplier is even
            if (table[0, 0] % 2 == 0)
                table[0, 1] = 0;

            int row = 1;
            while (row < amountOfRowsInArray)
            { 
                multiplier = multiplier / 2;
                table[row, 0] = multiplier;

                multiplicand = multiplicand * 2;
                if (multiplier % 2 == 0)
                {
                    table[row, 1] = 0;
                }
                else
                {
                    table[row, 1] = multiplicand;
                }

                row++;
            }

            int result = 0;
            for (int i = 0; i < amountOfRowsInArray; i++)
            {
                result = result + table[i, 1];
            }
            Console.WriteLine("Ergebnis äthiopische Multiplikation aus {0} * {1} = {2}", table[0, 0], firstMultiplicand, result);
            return result;
        }
    }
}