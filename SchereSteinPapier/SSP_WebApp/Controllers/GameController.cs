using SSP_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SSP_WebApp.Controllers
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
            if (Enum.GetName(typeof(Moves), self) == Enum.GetName(typeof(Moves), PCmove))
            {
                return Results.draw;

            }
            else if (Array.ConvertAll(winners, value => (int)value).Contains(PCmove))
            {
                return Results.loss;
            }
            else
            {
                return Results.win;
            }
        }
    }


    public class GameController : ApiController
    {

        public IHttpActionResult GetGameResult(int id)
        {
            Init();
            Move mov = Instances[id - 1];
            
            Random rnd = new Random();
            int PCmove = rnd.Next(1, 6);
            Enum result = mov.Check(PCmove);
            string erg = result.ToString();

            var game = new Game { Id = 444, playerName = "Player 1", playerMove = id, computerMove = PCmove, result = erg };
            return Ok(game);
        }


        static Move[] Instances = new Move[5];
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

    }
}