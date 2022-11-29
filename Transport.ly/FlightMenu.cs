using System;

namespace Transport.ly
{
    class FlightMenu
    {
        /// <summary>
        /// Display data by selected menu
        /// </summary>
        /// <param name="menu">Menu</param>
        /// <returns>User selected menu number</returns>
        public virtual int DisplayData(Menu menu)
        {
            Console.Clear();
            Console.WriteLine("======= {0} =======\n", menu.Header);

            foreach (var item in menu.Items)
            {
                Console.WriteLine(item);
            }

            Console.Write("\nEnter your choice: ");

            int userInput;
            int.TryParse(Console.ReadLine(), out userInput);

            return userInput;
        }
    }
}
