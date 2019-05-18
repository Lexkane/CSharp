using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LinqCSV
{
    public class Car
    {
        [Key]
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public double Displacement { get; set; }
        public int Cylinders { get; set; }
        public int City { get; set; }
        public int Highway { get; set; }
        public int Combined { get; set; }



        public Car(int year, string manufacturer, string name, double displacement, int cylinders, int city, int highway, int combined)
        {
            this.Year = year;
            this.Manufacturer = manufacturer;
            this.Name = name;
            this.Displacement = displacement;
            this.Cylinders = cylinders;
            this.City = city;
            this.Highway = highway;
            this.Combined = combined;
        }

        public Car() { }

        //public override string ToString()
        //{
        //  return String.Format("Year:{0},Manuacturer :{1}, Name:{2},Displacement:{3},Cylinders:{4}, City:{5}:, Highway:{6},{Combined}{7}",
        //    Year,Manufacturer,Name,Displacement,Cylinders,City,Highway,Combinded);
        //}

        internal static Car ParseFromCsv(string line)
        {
            var columns = line.Split(',');
            int x0, x4, x5, x6, x7;
            string x1, x2;
            double x3;
            int.TryParse(columns[0], out x0);
            x1 = columns[1];
            x2 = columns[2];
            x3 = double.Parse(columns[3], CultureInfo.InvariantCulture);
            int.TryParse(columns[4], out x4);
            int.TryParse(columns[5], out x5);
            int.TryParse(columns[6], out x6);
            int.TryParse(columns[7], out x7);
            return new Car(x0, x1, x2, x3, x4, x5, x6, x7);
        }

    }
}
