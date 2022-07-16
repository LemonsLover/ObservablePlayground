using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservablePlayground
{
    public class Message 
    {
        public string Text { get; protected set; }
        public Message (string text)
        {
            Text = text;
        }     
    }
}
