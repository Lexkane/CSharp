using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Xml.Linq;

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



            //Creation XML using Linq
             CreateXml2();

            QueryXML();






                       

            Console.ReadKey();
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


    }
}
