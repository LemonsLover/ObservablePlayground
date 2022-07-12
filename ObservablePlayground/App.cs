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
    }
}

