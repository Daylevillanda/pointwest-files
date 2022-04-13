using System;

namespace CSharp.Demo4b
{

    abstract class DatabaseConnector
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
        public string DatabaseName { get; set; }
        public string DatabaseProvider { get; set; }

        public abstract void Connect();
        public abstract void Disconnect();

        public void DisplayDatabaseProvider()
        {
            Console.WriteLine($"Database Provider: {DatabaseProvider}");
        }
    }

    class MySqlDatabaseConnector : DatabaseConnector
    {
        public override void Connect()
        {
            Console.WriteLine("MySql Connect()");
        }

        public override void Disconnect()
        {
            Console.WriteLine("MySql Disconnect()");
        }
    }

    class OracleDatabaseConnector : DatabaseConnector
    {
        public override void Connect()
        {
            Console.WriteLine("Oracle Connect()");
        }

        public override void Disconnect()
        {
            Console.WriteLine("Oracle Disconnect()");
        }
    }


    interface IPlayer
    {
        public string GetColor();

        string FirstName
        {
            get;
            set;
        }

        string LastName
        {
            get;
            set;
        }
    }

    abstract class BaseChessPlayer
    {
        string _firstName;
        public string FirstName { get => _firstName; set => _firstName = value; }

        string _lastName;
        public string LastName { get => _lastName; set => _lastName = value; }
    }

    class BlackPlayer : BaseChessPlayer, IPlayer
    {
        public string GetColor()
        {
            return "Black";
        }
    }

    class WhitePlayer: BaseChessPlayer, IPlayer
    {
        public string GetColor()
        {
            return "White";
        }
    }

    interface IMoveable
    {
        public void Move();
        public string GetPieceName();
    }

    class King: IMoveable
    {
        public void Move()
        {
            Console.WriteLine("King has been moved.");
        }

        public string GetPieceName()
        {
            return "King";
        }
    }

    class Queen: IMoveable
    {
        public void Move()
        {
            Console.WriteLine("Queen has been moved.");
        }

        public string GetPieceName()
        {
            return "Queen";
        }
    }

    class ChessBoard
    {
        public void ExecuteTurn(IPlayer player, IMoveable moveable)
        {
            Console.WriteLine($"{player.GetColor()} player turn.");
            Console.WriteLine($"{moveable.GetPieceName()}");
            moveable.Move();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            ChessBoard chessBoard = new ChessBoard();

            IPlayer playerA = new BlackPlayer();
            IMoveable whiteKing = new King();
            IMoveable whiteQueen = new Queen();
            chessBoard.ExecuteTurn(playerA, whiteKing);

            IPlayer playerB = new WhitePlayer();
            IMoveable blackKing = new King();
            IMoveable blackQueen = new Queen();
            chessBoard.ExecuteTurn(playerB, blackQueen);

            //IScheduler scheduler = new BatchJob();
            //IRunnable runnable = (IRunnable)scheduler;
            //ObjecRunner runner = new ObjecRunner();
            //runner.Execute(runnable);
        }
    }

    class ObjecRunner
    {
        public void Execute(IRunnable runnable)
        {
            Boolean result = runnable.Run();
            if(result)
            {
                Console.WriteLine("Log successful execution");
            }
            else
            {
                Console.WriteLine("Log failed execution");
            }
        }
    }

    interface IRunnable
    {
        public Boolean Run();
    }

    interface IScheduler
    {
        public Boolean IsScheduleToRun();
        public Boolean SetSchedule();
        public Boolean ClearSchedule();
        public Boolean GetScheduleStatus();
    }

    class BatchJob: IRunnable, IScheduler
    {
        public Boolean Run()
        {
            Console.WriteLine("Batch job executed");
            return true;
        }

        public Boolean IsScheduleToRun()
        {
            return true;
        }

        public bool SetSchedule()
        {
            throw new NotImplementedException();
        }

        public bool ClearSchedule()
        {
            throw new NotImplementedException();
        }

        public bool GetScheduleStatus()
        {
            throw new NotImplementedException();
        }
    }

    class Clock: IRunnable
    {
        public Boolean Run()
        {
            Console.WriteLine("Clock failed to run.");
            return false;
        }
    }

}

