using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarProject
{
    
    class Calendar
    {
        
        public int year;
        public int month;
        private static User user;

        public int Year { get; set; }
        public int Month { get; set; }

        public void Intro()
        {
            Console.Clear();
            Console.WriteLine("Enter your year:");
            year = ParseDateInput();
            Console.WriteLine("Enter your month:");
            month = ParseDateInput();
            Console.Clear();

            if (year > 0)
            {
                Months(year, month);
            }
            else
            {
                PrintMessage("year");
            } 
        }

        public void Intro2(User _user)
        {
            user = _user;
            Console.Clear();
            Console.WriteLine("Enter your year:");
            year = ParseDateInput();
            Console.WriteLine("Enter your month:");
            month = ParseDateInput();
            Console.Clear();

            if (year > 0)
            {
                Months(year, month);
            }
            else
            {
                PrintMessage("year");
            }
        }

        public int ParseDateInput()
        {
            int option;
            bool optionResult = int.TryParse(Console.ReadLine(), out option);

            if (optionResult == false)
            {
                option = -1;
            }
            return option;

        }
        public void PrintMessage(string str)
        {
            Console.WriteLine($"Your {str} is invalid");
            Intro();
        }

        public void Months(int year,int month)
        {
            switch (month)
            {
                case 1:
                    CalculateCalendar("January",31,month,year);
                    return;
                case 2:
                    if (year % 400 ==0)
                    {
                        CalculateCalendar("February",29 ,month, year);
                    }
                    else if (year%4==0 && year%100!=0)
                    {
                        CalculateCalendar("February",29 ,month, year);
                    }
                    else
                    {
                        CalculateCalendar("February",28 ,month, year);
                    }
                    
                    return;
                case 3:
                    CalculateCalendar("March",31 ,month, year);
                    return;
                case 4:
                    CalculateCalendar("April",30 ,month, year);
                    return;
                case 5:
                    CalculateCalendar("May",31 ,month, year);
                    return;
                case 6:
                    CalculateCalendar("June",30 ,month, year);
                    return;
                case 7:
                    CalculateCalendar("July",31 ,month, year);
                    return;
                case 8:
                    CalculateCalendar("August",31 ,month, year);
                    return;
                case 9:
                    CalculateCalendar("September",30 ,month, year);
                    return;
                case 10:
                    CalculateCalendar("October",31 ,month, year);
                    return;
                case 11:
                    CalculateCalendar("November",30 ,month, year);
                    return;
                case 12:
                    CalculateCalendar("December",31 ,month, year);
                    return;
                default:
                    PrintMessage("month");
                    return;
            } 
        }
        public static void PrintNameOfMonth(string nameOfMonth, int year)
        {
            Console.WriteLine("*******  " + year + "  *******");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("*******  " + nameOfMonth + "  *******");
            Console.WriteLine("--------------------------------\n");
            Console.WriteLine("Pon  Uto  Sre  Cet  Pet  Sub  Ned\n");
        }

        public static void CalculateCalendar(string nameOfMonth, int md,int Month, int Year)
        {
            int day = 6, month = 1, year = 2000;

            if (Year < 0)
            {
                Year *= -1;
            }

            if (Year == 0)
            {
                Console.WriteLine("Year 0 is not valid year.");
                return;
            }

            while (Year > year)
            {
                year++;
                day++;
                if (day > 7)
                {
                    day = 1;
                }
                if ((year - 1) % 4 == 0)
                {
                    if((year-1)%100==0 && (year - 1) % 400 != 0)
                    {

                    }
                    else
                    {
                        day++;
                    }
                    if (day > 7)
                    {
                        day = 1;
                    }
                }
            }

            while (Year < year)
            {
                year--;
                day--;
                if (day < 1)
                {
                    day = 7;
                }
                if ((year) % 4 == 0)
                {
                    if((year)%100==0 && (year) % 400 != 0)
                    {

                    }
                    else
                    {
                        day--;
                    }
                    if(day < 1)
                    {
                        day = 7;
                    }
                }
            }
            while (month != Month)
            {
                if (month == 2)
                {
                    if (year % 400 == 0)
                    {
                        md = 29;
                    }
                    else if (year % 4 == 0 && year % 100 != 0)
                    {
                        md = 29;
                    }
                    else
                    {
                        md = 28;
                    }
                }
                else if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                {
                    md = 31;
                }
                else
                {
                    md = 30;
                }
                for (; md > 0; md--)
                {
                    day++;
                    if (day > 7)
                    {
                        day = 1;
                    }
                }
                month++;
            }

            if (month == 2)
            {
                if (year % 400 == 0) 
                {
                    md = 29; 
                }
                else if (year % 4 == 0 && year % 100 != 0) 
                {
                    md = 29; 
                }
                else 
                { 
                    md = 28; 
                }
            }
            else if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12) 
            { 
                md = 31; 
            }
            else 
            { 
                md = 30; 
            }

            if (user != null)
            {
                PrintCalendar2(nameOfMonth, day, md, month, year);
            }

            PrintCalendar(nameOfMonth, day, md, month, year);

        }

        public static void PrintCalendar(string nameOfMonth, int p, int days,int month, int year)
        {            
            PrintNameOfMonth(nameOfMonth, year);
            int n = p;
            int s = n - 1;

            if (s > 0 && s < n && n > 1)
            {
                for (int j = 0; j < s; j++)
                {
                    Console.Write("     ");
                }
            }

            for (int i = 1; i <= days; i++)
            {
                if (i < 10 && n == 7)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(i + "    ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n");
                    n = 0;
                }
                else if (i < 10)
                {
                    Console.Write(i + "    ");
                }
                else if (n == 7)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(i + "    ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n");
                    n = 0;
                }
                else
                {
                    Console.Write(i + "   ");
                }
                n++;
            }
            Console.ReadLine();

            CalendarApp calendarApp = new CalendarApp();
            calendarApp.BackStep();
        }

        public static void PrintCalendar2(string nameOfMonth, int p, int days, int month, int year)
        {
            List<int> eventDates = new List<int>();
            Database database = new Database();
            eventDates = database.EventDates(month, year, user);
            int[] _array = eventDates.ToArray();
            PrintNameOfMonth(nameOfMonth, year);
            int n = p;
            int s = n - 1;
            bool b=true;

            if (s > 0 && s < n && n > 1)
            {
                for (int j = 0; j < s; j++)
                {
                    Console.Write("     ");
                }
            }

            for (int i = 1; i <= days; i++)
            {

                for (int j = 0; j < _array.Length; j++)
                {
                    if (i == _array[j])
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(i + "   ");
                        Console.ForegroundColor = ConsoleColor.White;
                        b = false;
                        break;
                    }                                      
                }

                if (b == true || n==7)
                {
                    if(b==false && n == 7) 
                    {
                        Console.Write("\n");
                        n = 0;
                    }
                    else if (i < 10 && n == 7)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(i + "    ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\n");
                        n = 0;
                    }
                    else if (i < 10)
                    {
                        Console.Write(i + "    ");
                    }
                    else if (n == 7)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(i + "    ");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\n");
                        n = 0;
                    }
                    else
                    {
                        Console.Write(i + "   ");
                    }                   
                }
                n++;
                b = true;
               
            }

            Console.ReadLine();

            CalendarApp calendarApp = new CalendarApp();
            calendarApp.BackStep();

        }

    }
}


