using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessCars("fuel.csv");
            var records = ProcessCars("fuel.csv");
            var manufacturers = ProcessManufacturer("manufacturer.csv");

            var document = new XDocument();
            var xcars = new XElement("Cars");



            //var query = cars.OrderByDescending(c => c.Combined)
            //                 .ThenBy(c => c.Name);

            var query1 = from car in cars
                         join manufacturer in manufacturers
                             on new { car.Manufacturer, car.Year }
                                 equals
                                 new { Manufacturer = manufacturer.Name, manufacturer.Year }
                         orderby car.Combined descending, car.Name ascending
                         select new
                         {
                             car.Manufacturer,
                             manufacturer.Headquarters,
                             car.Name,
                             car.Combined
                         };

            //Extension method syntax

            var query2 = cars
                .Join(manufacturers,
                    c => new { c.Manufacturer, c.Year },
                    m => new { Manufacturer = m.Name, m.Year },
                    (c, m) =>
                    new
                    {
                        c.Manufacturer,
                        m.Headquarters,
                        c.Name,
                        c.Combined
                    })
                .OrderByDescending(c => c.Combined)
                .ThenBy(c => c.Name)
                .ToList();

            //Console.WriteLine(DateTime.Now.ToString());
            //foreach (var car in query1.Take(10))
                //Console.WriteLine($"{car.Manufacturer} : {car.Headquarters} : {car.Name} : {car.Combined}");
            //Console.WriteLine(DateTime.Now.ToString());


            var query3 = from car in cars
                         group car by car.Manufacturer.ToUpper() into manufacturer
                         orderby manufacturer.Key
                         select manufacturer;

            var query4 = cars.GroupBy(c => c.Manufacturer.ToUpper())
                               .OrderBy(g => g.Key);

            var query5 = from manufacturer in manufacturers
                         join car in cars on manufacturer.Name equals car.Manufacturer
                         into carGroup
                         orderby manufacturer.Name
                         select new
                         {
                             manufacturer,
                             carGroup
                         };

            var query6 = manufacturers
                            .GroupJoin(cars,
                                        m => m.Name,
                                        c => c.Manufacturer,
                                        (m, c) => new
                                        {
                                            manufacturer = m,
                                            carGroup = c
                                        })
                            .OrderBy(g => g.manufacturer.Name);


            foreach (var group in query6)
            {
                //Console.WriteLine($"{group.manufacturer.Name} : {group.manufacturer.Headquarters}");
                foreach (var result in group.carGroup.OrderByDescending(r => r.Combined).Take(3))
                {
                    //Console.WriteLine($"\t {result.Name} : {result.Combined}");
                }
            }

            var query7 = from manufacturer in manufacturers
                         join car in cars on manufacturer.Name equals car.Manufacturer
                         into carGroup
                         select new
                         {
                             Manufacturer = manufacturer,
                             Car = carGroup
                         } into result
                         group result by result.Manufacturer.Headquarters;

            var query8 = manufacturers
                            .GroupJoin(cars,
                                        m => m.Name,
                                        c => c.Manufacturer,
                                        (m, g) => new
                                        {
                                            Manufacturer = m,
                                            Car = g
                                        })
                                        .GroupBy(m => m.Manufacturer.Headquarters);


            foreach(var group in query8)
            {
                //Console.WriteLine($"{group.Key}");
                foreach(var car in group
                                    .SelectMany(g => g.Car)
                                    .OrderByDescending(c => c.Combined)
                                    .Take(3))
                {
                    //Console.WriteLine($"\t{car.Name} : {car.Combined}");
                }
            }

            var query9 = from car in cars
                         group car by car.Manufacturer into carGroup
                         select new
                         {
                             Name = carGroup.Key,
                             Max = carGroup.Max(c => c.Combined),
                             Min = carGroup.Min(c => c.Combined),
                             Avg = carGroup.Average(c => c.Combined)
                         };

            var query10 = cars
                            .GroupBy(c => c.Manufacturer)
                            .Select(g => 
                                {
                                    var result = g.Aggregate
                                                    (new CarStatistics(), 
                                                        (acc, c) => acc.Accumulate(c), 
                                                        acc => acc.Compute());

                                    return new
                                    {
                                        Name = g.Key,
                                        result.Min,
                                        result.Max,
                                        result.Avg
                                    };
                                });

            foreach(var result in query10.OrderByDescending(c => c.Max))
            {
                Console.WriteLine($"{result.Name}");
                Console.WriteLine($"\t Max : {result.Max}");
                Console.WriteLine($"\t Min : {result.Min}");
                Console.WriteLine($"\t Avg : {result.Avg}");
            }
        }

        private static IEnumerable<Manufacturer> ProcessManufacturer(string path)
        {
            var manufacturer = File.ReadAllLines(path)
                                .Where(line => line.Length > 1)
                                .Skip(1)
                                .ToManufacturer()
                                .ToList();

            return manufacturer;

        }

        private static List<Car> ProcessCars(string path)
        {
            var cars = File.ReadAllLines(path)
                            .Where(line => line.Length > 1)
                            .Skip(1)
                            .Select(Car.ParseFileToCar)
                            .ToList();

            var carq = from line in File.ReadAllLines(path).Skip(1)
                       where line.Length > 1
                       select Car.ParseFileToCar(line);

            cars = carq.ToList();


            return cars;


        }
    }

    public class CarStatistics
    {
        public int Max { get; set; }
        public int Min { get; set; }
        public double Avg { get; set; }

        public int Total { get; set; }
        public int Count { get; set; }

        public CarStatistics()
        {
            Max = Int32.MinValue;
            Min = Int32.MaxValue;
        }

        public CarStatistics Accumulate(Car car)
        {
            Total += car.Combined;
            Count++;
            Max = Math.Max(Max,car.Combined);
            Min = Math.Min(Min, car.Combined);
            return this;
        }

        public CarStatistics Compute()
        {
            Avg = Total / Count;
            return this;
        }
    }
    public static class CarExtenstions
    {
        public static IEnumerable<Manufacturer> ToManufacturer(this IEnumerable<string> source)
        {
            foreach (var line in source)
            {
                var lineElements = line.Split(',');

                var manufacturer = new Manufacturer
                {
                    Name = lineElements[0],
                    Headquarters = lineElements[1],
                    Year = int.Parse(lineElements[2])
                };
                yield return manufacturer;
            }
        }
    }
}
