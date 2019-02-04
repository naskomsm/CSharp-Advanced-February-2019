﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            // engines 
            int engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                string[] engineArgs = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                Engine engine = null;
                if(engineArgs.Length == 2)
                {
                    string model = engineArgs[0];
                    int power = int.Parse(engineArgs[1]);

                    engine = new Engine(model,power);
                }
                else if(engineArgs.Length == 4)
                {
                    string model = engineArgs[0];
                    int power = int.Parse(engineArgs[1]);
                    int displacement = int.Parse(engineArgs[2]);
                    string efficiency = engineArgs[3];
                    
                    engine = new Engine(model, power, displacement,efficiency);
                }
                else if (engineArgs.Length == 3)
                {
                    string model = engineArgs[0];
                    int power = int.Parse(engineArgs[1]);

                    bool isDisplacement = int.TryParse(engineArgs[2],out int displacement);
                    if (isDisplacement)
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        engine = new Engine(model, power, engineArgs[2]);
                    }
                }
                engines.Add(engine);
            }


            // cars
            int carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                string[] carArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = carArgs[0];
                string engineModel = carArgs[1];

                Engine engine = engines.Where(x => x.Model == engineModel).FirstOrDefault();

                Car car = null;
                if (carArgs.Length == 2)
                {
                    car = new Car(model, engine);
                }
                else if (carArgs.Length == 4)
                {
                    double weight = double.Parse(carArgs[2]);
                    string color = carArgs[3];
                    car = new Car(model, engine, weight,color);
                }
                else if(carArgs.Length == 3)
                {
                    bool isWeight = double.TryParse(carArgs[2], out double weight);
                    if (isWeight)
                    {
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        car = new Car(model, engine, carArgs[2]);
                    }
                }
                cars.Add(car);
            }


            Console.WriteLine(string.Join(Environment.NewLine,cars));
        }
    }
}
