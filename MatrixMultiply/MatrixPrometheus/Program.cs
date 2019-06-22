using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixPrometheus
{
    class Program
    {


        public static void MultiplyMatrix()
        {

                 var a = new[,]
                         {
                          {5, 10, 13, -4, 10},
                          {20, 2, 9, 9, -1},
                          {5, 10, 4, 8, 14},
                          {6, 1, 2, 6, 10},
                          {95, 5, 10, 10, 2}
                        };
                 var b = new[,]
                        {
                          {5, 10, 8, -4, 62},
                          {20, 2, 9, 9, -1},
                          {5, 10, 1, 8, 1},
                          {6, 1, 2, 6, -5},
                          {95, 5, 1, 3, 2}
                        };


            var result = new int [a.GetLength(0),b.GetLength(1)];

            for (int n = 0; n < result.GetLength(0); n++)
            {
                for (int m = 0; m < result.GetLength(1); m++)
                {
                    for (int i = 0; i < a.GetLength(0); i++)
                    { 
                    result[n, m] += a[n,i] * b[i,m];
                    }

                    Console.Write("|{0}", result[n, m]);

                }
                Console.Write("|\n");
            }



        }

        static void Main(string[] args)
        {
            MultiplyMatrix();
            Console.ReadKey();


        }
    }
}

