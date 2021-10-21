using System;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using Faker.Fakers;

namespace UnitTests
{
    public class FakerTests
    {
        [SetUp]
        public void Setup()
        {
            Assembly.LoadFile(@"C:\Users\misha\RiderProjects\mpp_Faker\ArrayGenerator\bin\Debug\net5.0\ArrayGenerator.dll");
            Assembly.LoadFile(@"C:\Users\misha\RiderProjects\mpp_Faker\DoubleGenerator\bin\Debug\net5.0\DoubleGenerator.dll");
        }
        
        [TestCase(5)]
        [TestCase(5d)]
        public void Create_SimpleTypes_DoesntThrow<T>(T _)
        {
            Assert.DoesNotThrow(() => Faker.Fakers.Faker.DefaultFaker.Create<T>());
        }

        [Test]
        public void Create_DateTime_DoesntThrow()
        {
            Assert.DoesNotThrow(() => Faker.Fakers.Faker.DefaultFaker.Create<DateTime>());
            
        }
        
        [Test]
        public void Create_List_DoesntThrow()
        {
            Assert.DoesNotThrow(() => Faker.Fakers.Faker.DefaultFaker.Create<List<int>>());
        }
        
        private class A
        {
            public int x;
            public B b;

            public A(int x, B b)
            {
                this.x = x;
                this.b = b;
            }
        }

        private class B
        {
            public double x { get; set; }

            public B()
            {
                
            }

            public B(float x)
            {
                
            }
        }

        private class C
        {
            public C(D d)
            {
            }
        }

        private class D
        {
            public D(E e)
            {
            }
        }

        private class E
        {
            public E(F f)
            {
            }
        }

        private class F
        {
            public F(D d)
            {
            }
        }
    }
}