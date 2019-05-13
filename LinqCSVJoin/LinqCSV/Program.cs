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
            var manufacturers = ProcessManufacturers("manufacturers.csv");


            var query =
                   from car in cars
                   where car.Manufacturer == "BMW" && car.Year == 2016
                   orderby car.Combined descending, car.Name ascending
                   select new
                   {
                       car.Manufacturer,
                       car.Name,
                       car.Combined
                   };



            //query syntax
            var query2 =
                from car in cars
                join manufacturer in manufacturers on car.Manufacturer equals manufacturer.Name
                orderby car.Combined descending, car.Name ascending
                select new
                {
                    manufacturer.Headquarters,
                    car.Name,
                    car.Combined
                };


            //method syntax
            var query3 = cars.Join(manufacturers, c => c.Manufacturer,
                                  m => m.Name,

                                  (c, m) => new
                                  {
                                      m.Headquarters,
                                      c.Name,
                                      c.Combined
                                  }
                                  )
                                  .OrderByDescending(c => c.Combined)
                                  .ThenBy(c => c.Name);


            //method syntax

            var query4 = cars.Join(manufacturers, c => c.Manufacturer,
                                 m => m.Name,

                                 (c, m) => new
                                 {
                                     Car = c,
                                     Manufacturer = m
                                 })
                                 .OrderByDescending(c => c.Car.Combined)
                                 .ThenBy(c => c.Car.Name)
                                 .Select(c => new
                                 {
                                     c.Manufacturer.Headquarters,
                                     c.Car.Name,
                                     c.Car.Combined
                                 });


            //query syntax
            var query5 =
                from car in cars
                join manufacturer in manufacturers
                    on new { car.Manufacturer, car.Year } 
                    equals
                    new { Manufacturer=manufacturer.Name,manufacturer.Year}
                orderby car.Combined descending, car.Name ascending
                select new
                {
                    manufacturer.Headquarters,
                    car.Name,
                    car.Combined
                };


            //method syntax

            var query6 = cars.Join(manufacturers, c => new { c.Manufacturer, c.Year},
                               m => new {Manufacturer= m.Name,m.Year },

                               (c, m) => new
                               {
                                   Car = c,
                                   Manufacturer = m
                               })
                               .OrderByDescending(c => c.Car.Combined)
                               .ThenBy(c => c.Car.Name)
                               .Select(c => new
                               {
                                   c.Manufacturer.Headquarters,
                                   c.Car.Name,
                                   c.Car.Combined
                               });




            foreach (var car in query3.Take(10))
            {
                Console.WriteLine($"{car.Headquarters} {car.Name} : {car.Combined}");
            }


            Console.ReadKey();
        }


        private static List<Manufacturer> ProcessManufacturers(string path)
        {
            var query =
                File.ReadAllLines(path)
                    .Where(l => l.Length > 1)
                    .Select(l =>
                    {
                        var columns = l.Split(',');
                        return new Manufacturer
                        {
                            Name = columns[0],
                            Headquarters = columns[1],
                            Year = int.Parse(columns[2])
                        };
                    }

                    );
            return query.ToList();
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
