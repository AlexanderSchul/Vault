using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchereSteinPapier
{
    class Program
    {
        static string PlayerName;
        static bool endgame = false;
        static Move[] Instances = new Move[5];
        enum Moves
        {
            Schere = 1,
            Stein = 2,
            Papier = 3,
            Echse = 4,
            Spock = 5,
        }
        static void Main(string[] args)
        {
            Init();
            Console.WriteLine("Willkommen bei Schere, Stein, Papier, Echse, Spock");
            Console.WriteLine("Die Spielregeln lauten:");
            Console.WriteLine("Schere schneidet Papier");
            Console.WriteLine("Papier bedeckt Stein");
            Console.WriteLine("Stein zerquetscht Echse");
            Console.WriteLine("Echse vergiftet Spock");
            Console.WriteLine("Spock zertrümmert Schere");
            Console.WriteLine("Schere köpft Echse");
            Console.WriteLine("Echse frisst Papier");
            Console.WriteLine("Papier widerlegt Spock");
            Console.WriteLine("Spock verdampft Stein");
            Console.WriteLine("Stein zertrümmert Schere");
            Console.WriteLine("_____________________________");
            Console.Write("Gib deinen Spielernamen ein: ");
            PlayerName = Console.ReadLine();

            do
            {
                Console.WriteLine($"Gib deinen Zug ein ({(int)Moves.Schere} = Schere, {(int)Moves.Stein} = Stein, {(int)Moves.Papier} = Papier, {(int)Moves.Echse} = Echse, {(int)Moves.Spock} = Spock, 0 beendet das Spiel): ");

                bool check = int.TryParse(Console.ReadLine(), out int move);
                if (check == true && move<=5 && move>=0)
                {
                    if (move == 0)
                    {
                        endgame = true;
                    }
                    else
                    {
                        Random rnd = new Random();
                        int PCmove = rnd.Next(1, 5);
                        Move mov = Instances[move - 1];
                        string result = mov.Check(PCmove);
                        Output(result, PCmove, move);
                    }
                }

                else
                {
                    Console.WriteLine("Ungültiger Zug. Gib eine Zahl zwischen 0 und 5 ein.");
                    Console.WriteLine("____________________________________________________________");
                }

            } while (endgame == false);


            Console.WriteLine($"Auf Wiedersehen {PlayerName}!");
            Console.ReadKey();


        }
        static void Init()
        {
            int[] winners = new int[] { 3, 4 };
            int[] losers = new int[] { 2, 5 };
            Move Schere = new Move(winners, losers, 1);
            Instances[0] = Schere;
            winners = new int[] { 1, 4 };
            losers = new int[] { 3, 5 };
            Move Stein = new Move(winners, losers, 2);
            Instances[1] = Stein;
            winners = new int[] { 2, 5 };
            losers = new int[] { 1, 5 };
            Move Papier = new Move(winners, losers, 3);
            Instances[2] = Papier;
            winners = new int[] { 3, 5 };
            losers = new int[] { 1, 2 };
            Move Echse = new Move(winners, losers, 4);
            Instances[3] = Echse;
            winners = new int[] { 1, 2 };
            losers = new int[] { 3, 4 };
            Move Spock = new Move(winners, losers, 5);
            Instances[4] = Spock;
        }
        static void Output(string result, int pcmove, int move)
        {
            string playermove = Enum.GetName(typeof(Moves), move);
            string computermove = Enum.GetName(typeof(Moves), pcmove);
            Console.WriteLine($"Computer spielt {computermove} und {PlayerName} spielt {playermove}");

            if (result == "draw")
            {
               
                Console.WriteLine("Gleicher Zug, Runde wird wiederholt.");
                Console.WriteLine("____________________________________________________________");
            }
            else if (result == "loss")
            {
                Console.WriteLine($"{playermove} schlägt {computermove}!");
                Console.WriteLine($"{PlayerName} gewinnt!");
            }
            else
            {
                Console.WriteLine($"{computermove} schlägt {playermove}!");
                Console.WriteLine($"Computer gewinnt!");
            }
        }
        

        
    

    }

    class Move
    {
        int[] winners;
        int[] losers;
        int self;
        public Move(int[] winners, int[] losers, int self)
        {
            this.winners = winners;
            this.losers = losers;
            this.self = self;
        }

        public int Self()
        {
            return self;
        }

        public int[] Winners
        {
            get { return winners; }
            set { winners = value; }
        }
        public int[] Losers
        {
            get { return losers; }
            set { losers = value; }
        }
        public string Check(int PCmove)
        {            
            if(self == PCmove)
            {
                return "draw";
            }
            else if (winners.Contains(PCmove))
            {
                return "loss";
            }
            else
            {
                return "win";
            }
        }
    }

    
    

    
}
