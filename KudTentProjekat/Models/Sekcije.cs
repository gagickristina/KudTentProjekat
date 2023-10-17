using System;
using System.Collections.Generic;

namespace KudTentProjekat.Models
{
    public partial class Sekcije
    {
        public Sekcije()
        {
            Clan = new HashSet<Clan>();
        }

        public int Idsekcije { get; set; }
        public string Naziv { get; set; }

        public ICollection<Clan> Clan { get; set; }
    }
}
