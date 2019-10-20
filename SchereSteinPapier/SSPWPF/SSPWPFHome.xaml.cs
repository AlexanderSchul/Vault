using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;




namespace SSPWPF
{
    /// <summary>
    /// Interaction logic for SSPWPFHome.xaml
    /// </summary>
    /// 
    public class Game
    {
        public int Id { get; set; }
        public string playerName { get; set; }
        public int playerMove { get; set; }
        public int computerMove { get; set; }
        public string result { get; set; }

    }
    enum Moves
    {
        Schere = 1,
        Stein = 2,
        Papier = 3,
        Echse = 4,
        Spock = 5,
    }
    public class Score
    {
        public int pcscore = 0;
        public int playerscore = 0;
    }
    public partial class SSPWPFHome : Page
    {
        
        static HttpClient client = new HttpClient();
        public string name;
        Score score = new Score();
        
        public SSPWPFHome()
        {
            InitializeComponent();
            //DataContext = this;
            
            client.BaseAddress = new Uri("http://localhost:2954/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

         
            
            
            
            
            
        }
        
        
        static async Task<Game> GetResult(int playermove)
        {
            Game result = null;
            HttpResponseMessage response = await client.GetAsync("api/Game/" + playermove);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<Game>();
            }
            return result;
        }
        static void Output(Game result, TextBox Winner, TextBox Move, TextBox ScoreBox, TextBlock SPlayername, string playername, Score score) 
        {
            SPlayername.Text = playername;
            string playermove = Enum.GetName(typeof(Moves), result.playerMove);
            string computermove = Enum.GetName(typeof(Moves), result.computerMove);
            Move.Text = $"Computer spielt {computermove} und {playername} spielt {playermove}";
            if (result.result == "draw")
            {
                Winner.Text = "Unentschieden";
                ScoreBox.Text = score.playerscore + " : " + score.pcscore; 
            }
            else if (result.result == "loss")
            {
                Winner.Text = $"{playermove} schlägt {computermove} - {playername} gewinnt";
                score.playerscore++;
                ScoreBox.Text = score.playerscore + " : " + score.pcscore;
            }
            else
            {
                Winner.Text = $"{computermove} schlägt {playermove} - Computer gewinnt";
                score.pcscore++;
                ScoreBox.Text = score.playerscore + " : " + score.pcscore;
            }

        }

        private async void Spock_Click(object sender, RoutedEventArgs e)
        {
            name = PlayerName.Text;
            int move = 5;
            Game result = await GetResult(move);
            Output(result, Winner, Move, ScoreBox, ScorePlayerName, name, score);
        }

        private async void Echse_Click(object sender, RoutedEventArgs e)
        {
            name = PlayerName.Text;
            int move = 4;
            Game result = await GetResult(move);
            Output(result, Winner, Move, ScoreBox, ScorePlayerName, name, score);
        }

        private async void Papier_Click(object sender, RoutedEventArgs e)
        {
            name = PlayerName.Text;
            int move = 3;
            Game result = await GetResult(move);
            Output(result, Winner, Move, ScoreBox, ScorePlayerName, name, score);
        }

        private async void Stein_Click(object sender, RoutedEventArgs e)
        {
            name = PlayerName.Text;
            int move = 2;
            Game result = await GetResult(move);
            Output(result, Winner, Move, ScoreBox, ScorePlayerName, name, score);
        }

        private async void Schere_Click(object sender, RoutedEventArgs e)
        {
            name = PlayerName.Text;
            int move = 1;
            Game result = await GetResult(move);
            Output(result, Winner, Move, ScoreBox, ScorePlayerName, name, score);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}

