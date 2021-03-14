using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApplication
{
    public class ExampleClass
    {
        public int firstField;
        private float secondField;

        public ExampleClass(int first, float second)
        {
            firstField = first;
            secondField = second;
        }

        public float Calculate()
        {
            return firstField * secondField;
        }
    }
}
