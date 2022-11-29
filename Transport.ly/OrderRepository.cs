using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Transport.ly
{
    class OrderRepository : IOrderRepository
    {
        /// <summary>
        /// Get orders from Json data
        /// </summary>
        /// <returns>orders</returns>
        public IList<Order> GetOrders()
        {
            var jsonString = FileReader.ReadJsonData("JSON Files\\coding-assigment-orders.json");

            var orders = JsonConvert.DeserializeObject<Dictionary<string, Order>>(jsonString).Select(p =>
            new Order { Code = p.Key, Destination = p.Value.Destination, Priority = int.Parse(p.Key.Substring(p.Key.LastIndexOf('-') + 1)) }).ToList();

            return orders;
        }
    }
}
