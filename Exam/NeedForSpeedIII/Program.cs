using System;
using System.Collections.Generic;
using System.Linq;

namespace NeedForSpeedIII
{

    class Program
    {
        static void Main(string[] args)
        {
            //This problem given 90/100 point from on judge.softuni.bg

            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] infoCar = Console.ReadLine().Split("|");

                if (!cars.ContainsKey(infoCar[0]))
                {
                    cars.Add(infoCar[0], new Car(int.Parse(infoCar[1]), int.Parse(infoCar[2])));
                }
            }

            string commands = Console.ReadLine();

            while (commands != "Stop")
            {
                string[] commandsInfo = commands.Split(" : ");

                string command = commandsInfo[0];
                string model = commandsInfo[1];

                if (command == "Drive")
                {
                    int distance = int.Parse(commandsInfo[2]);
                    int fuel = int.Parse(commandsInfo[3]);


                    if (cars[model].Fuel < fuel)
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        cars[model].Mileage += distance;
                        cars[model].Fuel -= fuel;

                        Console.WriteLine($"{model} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                    }

                    if (cars[model].Mileage >= 100000)
                    {
                        cars.Remove(model);

                        Console.WriteLine($"Time to sell the {model}!");
                    }
                }
                else if (command == "Refuel")
                {
                    int fuels = int.Parse(commandsInfo[2]);

                    cars[model].Fuel += fuels;

                    if (cars[model].Fuel > 75)
                    {
                        cars[model].Fuel = 75;
                        Console.WriteLine($"{model} refueled with {cars[model].Fuel - fuels} liters");

                    }
                    else
                    {
                        Console.WriteLine($"{model} refueled with {fuels} liters");
                    }
                }
                else if (command == "Revert")
                {
                    int km = int.Parse(commandsInfo[2]);
                    cars[model].Mileage -= km;

                    if (cars[model].Mileage < 10000)
                    {
                        cars[model].Mileage = 10000;
                    }
                    else
                    {
                        Console.WriteLine($"{model} mileage decreased by {km} kilometers");
                    }
                }

                commands = Console.ReadLine();
            }

            var sortedCar = cars.OrderByDescending(x => x.Value.Mileage).ThenBy(x => x.Key);

            foreach (var item in sortedCar)
            {
                Console.WriteLine($"{item.Key} -> Mileage: {item.Value.Mileage} kms, Fuel in the tank: {item.Value.Fuel} lt.");
            }
        }
    }
    //public class Car
    //{
    //    public Car(int mileage, int fuel)
    //    {
    //        this.Mileage = mileage;
    //        this.Fuel = fuel;
    //    }

    //    public int Mileage { get; set; }
    //    public int Fuel { get; set; }
    //}
}
