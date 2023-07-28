using System;

namespace speedyair_coding_assessment
{
    public class OutputHandler
    {
        public void DisplaySchedule(ISchedule schedule)
        {
            Console.WriteLine("\nSchedule Information:");

            foreach (Flight flight in schedule.Flights)
            {
                Console.WriteLine($"Flight: {flight.FlightNumber}, departure: {flight.DepartureAirport}, " +
                                $"arrival: {flight.ArrivalAirport}, day: {flight.DayNumber} orderCount: {flight.GetCurrentLoad()}");

            }
        }
    }
}