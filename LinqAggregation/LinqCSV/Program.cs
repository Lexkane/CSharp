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

            var query = from car in cars
                        group car by car.Manufacturer.ToUpper();


            //query syntax
            var query2 = from car in cars
                        group car by car.Manufacturer.ToUpper() into manufacturer
                         orderby manufacturer.Key
                         select manufacturer;


            //Extension methods
            var query3 = cars.GroupBy(c => c.Manufacturer.ToUpper())
                .OrderBy(g => g.Key);




            //Group Join query

            var query4 =
                from manufacturer in manufacturers
                join car in cars on manufacturer.Name equals car.Manufacturer
                into carGroup
                select new
                {
                    Manufacturer = manufacturer,
                    Cars = carGroup
                };


            //Group Join extension methods

            var query5 =
                manufacturers.GroupJoin(cars, m => m.Name, c => c.Manufacturer, (m, g) => new
                {
                    Manufacturer = m,
                    Cars = g
                })
                .OrderBy(m => m.Manufacturer.Name);


            // Select top 3 most efficient from country
            //query    

            var query6 =
                         from manufacturer in manufacturers
                         join car in cars on manufacturer.Name equals car.Manufacturer
                         into carGroup
                         select new
                         {
                             Manufacturer = manufacturer,
                             Cars = carGroup
                         };



            // Select top 3 most efficient from country
            //query


            var query7 =
                from manufacturer in manufacturers
                join car in cars on manufacturer.Name equals car.Manufacturer
                into carGroup
                select new
                {
                    Manufacturer = manufacturer,
                    Cars = carGroup
                } into result
                group result by result.Manufacturer.Headquarters;




            // Select top 3 most efficient from country
            //extension methods

            var query8 =
                manufacturers.GroupJoin (cars, m => m.Name, c => c.Manufacturer, (m, g) => new
                {
                    Manufacturer = m,
                    Cars = g
                })
                .GroupBy(m => m.Manufacturer.Headquarters);



            //print top 3 most efficient cars per country 

            foreach ( var group in query8)
            {
                Console.WriteLine($"{group.Key}");
                foreach (var car in group.SelectMany(g => g.Cars).OrderByDescending(c => c.Combined).Take(2))
                {
                    Console.WriteLine($"\t {car.Name} :{car.Combined}");
                }
            }


            //Agregations


            //Min,Max,Average
            var query9 =
                from car in cars
                group car by car.Manufacturer into carGroup
                select new
                {
                    Name = carGroup.Key,
                    Max = carGroup.Max(c => c.Combined),
                    Min = carGroup.Min(c => c.Combined),
                    Avg = carGroup.Average(c => c.Combined)
                };



            //agregate and sort by max efficiency
            var query10 =
                from car in cars
                group car by car.Manufacturer into carGroup
                select new
                {
                    Name = carGroup.Key,
                    Max = carGroup.Max(c => c.Combined),
                    Min = carGroup.Min(c => c.Combined),
                    Avg = carGroup.Average(c => c.Combined)
                } into result
                orderby result.Max descending
                select result;


            //aggregate and sort by method extensions
            var query11 =
                cars.GroupBy(c => c.Manufacturer)
                .Select(g =>
                {
                    var results = g.Aggregate(new CarStatistics(), (acc, c) => acc.Accumulate(c), acc => acc.Compute());
                    return new
                    {
                        Name = g.Key,
                        Avg = results.Average,
                        Min = results.Min,
                        Max = results.Max
                    };

                }

                )
                .OrderByDescending(r => r.Max);




            foreach (var result in query11)
            {
                Console.WriteLine($"{result.Name}");
                Console.WriteLine($"\t Max: {result.Max}");
                Console.WriteLine($"\t Min: {result.Min}");
                Console.WriteLine($"\t Avg: {result.Avg}");
            }



            //print with grouping

            //foreach (var group in query5)
            //{
            //    Console.WriteLine(group.Manufacturer.Name);
            //    Console.WriteLine($"{group.Manufacturer.Name} : { group.Manufacturer.Headquarters}");
            //    foreach (var car in group.Cars.OrderByDescending(c=>c.Combined).Take(2))
            //    { 
            //        Console.WriteLine($"{car.Name} :{ car.Combined}");
            //    }
            //    }






            //print all cars by manufacturer
            //foreach (var result in query )
            //{
            //   Console.WriteLine($"{result.Key} has { result.Count()} cars");
            //}


            //print all cars sort by efficency
            //foreach (var group in query)
            //{
            //    Console.WriteLine(group.Key);
            //    foreach( var car in group.OrderByDescending (c=> c.Combined).Take(5))
            //        { Console.WriteLine($"\t{car.Name} :{car.Combined}"); }
            //}

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
