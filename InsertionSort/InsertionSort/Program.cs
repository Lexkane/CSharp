using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSortPrometheus
{
    class Program
    {
        static void Main(string[] args)
        {
            Sort();
            Console.ReadKey();
        }

        public static void Sort()
        {
            var a = new[]
            {
              10, 10, 5, 2, 2, 5, 6, 7, 8, 15, 4, 4, 4, 2, 3, 5, 5, 36, 32, 623, 7, 475, 7, 2, 2, 44, 5, 6, 7, 71, 2
                 };

            int length = a.Length;


            for (int i = 0; i < length-1; i++)

            {
                int check = 0;
                int maxPos = i;
                for (int j=i+1;j<length-1;j++)
                {
                    if ((a[j] > a[maxPos]))
                    {
                        maxPos = j;
                        check = 1;
                    }
                                      
                }

                if (check == 1)
                {
                    int temp = a[i];
                    a[i] = a[maxPos];
                    a[maxPos] = temp;
                    Console.Write($"{maxPos} ");
                }
                check = 0;

            }
            Console.Write("\n");
            foreach (int p in a)
            {
                Console.Write($"{p} ");
            }

            Console.ReadKey();


        }
    }
}
