using KudTentProjekat.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudTentProjekat.Models.EFRepository
{
    public class AuthRepository : IAuthRepository
    {
        private KulturnoUmetnickoDrustvoContext kudEntities = new KulturnoUmetnickoDrustvoContext();

        public void Create(ClanBO dodajClana)
        {
            Clan clanModel = new Clan();

            clanModel.Idclana = dodajClana.Id;
            clanModel.KorisnickoIme = dodajClana.KorisnickoIme;
            clanModel.PrezimeIme = dodajClana.PrezimeIme;
            clanModel.Lozinka = dodajClana.Lozinka;
            clanModel.Popust = dodajClana.Popust;
            clanModel.Idplaceno = dodajClana.Placeno.Id;
            clanModel.Idsekcije = dodajClana.Sekcije.Id;
            clanModel.Idprivilegije = dodajClana.Privilegije.Id;

            kudEntities.Clan.Add(clanModel);

            kudEntities.SaveChanges();
        }

        public void Edit(ClanBO azurirajClana)
        {
            Clan clanZaAzuriranje = kudEntities.Clan.FirstOrDefault(t => t.Idclana == azurirajClana.Id);
            clanZaAzuriranje.Idclana = azurirajClana.Id;
            clanZaAzuriranje.KorisnickoIme = azurirajClana.KorisnickoIme;
            clanZaAzuriranje.PrezimeIme = azurirajClana.PrezimeIme;
            clanZaAzuriranje.Lozinka = azurirajClana.Lozinka;
            clanZaAzuriranje.Popust = azurirajClana.Popust;
            clanZaAzuriranje.Idplaceno = azurirajClana.Placeno.Id;
            clanZaAzuriranje.Idsekcije = azurirajClana.Sekcije.Id;
            clanZaAzuriranje.Idprivilegije = azurirajClana.Privilegije.Id;



            kudEntities.SaveChanges();
        }

        public IEnumerable<PrivilegijeBO> GetAllPrivilegije()
        {
            List<PrivilegijeBO> privilegije = new List<PrivilegijeBO>();

            foreach (Privilegije privilegijaModel in kudEntities.Privilegije.ToList())
            {
                PrivilegijeBO privilegijeBO = new PrivilegijeBO();
                privilegijeBO.Id = privilegijaModel.Idprivilegije;
                privilegijeBO.Naziv = privilegijaModel.Naziv;
                privilegije.Add(privilegijeBO);
            }
            return privilegije;


        }

        public ClanBO GetClanByPrivilegija(int privilegijaID)
        {
            Clan clanModel = kudEntities.Clan.FirstOrDefault(t => t.Idprivilegije == privilegijaID);
            ClanBO clanBO = new ClanBO();
            if (clanModel != null)
            {


                clanBO.Id = clanModel.Idclana;
                clanBO.KorisnickoIme = clanModel.KorisnickoIme;
                clanBO.Lozinka = clanModel.Lozinka;
                clanBO.PrezimeIme = clanModel.PrezimeIme;
                clanBO.Popust = clanModel.Popust;
                Placeno p = kudEntities.Placeno.SingleOrDefault(b => b.Idplaceno == clanModel.Idplaceno);
                MesecnaClanarina mesecna = kudEntities.MesecnaClanarina.SingleOrDefault(m => m.Idmesecna == p.Idmesecna);
                GodisnjaClanarina godisnja = kudEntities.GodisnjaClanarina.SingleOrDefault(g => g.Idgodisnja == p.Idgodisnja);
                clanBO.Placeno = new PlacenoBO()
                {
                    Id = p.Idplaceno,
                    Mesecna = new MesecnaClanarinaBO()
                    {
                        Id = mesecna.Idmesecna,
                        Status = mesecna.Status,
                        CenaObicna = mesecna.CenaObicna,
                        CenaPopust = mesecna.CenaPopust,


                    },
                    Godisnja = new GodisnjaClanarinaBO()
                    {
                        Id = godisnja.Idgodisnja,
                        Status = godisnja.Status,
                        CenaObicna = godisnja.CenaObicna,
                        CenaPopust = godisnja.CenaPopust
                    }


                };

                Sekcije sekcije = kudEntities.Sekcije.SingleOrDefault(s => s.Idsekcije == clanModel.Idsekcije);
                clanBO.Sekcije = new SekcijeBO()
                {
                    Id = sekcije.Idsekcije,
                    Naziv = sekcije.Naziv
                };

                Privilegije privilegije = kudEntities.Privilegije.SingleOrDefault(pr => pr.Idprivilegije == clanModel.Idprivilegije);
                clanBO.Privilegije = new PrivilegijeBO()
                {
                    Id = privilegije.Idprivilegije,
                    Naziv = privilegije.Naziv
                };
            }
            return clanBO;
        }

        public bool IsKorisnik(ClanBO clanBO)
        {
            bool isKorisnik;
            if (clanBO.Privilegije.Id == 2)
            {
                isKorisnik= true;
                return isKorisnik;
            }
            else
            {
                isKorisnik = false;
                return isKorisnik;
            }
        }
        public bool IsAdmin(ClanBO clanBO)
        {
            bool isAdmin;
           if(clanBO.Privilegije.Id==1)
           {
                isAdmin = true;
                return isAdmin;
           }
            else
            {
                isAdmin = false;
                return isAdmin;
            }
           
            
        }

        public bool IsAsistent(ClanBO clanBO)
        {
            bool isAsistent;
            if (clanBO.Privilegije.Id == 3)
            {
                isAsistent = true;
                return isAsistent;
            }
            else
            {
                isAsistent = false;
                return isAsistent;
            }


        }

        //Ako se poklapaju korisnicko ime i lozinka stanje je validno
        public bool IsValid(ClanBO clanBO)
        {
            bool isValid =
                 kudEntities.Clan.Any(t => t.KorisnickoIme == clanBO.KorisnickoIme && t.Lozinka == clanBO.Lozinka);
            return isValid;
        }
    

        public ClanBO VratiClanaPoId(int clanId)
        {
            Clan clanModel = kudEntities.Clan.FirstOrDefault(t => t.Idclana == clanId);
            ClanBO clanBO = new ClanBO();
            if (clanModel != null)
            {


                clanBO.Id = clanModel.Idclana;
                clanBO.KorisnickoIme = clanModel.KorisnickoIme;
                clanBO.Lozinka = clanModel.Lozinka;
                clanBO.PrezimeIme = clanModel.PrezimeIme;
                clanBO.Popust = clanModel.Popust;
                Placeno p = kudEntities.Placeno.SingleOrDefault(b => b.Idplaceno == clanModel.Idplaceno);
                MesecnaClanarina mesecna = kudEntities.MesecnaClanarina.SingleOrDefault(m => m.Idmesecna == p.Idmesecna);
                GodisnjaClanarina godisnja = kudEntities.GodisnjaClanarina.SingleOrDefault(g => g.Idgodisnja == p.Idgodisnja);
                clanBO.Placeno = new PlacenoBO()
                {
                    Id = p.Idplaceno,
                    Mesecna = new MesecnaClanarinaBO()
                    {
                        Id = mesecna.Idmesecna,
                        Status = mesecna.Status,
                        CenaObicna = mesecna.CenaObicna,
                        CenaPopust = mesecna.CenaPopust,


                    },
                    Godisnja = new GodisnjaClanarinaBO()
                    {
                        Id = godisnja.Idgodisnja,
                        Status = godisnja.Status,
                        CenaObicna = godisnja.CenaObicna,
                        CenaPopust = godisnja.CenaPopust
                    }


                };

                Sekcije sekcije = kudEntities.Sekcije.SingleOrDefault(s => s.Idsekcije == clanModel.Idsekcije);
                clanBO.Sekcije = new SekcijeBO()
                {
                    Id = sekcije.Idsekcije,
                    Naziv = sekcije.Naziv
                };

                Privilegije privilegije = kudEntities.Privilegije.SingleOrDefault(pr => pr.Idprivilegije == clanModel.Idprivilegije);
                clanBO.Privilegije = new PrivilegijeBO()
                {
                    Id = privilegije.Idprivilegije,
                    Naziv = privilegije.Naziv
                };
            }
            return clanBO;
        }

        public IEnumerable<ClanBO> VratiSveClanove()
        {
            List<ClanBO> sviClanovi = new List<ClanBO>();

            foreach (Clan clanModel in kudEntities.Clan.ToList())
            {
                ClanBO clanBO = new ClanBO();

                clanBO.Id = clanModel.Idclana;
                clanBO.KorisnickoIme = clanModel.KorisnickoIme;
                clanBO.Lozinka = clanModel.Lozinka;
                clanBO.PrezimeIme = clanModel.PrezimeIme;
                clanBO.Popust = clanModel.Popust;
                Placeno p = kudEntities.Placeno.SingleOrDefault(b => b.Idplaceno == clanModel.Idplaceno);
                MesecnaClanarina mesecna = kudEntities.MesecnaClanarina.SingleOrDefault(m => m.Idmesecna == p.Idmesecna);
                GodisnjaClanarina godisnja = kudEntities.GodisnjaClanarina.SingleOrDefault(g => g.Idgodisnja == p.Idgodisnja);
                clanBO.Placeno = new PlacenoBO()
                {
                    Id = p.Idplaceno,
                    Mesecna = new MesecnaClanarinaBO()
                    {
                        Id = mesecna.Idmesecna,
                        Status = mesecna.Status,
                        CenaObicna = mesecna.CenaObicna,
                        CenaPopust = mesecna.CenaPopust,


                    },
                    Godisnja = new GodisnjaClanarinaBO()
                    {
                        Id = godisnja.Idgodisnja,
                        Status = godisnja.Status,
                        CenaObicna = godisnja.CenaObicna,
                        CenaPopust = godisnja.CenaPopust
                    }


                };

                Sekcije sekcije = kudEntities.Sekcije.SingleOrDefault(s => s.Idsekcije == clanModel.Idsekcije);
                clanBO.Sekcije = new SekcijeBO()
                {
                    Id = sekcije.Idsekcije,
                    Naziv = sekcije.Naziv
                };

                Privilegije privilegije = kudEntities.Privilegije.SingleOrDefault(pr => pr.Idprivilegije == clanModel.Idprivilegije);
                clanBO.Privilegije = new PrivilegijeBO()
                {
                    Id = privilegije.Idprivilegije,
                    Naziv = privilegije.Naziv
                };

                sviClanovi.Add(clanBO);
            }
            return sviClanovi;
        }
    }
}
