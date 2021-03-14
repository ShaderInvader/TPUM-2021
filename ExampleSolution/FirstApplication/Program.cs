using System;

namespace FirstApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ExampleClass example = new ExampleClass(2, 3.14f);
            Console.WriteLine($"Example class out value: {example.Calculate()}");
        }
    }
}
