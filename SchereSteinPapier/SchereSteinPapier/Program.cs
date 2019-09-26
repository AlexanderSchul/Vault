using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchereSteinPapier
{
    class Program
    {
        

        static void Main(string[] args)
        {
            string PlayerName;

            string Continue ="";

            string PlayerMove;

            string[] Moves = new string[5] { "Schere", "Stein", "Papier", "Echse", "Spock" };
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
            Random rnd = new Random();

            while (Continue != "N")
            {
                
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

                    else if ((PlayerMove == "Schere" || PlayerMove == "schere") && Moves[PCmoveN] == "Papier")
                {
                    Console.WriteLine("Computer spielt " + Moves[PCmoveN]);
                    Console.WriteLine("Schere schneidet Papier - " + PlayerName + " gewinnt");
                }


                    else if ((PlayerMove == "Papier" || PlayerMove == "papier") && Moves[PCmoveN] == "Schere")
                {
                    Console.WriteLine("Computer spielt " + Moves[PCmoveN]);
                    Console.WriteLine("Schere schneidet Papier - Computer gewinnt");
                }


                    else if ((PlayerMove == "Papier" || PlayerMove == "papier") && Moves[PCmoveN] == "Stein")
                {
                    Console.WriteLine("Computer spielt " + Moves[PCmoveN]);
                    Console.WriteLine("Papier bedeckt Stein - " + PlayerName + " gewinnt");
                }

                    else if ((PlayerMove == "Stein" || PlayerMove == "stein") && Moves[PCmoveN] == "Papier")
                {
                    Console.WriteLine("Computer spielt " + Moves[PCmoveN]);
                    Console.WriteLine("Papier bedeckt Stein - Computer gewinnt");
                }

                    else if ((PlayerMove == "Stein" || PlayerMove == "stein") && Moves[PCmoveN] == "Echse")
                {
                    Console.WriteLine("Computer spielt " + Moves[PCmoveN]);
                    Console.WriteLine("Stein zerquetscht Echse - " + PlayerName + " gewinnt");
                }

                    else if ((PlayerMove == "Echse" || PlayerMove == "echse") && Moves[PCmoveN] == "Stein")
                {
                    Console.WriteLine("Computer spielt " + Moves[PCmoveN]);
                    Console.WriteLine("Stein zerquetscht Echse - Computer gewinnt");
                }

                    else if ((PlayerMove == "Echse" || PlayerMove == "echse") && Moves[PCmoveN] == "Spock")
                {
                    Console.WriteLine("Computer spielt " + Moves[PCmoveN]);
                    Console.WriteLine("Echse vergited Spock - " + PlayerName + " gewinnt");
                }

                    else if ((PlayerMove == "Spock" || PlayerMove == "spock") && Moves[PCmoveN] == "Echse")
                {
                    Console.WriteLine("Computer spielt " + Moves[PCmoveN]);
                    Console.WriteLine("Echse vergited Spock - Computer gewinnt");
                }

                    else if ((PlayerMove == "Spock" || PlayerMove == "spock") && Moves[PCmoveN] == "Schere")
                {
                    Console.WriteLine("Computer spielt " + Moves[PCmoveN]);
                    Console.WriteLine("Spock zertrümmert Schere - " + PlayerName + " gewinnt");
                }

                    else if ((PlayerMove == "Schere" || PlayerMove == "schere") && Moves[PCmoveN] == "Spock")
                {
                    Console.WriteLine("Computer spielt " + Moves[PCmoveN]);
                    Console.WriteLine("Spock zertrümmert Schere - Computer gewinnt");
                }

                    else if ((PlayerMove == "Schere" || PlayerMove == "schere") && Moves[PCmoveN] == "Echse")
                {
                    Console.WriteLine("Computer spielt " + Moves[PCmoveN]);
                    Console.WriteLine("Schere köpft Echse - " + PlayerName + " gewinnt");
                }

                    else if ((PlayerMove == "Echse" || PlayerMove == "echse") && Moves[PCmoveN] == "Schere")
                {
                    Console.WriteLine("Computer spielt " + Moves[PCmoveN]);
                    Console.WriteLine("Schere köpft Echse - Computer gewinnt");
                }

                    else if ((PlayerMove == "Echse" || PlayerMove == "echse") && Moves[PCmoveN] == "Papier")
                {
                    Console.WriteLine("Computer spielt " + Moves[PCmoveN]);
                    Console.WriteLine("Echse frisst Papier - " + PlayerName + " gewinnt");
                }

                    else if ((PlayerMove == "Echse" || PlayerMove == "echse") && Moves[PCmoveN] == "Papier")
                {
                    Console.WriteLine("Computer spielt " + Moves[PCmoveN]);
                    Console.WriteLine("Echse frisst Papier - Computer gewinnt");
                }

                    else if ((PlayerMove == "Papier" || PlayerMove == "papier") && Moves[PCmoveN] == "Spock")
                {
                    Console.WriteLine("Computer spielt " + Moves[PCmoveN]);
                    Console.WriteLine("Papier wiederlegt Spock - " + PlayerName + " gewinnt");
                }
                    else if ((PlayerMove == "Spock" || PlayerMove == "spock")  && Moves[PCmoveN] == "Papier")
                {
                    Console.WriteLine("Computer spielt " + Moves[PCmoveN]);
                    Console.WriteLine("Papier wiederlegt Spock - Computer gewinnt");
                }

                    else if ((PlayerMove == "Spock" || PlayerMove == "spock") && Moves[PCmoveN] == "Stein")
                {
                    Console.WriteLine("Computer spielt " + Moves[PCmoveN]);
                    Console.WriteLine("Spock verdampft Stein - " + PlayerName + " gewinnt");
                }

                    else if ((PlayerMove == "Stein" || PlayerMove == "stein") && Moves[PCmoveN] == "Spock")
                {
                    Console.WriteLine("Computer spielt " + Moves[PCmoveN]);
                    Console.WriteLine("Spock verdampft Stein - Computer gewinnt");
                }

                    else if ((PlayerMove == "Stein" || PlayerMove == "stein") && Moves[PCmoveN] == "Schere")
                {
                    Console.WriteLine("Computer spielt " + Moves[PCmoveN]);
                    Console.WriteLine("Stein zertrümmert Schere - " + PlayerName + " gewinnt");
                }

                    else if ((PlayerMove == "Schere" || PlayerMove == "schere") && Moves[PCmoveN] == "Stein")
                {
                    Console.WriteLine("Computer spielt " + Moves[PCmoveN]);
                    Console.WriteLine("Stein zertrümmert Schere - Computer gewinnt");
                }

                    else 
                {
                    Console.WriteLine("ungültiger Zug");
                }
                    if (Continue != "Y")
                {
                    Console.WriteLine("_______________________________________________");
                    Console.WriteLine("Enter zum weiterspielen. 'N' beendet das Spiel.");
                    Continue = Console.ReadLine();
                }
                
            }






            Console.WriteLine("Auf Wiedersehen " + PlayerName);

            

            Console.ReadKey();



        }
    }
}
