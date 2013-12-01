using System;

namespace Carpets
{
    class Program
    {
        static void Main()
        {
            int fullSize = int.Parse(Console.ReadLine());
            int halfSize = fullSize / 2;

            for (int i = 1; i <= halfSize; i++)
            {
                Console.Write(new string('.', halfSize - i));
                string str = new string(' ', 2 * i);
                char[] chr = str.ToCharArray();
                for (int j = 0; j < chr.Length / 2; j++)
                {
                    if (j % 2 == 0)
                    {
                        chr[j] = '/';
                        chr[chr.Length - j - 1] = '\\';
                    }
                }
                str = new string(chr);
                Console.Write(str);
                Console.Write(new string('.', halfSize - i));
                Console.WriteLine();
            }

            for (int i = 1; i <= halfSize; i++)
            {
                Console.Write(new string('.', i - 1));
                string str = new string(' ', 2 * (halfSize + 1) - 2 * i);
                char[] chr = str.ToCharArray();
                for (int j = 0; j < chr.Length / 2; j++)
                {
                    if (j % 2 == 0)
                    {
                        chr[j] = '\\';
                        chr[chr.Length - j - 1] = '/';
                    }
                }
                str = new string(chr);
                Console.Write(str);
                Console.Write(new string('.', i - 1));
                Console.WriteLine();
            }
        }
    }
}
