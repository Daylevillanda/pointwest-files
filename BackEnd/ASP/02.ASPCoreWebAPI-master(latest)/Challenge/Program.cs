using System;

namespace Challenge
{
    interface OldTrick
    {
        public void doTrick();
    }

    class OldDog
    {
        private OldTrick someTrick;

        public OldDog(OldTrick oldTrick)
        {
            this.someTrick = oldTrick;
        }

        public void perform()
        {
            someTrick.doTrick();
        }
    }

    class SleepingTrick : OldTrick
    {
        public void doTrick()
        {
            Console.WriteLine("Doing sleeping trick");
        }
    }

    class PlayDeadTrick : OldTrick
    {
        public void doTrick()
        {
            Console.WriteLine("Doing play dead trick");
        }
    }
    interface NewTrick
    {
        public void doTrick();
    }

    class TalkTrick : NewTrick
    {
        public void doTrick()
        {
            Console.WriteLine("Dog is talking...");
        }
    }

    class OldTrickAdapter: OldTrick
    {
        private NewTrick someNewTrick;
        public OldTrickAdapter(NewTrick newTrick)
        {
            this.someNewTrick = newTrick;
        }

        public void doTrick()
        {
            this.someNewTrick.doTrick();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            NewTrick newTrick = new TalkTrick();

            OldTrickAdapter oldTrickAdapter = new OldTrickAdapter(newTrick);

            OldTrick oldTrick = new SleepingTrick();
            OldDog askal = new OldDog(oldTrickAdapter);
            askal.perform();
        }
    }

}
