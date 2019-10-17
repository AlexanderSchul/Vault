using System;
using System.Net;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

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
     public class Round
    {
        public string Playername { get; set; }
        public int Playermove { get; set; }
        public Enum[] Result { get; set; }
    }

    class Program
    {
        static string PlayerName;
        static bool endgame = false;

        static HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            //Init();

            client.BaseAddress = new Uri("http://localhost:2954/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            
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
                if (check == true && move <= 5 && move >= 0)
                {
                    if (move == 0)
                    {
                        endgame = true;
                    }
                    else
                    {
                        await SendMove(move);
                        await SendName(PlayerName);
                        Enum[] result = await GetResult("Controllers/GameController.cs/[output]");
                      

                        Output(result[1],result[2], move);
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

        
        static async Task<Uri> SendMove(int playermove) 
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("api/Game", playermove);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
        static async Task<Uri> SendName(string playername)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("Game/[playername]", playername);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
        static async Task<Enum[]> GetResult(string path) 
        {
            Enum[] result = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<Enum[]>();
            }
            return result;
        }
        static void Output(Enum result, Enum pcmove, int move)
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
}