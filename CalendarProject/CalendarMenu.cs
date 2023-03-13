using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CalendarProject
{
    public class CalendarMenu
    {
        public User user;
        public void Menu(User users)
        {
            while (true)
            {
                user = users;
                Console.Clear();
                int option;
                CalendarApp calendarApp = new CalendarApp();
                Console.WriteLine("###############################");
                Console.WriteLine("         Welcome                 ");
                Console.WriteLine($"        {users.FirstName} {users.LastName}");
                Console.WriteLine("           to                 ");
                Console.WriteLine("         Calendar                 ");
                Console.WriteLine("-------------------------------\n");
                Console.WriteLine("Choose option:");
                Console.WriteLine("1. See Calendar");
                Console.WriteLine("2. See Event");
                Console.WriteLine("3. Add Event");
               // Console.WriteLine("4. See");
                Console.WriteLine("0. Logout");
                Console.WriteLine("Enter number:");
                option = calendarApp.ParseUserInput();

                switch (option)
                {
                    case 1:
                        Calendar calendar = new Calendar();
                        calendar.Intro2(user);
                        break;
                    case 2:
                        SeeEvent();
                        break;
                    case 3:
                        AddEvent();
                        break;
                    //case 4:
                    //    See();
                    //    break;
                    case 0:
                        Logout();
                        return;
                    default:
                        Console.WriteLine("Your number is invalid. try again.");
                        Console.ReadLine();
                        Menu(users);
                        break;
                }
            }
        }

        //public void See()
        //{
        //    Console.Clear();
        //    int month, year;
        //    Console.WriteLine("Write year:");
        //    year = ParseDateInput();
        //    Console.WriteLine("Write month:");
        //    month = ParseDateInput();


        //    List<int> eventDates = new List<int>();
        //    Database database = new Database();
        //    eventDates = database.EventDates(month, year, user);

        //    Console.WriteLine("First\n");
        //    Thread.Sleep(1000);
        //    //foreach (int a in eventDates)
        //    //{
        //    //    Console.WriteLine(a);
        //    //    Thread.Sleep(1000);
        //    //}
        //    int[] _array = eventDates.ToArray();

        //   // Console.WriteLine("Second");
        //   // Console.WriteLine(_array[0]);
        //    //Thread.Sleep(1000);
        //    for (int j = 0; j < _array.Length ; j++)
        //    {
        //        Console.WriteLine("Petlja\n");
        //        Thread.Sleep(1000);
        //        Console.Write(_array[j] + "  ");
        //        Thread.Sleep(1000);
        //    }
        //}

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

        public void SeeEvent()
        {
            int year;
            int month;
            int day;
            int option;
            int n;
            int i=0;
            List<Event> events;
            Console.Clear();
            Console.WriteLine("Enter year:");
            year = ParseDateInput();
            Console.WriteLine("Enter month:");
            month = ParseDateInput();
            Console.WriteLine("Enter day:");
            day = ParseDateInput();
            Database database = new Database();
            events=database.SeeEvent(day, month, year, user);
            Console.Clear();

            if(events.Count()==0)
            {
                Console.WriteLine("No events. Try with other date. ");
                Console.ReadLine();
                SeeEvent(); 
            }
            else
            {
                foreach (var e in events)
                {
                    i++;
                    Console.WriteLine($"\n{i}.Title: {e.Title}\nLocation: {e.Location}\nDate: {e.Date}\nDescription: {e.Description}\n");
                }
                i = 0;

                Console.WriteLine("Choose option:");
                Console.WriteLine("1. Delete Event");
                Console.WriteLine("0. Back to last page");
                Console.WriteLine("Enter number:");
                CalendarApp calendarApp = new CalendarApp();
                option = calendarApp.ParseUserInput();
                switch (option)
                {
                    case 1:
                        Console.WriteLine("Enter number of Event: ");
                        //n =Convert.ToInt32(Console.ReadLine());//ovde moze da pukne
                        n = ParseDateInput();
                        DeleteEvent(events, n);
                        break;
                    case 0:
                        break;
                    default:
                        CalendarApp calendar = new CalendarApp();
                        calendar.PrintMessage();
                        break;
                }
                calendarApp.BackStep();  
            } 
        }

        public void AddEvent()
        {
            string title;
            string location;
            string dateTime;
            string description;
            DateTime dateParse= DateTime.Now;//rezultat konverzija
            Console.Clear();
            Console.WriteLine("Enter Title of Event:");
            title=Console.ReadLine();
            Console.WriteLine("Enter Location:");
            location=Console.ReadLine();
            Console.WriteLine("Enter DateTime - dd-mm-yyyy hh:mm:ss");
            bool parseResult = false;   

            while (!parseResult)
            {
                Console.WriteLine("Enter valid DateTime:");
                dateTime = Console.ReadLine();
                parseResult = DateTime.TryParse(dateTime, out dateParse);

            }

            Console.WriteLine("Enter Description:");
            description = Console.ReadLine();
            Database database = new Database();

            database.AddEvent(title,location, dateParse, description,user.Id);
        }

        public void DeleteEvent(List<Event> events, int n)
        {
            int id=0;
            Database database = new Database();

            if(n>events.Count() || n <= 0)
            {
                Console.WriteLine("Your number is not valid. Try again.");
                Console.ReadLine();
                SeeEvent();
            }
            else
            {
                foreach(var e in events)
                { 
                    if (id == n - 1)
                    {
                        database.DeleteEvent(e.EventId, user.Id);
                    }
                    id++;
                }
            }    
        }

        public void Logout()
        {
            CalendarApp calendarApp = new CalendarApp();
            user = null;
            calendarApp.Start();
        }
    }
}
