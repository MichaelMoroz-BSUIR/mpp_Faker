using System;
using System.Collections;
using System.Collections.Generic;
using Faker.Generators.Interfaces;

namespace Faker.Generators
{
    public class ListGenerator : IGenerator
    {
        private readonly Random _random = new Random();
        
        public bool CanGenerate(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>);
        }

        public object Generate(Type type)
        {
            if (CanGenerate(type))
            {
                var list = (IList)Activator.CreateInstance(type);
                var amount = _random.Next(0, 10);

                for (int i = 0; i < amount; i++)
                {
                    list.Add(Fakers.Faker.DefaultFaker.Create(type.GetGenericArguments()[0]));
                }

                return list;
            }

            throw new ArgumentException("Cannot create object of type: {t}");
        }
    }
}