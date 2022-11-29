using System;

namespace Transport.ly
{
    class FlightInformation : FlightMenu
    {
        public override int DisplayData(Menu menu)
        {
            Console.WriteLine(menu.Header);

            foreach (var item in menu.Items)
            {
                Console.WriteLine(item);
            }

            Console.Write("\nPress any key to return to main menu... ");
            Console.ReadKey();

            return 0;
        }   
    }
}
