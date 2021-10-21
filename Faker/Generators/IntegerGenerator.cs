using System;
using Faker.Generators.Interfaces;

namespace Faker.Generators
{
    public class IntegerGenerator : IGenerator
    {
        private readonly Random _random = new Random();
        
        public bool CanGenerate(Type type)
        {
            return type == typeof(int);
        }

        public object Generate(Type type)
        {
            if (CanGenerate(type))
            {
                return _random.Next();
            }

            throw new ArgumentException("Cannot create object of type: {t}");
        }
    }
}