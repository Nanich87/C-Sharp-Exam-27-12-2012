using System;

namespace TribonacciTriangle
{
    class Program
    {
        static void Main()
        {
            long firstNumber = long.Parse(Console.ReadLine());
            long secondNumber = long.Parse(Console.ReadLine());
            long thirdNumber = long.Parse(Console.ReadLine());
            int linesCount = int.Parse(Console.ReadLine());

            Console.WriteLine(firstNumber);
            Console.WriteLine(secondNumber + " " + thirdNumber);
            
            int membersCount = 0;
            for (int i = 1; i <= linesCount; i++)
            {
                membersCount += i;
            }

            int nextLine = 3;
            int lineSize = 0;
            for (int i = 4; i <= membersCount; i++)
            {
                long currentNumber = firstNumber + secondNumber + thirdNumber;
                firstNumber = secondNumber;
                secondNumber = thirdNumber;
                thirdNumber = currentNumber;
                Console.Write(currentNumber + " ");
                lineSize++;
                if (lineSize == nextLine)
                {
                    Console.WriteLine();
                    nextLine += 1;
                    lineSize = 0;
                }
            }
        }
    }
}
