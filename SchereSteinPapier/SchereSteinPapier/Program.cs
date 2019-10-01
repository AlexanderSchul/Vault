using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchereSteinPapier
{
    class Program
    {

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

            int[] Data = new int[3];

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
            string PlayerName = Console.ReadLine();

            do
            {
                Console.WriteLine("Gib deinen Zug ein (1 = Schere, 2 = Stein, 2 = Papier, 4 = Echse, 5 = Spock, 0 beendet das Spiel): ");
                bool check = int.TryParse(Console.ReadLine(), out int playermove);
                if (check == true)
                {
                    Array.Copy(Game(playermove), 0, Data, 0, 3);

                    if (Data[2] == 1)
                    {
                        Console.WriteLine("Computer spielt " + Enum.GetName(typeof(Moves), Data[1]) + " und " + PlayerName + " spielt " + Enum.GetName(typeof(Moves), Data[0]));
                        Console.WriteLine(Enum.GetName(typeof(Moves), Data[0]) + " schlägt " + Enum.GetName(typeof(Moves), Data[1]));
                        Console.WriteLine(PlayerName + " gewinnt.");
                        Console.WriteLine("____________________________________________________________");
                    }
                    else if (Data[2] == 0)
                    {
                        Console.WriteLine("Computer spielt " + Enum.GetName(typeof(Moves), Data[1]) + " und " + PlayerName + " spielt " + Enum.GetName(typeof(Moves), Data[0]));
                        Console.WriteLine(Enum.GetName(typeof(Moves), Data[1]) + " schlägt " + Enum.GetName(typeof(Moves), Data[0]));
                        Console.WriteLine("Computer gewinnt.");
                        Console.WriteLine("____________________________________________________________");
                    }
                    else if (Data[2] == 2)
                    {
                        Console.WriteLine("Computer spielt " + Enum.GetName(typeof(Moves), Data[1]) + " und " + PlayerName + " spielt " + Enum.GetName(typeof(Moves), Data[0]));
                        Console.WriteLine("Gleicher Zug, Runde wird wiederholt.");
                        Console.WriteLine("____________________________________________________________");
                    }
                    else if (Data[2] == 4)
                    {
                        Console.WriteLine("Ungültiger Zug. Gib eine Zahl zwischen 0 und 5 ein.");
                        Console.WriteLine("____________________________________________________________");
                    }
                }
                else
                {
                    Console.WriteLine("Ungültiger Zug. Gib eine Zahl zwischen 0 und 5 ein.");
                }

            } while (Data[2] != 3);

            Console.WriteLine("Auf Wiedersehen " + PlayerName + "!");
            Console.ReadKey();


        }


        static Array Game(int Pmove)
        {
            Random rnd = new Random();
            int[] gameData = new int[3];
            int PCmove = rnd.Next(1, 5);

            switch (Pmove)                   // gameData[2]: 0=loss, 1=win, 2=same, 3=end game, 4= invalid
            {
                case 0:
                    gameData[2] = 3;
                    break;

                case 1:
                    if (PCmove == 1)
                    {
                        gameData[2] = 2;
                    }
                    else if (PCmove == 2)
                    {
                        gameData[2] = 0;
                    }
                    else if (PCmove == 3)
                    {
                        gameData[2] = 1;
                    }
                    else if (PCmove == 4)
                    {
                        gameData[2] = 1;
                    }
                    else if (PCmove == 5)
                    {
                        gameData[2] = 0;
                    }
                    break;

                case 2:
                    if (PCmove == 1)
                    {
                        gameData[2] = 1;
                    }
                    else if (PCmove == 2)
                    {
                        gameData[2] = 2;
                    }
                    else if (PCmove == 3)
                    {
                        gameData[2] = 0;
                    }
                    else if (PCmove == 4)
                    {
                        gameData[2] = 1;
                    }
                    else if (PCmove == 5)
                    {
                        gameData[2] = 0;
                    }
                    break;

                case 3:
                    if (PCmove == 1)
                    {
                        gameData[2] = 0;
                    }
                    else if (PCmove == 2)
                    {
                        gameData[2] = 1;
                    }
                    else if (PCmove == 3)
                    {
                        gameData[2] = 2;
                    }
                    else if (PCmove == 4)
                    {
                        gameData[2] = 0;
                    }
                    else if (PCmove == 5)
                    {
                        gameData[2] = 0;
                    }
                    break;

                case 4:
                    if (PCmove == 1)
                    {
                        gameData[2] = 0;
                    }
                    else if (PCmove == 2)
                    {
                        gameData[2] = 0;
                    }
                    else if (PCmove == 3)
                    {
                        gameData[2] = 1;
                    }
                    else if (PCmove == 4)
                    {
                        gameData[2] = 2;
                    }
                    else if (PCmove == 5)
                    {
                        gameData[2] = 1;
                    }
                    break;

                case 5:
                    if (PCmove == 1)
                    {
                        gameData[2] = 1;
                    }
                    else if (PCmove == 2)
                    {
                        gameData[2] = 1;
                    }
                    else if (PCmove == 3)
                    {
                        gameData[2] = 0;
                    }
                    else if (PCmove == 4)
                    {
                        gameData[2] = 0;
                    }
                    else if (PCmove == 5)
                    {
                        gameData[2] = 2;
                    }
                    break;

                default:
                    gameData[2] = 4;
                    break;

            }

            gameData[0] = Pmove;
            gameData[1] = PCmove;

            return gameData;


        }
    }
}
