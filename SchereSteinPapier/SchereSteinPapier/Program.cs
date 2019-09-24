using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchereSteinPapier
{
    class Program
    {
        //enum Moves { Schere, Stein, Papier, Echse, Spock, };

        static void Main(string[] args)
        {
            string PlayerName;

            string Continue ="";

            string PlayerMove;

            string[] Moves = new string[5] { "Schere", "Stein", "Papier", "Echse", "Spock" };

            Console.Write("Gib deinen Spielernamen ein: ");
            PlayerName = Console.ReadLine();

            while (Continue != "N")
            {
                Random rnd = new Random();
                int PCmoveN = rnd.Next(0, 4);
                Continue = "";
                Console.WriteLine("Gib deinen Zug ein: ");
                PlayerMove = Console.ReadLine();
                //Console.WriteLine("Computer move is: " + Moves[PCmoveN]);

                    if (PlayerMove == Moves[PCmoveN])
                {
                    Console.WriteLine("Gleicher Zug - Runde wird wiederholt");
                    Continue = "Y";
                }

                    else if (PlayerMove == "Schere" && Moves[PCmoveN] == "Papier")
                {
                    Console.WriteLine("Schere schneidet Papier -" + PlayerName + " gewinnt");
                }


                    else if (PlayerMove == "Papier" && Moves[PCmoveN] == "Schere")
                {
                    Console.WriteLine("Schere schneidet Papier - Computer gewinnt");
                }


                    else if (PlayerMove == "Papier" && Moves[PCmoveN] == "Stein")
                {
                    Console.WriteLine("Papier bedeckt Stein - " + PlayerName + " gewinnt");
                }

                    else if (PlayerMove == "Stein" && Moves[PCmoveN] == "Papier")
                {
                    Console.WriteLine("Papier bedeckt Stein - Computer gewinnt");
                }

                    else if (PlayerMove == "Stein" && Moves[PCmoveN] == "Echse")
                {
                    Console.WriteLine("Stein zerquetscht Echse - " + PlayerName + " gewinnt");
                }

                    else if (PlayerMove == "Echse" && Moves[PCmoveN] == "Stein")
                {
                    Console.WriteLine("Stein zerquetscht Echse - Computer gewinnt");
                }

                    else if (PlayerMove == "Echse" && Moves[PCmoveN] == "Spock")
                {
                    Console.WriteLine("Echse vergited Spock - " + PlayerName + " gewinnt");
                }

                    else if (PlayerMove == "Spock" && Moves[PCmoveN] == "Echse")
                {
                    Console.WriteLine("Echse vergited Spock - Computer gewinnt");
                }

                    else if (PlayerMove == "Spock" && Moves[PCmoveN] == "Schere")
                {
                    Console.WriteLine("Spock zertrümmert Schere - " + PlayerName + " gewinnt");
                }

                    else if (PlayerMove == "Schere" && Moves[PCmoveN] == "Spock")
                {
                    Console.WriteLine("Spock zertrümmert Schere - Computer gewinnt");
                }

                    else if (PlayerMove == "Schere" && Moves[PCmoveN] == "Echse")
                {
                    Console.WriteLine("Schere köpft Echse - " + PlayerName + " gewinnt");
                }

                    else if (PlayerMove == "Echse" && Moves[PCmoveN] == "Schere")
                {
                    Console.WriteLine("Schere köpft Echse - Computer gewinnt");
                }

                    else if (PlayerMove == "Echse" && Moves[PCmoveN] == "Papier")
                {
                    Console.WriteLine("Echse frisst Papier - " + PlayerName + " gewinnt");
                }

                    else if (PlayerMove == "Echse" && Moves[PCmoveN] == "Papier")
                {
                    Console.WriteLine("Echse frisst Papier - Computer gewinnt");
                }

                    else if (PlayerMove == "Papier" && Moves[PCmoveN] == "Spock")
                {
                    Console.WriteLine("Papier wiederlegt Spock - " + PlayerName + " gewinnt");
                }
                    else if (PlayerMove == "Spock" && Moves[PCmoveN] == "Papier")
                {
                    Console.WriteLine("Papier wiederlegt Spock - Computer gewinnt");
                }

                    else if (PlayerMove == "Spock" && Moves[PCmoveN] == "Stein")
                {
                    Console.WriteLine("Spock verdampft Stein - " + PlayerName + " gewinnt");
                }

                    else if (PlayerMove == "Stein" && Moves[PCmoveN] == "Spock")
                {
                    Console.WriteLine("Spock verdampft Stein - Computer gewinnt");
                }

                    else if (PlayerMove == "Stein" && Moves[PCmoveN] == "Schere")
                {
                    Console.WriteLine("Stein zertrümmert Schere - " + PlayerName + " gewinnt");
                }

                    else if (PlayerMove == "Schere" && Moves[PCmoveN] == "Stein")
                {
                    Console.WriteLine("Stein zertrümmert Schere - Computer gewinnt");
                }

                    else 
                {
                    Console.WriteLine("ungültiger Zug");
                }
                    if (Continue != "Y")
                {
                    Console.WriteLine("Möchtest du weiter spielen? (Y/N): ");
                    Continue = Console.ReadLine();
                }
                
            }






            Console.WriteLine("Auf Wiedersehen " + PlayerName);

            

            Console.ReadKey();



        }
    }
}
