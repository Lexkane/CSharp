using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get elements which are even
            List<int> list = new List<int>(){1,2,2,4,5,6,2,4,5,2,5,2};
            int k=2;
            var query = (from items in list
                         where items % 2 == 0
                         orderby items
                         select items).ToList();
            foreach(var q in query)
            {
                Console.Write(q);
            }
           
            Console.ReadLine();

        }
    }
}