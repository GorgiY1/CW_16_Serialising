using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW_16_02_Delegate
{
    internal delegate void VoidDelegate();
    delegate int IntDelegate(int x, int y);
    delegate T AddDelegate<T>(T x, T y) where T: struct;

    class AddExemple
    {
        public int AddInt(int n1, int n2)
        {
            return n1 + n2;
        }
        public double AddDouble(double n1, double n2)
        {
            return n1 + n2;
        }
        public char AddChar(char n1, char n2)
        {
            return (char)(n1 + n2);
        }

        public string AddString(string n1, string n2)
        {
            return n1 + n2;
        }
    }
    class Calculator
    {
        public int Add(int n1, int n2)
        {
            Console.WriteLine("Add");
            return n1 + n2;
        }

        public int Sub(int n1, int n2)
        {
            Console.WriteLine("Sub");
            return n1 - n2;
        }

        public int Mult(int n1, int n2)
        {
            Console.WriteLine("Mult");
            return n1 * n2;
        }

        public int Div(int n1, int n2)
        {
            Console.WriteLine("Div");
            if (n2 != 0)
            {
                return n1 / n2;
            }
            throw new DivideByZeroException();
        }
    }
    class Program
    {
        private static void Hello()
        {
            Console.WriteLine("Hello");
        }
        static void Main(string[] args)
        {
            //VoidDelegate voidDelegate = new VoidDelegate(Hello);
            //voidDelegate();

            //Calculator calculator = new Calculator();

            ////IntDelegate intDelegate = new IntDelegate(calculator.Add);

            //IntDelegate intDelegate = calculator.Add; //Групповое преоиразование методов

            //intDelegate += calculator.Sub;
            //intDelegate -= calculator.Sub;
            //intDelegate += calculator.Mult;
            //intDelegate += calculator.Div;

            //foreach (IntDelegate item in intDelegate.GetInvocationList())
            //{
            //    Console.WriteLine(item(45, 7));
            //}

            AddExemple addex = new AddExemple();

            AddDelegate<int> delInt = addex.AddInt;
            Console.WriteLine($"45 + 87 = {delInt(45,87)}");

            AddDelegate<double> delDouble = addex.AddDouble;
            Console.WriteLine($"3.76 + 4.31 = {delDouble(3.76, 4.31)}");

            AddDelegate<char> delChar = addex.AddChar;
            Console.WriteLine($" 'S' + 'H' = {delChar('S', 'H')}");

            //AddDelegate<string> delString = addex.AddString;
            //Console.WriteLine($" \"Yes\" + \"No\" = {delString("Yes", "No")}");

            Console.ReadKey();
        }
    }
}
