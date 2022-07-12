using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservablePlayground
{
    public class ChatListener : IObserver<Message>
    {
        private readonly string name;
        public ChatListener(string name)
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

        public void OnNext(Message value)
        {
            Console.WriteLine($"From {name}: {value.Text}");
        }
    }
}
