using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservablePlayground
{
    public class MessageListener : IObserver<MessageObservable>
    {
        private readonly string name;
        public MessageListener(string name)
        {
            this.name = name;
        }
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(MessageObservable value)
        {
            Console.WriteLine($"From {name}: {value.Text}");
        }
    }
}
