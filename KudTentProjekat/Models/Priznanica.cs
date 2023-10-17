using System;
using System.Collections.Generic;

namespace KudTentProjekat.Models
{
    public partial class Priznanica
    {
        public int Idpriznanice { get; set; }
        public string Datum { get; set; }
        public int Cena { get; set; }
        public string NazivMeseca { get; set; }
        public int Idkorisnika { get; set; }

        public Clan IdkorisnikaNavigation { get; set; }
    }
}
