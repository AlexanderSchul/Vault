using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSP_WebApp.Models
{
    
    public class Round
    {
        public string Playername { get; set; }
        public int Playermove { get; set; }
        public Enum[] Result { get; set; }
    }

}