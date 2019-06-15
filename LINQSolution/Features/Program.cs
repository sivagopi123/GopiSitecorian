using System;
using System.Collections.Generic;

namespace Features
{
    class Program
    {

        static void Main(string[] args)
        {
            Func<int, int> square = x => x * x;

            Func<int, int, int> add = (x, y) => x + y;

            Func<int, int> name = x =>
            {
                //dosomething
                return x;
            };

            Action<int> nameAction = x =>
            {
                Console.WriteLine(x);
            };

            Console.WriteLine(square(add(10, 34)));
            Console.Read();
        }
    }

    public static class Mylinq
    {
        public static int Count<T>(this IEnumerable<T> sequence)
        {
            int count = 0;
            foreach (var item in sequence)
            {
                count += 1;
            }
            return count;

        }
    }

}
