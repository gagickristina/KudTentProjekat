using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace KudTentProjekat.Models
{
    public class PlacenoBO
    {
        public int Id{ get; set; }

       
        public GodisnjaClanarinaBO Godisnja { get; set; }

      
        public MesecnaClanarinaBO Mesecna { get; set; }
    }
}
