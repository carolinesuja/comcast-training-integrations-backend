using System;
using System.Collections.Generic;

namespace Event_Management_System
{
    class Program
    {
        static void Main(String[] args)
        {
            EventManagement em = new EventManagement(); // object creation for event management

            while (true)
            {
                Console.WriteLine("\n Event Management System");
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

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        WeddingEvent we = new WeddingEvent(); // Object for wedding event

                        Console.Write("Enter Id : ");
                        we.EventId = int.Parse(Console.ReadLine());

                        Console.Write("Enter Name : ");
                        we.Name = Console.ReadLine();

                        Console.Write("Enter Location : ");
                        we.Location = Console.ReadLine();

                        Console.Write("Enter Date (yyyy-mm-dd) : ");
                        we.Date = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter Cost : ");
                        we.Cost = int.Parse(Console.ReadLine());

                        Console.Write("Enter Number of Guests : ");
                        we.NumberOfGuests = int.Parse(Console.ReadLine());

                        em.AddEvent(we); // Method to add event - wedding

                        break;

                    case 2:

                        BirthdayEvent be = new BirthdayEvent(); // Object for birthday event

                        Console.Write("Enter Id : ");
                        be.EventId = int.Parse(Console.ReadLine());

                        Console.Write("Enter Name : ");
                        be.Name = Console.ReadLine();

                        Console.Write("Enter Location : ");
                        be.Location = Console.ReadLine();

                        Console.Write("Enter Date (yyyy-mm-dd) : ");
                        be.Date = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter Cost : ");
                        be.Cost = int.Parse(Console.ReadLine());

                        Console.Write("Enter Number of Guests : ");
                        be.NumberOfGuests = int.Parse(Console.ReadLine());

                        em.AddEvent(be); // Method to add event - birthday

                        break;

                    case 3:

                        ConferenceEvent ce = new ConferenceEvent(); // Object for conference event

                        Console.Write("Enter Id : ");
                        ce.EventId = int.Parse(Console.ReadLine());

                        Console.Write("Enter Name : ");
                        ce.Name = Console.ReadLine();

                        Console.Write("Enter Location : ");
                        ce.Location = Console.ReadLine();

                        Console.Write("Enter Date (yyyy-mm-dd) : ");
                        ce.Date = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter Cost : ");
                        ce.Cost = int.Parse(Console.ReadLine());

                        Console.Write("Enter Number of Guests : ");
                        ce.NumberOfGuests = int.Parse(Console.ReadLine());

                        em.AddEvent(ce); // Method to add event - conference

                        break;

                    case 4:

                        em.ViewAllEvents(); // Method to view all events

                        break;

                    case 5:

                        em.ViewEventsByType<WeddingEvent>(); // Method to add event by specific type - Wedding Event

                        break;

                    case 6:

                        em.ViewEventsByType<BirthdayEvent>(); // Method to add event by specific type - Birthday Event

                        break;

                    case 7:

                        em.ViewEventsByType<ConferenceEvent>(); // Method to add event by specific type - Conference Event

                        break;

                    case 8:

                        Console.Write("Enter Event Id : ");
                        int uid = int.Parse(Console.ReadLine());

                        Console.Write("Enter New Cost : ");
                        double newcost = double.Parse(Console.ReadLine());

                        em.UpdateEventCost(uid, newcost); // Method to update cost of events

                        break;

                    case 9:

                        Console.Write("Enter Event Id to delete : ");
                        int did = int.Parse(Console.ReadLine());
                        em.DeleteEvent(did); // Method to delete event

                        break;

                    case 10:

                        Console.Write("Exiting Program ... ");

                        return;

                }

            }
        }
    }
}