using System;
using System.Collections.Generic;

namespace KudTentProjekat.Models
{
    public partial class MesecnaClanarina
    {
        public MesecnaClanarina()
        {
            Placeno = new HashSet<Placeno>();
        }

        public int Idmesecna { get; set; }
        public string Status { get; set; }
        public int CenaObicna { get; set; }
        public int CenaPopust { get; set; }

        public ICollection<Placeno> Placeno { get; set; }
    }
}
