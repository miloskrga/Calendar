using System;

using System.Threading;

namespace CalendarProject
{
    class CalendarApp
    {       
        private static User _user;
       
        public void Start()
        {
           
            while (true)
            {
                Console.Clear();
                Console.WriteLine("###############################");
                Console.WriteLine("         Welcome                 ");
                Console.WriteLine("           to                 ");
                Console.WriteLine("         Calendar                 ");
                Console.WriteLine("-------------------------------\n");
                Console.WriteLine("Choose option:");
                Console.WriteLine("1. See Calendar");
                Console.WriteLine("2. Registration");
                Console.WriteLine("3. Login");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter number:");
                int option = ParseUserInput();
                Console.Clear();

                switch (option)
                {
                    case 1:
                        Calendar calendar = new Calendar();
                        calendar.Intro();
                        break;
                    case 2:
                        Registration();
                        break;
                    case 3:
                        Login();
                        break;
                    case 0:
                        Environment.Exit(-1);
                        break;
                    default:
                        PrintMessage();
                        break;
                }
            }
            
        }
        public int ParseUserInput()
        {
            int option;
            bool optionResult = int.TryParse(Console.ReadLine(), out option);
           

            if (optionResult == false)
            {
                option = -1;
            }
            return option;

        }

        public void Registration()
        {
            Database database = new Database();
            User user = new User();
            Console.WriteLine("Enter your First Name:");
            user.FirstName = Console.ReadLine();
            Console.WriteLine("Enter your Last Name:");
            user.LastName = Console.ReadLine();
            Console.WriteLine("Enter your Email:");
            user.Email = Console.ReadLine();
            Console.WriteLine("Enter your Password:");
            user.Password = Console.ReadLine();

            PrintDotAnimation();
            Console.WriteLine();
            database.InsertUser(user);
        }

        public void Login()
        {
            Console.Clear();
            User user1;
            Database database = new Database();
            User user = new User();
            Console.WriteLine("Entr your email:");
            user.Email = Console.ReadLine();
            Console.WriteLine("Enter your password:");
            user.Password = Console.ReadLine();
            PrintDotAnimation();
            user1 = database.FindUser(user);
            if (user1 != null)
            {
                _user = user1;
                CalendarMenu calculatorMenu = new CalendarMenu();
                calculatorMenu.Menu(user1);
            }
            else
            {
                Console.WriteLine("Your Email or password is invalid. Try again.");
                Console.ReadLine();
                Login();
            }

        }

        public void BackStep()
        { 
            int option;
            
            Console.WriteLine("0. Back to last page");
            option = ParseUserInput();

            switch (option)
            {
                case 0:
                    if (_user != null ) 
                    {
                        CalendarMenu calendarMenu = new CalendarMenu();
                        calendarMenu.Menu(_user);                       
                    }
                    else
                    {
                        Start();
                        return;
                    }

                    break;
                default:
                    PrintMessage();
                    BackStep();
                    return;
            }
        }

        public void PrintDotAnimation(int timer = 10)
        {
            for(int i = 0; i < timer; i++)
            {
                Console.Write(".");
                Thread.Sleep(200); 
            }
        }

        public void PrintMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Your option was not correct. Try again.\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
