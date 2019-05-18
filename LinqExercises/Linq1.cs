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
            //Get elements with string Length less then x;
            List<string> list = new List<string>(){"Marry", "Jane", "Kate", "Monica", "Lucy", "Sharon", "Victoria"};
            int k;
           // IEnumerable<string> query;
           var query = (from items in list
                    where items.Length < 5
                    orderby items
                    select items).Count();

            Console.WriteLine(query);
            Console.ReadLine();

        }
    }
}
