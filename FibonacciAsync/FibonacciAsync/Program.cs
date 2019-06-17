using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciAsync
{
    class Program
    {
        static FibonacciCalculator calculator = new FibonacciCalculator();
        static List<int> fibonacciSequence;
        static void Main(string[] args)
        {
            fibonacciSequence = calculator.Invoke(40);
            foreach (int item in fibonacciSequence)
            {
                Console.Write("{0}, ", item);
            }

            
            IAsyncResult asyncResult2 = calculator.BeginInvoke(40, null, null);
            Console.WriteLine("My work!");
            fibonacciSequence = calculator.EndInvoke(asyncResult2);
            foreach(int item in fibonacciSequence)
            {   
                Console.Write("{0}, ", item);
            }

            IAsyncResult asyncResult3 = calculator.BeginInvoke(40, Callback, calculator);


            Console.WriteLine("Threads Ended Execution");
            Console.ReadKey();


        }


        static void Callback(IAsyncResult asyncResult)
        {
            FibonacciCalculator calculator = (FibonacciCalculator)asyncResult.AsyncState;
            List<int> fibonacciSequence = calculator.EndInvoke(asyncResult);

            foreach (int item in fibonacciSequence)
            {
                Console.Write("{0}, ", item);
            }
        }
    }
}
