using System;
using System.Collections.Generic;
using System.Text;

namespace Transport.ly
{
    interface IOrderRepository
    {
        IList<Order> GetOrders();
    }
}
