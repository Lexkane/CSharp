using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;

namespace FibonacciAsync
{
    class FibonacciCalculator
    {

        int count;
        List<int> fibonacciSequence = new List<int>();


        public List<int> Invoke(int count)
        {
            fibonacciSequence = Fibonacci(count);
            return fibonacciSequence;
        }

        public IAsyncResult BeginInvoke(int count, AsyncCallback callback, object @object)
        {
            this.count = count;
            Message message = new Message(new System.Threading.WaitCallback(Fibonacci), callback, @object);
            AsyncResult asyncResult = new AsyncResult();
            asyncResult.SyncProcessMessage(message);
            return (IAsyncResult)asyncResult;
        }

        public IAsyncResult BeginInvoke2(int count, AsyncCallback callback, object @object)
        {
            Func<int, List<int>> fibonacci = new Func<int, List<int>>(Fibonacci);
            IAsyncResult asyncResult = fibonacci.BeginInvoke(count, callback, @object);
            return (IAsyncResult)asyncResult;
        }

        public List<int> EndInvoke(IAsyncResult result)
        {
            if (!(result as AsyncResult).isInvokeAsyncCallback)
                result.AsyncWaitHandle.WaitOne();
            return fibonacciSequence;
        }

        public List<int> EndInvoke2(IAsyncResult result)
        {
            AsyncResult asyncResult = result as AsyncResult;
            Func<int, List<int>> fibonacci = asyncResult.AsyncDelegate as Func<int, List<int>>;
            fibonacciSequence = fibonacci.EndInvoke(result);
            return fibonacciSequence;
        }

        void Fibonacci(object arg)
        {
            Func<int, int> fib = null;
            fib = (x) => x > 1 ? fib(x - 1) + fib(x - 2) : x;
            for (int i = 0; i < count; ++i)
                fibonacciSequence.Add(fib.Invoke(i));
        }

        List<int> Fibonacci(int count)
        {
            Func<int, int> fib = null;
            fib = (x) => x > 1 ? fib(x - 1) + fib(x - 2) : x;
            for (int i = 0; i < count; ++i)
                fibonacciSequence.Add(fib.Invoke(i));
            return fibonacciSequence;
        }
    }
}
