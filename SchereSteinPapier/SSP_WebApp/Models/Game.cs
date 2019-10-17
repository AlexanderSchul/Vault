using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSP_WebApp.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string playerName { get; set; }
        public int playerMove { get; set; }
        public int computerMove { get; set; }
        public string result { get; set; }

    }
}