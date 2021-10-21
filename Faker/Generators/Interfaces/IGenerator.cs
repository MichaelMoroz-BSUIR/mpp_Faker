using System;

namespace Faker.Generators.Interfaces
{
    public interface IGenerator
    {
        bool CanGenerate(Type type);

        object Generate(Type type);
    }
}