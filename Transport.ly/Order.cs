using System;
using System.Collections.Generic;
using System.Text;

namespace Transport.ly
{
    class Order
    {
        public int Priority { get; set; }
        public string Code { get; set; }
        public string Destination { get; set; }
        public Schedule Schedule { get; set; }

        public bool IsNotLoaded()
        {
            return Schedule == null;
        }
    }
}
