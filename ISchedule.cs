using System.Collections.Generic;

namespace speedyair_coding_assessment
{
    public interface ISchedule
    {
        List<Flight> Flights { get; set; }
    }

    public class Flight
    {
        public int Capacity { get; } = 20;
        public int FlightNumber { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public int DayNumber { get; set; }

        public int GetCurrentLoad () {
            return Orders.Count;
        }

        //return false if no capacity
        public bool LoadOrder (Order order) {
            if (Capacity - GetCurrentLoad() > 0)
            {
                Orders.Add(order);
                return true;
            }
            
            return false;
        }

        public List<Order> Orders { get; } = new List<Order>();
    }

}