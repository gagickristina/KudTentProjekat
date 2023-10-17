using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KudTentProjekat.Models
{
    public class ClanBO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Morate uneti korisničko ime")]
        [Display(Name = "Korisničko ime:")]
        [RegularExpression(@"^[a-zA-Z0-9._]+$", ErrorMessage = "Korisničko ime ne sme da sadrzi razmake i posebne karaktere.")]

        public string? KorisnickoIme { get; set; }

        [Required(ErrorMessage = "Morate uneti lozinku")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "Lozinka mora da ima minimalno 8 karaktera i da sadrži 1 slovo, 1 broj, and 1 specijalan karakter.")]
        public string? Lozinka { get; set; }

        [Required(ErrorMessage = "Morate uneti prezime i ime")]
        [Display(Name = "Prezime i ime:")]
        [RegularExpression(@"^[A-ZŠĐČĆŽ][a-zšđčćž]+ [A-ZŠĐČĆŽ][a-zšđčćž]+$", ErrorMessage = "Unesite prezime i ime u formatu 'Prezime Ime'.")]
        public string? PrezimeIme { get; set; }
        [Required(ErrorMessage = "Morate izabrati da ili ne")]
        [Display(Name = "Da li imate brata/sestru koji je član:")]
        public string? Popust { get; set; }

        public PrivilegijeBO Privilegije { get; set; }

        [Required(ErrorMessage = "Morate izabrati sekciju")]
        [Display(Name = "Izaberite sekciju:")]
        public SekcijeBO Sekcije { get; set; }
        [Required]
        [Display(Name = "Status članarine:")]
        public PlacenoBO Placeno { get; set; }
    }
}
