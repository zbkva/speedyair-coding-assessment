using System;
using System.Collections.Generic;

namespace speedyair_coding_assessment
{
    public class InputHandler
    {
        public Schedule GetScheduleFromUser()
        {
            List<Flight> flights = new List<Flight>();

            while (true)
            {
                Console.WriteLine("Enter the details for a Flight:");
                Flight flight = new Flight();

                Console.WriteLine("Enter Flight Number:");
                flight.FlightNumber = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Departure Airport:");
                flight.DepartureAirport = Console.ReadLine();

                Console.WriteLine("Enter Arrival Airport:");
                flight.ArrivalAirport = Console.ReadLine();

                Console.WriteLine("Enter Day Number:");
                flight.DayNumber = int.Parse(Console.ReadLine());

                flights.Add(flight);

                Console.WriteLine("Do you want to add another flight? (y/n)");
                string input = Console.ReadLine();
                if (input.ToLower() != "y")
                {
                    break;
                }
            }

            return new Schedule
            {
                Flights = flights
            };
        }
    }
}