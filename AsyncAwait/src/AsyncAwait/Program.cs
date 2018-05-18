using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncAwait
{
    public class Program
    {
        public void Main()
        {
            //var item = new Vegetable("eggplant");
            //var date = DateTime.Now;
            //var price = 1.99m;
            //Console.WriteLine($"On {date:d}, the price of {item} was {price:c2} per {item}.");
            listCollection();
            Console.ReadLine();
        }

        /**
         * Variable types string and numbers
         * */
        #region numbers
        private void OrderofOperations()
        {
            int a = 7;
            int b = 4;
            int c = 3;
            int d = (a + b) - 6 * c + (12 * 4) / 3 + 12;
            int e = (a + b) / c;
            Console.WriteLine(d);
            Console.WriteLine(e);
            Console.ReadLine();
        }

        private void integerPrecisionandLimits()
        {

            //int a = 7;
            //int b = 4;
            //int c = 3;
            //int d = (a + b) / c;
            //int e = (a + b) % c;
            //Console.WriteLine($"quotient: {d}");
            //Console.WriteLine($"remainder: {e}");
            //int max = int.MaxValue;
            //int min = int.MinValue;
            //Console.WriteLine($"The range of integers is {min} to {max}");
            //int what = max + 3;
            //int see = min - 4;
            //Console.WriteLine($"An example of overflow: {what} and  {see}");

            //Double Precision
            double a = 2304982043049328403;
            double b = 3048204393280498304;
            double c = 2340983204983204938;
            double d = a * b / c;
            Console.WriteLine(d);
            double max = double.MaxValue;
            double min = double.MinValue;
            Console.WriteLine($"The range of double is {min} to {max}");
            double third = 1.0 / 3.0;
            Console.WriteLine(third);
            Console.ReadLine();

        }

        private void fixedPointTypes()
        {
            decimal a = 1.0M;
            decimal b = 3.0M;
            decimal c = a / b;
            decimal min = decimal.MinValue;
            decimal max = decimal.MaxValue;
            Console.WriteLine($"The range of the decimal type is {min} to {max} - {c}");
            double radius = 2.50;
            double area = Math.PI * radius * radius;
            Console.WriteLine($"The circle information is Given Radius: {radius} and Calculated area:  {area}");
            Console.ReadLine();
        }
        #endregion
        /**
         * Branches and Loops
         * */
        #region Branches and loops
        private void ifStateent()
        {
            int a = 5;
            int b = 3;
            if (a + b > 10)
                Console.WriteLine("The answer is greater than 10.");
            else
                Console.WriteLine("The answer is lesser than 10.");
            Console.ReadLine();
        }
        private void loopRepeat()
        {
            int counter = 1;
            while (counter < 1)
            {
                Console.WriteLine("First Loop");
                Console.WriteLine($"The while loop counter value is: {counter}");
                counter++;
            }
            counter = 1;
            do
            {
                Console.WriteLine("Second Loop");
                Console.WriteLine($"The while loop counter value is: {counter}");
                counter++;
            } while (counter < 1);
            Console.ReadLine();
        }
        #endregion

        private void listCollection()
        {
            var names = new List<string> { "Gopi", "Ana", "Felipe" };
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }
        }

    }

    public class Vegetable
    {
        public Vegetable(string name) { Name = name; }

        public string Name { get; }

        public override string ToString() => Name;
    }

    public class Example
    {
        public enum Unit { item, pound, ounce, dozen };
    }

}
