using System;


namespace Event_Management_System
{
    class WeddingEvent : Event
    {
        public override void Display()
        {
            Console.WriteLine($"[Wedding] Id: {EventId}, Name: {Name}, Location: {Location}, Date: {Date.ToShortDateString()}, Cost: {Cost}, Guests: {NumberOfGuests}");
        }
    }

    class BirthdayEvent : Event
    {
        public override void Display()
        {
            Console.WriteLine($"[Birthday] Id: {EventId}, Name: {Name}, Location: {Location}, Date: {Date.ToShortDateString()}, Cost: {Cost}, Guests: {NumberOfGuests}");
        }
    }

    class ConferenceEvent : Event
    {
        public override void Display()
        {
            Console.WriteLine($"[Conference] Id: {EventId}, Name: {Name}, Location: {Location}, Date: {Date.ToShortDateString()}, Cost: {Cost}, Guests: {NumberOfGuests}");
        }
    }
}
