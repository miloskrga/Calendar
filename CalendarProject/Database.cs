using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarProject
{
    public class Database
    {
        public const string ConnectionString = "Data Source=DESKTOP-58KNIID; Initial Catalog=Calendar; Integrated Security=SSPI";

        public void InsertUser(User user)
        {
            string sql = $"INSERT INTO dbo.Users(FirstName, LastName, Email,Password) VALUES('{user.FirstName}', '{user.LastName}', '{user.Email}','{user.Password}')";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
           
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Your registration was successful\n");
            CalendarApp calendarApp = new CalendarApp();
            calendarApp.BackStep();
        }

        public User FindUser(User user)
        {
           
            User user1=null;
            string sql = $"SELECT Id,FirstName,LastName FROM Users WHERE Users.Email='{user.Email}' AND Users.Password='{user.Password}'";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                user1 = new User()
                {
                    Id=sqlDataReader.GetInt32(0),
                    FirstName = sqlDataReader.GetString(1),
                    LastName = sqlDataReader.GetString(2)
                };

            }

            return user1;
        }

        public void AddEvent(string title, string location, DateTime dateTime, string description, int userId)
        {

            string sql = $"INSERT INTO dbo.Event(Title,Location,DateTime, Description, UserId) Values ('{title }','{location}','{dateTime:yyyy-MM-dd HH:mm:ss}','{description}',{userId})";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql,con);
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Your insert date and time was successful\n");
            CalendarApp calendarApp = new CalendarApp();
            calendarApp.BackStep();
        }

        public void DeleteEvent(int n, int userId)
        {
            string sql = $"delete from dbo.Event where  EventId='{n}' and UserId={userId}";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
       
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Delete of your Event was successful\n");
            CalendarApp calendarApp = new CalendarApp();
            calendarApp.BackStep();
        }

        public List<Event> SeeEvent(int day, int month, int year, User user)
        {
            List<Event> events = new List<Event>();
            string sql = $"Select EventId ,Title, Location, DateTime,Description from Event where UserId= {user.Id} and  day(DateTime)={day} and month(DateTime)={month} and year(DateTime)={year}";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Event _events = new Event()
                {
                    EventId=sqlDataReader.GetInt32(0),
                    Title = sqlDataReader.GetString(1),
                    Location=sqlDataReader.GetString(2),
                    Date=sqlDataReader.GetDateTime(3),
                    Description=sqlDataReader.GetString(4)
                };
                events.Add(_events);
            }

            return events;
        }

        public List<int> EventDates(int month, int year, User user)
        {
            List<int> dates = new List<int>();
            string sql = $"SELECT distinct day(DateTime) from Event where UserId= {user.Id} and month(DateTime)={month} and year(DateTime)={year}";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                dates.Add(sqlDataReader.GetInt32(0));
            }

            return dates;
        }

    }
}
