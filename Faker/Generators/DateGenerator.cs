using System;
using Faker.Generators.Interfaces;

namespace Faker.Generators
{
    public class DateGenerator : IGenerator
    {
        private readonly Random _random = new Random();
        
        public bool CanGenerate(Type type)
        {
            return type == typeof(DateTime);
        }

        public object Generate(Type type)
        {
            if (CanGenerate(type))
            {
                return new DateTime(_random.Next(1921, 2021), _random.Next(1, 12), _random.Next(1, 28));
            }

            throw new ArgumentException("Cannot create object of type: {t}");
        }
    }
}