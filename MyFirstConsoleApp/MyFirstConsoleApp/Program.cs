using MyFirstClassLibrary;
using System;
using System.Collections.Generic;

namespace MyFirstConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.ReadKey();

            //Student studentObject = new Student();
            //studentObject.Name = "Gopi";
            //studentObject.Id = 123;

            Student studentObject = new Student
            {
                Name = "Nitish",
                Id = 123,
                MathMark = 89,
                EnglishMark = 34
            };
            studentObject.TotalMark(34, 56);
            studentObject.TotalMark(99);
            studentObject.TotalMark();

            //String Interpolation
            Console.WriteLine($"The student name is " +
                $"{studentObject.Name} and the Id is " +
                $"{studentObject.Id} and his total mark is " +
                $"{studentObject.TotalMark()}");

            Major obj = new Major();

            Console.WriteLine(obj.TotalMark());

            IEnumerable<string> listOfString = new List<string>();

            IDictionary<string, int> sampleDict = new Dictionary<string, int>
            {
                {"Mango", 5},
                {"Orange", 10}
            };

            foreach (var dictValue in sampleDict)
            {
                Console.WriteLine($"I want to buys {dictValue.Key} of amount {dictValue.Value}");
            }




        }
    }
}
