using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AdvancedLinq
{
    static class MyLinqExtensions
    {
        public static IEnumerable<KeyValuePair<TKey, int>> CountBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> selector)
        {
            var counts = new Dictionary<TKey, int>();
            foreach (var item in source)
            {
                var key = selector(item);
                if (counts.ContainsKey(key))
                    counts[key]++;
                else
                    counts[key] = 1;

            }
            return counts;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //PipelineSample();
            //MusicLength();
            //ExpandingString();
            //SortingAge();
            //BishopMove();
            //BishopMoveFromQueryExpression();
            //LongestBookExample();
            DogCountSample();

        }

        private static void DogCountSample()
        {
            var str = "Dog,Cat,Rabbit,Dog,Dog,Lizard,Cat,Cat,Dog,Rabbit,Guinea Pig,Dog";

            var result = str.Split(',')
                            .CountBy(x => (x != "Dog" && x != "Cat") ? "Other" : x);

            foreach (var res in result)
                Console.WriteLine($"{res.Key}\t:{res.Value}");
        }

        private static void LongestBookExample()
        {
            var books = new[] { new { Author = "Robert Martin", Title = "Clean Code", Pages = 464},
                                new { Author = "Oliver", Title = "C# Learning", Pages = 345},
                                new { Author = "Gopi", Title = "Wonder Land", Pages = 3245},
                                new { Author = "Neha", Title = "Marken Spencer", Pages = 234},
                                new { Author = "Mruthi", Title = "Role Model", Pages = 2342},
                                new { Author = "Jamba", Title = "Rookie Magic", Pages = 345},
                                new { Author = "Crane", Title = "Bason Robins", Pages = 234},
                                new { Author = "Bishop", Title = "Major General", Pages = 456},
                                };

            //books.OrderByDescending(x => x.Pages).Take(1);
            //books.First(x => x.Pages == books.Max(b => b.Pages));
            //books.Aggregate((agg, next) => agg.Pages > next.Pages ? agg : next);
            //books.MaxBy(x => x.Pages);

        }


        private static void BishopMoveFromQueryExpression()
        {
            var result = from row in Enumerable.Range('a', 8)
                         from column in Enumerable.Range('1', 8)
                         let dx = Math.Abs(row - 'c')
                         let dy = Math.Abs(column - '6')
                         where dx == dy && dx != 0
                         select string.Format("{0}{1}", (char)row, (char)column);

            foreach (var res in result)
                Console.WriteLine(res);
        }

        private static void BishopMove()
        {
            var startingFileRank = "c6";
            var result = GetBoardPositions()
                                .Where(x => BishopCanMoveTo(x, startingFileRank));

            foreach (var res in result)
                Console.WriteLine(res);


        }

        private static IEnumerable<string> GetBoardPositions()
        {
            return Enumerable.Range('a', 8)
                                .SelectMany(
                                        x => Enumerable.Range('1', 8),
                                        (f, r) => string.Format("{0}{1}", (char)f, (char)r));
        }

        private static bool BishopCanMoveTo(dynamic StartPos, dynamic TargetPos)
        {
            var dx = Math.Abs(StartPos[0] - TargetPos[0]);
            var dy = Math.Abs(StartPos[1] - TargetPos[1]);

            return dx == dy && dx != 0;
        }

        private static void SortingAge()
        {
            var str = "Gopi Sivanappan Vasanthi, 04/08/1986;Prarthana Gopi Devika, 05/22/2012;Devi Sulochana, 03/08/1986";
            var result = str.Split(';')
                            .Select(d => d.Split(','))
                            .Select(n => new
                            {
                                Name = n[0].Trim(),
                                DateOfBirth = ParseDateOfBirthFromString(n[1]),
                                Age = CalculateAge(n[1])
                            }).OrderBy(n => n.Age);
            foreach (var item in result)
            {
                Console.WriteLine($"Name \t:{item.Name}\nAge \t:{item.Age} \n");
            }
        }

        private readonly static Func<string, DateTime> ParseDateOfBirthFromString =
                n => DateTime.ParseExact(n, "MM/dd/YYY", CultureInfo.InvariantCulture);


        private static int CalculateAge(string n)
        {
            var today = DateTime.Today;
            var Dob = ParseDateOfBirthFromString(n);
            var age = today.Year - Dob.Year;
            if (Dob > today.AddYears(-age)) age--;
            return age;
        }

        private static void ExpandingString()
        {
            var str = "2,5,7-10,11,17-18,2-7";

            var result = str.Split(',')
                .Select(s => s.Split('-'))
                .Select(s => new
                {
                    First = int.Parse(s.First()),
                    Last = int.Parse(s.Last())
                })
                .SelectMany(r => Enumerable.Range(r.First, r.Last - r.First + 1))
                .OrderBy(r => r)
                .Distinct()
                .ToList();
            foreach (var s in result)
                Console.WriteLine(s);

        }

        private static void MusicLength()
        {
            var str = "2:54,3:48,4:51,3:32,6:15,4:08,5:17,3:13,4:16,3:55,4:53,5:35,4:24";

            Console.WriteLine(
            str.Split(',')
            .Select(s => TimeSpan.Parse("0:" + s))
            .Aggregate((s, s1) => s + s1)
            );
        }

        private static void PipelineSample()
        {
            var str = "10,5,0,8,10,1,4,0,10,1";

            Console.WriteLine(str.Split(',')
                .Select(int.Parse)
                .OrderBy(s => s)
                .Skip(3)
                .Sum(s => s));
        }
    }
}
