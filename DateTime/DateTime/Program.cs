using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTime2
{

    enum MyStruct : byte
    {
          zero,
          one,
          two,
          three

    }
    
    enum EnumType:byte
    {
        Zero=0,
        one=1,
        two=2,
        three=3


    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(EnumType.one);
            Console.WriteLine(EnumType.two);
            Console.WriteLine((byte)EnumType.one);
            EnumType digit = EnumType.Zero;
            Console.WriteLine(digit);
            Console.WriteLine((byte)digit);

            Array array = EnumType.GetValues(typeof(EnumType));

            for (int i=0; i < array.Length; i++)
            {
                Console.WriteLine($" Array element {array.GetValue(i)}");

            }
             //DateTime now = DateTime.Now;
            //Console.WriteLine("Date Now is :{0:D} ", now);
            //Console.WriteLine("Date Now is :{0:F} ",now);
            //Console.WriteLine("Date Now is :{0:G} ", now);
            //Console.WriteLine("Date Now is :{0:M} ", now);
            //Console.WriteLine("Date Now is :{0:Y} ", now);
            //Console.WriteLine("Date Now is :{0:T} ", now);
            Console.ReadKey();
        }
    }
}
