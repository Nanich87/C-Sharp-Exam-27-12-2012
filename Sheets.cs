using System;
using System.Collections.Generic;

namespace Sheets
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int[] piecesList = new int[11];
            Dictionary<int, string> sheets = new Dictionary<int, string>();
            sheets.Add(0, "A0");
            sheets.Add(1, "A1");
            sheets.Add(2, "A2");
            sheets.Add(3, "A3");
            sheets.Add(4, "A4");
            sheets.Add(5, "A5");
            sheets.Add(6, "A6");
            sheets.Add(7, "A7");
            sheets.Add(8, "A8");
            sheets.Add(9, "A9");
            sheets.Add(10, "A10");

            piecesList[10] = 1;
            for (int i = 9; i >= 0; i--)
            {
                piecesList[i] = piecesList[i + 1] * 2;
            }

            for (int i = 0; i < piecesList.Length; i++)
            {
                if (n >= piecesList[i])
                {
                    n -= piecesList[i];
                    sheets.Remove(i);
                }
            }

            foreach (var item in sheets)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
