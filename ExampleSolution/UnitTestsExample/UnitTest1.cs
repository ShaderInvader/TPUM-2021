using FirstApplication;
using NUnit.Framework;

namespace UnitTestsExample
{
    public class Tests
    {
        private ExampleClass example;

        [SetUp]
        public void Setup()
        {
            example = new ExampleClass(2, 3.14f);
        }

        [Test]
        public void Test1()
        {
            Assert.AreEqual(6.28f, example.Calculate(), 0.0000001d);
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(2, example.firstField);
        }
    }
}