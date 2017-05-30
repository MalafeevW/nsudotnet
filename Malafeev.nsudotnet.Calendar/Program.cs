using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Malafeev.Nsudotnet.Calendar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter date, please ");
            string date = Console.ReadLine();
            Time resultDate;
            if (!Time.TryParse(date, out result))
            {
                Console.Write("Error date format!");
            }
            else
            {
                Time week = new Time(2016, 5, 2);
                for (int j = 0; j < 7; j++)
                {
                    Console.Write("{0,-6}", week.ToString("ddd", Culture.GetCulture("ru-ru")));
                    week = week.AddDays(1);
                }
                Console.Write();
                Time d = new Time(result.Year, result.Month, 1);
               int  i = 0;
                int beginDay = (int)d.DayOfWeek-1;
                if (beginDay == -1)
                {
                    beginDay += 7;
                }
                i = beginDay;
                int number = 1;
                Console.SetCursorPosition(i * 6, Console.CursorTop);
                Console.Write("{0,-6}", number);
                int weekend = 0;
                while(number<= Time.DaysInMonth(result.Year,result.Month))
                {
                    for (int k = i+1; k < 7; k++)
                    {
                        number++;
                        if (number > Time.DaysInMonth(result.Year,result.Month))
                        {
                            break;
                        }
                        i = -1;
                        if (k >= 5)
                        {
                            weekend++;
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        if resultDate == DateTime.Now
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                        }
                        if (number == resultDate.Day)
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                        }
                        Console.Write("{0,-6}", number);
                        Console.ResetColor();
                    }
                    Console.Write();
                    i = -1;
                }
                Console.Write("Working days: {0}" , Time.DaysInMonth(resultDate.Year, result.Month) - weekend);
                Console.ReadKey();
            }
        }
    }
}
