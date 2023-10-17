using System;
using System.Collections.Generic;

namespace KudTentProjekat.Models
{
    public partial class Clan
    {
        public Clan()
        {
            Priznanica = new HashSet<Priznanica>();
        }

        public int Idclana { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string PrezimeIme { get; set; }
        public string Popust { get; set; }
        public int Idprivilegije { get; set; }
        public int Idsekcije { get; set; }
        public int Idplaceno { get; set; }

        public Placeno IdplacenoNavigation { get; set; }
        public Privilegije IdprivilegijeNavigation { get; set; }
        public Sekcije IdsekcijeNavigation { get; set; }
        public ICollection<Priznanica> Priznanica { get; set; }
    }
}
