using System;
using System.Collections.Generic;

namespace Transport.ly
{
    class Program
    {
        static void Main(string[] args)
        {
            var inventory = new FlightInventories();

            GetMainMenu(inventory);
        }

        /// <summary>
        /// Get main menu to display
        /// </summary>
        /// <param name="inventory">Flight inventory</param>
        private static void GetMainMenu(FlightInventories inventory)
        {
            int userChoice;
            Menu menu = GetMainMenu();

            do
            {
                userChoice = new FlightMenu().DisplayData(menu);
                MainMenu(userChoice, inventory);
            } while (userChoice != menu.ExitValue);
        }

        /// <summary>
        /// Display data by selected main menu
        /// </summary>
        /// <param name="userChoice">Selected menu number</param>
        /// <param name="inventory">Flight inventory</param>
        private static void MainMenu(int userChoice, FlightInventories inventory)
        {
            switch (userChoice)
            {
                case 1:
                    FlightScheduleMenu(inventory);
                    break;
                case 2:
                    inventory.LoadedSchedules();
                    break;
                case 3:
                    inventory.FlightItineraries();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }

        private static void FlightScheduleMenu(FlightInventories inventory)
        {
            int userChoice;
            Menu menu;

            do
            {
                menu = inventory.GetFlightScheduleMenu();
                userChoice = new FlightMenu().DisplayData(menu);
                inventory.FlightScheduleMenuChoice(userChoice);
            } while (userChoice != menu.ExitValue);
        }
        /// <summary>
        /// Main menu
        /// </summary>
        /// <returns>Display main menu</returns>
        private static Menu GetMainMenu()
        {
            var menu = new Menu
            {
                Header = "Transport.ly",
                Items = new List<string>()
            {
                "1. Load a schedule",
                "2. List out loaded flight schedules",
                "3. Generate flight itineraries",
            }
            };

            menu.ExitValue = menu.Items.Count + 1;
            menu.Items.Add($"{menu.ExitValue}. Exit");

            return menu;
        }
    }
}
