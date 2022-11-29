﻿namespace Transport.ly
{
    class Schedule
    {
        public int FlightNumber { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public int Day { get; set; }
        public bool IsLoaded { get; set; }

        public override string ToString()
        {
            return $"Flight: {FlightNumber}, departure: {Departure},  arrival: {Arrival}, day: {Day}";
        }
    }
}
