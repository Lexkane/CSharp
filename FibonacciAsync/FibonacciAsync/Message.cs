using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FibonacciAsync
{
    class Message:IMessage
    {

        IDictionary dictionary;

        public Message(WaitCallback asyncTask,
                        AsyncCallback asyncCallback,
                        object asyncState
            )
        {
            dictionary = new Hashtable();
            dictionary.Add("asyncTask", asyncTask);
            dictionary.Add("asyncCallback", asyncCallback);
            dictionary.Add("asyncState", asyncState);
        }
        public IDictionary Properties
        {
            get { return dictionary; }
        }

    }
}
