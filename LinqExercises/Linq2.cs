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
            //Get elements which are equal to k
            List<int> list = new List<int>(){1,2,2,4,5,6,2,4,5,2,5,2};
            int k=2;
            var query = (from items in list
                    where items==k
                    orderby items
                    select items).Count();

            Console.WriteLine(query);
            Console.ReadLine();

        }
    }
}
