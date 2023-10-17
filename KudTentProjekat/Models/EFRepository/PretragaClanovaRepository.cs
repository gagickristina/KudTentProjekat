using KudTentProjekat.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudTentProjekat.Models.EFRepository
{
    public class PretragaClanovaRepository : IPretragaClanovaRepository
    {
        private KulturnoUmetnickoDrustvoContext kudEntities = new KulturnoUmetnickoDrustvoContext();
        public void Add(ClanBO dodajClana)
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
            clanZaAzuriranje.Idsekcije = azurirajClana.Sekcije.Id;
            clanZaAzuriranje.Idprivilegije = azurirajClana.Privilegije.Id;

            kudEntities.SaveChanges();



            clanZaAzuriranje.Idplaceno = azurirajClana.Placeno.Id;
            kudEntities.SaveChanges();
        }

       

        public IEnumerable<ClanBO> GetAllClanovi()
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

        public IEnumerable<GodisnjaClanarinaBO> GetAllGodisnja()
        {
            List<GodisnjaClanarinaBO> sveGodisnje = new List<GodisnjaClanarinaBO>();
            foreach (GodisnjaClanarina godisnjaModel in kudEntities.GodisnjaClanarina.ToList())
            {
                GodisnjaClanarinaBO godisnjaBO = new GodisnjaClanarinaBO();
                godisnjaBO.Id = godisnjaModel.Idgodisnja;
                godisnjaBO.Status = godisnjaModel.Status;
                godisnjaBO.CenaObicna = godisnjaModel.CenaObicna;
                godisnjaBO.CenaPopust = godisnjaModel.CenaPopust;
                sveGodisnje.Add(godisnjaBO);
            }
            return sveGodisnje;
        }

        public IEnumerable<MesecnaClanarinaBO> GetAllMesecna()
        {
            List<MesecnaClanarinaBO> sveMesecne = new List<MesecnaClanarinaBO>();
            foreach (MesecnaClanarina mesecnaModel in kudEntities.MesecnaClanarina.ToList())
            {
                MesecnaClanarinaBO mesecnaBO = new MesecnaClanarinaBO();
                mesecnaBO.Id = mesecnaModel.Idmesecna;
                mesecnaBO.Status = mesecnaModel.Status;
                mesecnaBO.CenaObicna = mesecnaModel.CenaObicna;
                mesecnaBO.CenaPopust = mesecnaModel.CenaPopust;
                sveMesecne.Add(mesecnaBO);
            }
            return sveMesecne;
        }

        public IEnumerable<PlacenoBO> GetAllPlaceno()
        {
            List<PlacenoBO> svePlaceno = new List<PlacenoBO>();
            foreach (Placeno placenoModel in kudEntities.Placeno.ToList())
            {
                PlacenoBO placenoBO = new PlacenoBO();



                placenoBO.Id = placenoModel.Idplaceno;
                MesecnaClanarina mesecna = kudEntities.MesecnaClanarina.SingleOrDefault(m => m.Idmesecna == placenoModel.Idmesecna);
                GodisnjaClanarina godisnja = kudEntities.GodisnjaClanarina.SingleOrDefault(g => g.Idgodisnja == placenoModel.Idgodisnja);

                placenoBO.Mesecna = new MesecnaClanarinaBO()
                {
                    Id = mesecna.Idmesecna,
                    Status = mesecna.Status,
                    CenaObicna = mesecna.CenaObicna,
                    CenaPopust = mesecna.CenaPopust,


                };
                placenoBO.Godisnja = new GodisnjaClanarinaBO()
                {
                    Id = godisnja.Idgodisnja,
                    Status = godisnja.Status,
                    CenaObicna = godisnja.CenaObicna,
                    CenaPopust = godisnja.CenaPopust
                };

                svePlaceno.Add(placenoBO);

            }
            return svePlaceno;
        }

        public IEnumerable<PrivilegijeBO> GetAllPrivilegije()
        {
            List<PrivilegijeBO> svePrivilegije = new List<PrivilegijeBO>();
            foreach (Privilegije privilegijeModel in kudEntities.Privilegije.ToList())
            {
                PrivilegijeBO privilegijeBO = new PrivilegijeBO();
                privilegijeBO.Id = privilegijeModel.Idprivilegije;
                privilegijeBO.Naziv = privilegijeModel.Naziv;

                svePrivilegije.Add(privilegijeBO);
            }
            return svePrivilegije;
        }



        public IEnumerable<SekcijeBO> GetAllSekcije()
        {
            List<SekcijeBO> sveSekcije = new List<SekcijeBO>();
            foreach (Sekcije sekcijeModel in kudEntities.Sekcije.ToList())
            {
                SekcijeBO sekcijeBO = new SekcijeBO();

                sekcijeBO.Id = sekcijeModel.Idsekcije;
                sekcijeBO.Naziv = sekcijeModel.Naziv;
                sveSekcije.Add(sekcijeBO);
            }
            return sveSekcije;

        }

        public IEnumerable<ClanBO> GetByClanId(int clanId)
        {
            List<ClanBO> clanoviPoId = new List<ClanBO>();

            foreach (Clan clanModel in kudEntities.Clan.Where(t => t.Idclana == clanId).ToList())
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

                clanoviPoId.Add(clanBO);
            }
            return clanoviPoId;
        }

        public IEnumerable<ClanBO> GetBySekcijaId(int sekcijaId)
        {
            List<ClanBO> clanoviPoSekcijaId = new List<ClanBO>();

            foreach (Clan clanModel in kudEntities.Clan.Where(t => t.Idsekcije == sekcijaId).ToList())
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

                clanoviPoSekcijaId.Add(clanBO);
            }
            return clanoviPoSekcijaId;
        }


        public ClanBO GetIDClan(int clanId)
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

        public ClanBO GetUserName(string korisnickoIme)
        {
            Clan clanModel = kudEntities.Clan.FirstOrDefault(t => t.KorisnickoIme == korisnickoIme);
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

        /*
        public bool CheckIfUsernameExists(string korisnickoIme)
        {
            ClanBO clanBO = GetUserName(korisnickoIme);

            // Ako clanBO nije null, korisničko ime već postoji
            return clanBO != null;
        }*/




    }
}
