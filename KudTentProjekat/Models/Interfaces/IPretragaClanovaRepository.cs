using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudTentProjekat.Models.Interfaces
{
    interface IPretragaClanovaRepository
    {
        IEnumerable<ClanBO> GetAllClanovi();
        IEnumerable<SekcijeBO> GetAllSekcije();
        IEnumerable<PrivilegijeBO> GetAllPrivilegije();
        IEnumerable<PlacenoBO> GetAllPlaceno();
        IEnumerable<MesecnaClanarinaBO> GetAllMesecna();
        IEnumerable<GodisnjaClanarinaBO> GetAllGodisnja();
        IEnumerable<ClanBO> GetByClanId(int clanId);
        IEnumerable<ClanBO> GetBySekcijaId(int sekcijaId);
      
        ClanBO GetIDClan(int clanId);
        ClanBO GetUserName(string korisnickoIme);
       
        void Add(ClanBO dodajClana);

        void Edit(ClanBO azurirajClana);

       // public bool CheckIfUsernameExists(string korisnickoIme);
       


    }
}
