using System.Collections.Generic;
using System.Linq;

namespace Transport.ly
{
    class FlightInventories
    {
        public IList<Order> Orders { get; private set; }
        public IList<Flight> FlightsScheduled { get; private set; }
        public IList<Schedule> Schedules { get; private set; }

        public FlightInventories()
        {
            FlightsScheduled = new List<Flight>();
            Schedules = new ScheduleRepository().GetSchedules();
        }

        public void FlightScheduleMenuChoice(int userChoice)
        {
            if (userChoice > 0 && userChoice <= Schedules.Count)
            {
                var selectedSchedule = Schedules.FirstOrDefault(s => !s.IsLoaded && s.FlightNumber == userChoice);
                if (selectedSchedule != null)
                {
                    var scheduledFlight = new Flight(20, selectedSchedule);
                    FlightsScheduled.Add(scheduledFlight);
                    FlightsScheduled = FlightsScheduled.OrderBy(f => f.Schedule.FlightNumber).ToList();
                    DisplayScheduleMessage(selectedSchedule);
                }
            }
        }

        public void DisplayScheduleMessage(Schedule schedule)
        {
            var menu = new Menu()
            {
                Items = new List<string>()
            {
                $"{FlightSchedule.DisplayMessage(schedule)}"
            }
            };

            new FlightInformation().DisplayData(menu);
        }

        public void LoadedSchedules()
        {
            var menu = new Menu()
            {
                Header = "\n======= Loaded schedules =======\n"
            };

            foreach (var flight in FlightsScheduled)
            {
                menu.Items.Add(flight.FlightSchedule());
            }

            new FlightInformation().DisplayData(menu);
        }

        public void FlightItineraries()
        {
            LoadOrdersInFlights();

            var menu = new Menu()
            {
                Header = "\n======= Flight itineraries =======\n"
            };

            foreach (var order in Orders)
            {
                menu.Items.Add(ItinenaryManager.Itinerary(order));
            }

            new FlightInformation().DisplayData(menu);
        }

        private void LoadOrdersInFlights()
        {
            Orders = new OrderRepository().GetOrders().OrderBy(o => o.Priority).ToList();

            foreach (var schedule in Schedules)
            {
                if (schedule.IsLoaded)
                {
                    var loadedFlights = FlightsScheduled.Where(f => f.Schedule == schedule).ToList();

                    foreach (var flight in loadedFlights)
                    {
                        var flightOrders = Orders.Where(o => o.IsNotLoaded() && o.Destination == schedule.Arrival).Take(flight.Capacity).Select(o => { o.Schedule = schedule; return o; }).ToList();
                        flight.Orders = flightOrders;
                    }
                }
            }
        }

        public Menu GetFlightScheduleMenu()
        {
            var menu = new Menu
            {
                Header = "Choose a schedule to load"
            };

            foreach (var item in Schedules)
            {
                if (!item.IsLoaded)
                {
                    menu.Items.Add(item.ToString());
                }
            }

            menu.ExitValue = Schedules.Count + 1;
            menu.Items.Add($"{menu.ExitValue}. Main menu");

            return menu;
        }
    }
}
