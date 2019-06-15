using System;

namespace Cars
{
    public class Car
    {
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Displacement { get; set; }
        public int Cylinders { get; set; }
        public int City { get; set; }
        public int Highway { get; set; }
        public int Combined
        {
            get; set;
        }

        internal static Car ParseFileToCar(string line)
        {
            string[] lineElements = line.Split(',');

            var car = new Car
            {
                Year = Convert.ToInt32(lineElements[0]),
                Manufacturer = lineElements[1],
                Name = lineElements[2],
                Displacement = Convert.ToDouble(lineElements[3]),
                Cylinders = Convert.ToInt32(lineElements[4]),
                City = Convert.ToInt32(lineElements[5]),
                Highway = Convert.ToInt32(lineElements[6]),
                Combined = Convert.ToInt32(lineElements[7])
            };

            return car;
        }
    }
}
