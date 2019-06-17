using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FibonacciAsync
{
    class AsyncResult
    {

        IMessage message;
        WaitCallback asyncTask;
        AsyncCallback asyncCallback;

        object asyncState;
        ManualResetEvent waitHandle;
        bool isCompleted;
        public bool isInvokeAsyncCallback;

        public IMessageSink NextSink 
        {
            get { return null; }
        }

        public IMessage SyncProcessMessage(IMessage message)
        {
            this.message = message;
            asyncTask = (WaitCallback)message.Properties["asyncTask"];
            asyncCallback = (AsyncCallback)message.Properties["asyncCallback"];
            asyncState = message.Properties["asyncState"];

            waitHandle = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem(AsyncTask, this);
            return message;
        }
        public IMessageCtrl AsyncProcessMessage (IMessage msg, IMessageSink replySink)
        {
            throw new NotSupportedException("NotSupported_Method");
        }


        void AsyncTask(object asyncResult)
        {
            if (asyncTask != null)
            {
                asyncTask.Invoke(null);
            }
            if (asyncCallback != null)
            {
                isInvokeAsyncCallback = true;
                asyncCallback.Invoke(asyncResult as IAsyncResult);
            }
            waitHandle.Set();
            isCompleted = true;
        }

    }
}
