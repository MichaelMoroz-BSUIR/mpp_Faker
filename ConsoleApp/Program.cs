using System;
using System.Collections.Generic;
using Faker.Fakers;

namespace ConsoleApp
{
    class App
    {
        static void Main(string[] args)
        {
            try
            {
                var faker = new Faker.Fakers.Faker();

                double value = faker.Create<double>();
                Console.WriteLine("Value = " + value);

                var list = faker.Create<List<List<DateTime>>>();
                foreach (var values in list)
                {
                    foreach (var fakerValue in values)
                    {
                        Console.WriteLine(fakerValue);
                    }
                }

                double[] array = faker.Create<double[]>();
                foreach (var arrayValue in array)
                {
                    Console.WriteLine(arrayValue);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}