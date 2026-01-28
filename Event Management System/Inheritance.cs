using System;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Event_Management_System
{
    class WeddingEvent : Event
    {
        // overriding
        public override void Display()
        {
            Console.WriteLine($"[Wedding] Id: {EventId}, Name: {Name}, Location: {Location}, Date: {Date.ToShortDateString()}, Cost: {Cost}, Guests: {NumberOfGuests}");
        }
    }

    // Child class
    class BirthdayEvent : Event
    {
        // overriding
        public override void Display()
        {
            Console.WriteLine($"[Birthday] Id: {EventId}, Name: {Name}, Location: {Location}, Date: {Date.ToShortDateString()}, Cost: {Cost}, Guests: {NumberOfGuests}");
        }

    }

    // Child class
    class ConferenceEvent : Event
    {
        // overriding
        public override void Display()
        {
            Console.WriteLine($"[Conference] Id: {EventId}, Name: {Name}, Location: {Location}, Date: {Date.ToShortDateString()}, Cost: {Cost}, Guests: {NumberOfGuests}");

        }
    }
}
