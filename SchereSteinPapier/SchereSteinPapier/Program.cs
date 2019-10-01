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
                if (check == true)
                {
                    Round round = Game(move);
                    Output(round);
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

        static void Output(Round round)
        {
            if (round.winner == "end")
            {
                endgame = true;
            }
            else if (round.winner == "invalid")
            {
                Console.WriteLine("Ungültiger Zug. Gib eine Zahl zwischen 0 und 5 ein.");
                Console.WriteLine("____________________________________________________________");
            }
            else if (round.winner == "none")
            {
                Console.WriteLine($"Computer spielt {round.PCMove()} und {PlayerName} spielt {round.PlayerMove()}");
                Console.WriteLine("Gleicher Zug, Runde wird wiederholt.");
                Console.WriteLine("____________________________________________________________");
            }
            else
            {
                Console.WriteLine($"Computer spielt {round.PCMove()} und {PlayerName} spielt {round.PlayerMove()}");

                if (round.winner == "Computer")
                {
                    Console.WriteLine($"{round.PCMove()} schlägt {round.PlayerMove()}!");
                }
                else
                {
                    Console.WriteLine($"{round.PlayerMove()} schlägt {round.PCMove()}");
                }
                Console.WriteLine($"{round.winner} gewinnt!");
                Console.WriteLine("____________________________________________________________");
            }
        }
        static Round Game(int Pmove)
        {
            Random rnd = new Random();
            int PCmove = rnd.Next(1, 5);
            Round round = new Round(Enum.GetName(typeof(Moves), Pmove), Enum.GetName(typeof(Moves), PCmove), null);

            if (Pmove == 0)
            {
                round.winner = "end";
                return round;
            }

            if (round.PlayerMove() == round.PCMove())
            {
                round.winner = "none";
                return round;
            }
            else if (round.PlayerMove() == Enum.GetName(typeof(Moves), 1) && ((round.PCMove() == Enum.GetName(typeof(Moves), 3)) || round.PCMove() == Enum.GetName(typeof(Moves), 4)))
            {
                round.winner = PlayerName;
                return round;
            }
            else if (round.PlayerMove() == Enum.GetName(typeof(Moves), 1) && ((round.PCMove() == Enum.GetName(typeof(Moves), 2)) || round.PCMove() == Enum.GetName(typeof(Moves), 5)))
            {
                round.winner = "Computer";
                return round;
            }
            else if (round.PlayerMove() == Enum.GetName(typeof(Moves), 2) && ((round.PCMove() == Enum.GetName(typeof(Moves), 1)) || round.PCMove() == Enum.GetName(typeof(Moves), 4)))
            {
                round.winner = PlayerName;
                return round;
            }
            else if (round.PlayerMove() == Enum.GetName(typeof(Moves), 2) && ((round.PCMove() == Enum.GetName(typeof(Moves), 3)) || round.PCMove() == Enum.GetName(typeof(Moves), 5)))
            {
                round.winner = "Computer";
                return round;
            }
            else if (round.PlayerMove() == Enum.GetName(typeof(Moves), 3) && ((round.PCMove() == Enum.GetName(typeof(Moves), 2)) || round.PCMove() == Enum.GetName(typeof(Moves), 5)))
            {
                round.winner = PlayerName;
                return round;
            }
            else if (round.PlayerMove() == Enum.GetName(typeof(Moves), 3) && ((round.PCMove() == Enum.GetName(typeof(Moves), 1)) || round.PCMove() == Enum.GetName(typeof(Moves), 4)))
            {
                round.winner = "Computer";
                return round;
            }
            else if (round.PlayerMove() == Enum.GetName(typeof(Moves), 4) && ((round.PCMove() == Enum.GetName(typeof(Moves), 3)) || round.PCMove() == Enum.GetName(typeof(Moves), 5)))
            {
                round.winner = PlayerName;
                return round;
            }
            else if (round.PlayerMove() == Enum.GetName(typeof(Moves), 4) && ((round.PCMove() == Enum.GetName(typeof(Moves), 1)) || round.PCMove() == Enum.GetName(typeof(Moves), 2)))
            {
                round.winner = "Computer";
                return round;
            }
            else if (round.PlayerMove() == Enum.GetName(typeof(Moves), 5) && ((round.PCMove() == Enum.GetName(typeof(Moves), 1)) || round.PCMove() == Enum.GetName(typeof(Moves), 2)))
            {
                round.winner = PlayerName;
                return round;
            }
            else if (round.PlayerMove() == Enum.GetName(typeof(Moves), 5) && ((round.PCMove() == Enum.GetName(typeof(Moves), 3)) || round.PCMove() == Enum.GetName(typeof(Moves), 4)))
            {
                round.winner = "Computer";
                return round;
            }
            else
            {
                round.winner = "invalid";
                return round;
            }
           

        }

        
    

    }

    class Round
    {
        private readonly string playermove;
        private readonly string pcmove;
        public string winner;
       
        public Round(string playermove, string pcmove, string winner)
        {
            this.playermove = playermove;
            this.pcmove = pcmove;
            this.winner = winner;
        }
        public string PlayerMove()
        {
            return playermove;
        }

        public string PCMove()
        {
            return pcmove;
        }
       
        public string Winner()
        {
            return winner;
        }
    }
}
