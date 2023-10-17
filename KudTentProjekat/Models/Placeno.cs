using System;
using System.Collections.Generic;

namespace KudTentProjekat.Models
{
    public partial class Placeno
    {
        public Placeno()
        {
            Clan = new HashSet<Clan>();
        }

        public int Idplaceno { get; set; }
        public int Idgodisnja { get; set; }
        public int Idmesecna { get; set; }

        public GodisnjaClanarina IdgodisnjaNavigation { get; set; }
        public MesecnaClanarina IdmesecnaNavigation { get; set; }
        public ICollection<Clan> Clan { get; set; }
    }
}
