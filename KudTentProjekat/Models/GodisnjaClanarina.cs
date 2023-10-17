using System;
using System.Collections.Generic;

namespace KudTentProjekat.Models
{
    public partial class GodisnjaClanarina
    {
        public GodisnjaClanarina()
        {
            Placeno = new HashSet<Placeno>();
        }

        public int Idgodisnja { get; set; }
        public string Status { get; set; }
        public int CenaObicna { get; set; }
        public int CenaPopust { get; set; }

        public ICollection<Placeno> Placeno { get; set; }
    }
}
