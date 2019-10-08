using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchereSteinPapier
{
    enum Moves
    {
        Schere = 1,
        Stein = 2,
        Papier = 3,
        Echse = 4,
        Spock = 5,
    }
    enum Results { win, loss, draw }
    class Program
    {
        static string PlayerName;
        static bool endgame = false;
        static Move[] Instances = new Move[5];
        
       
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
                        int PCmove = rnd.Next(1, 6);
                        Move mov = Instances[move - 1];
                        //string result = mov.Check(PCmove).ToString();
                        Output(mov.Check(PCmove), PCmove, move);
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
            Moves[] winners = new Moves[] { Moves.Papier, Moves.Echse };
            Moves[] losers = new Moves[] { Moves.Stein, Moves.Spock };
            Move Schere = new Move(winners, losers, Moves.Schere);
            Instances[0] = Schere;
            winners = new Moves[] { Moves.Schere, Moves.Echse };
            losers = new Moves[] { Moves.Papier, Moves.Spock };
            Move Stein = new Move(winners, losers, Moves.Stein);
            Instances[1] = Stein;
            winners = new Moves[] { Moves.Stein, Moves.Spock };
            losers = new Moves[] { Moves.Schere, Moves.Echse };
            Move Papier = new Move(winners, losers, Moves.Papier);
            Instances[2] = Papier;
            winners = new Moves[] { Moves.Papier, Moves.Spock };
            losers = new Moves[] { Moves.Schere, Moves.Stein };
            Move Echse = new Move(winners, losers, Moves.Echse);
            Instances[3] = Echse;
            winners = new Moves[] { Moves.Schere, Moves.Stein };
            losers = new Moves[] { Moves.Papier, Moves.Echse };
            Move Spock = new Move(winners, losers, Moves.Spock);
            Instances[4] = Spock;
            
        }
        static void Output(Enum result, int pcmove, int move)
        {
            string playermove = Enum.GetName(typeof(Moves), move);
            string computermove = Enum.GetName(typeof(Moves), pcmove);
            Console.WriteLine($"Computer spielt {computermove} und {PlayerName} spielt {playermove}");

            if (result.Equals(Results.draw))
            {
                Console.WriteLine("Gleicher Zug, Runde wird wiederholt.");
                
            }
            else if (result.Equals(Results.loss))
            {
                Console.WriteLine($"{playermove} schlägt {computermove}!");
                Console.WriteLine($"{PlayerName} gewinnt!");
            }
            else
            {
                Console.WriteLine($"{computermove} schlägt {playermove}!");
                Console.WriteLine($"Computer gewinnt!");
            }
            Console.WriteLine("____________________________________________________________");
        }
        

        
    

    }

    class Move
    {
        
        Moves[] winners;
        Moves[] losers;
        Moves self;
        

        public Move(Moves[] winners, Moves[] losers, Moves self)
        {
            this.winners = winners;
            this.losers = losers;
            this.self = self;
        }

        public Moves Self()
        {
            return self;
        }

        public Moves[] Winners
        {
            get { return winners; }
            set { winners = value; }
        }
        public Moves[] Losers
        {
            get { return losers; }
            set { losers = value; }
        }
        public Enum Check(int PCmove)
        {            
            if(Enum.GetName(typeof(Moves), self) == Enum.GetName(typeof(Moves), PCmove))
            {
                return Results.draw;

            }
            else if (Array.ConvertAll(winners, value => (int) value).Contains(PCmove))
            {
                return Results.loss;
            }
            else
            {
                return Results.win;
            }
        }
    }

    
    

    
}
