using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace ObservablePlayground;

public class App
{
    public void Start()
    {
        Console.WriteLine("____________Chat as observable test.__________\n");

        var chat = new Chat();
        var chatListener1 = new ChatListener("chatListener1");
        var unsubscribe1 = chat.Subscribe(chatListener1);
        var chatListener2 = new ChatListener("chatListener2");
        var unsubscribe2 = chat.Subscribe(chatListener2);

        chat.AddMessage(new Message("Priver mir!"));
        chat.AddMessage(new Message("I love lemons!"));
        unsubscribe1.Dispose();
        chat.AddMessage(new Message("Do you like lemons as much as i do?"));
        chat.AddMessage(new Message("I do hope so!"));

        Console.WriteLine("\n\n____________Message as observable test.__________\n");

        var messageObservable = new MessageObservable("First text");
        var messageListener1 = new MessageListener("messageListener1");
        var unsubscribe3 = messageObservable.Subscribe(messageListener1);
        var messageListener2 = new MessageListener("messageListener2");
        var unsubscribe4 = messageObservable.Subscribe(messageListener2);
        messageObservable.ChangeMessage("Second text, WOW!");
        messageObservable.ChangeMessage("Third text, that even cooler!!");
        unsubscribe3.Dispose();
        messageObservable.ChangeMessage($"This message will not be available for losers, which is {nameof(messageListener1)}");


        Console.WriteLine("\n\n____________Subject reactive test.__________\n");

        ISubject<Message> messageStream = new Subject<Message>();

        var observable1 = messageStream.Where(m => m.Text.Contains("Hello")).AsObservable();

        var observable2 = messageStream.AsObservable();

        observable1.Subscribe(m => Console.WriteLine($"From {nameof(observable1)}: {m.Text}"));
        observable2.Subscribe(m => Console.WriteLine($"From {nameof(observable2)}: {m.Text}"));

        //Only observable2 will receive this messages 
        messageStream.OnNext(new Message("asdasd"));
        messageStream.OnNext(new Message("123123"));

        //This messages will be resived by observable1 and observable2
        messageStream.OnNext(new Message("Hello"));

        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("\n\nI LOVE ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("LEMONS");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("!");
        Console.ForegroundColor = ConsoleColor.White;
    }
}

