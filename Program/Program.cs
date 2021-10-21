using System;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var faker = new Faker.Fakers.Faker();
                

                var list = faker.Create<List<List<DateTime>>>();
                foreach (var values in list)
                {
                    foreach (var fakerValue in values)
                    {
                        Console.WriteLine(fakerValue);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}