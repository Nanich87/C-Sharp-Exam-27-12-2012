using System;

namespace NextDay
{
    class Program
    {
        static void Main()
        {
            int day = int.Parse(Console.ReadLine());
            int month = int.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());

            DateTime today = new DateTime(year, month, day);
            DateTime nextDay = today.AddDays(1);

            Console.WriteLine(nextDay.ToString("d.M.yyyy"));
        }
    }
}
