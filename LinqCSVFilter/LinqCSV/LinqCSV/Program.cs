using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            //Alt Path D:\\CSV\\fuel.csv
          //  var cars = File.ReadAllLines("D:/CSV/fuel.csv");
            var cars = ProcessFile("D:/CSV/fuel.csv");



            //Sort by fuel efficency
            var query = cars.OrderByDescending(c => c.Combinded).ThenBy(c=>c.Name);

            var query2 = from car in cars
                        orderby car.Combinded ascending, car.Name ascending
                        select car;

            var query3 =from car in cars
                       where car.Manufacturer == "BMW" && car.Year == 2016
                       orderby car.Combinded descending, car.Name ascending
                       select car;

            var query4 = cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                             .OrderByDescending(c => c.Combinded)
                             .ThenBy(c => c.Name)
                             .Select(c => c);


            var top = cars
                             .OrderByDescending(c => c.Combinded)
                             .ThenBy(c => c.Name)
                             .Select(c => c)
                             .FirstOrDefault(c => c.Manufacturer == "BMW" && c.Year == 2016);

            var result = cars.Any(c=>c.Manufacturer=="Ford");
            var result2 = cars.All(c => c.Manufacturer == "Ford");
            var result3 = cars.All(c=>c.Manufacturer.Contains("Ford"));


            Console.WriteLine(top.Name);
            foreach (var car in query4.Take(10))
            {
                Console.WriteLine($"{car.Manufacturer} {car.Name} : {car.Combinded}");
            }

            Console.ReadKey();
        }
        
        private static List<Car> ProcessFile (string path)
        {
            var query =
                 from line in File.ReadAllLines(path).Skip(1)
                 where line.Length > 1
                 select Car.ParseFromCsv(line);
            return query.ToList();

        }

        private static List<Car> ProcessFile2 (string path)
        {
            return
                File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(Car.ParseFromCsv)
                .ToList();

        }

        private static List<Car> ProcessFile3(string path)
        {
            return
                File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(l => Car.ParseFromCsv(l))
                .ToList();

        }

    }
}
