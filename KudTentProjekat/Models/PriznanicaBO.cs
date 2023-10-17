using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KudTentProjekat.Models
{
    public class PriznanicaBO
    {
        public int Id{ get; set; }

        [Required(ErrorMessage ="Morate uneti datum")]
        [Display(Name = "Izaberite datum:")]
        [RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])[\/](0[1-9]|1[012])[\/](19|20)\d\d$", ErrorMessage = "Morate uneti datum (dan/mesec/godina).")]
        public string Datum { get; set; }

        [Required(ErrorMessage ="Morate uneti cenu")]
        [Display(Name = "Cena:")]
        public int Cena { get; set; }

        [Required(ErrorMessage = "Morate izabrati da li je godišnja ili mesečna članarina")]
        [Display(Name = "Za šta se izdaje priznanica:")]
        public string? NazivMeseca { get; set; }

        [Required(ErrorMessage = "Morate izabrati člana")]
        [Display(Name = "Član:")]
        public ClanBO ClanPriznanica { get; set; }
    }
}
