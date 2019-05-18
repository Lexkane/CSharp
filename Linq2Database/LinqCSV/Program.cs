using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Xml.Linq;
using System.Data.Entity;

namespace LinqCSV
{
    class Program
    {
        static void Main(string[] args)
        {

            //Alt Path D:\\CSV\\fuel.csv
            //  var cars = File.ReadAllLines("D:/CSV/fuel.csv");
            var records = ProcessFile("fuel.csv");
            var manufacturers = ProcessManufacturers("manufacturers.csv");
            


        //    Func<int, int> square = x => x * x;
        //    Func<int, int, int> add = (x, y) => x + y;

        ///    Expression<Func<int, int, int>> add2 = (x, y) => x + y;

         //   Func<int, int, int> addI = add2.Compile();

         //   var result = add(3, 5);
        //    var result2 = add2.Compile()(3, 5);

          //  Console.WriteLine(result);

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CarDb>());

           InsertData();
           QueryData();

                                                                

            Console.ReadKey();
        }

        private static void InsertData()
        {
            var cars = ProcessFile("fuel.csv");
            var db = new CarDb();
            db.Database.Log = Console.WriteLine;
            if (!db.Cars.Any())
            {
                foreach( var car in cars)
                {
                    db.Cars.Add(car);
                }
                db.SaveChanges();
            }
        }

        private static void QueryData()
        {
            var db = new CarDb();
            db.Database.Log = Console.WriteLine;

            //Query 
            var query = from car in db.Cars
                        orderby car.Combined descending, car.Name ascending
                        select car;


            //Extension methods

            var query2 = db.Cars.OrderByDescending(c => c.Combined).ThenBy(c => c.Name).Take(10);

            //Query BMW

            var query3 = db.Cars.Where(c => c.Manufacturer == "BMW")
                               .OrderByDescending(c => c.Combined)
                               .ThenBy(c => c.Name)
                               .Take(10);



            var query4 = db.Cars.Where(c => c.Manufacturer == "BMW")
                .OrderByDescending(c => c.Combined)
                .ThenBy(c => c.Name)
                .Take(10)
                .ToList()
                .Select(c => new { Name = c.Name.Split(' ') });

            var query5 = db.Cars.GroupBy(c => c.Manufacturer)
                .Select(g => new
                {
                    Name = g.Key,
                    Cars = g.OrderByDescending(c => c.Combined).Take(2)
                });


            var query6 =
                from car in db.Cars
                group car by car.Manufacturer into manufacturer
                select new
                {
                    Name = manufacturer.Key,
                    Cars = (from car in manufacturer
                            orderby car.Combined descending
                            select car).Take(2)
                };

            foreach( var group in query5)
            {
                Console.WriteLine(group.Name);
                foreach (var car in group.Cars)
                {
                    Console.WriteLine($"\t{car.Name}:{car.Combined}");
                }
            }


           // foreach (var car in query.Take(10))
          //  {
            //    Console.WriteLine($"{car.Name}:{car.Combined}");
            //}
        }

        //Quering XML
        private static void QueryXML()
        {
            var document = XDocument.Load("fuel3.xml");

            var query =
                from element in document.Element("Cars").Elements("Car")
                where element.Attribute("Manufacturer").Value == "BMW"
                select element.Attribute("Name").Value;

            foreach(var name in query)
            {
                Console.WriteLine(name);

            }

        }

        //Quering XML 
        private static void QueryXML2()
        {
            var document = XDocument.Load("fuel3.xml");
            

            var query =
                from element in document.Descendants("Car")
                where element.Attribute("Manufacturer")?.Value == "BMW"
                select element.Attribute("Name").Value;

            foreach (var name in query)
            {
                Console.WriteLine(name);

            }


        }



        //Quering XML  with namespaces
        private static void QueryXML3()
        {
            var document = XDocument.Load("fuel3.xml");
            var ns = (XNamespace)"http://mycars.com";
            var ex = (XNamespace)"http://mycars.com/ex";

            var query =
                from element in document.Element("Cars")?.Elements(ex + "Car") ??
                Enumerable.Empty<XElement>()
                where element.Attribute("Manufacturer")?.Value == "BMW"
                select element.Attribute("Name").Value;

            foreach (var name in query)
            {
                Console.WriteLine(name);

            }

        }


        //Creation of XML using LINQ with XML namespaces
        private static void CreateXml2()
        {
            var records3 = ProcessFile("fuel.csv");

            var ns = (XNamespace)"http://mycars.com";
            var ex = (XNamespace)"http://mycars.com/ex";

            var document3 = new XDocument();
            var cars3 = new XElement(ns+ "Cars",

            from record in records3
            select new XElement(ex+ "Car",
                    new XAttribute("Name", record.Name),
                    new XAttribute("Combined", record.Combined),
                    new XAttribute("Manufacturer", record.Manufacturer))
                    );
            cars3.Add(new XAttribute(XNamespace.Xmlns + "ex",ex));

            document3.Add(cars3);
            document3.Save("fuel5.xml");

        }


        //Creation of XML using LINQ
        private static void CreateXml1()
        {
            var records3 = ProcessFile("fuel.csv");
            var document3 = new XDocument();
            var cars3= new XElement("Cars",

            from record in records3
            select new XElement("Car",
                    new XAttribute("Name", record.Name),
                    new XAttribute("Combined", record.Combined),
                    new XAttribute("Manufacturer", record.Manufacturer))
                    );

            document3.Add(cars3);
            document3.Save("fuel4.xml");

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

        //Creation XML using Linq
        //with nested elements

        //var document1 = new XDocument();
        //var cars2 = new XElement("cars");

        //foreach (var record in records)
        //{
        //    var car1 = new XElement("car");
        //    var name = new XElement("name", record.Name);
        //    var combined = new XElement("combined", record.Combined);
        //    car1.Add(name);
        //    car1.Add(combined);

        //    cars2.Add(car1);
        //}
        //document1.Add(cars2);
        //document1.Save("fuel1.xml");



        //with nested attributes

        //var document = new XDocument();
        //var cars = new XElement("Cars");

        //foreach (var record in records)
        //{
        //    var car = new XElement("Car");
        //    var name = new XAttribute("Name", record.Name);
        //    var combined = new XAttribute("Combined", record.Combined);
        //    car.Add(name);
        //    car.Add(combined);
        //    cars.Add(car);
        //}
        //document.Add(cars);
        //document.Save("fuel2.xml");


        //with nested attributes
        //var document3 = new XDocument();
        //var cars3 = new XElement("Cars");

        //foreach (var record in records)
        //{
        //    var car = new XElement("Car", 
        //        new XAttribute("Name",record.Name),
        //        new XAttribute("Combined",record.Combined), 
        //        new XAttribute("Manufacturer",record.Manufacturer));
        //    cars3.Add(car);
        //}
        //document3.Add(cars3);
        //document3.Save("fuel3.xml");


    }
}
