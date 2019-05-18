using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
    class Point
    {
        public int X;
        public int Y;
        public int Z;

        public Point(int _x,int _y,int _z)
        {
            X = _x;
            Y = _y;
            Z = _z;
        }

    }

    class Program
    {

        static void Main(string[] args)
        {
            
            //Linq query from 3d points 2d points with X and Y coordinates          

              var numbers = from n in list
              select new { X = n.X, Y = n.Y };

            foreach (var item in numbers)
            {
                Console.WriteLine($"{item}");

            }
          }
    }
}

