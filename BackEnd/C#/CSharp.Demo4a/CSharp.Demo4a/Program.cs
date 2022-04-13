using System;

namespace CSharp.Demo4a
{
    // contract
    // what?
    interface IMessageProvider
    {
        public string GetMessage(); // abstract method - a method that doesn't have an implementation/body
    }

    // is a relationship
    // implementing class -> how?
    class DefaultMessageProvider : IMessageProvider
    {
        public string GetMessage()
        {
            return "Hello World";
        }
    }

    class FileMessageProvider: IMessageProvider
    {
        public string GetMessage()
        {
            // some logic that will retrieve the message from a given file
            return "Hello from file";
        }

        public void ReadFile()
        {

        }

        public void FormatMessage()
        {

        }
    }

    interface IMessageRenderer
    {
        public void DisplayMessage();
    }


    class ConsoleMessageRenderer: IMessageRenderer
    {
        IMessageProvider messageProvider;

        public ConsoleMessageRenderer(IMessageProvider messageProvider)
        {
            this.messageProvider = messageProvider;
        }

        public void DisplayMessage()
        {
            Console.WriteLine(messageProvider.GetMessage());
            
        }
    }

    class FileMessageRenderer: IMessageRenderer
    {
        IMessageProvider messageProvider;

        public FileMessageRenderer(IMessageProvider messageProvider)
        {
            this.messageProvider = messageProvider;
        }

        public void DisplayMessage()
        {
            // logic to write the message to a file
            Console.WriteLine($"Message {messageProvider.GetMessage()} written to a file.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //DefaultMessageProvider defaultMessageProvider = new DefaultMessageProvider();
            //ConsoleMessageRenderer consoleMessageRenderer = new ConsoleMessageRenderer(fileMessageProvider);

            //FileMessageProvider fileMessageProvider = new FileMessageProvider();
            //FileMessageRenderer fileMessageRenderer = new FileMessageRenderer(fileMessageProvider);
            //fileMessageRenderer.DisplayMessage();

            DefaultMessageProvider messageProvider = new DefaultMessageProvider();
            FileMessageRenderer messageRenderer = new FileMessageRenderer(messageProvider);
            messageRenderer.DisplayMessage();
        }
    }
}

