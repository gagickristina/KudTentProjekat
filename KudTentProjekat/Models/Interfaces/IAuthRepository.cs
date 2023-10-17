using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudTentProjekat.Models.Interfaces
{
    interface IAuthRepository
    {
        IEnumerable<ClanBO> VratiSveClanove();
        ClanBO VratiClanaPoId(int clanId);
        void Create(ClanBO dodajClana);
        void Edit(ClanBO azurirajClana);
        public IEnumerable<PrivilegijeBO> GetAllPrivilegije();
        public ClanBO GetClanByPrivilegija(int privilegijaID);
        public bool IsKorisnik(ClanBO clanBO);
        public bool IsAdmin(ClanBO clanBO);
        public bool IsAsistent(ClanBO clanBO);
        public bool IsValid(ClanBO clanBO);
     

    }
}
