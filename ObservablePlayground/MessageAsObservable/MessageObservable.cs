using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservablePlayground
{
    public class MessageObservable : Message, IObservable<MessageObservable>
    {
        private List<IObserver<MessageObservable>> observers;
        public MessageObservable(string text)
            : base(text)
        {
            observers = new List<IObserver<MessageObservable>>();
        }

        public void ChangeMessage(string newText)
        {
            Text = newText;
            NotifyObservers(this);
        }

        public IDisposable Subscribe(IObserver<MessageObservable> observer)
        {
            if (observer != null)
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        public void AddMessage(MessageObservable message)
        {
            NotifyObservers(message);
        }

        public void NotifyObservers(MessageObservable message)
        {
            foreach (var observer in observers)
                observer.OnNext(message);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<MessageObservable>> observers;
            private IObserver<MessageObservable> observer;

            public Unsubscriber(List<IObserver<MessageObservable>> observers, IObserver<MessageObservable> observer)
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
