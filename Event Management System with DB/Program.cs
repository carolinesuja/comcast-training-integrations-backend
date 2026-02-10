using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient; // modern .NET so we use nuget package Microsoft.Data.SqlClient


namespace Event_Management_System
{
    // event class - parent class
    class Event
    {
        // properties - gets and sets values
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public double Cost { get; set; }
        public int NumberOfGuests { get; set; }
        public string EventType { get; set; }
    }

    // wedding event class - child class
    class WeddingEvent : Event
    {
        //constructor
        public WeddingEvent()
        {
            EventType = "Wedding"; // when object is created type is assigned 
        }
    }

    // birthday event class - child class
    class BirthdayEvent : Event
    {
        // constructor
        public BirthdayEvent()
        {
            EventType = "Birthday"; // when object is created type is assigned
        }
    }

    // conference event class - child class
    class ConferenceEvent : Event
    {
        // constructor
        public ConferenceEvent()
        {
            EventType = "Conference"; // when object is created type is assigned
        }
    }

    // event management class with all methods 
    class EventManagement
    {
        // connection string to connect to the DB , tells which server,db and authentication mode
        string connectionString =
        @"Server=(localdb)\MSSQLLocalDB;
          Database=EventManagementDB;
          Trusted_Connection=True;";

        // add event method
        public void AddEvent(Event e)
        {
            // SqlConnection - opens a connection to SQL Server
            // using - automatically closes connection
            using (SqlConnection con = new SqlConnection(connectionString))  
            {
                // parameterised query
                string query = @"INSERT INTO Events
                                VALUES (@Id,@Name,@Location,@Date,@Cost,@Guests,@Type)";
                
                // executes query , links query with connection
                SqlCommand cmd = new SqlCommand(query, con);

                // maps C# values to SQL parameters
                cmd.Parameters.AddWithValue("@Id", e.EventId);
                cmd.Parameters.AddWithValue("@Name", e.Name);
                cmd.Parameters.AddWithValue("@Location", e.Location);
                cmd.Parameters.AddWithValue("@Date", e.Date);
                cmd.Parameters.AddWithValue("@Cost", e.Cost);
                cmd.Parameters.AddWithValue("@Guests", e.NumberOfGuests);
                cmd.Parameters.AddWithValue("@Type", e.EventType);

                // opens DB connection
                con.Open();
                // makes changes in the database
                cmd.ExecuteNonQuery();
            }

            Console.WriteLine("Event added successfully.");
        }

        // view all events method
        public void ViewAllEvents()
        {
            // SqlConnection - opens a connection to SQL Server
            // using - automatically closes connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Events";

                // executes query , links query with connection
                SqlCommand cmd = new SqlCommand(query, con);

                // opens DB connection
                con.Open();
                //SqlDataReader - reads data row by row
                SqlDataReader dr = cmd.ExecuteReader();

                if (!dr.HasRows)
                {
                    Console.WriteLine("No events found.");
                    return;
                }

                while (dr.Read())
                {
                    // access column by name
                    Console.WriteLine(
                        $"[{dr["EventType"]}] " +
                        $"Id:{dr["EventId"]}, " +
                        $"Name:{dr["Name"]}, " +
                        $"Location:{dr["Location"]}, " +
                        $"Date:{dr["Date"]}, " +
                        $"Cost:{dr["Cost"]}, " +
                        $"Guests:{dr["NumberOfGuests"]}");
                }
            }
        }

        // view event by type method
        public void ViewEventsByType(string type)
        {
            // SqlConnection - opens a connection to SQL Server
            // using - automatically closes connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // parameterised query
                string query = "SELECT * FROM Events WHERE EventType=@Type";
                // executes query , links query with connection
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Type", type);

                // opens DB connection
                con.Open();
                //SqlDataReader - reads data row by row
                SqlDataReader dr = cmd.ExecuteReader();

                if (!dr.HasRows)
                {
                    Console.WriteLine($"No {type} events found.");
                    return;
                }

                while (dr.Read())
                {
                    // access column by name
                    Console.WriteLine(
                        $"Id:{dr["EventId"]}, " +
                        $"Name:{dr["Name"]}, " +
                        $"Location:{dr["Location"]}, " +
                        $"Date:{dr["Date"]}, " +
                        $"Cost:{dr["Cost"]}, " +
                        $"Guests:{dr["NumberOfGuests"]}");
                }
            }
        }

        // update cost method
        public void UpdateEventCost(int id, double cost)
        {
            // SqlConnection - opens a connection to SQL Server
            // using - automatically closes connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // parameterised query
                string query = "UPDATE Events SET Cost=@Cost WHERE EventId=@Id";
                // executes query , links query with connection
                SqlCommand cmd = new SqlCommand(query, con);

                // maps C# values to SQL parameters
                cmd.Parameters.AddWithValue("@Cost", cost);
                cmd.Parameters.AddWithValue("@Id", id);

                // opens DB connection
                con.Open();
                // makes changes in the database
                int rows = cmd.ExecuteNonQuery();

                Console.WriteLine(rows > 0 ? "Cost updated." : "Event not found.");
            }
        }

        // delete event method
        public void DeleteEvent(int id)
        {
            // SqlConnection - opens a connection to SQL Server
            // using - automatically closes connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // parameterised query
                string query = "DELETE FROM Events WHERE EventId=@Id";
                // executes query , links query with connection
                SqlCommand cmd = new SqlCommand(query, con);
                // maps C# values to SQL parameters
                cmd.Parameters.AddWithValue("@Id", id);

                // opens DB connection
                con.Open();
                // makes changes in the database
                int rows = cmd.ExecuteNonQuery();

                Console.WriteLine(rows > 0 ? "Event deleted." : "Event not found.");
            }
        }
    }

    // main class
    class Program
    {
        static void Main(string[] args)
        {
            EventManagement em = new EventManagement();

            while (true)
            {
                Console.WriteLine("\n--- EVENT MANAGEMENT SYSTEM ---");
                Console.WriteLine("1. Add Wedding Event");
                Console.WriteLine("2. Add Birthday Event");
                Console.WriteLine("3. Add Conference Event");
                Console.WriteLine("4. View All Events");
                Console.WriteLine("5. View Wedding Events");
                Console.WriteLine("6. View Birthday Events");
                Console.WriteLine("7. View Conference Events");
                Console.WriteLine("8. Update Event Cost");
                Console.WriteLine("9. Delete Event");
                Console.WriteLine("10. Exit");

                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        WeddingEvent we = new WeddingEvent();

                        Console.Write("Id: ");
                        we.EventId = int.Parse(Console.ReadLine());

                        Console.Write("Name: ");
                        we.Name = Console.ReadLine();

                        Console.Write("Location: ");
                        we.Location = Console.ReadLine();

                        Console.Write("Date (yyyy-mm-dd): ");
                        we.Date = DateTime.Parse(Console.ReadLine());

                        Console.Write("Cost: ");
                        we.Cost = double.Parse(Console.ReadLine());

                        Console.Write("Guests: ");
                        we.NumberOfGuests = int.Parse(Console.ReadLine());

                        em.AddEvent(we);
                        break;

                    case 2:
                        BirthdayEvent be = new BirthdayEvent();

                        Console.Write("Id: ");
                        be.EventId = int.Parse(Console.ReadLine());

                        Console.Write("Name: ");
                        be.Name = Console.ReadLine();

                        Console.Write("Location: ");
                        be.Location = Console.ReadLine();

                        Console.Write("Date (yyyy-mm-dd): ");
                        be.Date = DateTime.Parse(Console.ReadLine());

                        Console.Write("Cost: ");
                        be.Cost = double.Parse(Console.ReadLine());

                        Console.Write("Guests: ");
                        be.NumberOfGuests = int.Parse(Console.ReadLine());

                        em.AddEvent(be);
                        break;

                    case 3:
                        ConferenceEvent ce = new ConferenceEvent();

                        Console.Write("Id: ");
                        ce.EventId = int.Parse(Console.ReadLine());

                        Console.Write("Name: ");
                        ce.Name = Console.ReadLine();

                        Console.Write("Location: ");
                        ce.Location = Console.ReadLine();

                        Console.Write("Date (yyyy-mm-dd): ");
                        ce.Date = DateTime.Parse(Console.ReadLine());

                        Console.Write("Cost: ");
                        ce.Cost = double.Parse(Console.ReadLine());

                        Console.Write("Guests: ");
                        ce.NumberOfGuests = int.Parse(Console.ReadLine());

                        em.AddEvent(ce);
                        break;

                    case 4:
                        em.ViewAllEvents();
                        break;

                    case 5:
                        em.ViewEventsByType("Wedding");
                        break;

                    case 6:
                        em.ViewEventsByType("Birthday");
                        break;

                    case 7:
                        em.ViewEventsByType("Conference");
                        break;

                    case 8:
                        Console.Write("Event Id: ");
                        int uid = int.Parse(Console.ReadLine());

                        Console.Write("New Cost: ");
                        double cost = double.Parse(Console.ReadLine());

                        em.UpdateEventCost(uid, cost);
                        break;

                    case 9:
                        Console.Write("Event Id: ");
                        int did = int.Parse(Console.ReadLine());

                        em.DeleteEvent(did);
                        break;

                    case 10:
                        Console.WriteLine("Exiting program...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}
