using System;
using System.Collections.Generic;
using System.Linq;

namespace Faker.Utils
{
    class Node : IDisposable
    {
        private Node _parent;
        private Type _type;

        public Node(Node parent, Type type)
        {
            _parent = parent;
            _type = type;
        }

        public Node Parent => _parent;
        public Type Type => _type;

        public void Dispose()
        {
            _parent = null;
            _type = null;
        }
    }

    public class CyclicDependency
    {
        private const int MaxCashCount = 10;
        private static readonly Queue<Type> Queue = new Queue<Type>();

        private static bool IsCyclic(Node parent, Type type)
        {
            for (Node node = parent; node != null; node = node.Parent)
            {
                if (node.Type == type)
                {
                    return true;
                }
            }

            using var currentNode = new Node(parent, type);
            return type.GetConstructors()
                .SelectMany(constructor => constructor.GetParameters())
                .Select(p => p.ParameterType)
                .Concat(type.GetFields()
                    .Select(field => field.FieldType))
                .Any(t => IsCyclic(currentNode, t));
        }

        public static bool IsCyclic(Type type)
        {
            lock (Queue)
            {
                if (Queue.Contains(type))
                    return true;
                if (IsCyclic(null, type))
                {
                    Queue.Enqueue(type);
                    if (Queue.Count >= MaxCashCount)
                        Queue.Dequeue();
                    return true;
                }

                return false;
            }
        }
    }
}