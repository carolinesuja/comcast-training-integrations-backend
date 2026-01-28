using System;
using System.Collections.Generic;


namespace Event_Management_System
{
    // Event Management class with all methods and a list for events
    class EventManagement
    {
        private List<Event> events = new List<Event>();

        public void AddEvent(Event e)
        {
            events.Add(e);
            Console.WriteLine("Event Added Suiccessfully.");
        }

        public void ViewAllEvents()
        {
            if (events.Count == 0)
            {
                Console.WriteLine("No events found.");
                return;
            }

            foreach (Event e in events)
            {
                e.Display();
            }
        }

        public void ViewEventsByType<T>() where T : Event
        {
            bool found = false;
            foreach (Event e in events)
            {
                if (e is T)
                {
                    found = true;
                    break;
                }

            }
            if (!found)
            {
                Console.WriteLine($"No events of type {typeof(T).Name} found.");
            }
        }

        public void UpdateEventCost(int id, double Newcost)
        {
            foreach (Event e in events)
            {
                if (e.EventId == id)
                {
                    e.Cost = Newcost;
                    Console.WriteLine("Event Cost Updated Successfully");
                    return;
                }
            }
            Console.WriteLine("Event not found.");

        }

        public void DeleteEvent(int id)
        {
            Event EventToRemove = null;
            foreach (Event e in events)
            {
                if (e.EventId == id)
                {
                    EventToRemove = e;
                    break;
                }
            }
            if (EventToRemove != null)
            {
                events.Remove(EventToRemove);
            }
            else
            {
                Console.WriteLine("Event not found.");
            }
        }
    }

}
