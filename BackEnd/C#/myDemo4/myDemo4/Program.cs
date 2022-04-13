using System;

namespace myDemo4
{

    interface IMessageProvider
    {
        public string GetMessage();
    }

    class DefaultMessageProvider: IMessageProvider
    {
        public string GetMessage()
        {
            return "Hello World";
        }

    }
    
    class MessageRenderer
    {
        IMessageProvider messageProvider;
        public MessageRenderer(IMessageProvider messageProvider)
        {
            this.messageProvider = messageProvider;
        }

        public void DisplayMessage()
        {
            Console.WriteLine(this.messageProvider.GetMessage());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DefaultMessageProvider messageProvider = new DefaultMessageProvider();
            MessageRenderer messageRenderer= new MessageRenderer(messageProvider);
            messageRenderer.DisplayMessage();
        }
    }
}
