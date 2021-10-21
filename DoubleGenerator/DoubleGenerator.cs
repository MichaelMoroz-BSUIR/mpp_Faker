using System;
using Faker.Generators.Interfaces;

namespace DoubleGenerator
{
    public class DoubleGenerator : IGenerator
    {
        private readonly Random _random = new Random();
        public bool CanGenerate(Type type)
        {
            return type == typeof(double);
        }

        public object Generate(Type type)
        {
            if (CanGenerate(type))
            {
                return _random.NextDouble();
            }

            throw new ArgumentException($"Cannot create object of type: {type}");
        }
    }
}