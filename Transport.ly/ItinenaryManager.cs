using System;
using System.Collections.Generic;
using System.Text;

namespace Transport.ly
{
    class ItinenaryManager
    {
        public static string Itinerary(Order order)
        {
            return order.IsNotLoaded() ? $"order: {order.Code}, flightNumber: not scheduled"
                : $"order: {order.Code}, flightNumber: {order.Schedule.FlightNumber}, departure: {order.Schedule.Departure}, arrival: {order.Schedule.Arrival}, day: {order.Schedule.Day}";
        }
    }
}
