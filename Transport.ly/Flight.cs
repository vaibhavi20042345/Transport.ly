using System.Collections.Generic;

namespace Transport.ly
{
    class Flight
    {
        public int Capacity { get; private set; }
        public Schedule Schedule { get; private set; }
        public IList<Order> Orders { get; set; }

        public Flight(int capacity, Schedule schedule)
        {
            Capacity = capacity;
            schedule.IsLoaded = true;
            Schedule = schedule;
            Orders = new List<Order>();
        }

        public string FlightSchedule()
        {
            return $"Flight: {Schedule.FlightNumber}, departure: {Schedule.Departure}, arrival: {Schedule.Arrival}, day: {Schedule.Day}";
        }
    }
}
