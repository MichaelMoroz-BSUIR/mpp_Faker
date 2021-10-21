using System;
using System.Collections.Generic;
using System.Linq;
using Faker.Generators.Interfaces;
using Faker.Utils;

namespace Faker.Fakers
{
    public class Faker
    {
        private static readonly Faker _faker = new Faker();

        public static Faker DefaultFaker => _faker;

        private static List<IGenerator> _generators;

        public Faker()
        {
            var generatorType = typeof(IGenerator);
            var impls = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(c => c.IsClass && c.GetInterfaces().Contains(generatorType) && c.IsClass)
                .Select(c => (IGenerator)Activator.CreateInstance(c));
            _generators = new List<IGenerator>(impls);
        }

        private static object GetDefaultValue(Type t)
        {
            return t.IsValueType ? Activator.CreateInstance(t) : null;
        }

        public T Create<T>() => (T)Create(typeof(T));

        private static void InitializeFields(object o)
        {
            foreach (var field in o.GetType().GetFields())
            {
                try
                {
                    if (Equals(field.GetValue(o), GetDefaultValue(field.FieldType)))
                    {
                        field.SetValue(o, Create(field.FieldType));
                    }
                }
                catch
                {
                    //some message
                }
            }
        }

        public static object Create(Type type)
        {
            if (CyclicDependency.IsCyclic(type))
            {
                throw new Exception($"{type} contains cyclical dependency");
            }

            foreach (var generator in _generators)
            {
                if (generator.CanGenerate(type))
                {
                    return generator.Generate(type);
                }
            }

            foreach (var constructor in type.GetConstructors())
            {
                try
                {
                    var args = constructor.GetParameters()
                        .Select(p => p.ParameterType)
                        .Select(Create);
                    object o = constructor.Invoke(args.ToArray());
                    InitializeFields(o);
                    return o;
                }
                catch
                {
                    //some message
                }
            }

            throw new Exception($"Cannot create object of type: {type}");
        }
    }
}