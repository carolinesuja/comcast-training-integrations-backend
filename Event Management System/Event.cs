using System;

// Main class for all events
namespace Event_Management_System
{
    class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public double Cost { get; set; }
        public int NumberOfGuests { get; set; }

        public virtual void Display()
        {
            Console.WriteLine($"Id: {EventId}, Name: {Name}, Location: {Location}, Date: {Date.ToShortDateString()}, Cost: {Cost}, Guests: {NumberOfGuests}");
        }
    }
}