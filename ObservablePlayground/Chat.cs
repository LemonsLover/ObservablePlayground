using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservablePlayground
{
    internal class Chat : IObservable<Message>
    {
        private List<IObserver<Message>> observers;
        public Chat()
        {
            observers = new List<IObserver<Message>>();
        }

        public IDisposable Subscribe(IObserver<Message> observer)
        {
            if (observer != null)
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        public void AddMessage(Message message)
        {
            foreach (var observer in observers)
                observer.OnNext(message);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Message>> observers;
            private IObserver<Message> observer;

            public Unsubscriber(List<IObserver<Message>> observers, IObserver<Message> observer)
            {
                this.observers = observers;
                this.observer = observer;
            }

            public void Dispose()
            {
                if (observers != null && observers.Contains(observer))
                    observers.Remove(observer);
            }
        }
    }
}
