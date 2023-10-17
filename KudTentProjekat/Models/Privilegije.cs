using System;
using System.Collections.Generic;

namespace KudTentProjekat.Models
{
    public partial class Privilegije
    {
        public Privilegije()
        {
            Clan = new HashSet<Clan>();
        }

        public int Idprivilegije { get; set; }
        public string Naziv { get; set; }

        public ICollection<Clan> Clan { get; set; }
    }
}
