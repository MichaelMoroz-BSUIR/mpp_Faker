using System;
using Faker.Generators.Interfaces;

namespace ArrayGenerator
{
    class ArrayGenerator : IGenerator
    {
        private readonly Random _random = new Random();
        public bool CanGenerate(Type type)
        {
            return type.IsArray;
        }

        public object Generate(Type type)
        {
            if (!CanGenerate(type))
            {
                throw new ArgumentException($"Cannot create object of type: {type}");
            }

            var size = _random.Next(3, 18);
            var array = (Array)Activator.CreateInstance(type, size);

            for (int i = 0; i < array.Length; i++)
            {
                array.SetValue(Faker.Fakers.Faker.Create(type.GetElementType()), i);
            }

            return array;
        }
    }
}