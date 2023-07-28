using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace speedyair_coding_assessment
{
    class Program
    {
        static void Main(string[] args)
        {
            //get schedule from user
            Schedule schedule = GetFlightScheduleFromUser();

            //load orders from json
            string jsonFilePath = "coding-assigment-orders.json";
            Dictionary<string, Order> orders = LoadOrdersFromJsonFile(jsonFilePath);

            foreach (KeyValuePair<string, Order> orderPair in orders)
            {
                if (!AssignOrderToFlights(schedule, orderPair.Value))
                {
                    Console.WriteLine("No flight with capacity or matching destination found for order ", orderPair.Key);
                }
            }
            
            //display schedule
            DisplayFlightSchedule(schedule);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static Schedule GetFlightScheduleFromUser()
        {
            InputHandler inputHandler = new InputHandler();
            Schedule schedule = inputHandler.GetScheduleFromUser();
            return schedule;
        }

        static Dictionary<string, Order> LoadOrdersFromJsonFile(string jsonFilePath)
        {
            string jsonString = File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<Dictionary<string, Order>>(jsonString);
        }

        static void DisplayFlightSchedule(Schedule schedule)
        {
            OutputHandler outputHandler = new OutputHandler();
            outputHandler.DisplaySchedule(schedule);
        }

        static bool AssignOrderToFlights(Schedule schedule, Order order)
        {
            var sortedFlights = schedule.Flights.OrderBy(f => f.DayNumber).ToList();
            foreach(var flight in sortedFlights)
            {
                if (flight.ArrivalAirport == order.Destination)
                {
                    if (flight.LoadOrder(order))
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
    }
}
