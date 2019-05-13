using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace LinqCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            //Alt Path D:\\CSV\\fuel.csv
          //  var cars = File.ReadAllLines("D:/CSV/fuel.csv");
            var cars = ProcessFile("fuel.csv");



            //Sort by fuel efficency
            var query = cars.OrderByDescending(c => c.Combined).ThenBy(c=>c.Name);

            var query2 = from car in cars
                        orderby car.Combined ascending, car.Name ascending
                        select car;

            var query3 =from car in cars
                       where car.Manufacturer == "BMW" && car.Year == 2016
                       orderby car.Combined descending, car.Name ascending
                       select car;

            var query4 = cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016)
                             .OrderByDescending(c => c.Combined)
                             .ThenBy(c => c.Name)
                             .Select(c => c);



            var query5 = from car in cars
                         where car.Manufacturer == "BMW" && car.Year == 2016
                         orderby car.Combined descending, car.Name ascending
                         select new
                         {
                              car.Manufacturer,
                              car.Name,
                              car.Combined
                         };



            var top = cars
                             .OrderByDescending(c => c.Combined)
                             .ThenBy(c => c.Name)
                             .Select(c => c)
                             .FirstOrDefault(c => c.Manufacturer == "BMW" && c.Year == 2016);

            var result = cars.Any(c=>c.Manufacturer=="Ford");
            var result2 = cars.All(c => c.Manufacturer == "Ford");
            var result3 = cars.All(c=>c.Manufacturer.Contains("Ford"));
            var result4 = cars.Select(c => new { c.Manufacturer, c.Name, c.Combined });


            var result5 = cars.Select(c => c.Name);

            //foreach (var name in result5)
            //{
            //    foreach (var character in name)
            //    {
            //        Console.WriteLine(name);
            //    }
            //}


            //Show characters
            var result6 = cars.SelectMany(c => c.Name);

            var result7 = cars.SelectMany(c => c.Name)
                              .OrderBy(c => c);

            foreach ( var character in result7)
            {
                Console.WriteLine(character);
            }




            var query6 = ProcessFile4("fuel.csv");





            Console.WriteLine(top.Name);

            //foreach (var car in query5.take(10))
            //{
            //    Console.writeline($"{car.manufacturer} {car.name} : {car.combined}");
            //}

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

        private static List<Car> ProcessFile4(string path)
        {
            return
                File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .ToCar()
                .ToList();
           
        }


    }
}
