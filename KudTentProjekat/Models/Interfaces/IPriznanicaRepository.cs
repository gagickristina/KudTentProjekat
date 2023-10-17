using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudTentProjekat.Models.Interfaces
{
    interface IPriznanicaRepository
    {
        IEnumerable<PriznanicaBO> GetAllPriznanice();
        IEnumerable<ClanBO> GetAllClanovi();
        IEnumerable<PriznanicaBO> GetPriznaniceByClanId(int clanId);
        IEnumerable<PriznanicaBO> GetPriznaniceByPriznanicaId(int priznanicaId);
        void Add(PriznanicaBO dodajPriznanicu);
     
        PriznanicaBO GetIDPriznanice(int clanId);
       
        void Edit(PriznanicaBO azurirajPriznanicu);

    }
}
