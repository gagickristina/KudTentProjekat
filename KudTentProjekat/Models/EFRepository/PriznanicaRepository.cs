using KudTentProjekat.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KudTentProjekat.Models.EFRepository
{
    public class PriznanicaRepository : IPriznanicaRepository
    {
        private KulturnoUmetnickoDrustvoContext kudEntities = new KulturnoUmetnickoDrustvoContext();
        public void Add(PriznanicaBO dodajPriznanicu)
        {
            Priznanica priznanicaModel = new Priznanica();

            priznanicaModel.Idpriznanice = dodajPriznanicu.Id;
            priznanicaModel.Datum = dodajPriznanicu.Datum;
            /*if(dodajPriznanicu.ClanPriznanica.Popust=="Da")
            {
                priznanica.Cena = dodajPriznanicu.ClanPriznanica.Placeno.Mesecna.CenaPopust;
            }
            else
            {
                priznanica.Cena = dodajPriznanicu.ClanPriznanica.Placeno.Mesecna.CenaObicna;
            }
           */
            priznanicaModel.Cena = dodajPriznanicu.Cena;
            priznanicaModel.NazivMeseca = dodajPriznanicu.NazivMeseca;
            priznanicaModel.Idkorisnika = dodajPriznanicu.ClanPriznanica.Id;


            kudEntities.Priznanica.Add(priznanicaModel);

            kudEntities.SaveChanges();


        }

        public void Edit(PriznanicaBO azurirajPriznanicu)
        {
            Priznanica priznanicaZaAzuriranje = kudEntities.Priznanica.FirstOrDefault(t => t.Idpriznanice == azurirajPriznanicu.Id);
            priznanicaZaAzuriranje.Idpriznanice = azurirajPriznanicu.Id;
            priznanicaZaAzuriranje.Datum = azurirajPriznanicu.Datum;
            priznanicaZaAzuriranje.Cena = azurirajPriznanicu.Cena;
            
            priznanicaZaAzuriranje.NazivMeseca = azurirajPriznanicu.NazivMeseca;
            priznanicaZaAzuriranje.Idkorisnika = azurirajPriznanicu.ClanPriznanica.Id;

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

        public IEnumerable<PriznanicaBO> GetAllPriznanice()
        {
            List<PriznanicaBO> priznanice = new List<PriznanicaBO>();
            foreach (Priznanica priznanicaModel in kudEntities.Priznanica.ToList())
            {
                PriznanicaBO priznanicaBO = new PriznanicaBO();
                priznanicaBO.Id = priznanicaModel.Idpriznanice;
                priznanicaBO.Datum = priznanicaModel.Datum;
                priznanicaBO.Cena = priznanicaModel.Cena;
                priznanicaBO.NazivMeseca = priznanicaModel.NazivMeseca;

                Clan clanPriznanica = kudEntities.Clan.SingleOrDefault(t => t.Idclana == priznanicaModel.Idkorisnika);

                Placeno p = kudEntities.Placeno.SingleOrDefault(b => b.Idplaceno == clanPriznanica.Idplaceno);
                MesecnaClanarina mesecna = kudEntities.MesecnaClanarina.SingleOrDefault(m => m.Idmesecna == p.Idmesecna);
                GodisnjaClanarina godisnja = kudEntities.GodisnjaClanarina.SingleOrDefault(g => g.Idgodisnja == p.Idgodisnja);
                Sekcije sekcije = kudEntities.Sekcije.SingleOrDefault(s => s.Idsekcije == clanPriznanica.Idsekcije);
                Privilegije privilegije = kudEntities.Privilegije.SingleOrDefault(pr => pr.Idprivilegije == clanPriznanica.Idprivilegije);
                priznanicaBO.ClanPriznanica = new ClanBO()
                {
                    Id = clanPriznanica.Idclana,
                    KorisnickoIme = clanPriznanica.KorisnickoIme,
                    Lozinka = clanPriznanica.Lozinka,
                    PrezimeIme = clanPriznanica.PrezimeIme,
                    Popust = clanPriznanica.Popust,

                    Placeno = new PlacenoBO()
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


                    },


                    Sekcije = new SekcijeBO()
                    {
                        Id = sekcije.Idsekcije,
                        Naziv = sekcije.Naziv
                    },


                    Privilegije = new PrivilegijeBO()
                    {
                        Id = privilegije.Idprivilegije,
                        Naziv = privilegije.Naziv
                    }
                };

                priznanice.Add(priznanicaBO);
            }
            return priznanice;
        }

        public PriznanicaBO GetIDPriznanice(int priznanicaId)
        {
            Priznanica priznanicaModel = kudEntities.Priznanica.FirstOrDefault(t => t.Idpriznanice == priznanicaId);
            PriznanicaBO priznanicaBO = new PriznanicaBO();
            if (priznanicaModel != null)
            {

                priznanicaBO.Id = priznanicaModel.Idpriznanice;
                priznanicaBO.Datum = priznanicaModel.Datum;
                priznanicaBO.Cena = priznanicaModel.Cena;
                priznanicaBO.NazivMeseca = priznanicaModel.NazivMeseca;

                Clan clanPriznanica = kudEntities.Clan.SingleOrDefault(t => t.Idclana == priznanicaModel.Idkorisnika);

                Placeno p = kudEntities.Placeno.SingleOrDefault(b => b.Idplaceno == clanPriznanica.Idplaceno);
                MesecnaClanarina mesecna = kudEntities.MesecnaClanarina.SingleOrDefault(m => m.Idmesecna == p.Idmesecna);
                GodisnjaClanarina godisnja = kudEntities.GodisnjaClanarina.SingleOrDefault(g => g.Idgodisnja == p.Idgodisnja);
                Sekcije sekcije = kudEntities.Sekcije.SingleOrDefault(s => s.Idsekcije == clanPriznanica.Idsekcije);
                Privilegije privilegije = kudEntities.Privilegije.SingleOrDefault(pr => pr.Idprivilegije == clanPriznanica.Idprivilegije);
                priznanicaBO.ClanPriznanica = new ClanBO()
                {
                    Id = clanPriznanica.Idclana,
                    KorisnickoIme = clanPriznanica.KorisnickoIme,
                    Lozinka = clanPriznanica.Lozinka,
                    PrezimeIme = clanPriznanica.PrezimeIme,
                    Popust = clanPriznanica.Popust,

                    Placeno = new PlacenoBO()
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


                    },


                    Sekcije = new SekcijeBO()
                    {
                        Id = sekcije.Idsekcije,
                        Naziv = sekcije.Naziv
                    },


                    Privilegije = new PrivilegijeBO()
                    {
                        Id = privilegije.Idprivilegije,
                        Naziv = privilegije.Naziv
                    }
                };
            }
            return priznanicaBO;
        }

        public IEnumerable<PriznanicaBO> GetPriznaniceByClanId(int clanId)
        {
            List<PriznanicaBO> priznanice = new List<PriznanicaBO>();
            foreach (Priznanica priznanicaModel in kudEntities.Priznanica.Where(t => t.Idkorisnika== clanId).ToList())
            {
                PriznanicaBO priznanicaBO = new PriznanicaBO();
                priznanicaBO.Id = priznanicaModel.Idpriznanice;
                priznanicaBO.Datum = priznanicaModel.Datum;
                priznanicaBO.Cena = priznanicaModel.Cena;
                priznanicaBO.NazivMeseca = priznanicaModel.NazivMeseca;
                Clan clanPriznanica = kudEntities.Clan.SingleOrDefault(t => t.Idclana == priznanicaModel.Idkorisnika);

                Placeno p = kudEntities.Placeno.SingleOrDefault(b => b.Idplaceno == clanPriznanica.Idplaceno);
                MesecnaClanarina mesecna = kudEntities.MesecnaClanarina.SingleOrDefault(m => m.Idmesecna == p.Idmesecna);
                GodisnjaClanarina godisnja = kudEntities.GodisnjaClanarina.SingleOrDefault(g => g.Idgodisnja == p.Idgodisnja);
                Sekcije sekcije = kudEntities.Sekcije.SingleOrDefault(s => s.Idsekcije == clanPriznanica.Idsekcije);
                Privilegije privilegije = kudEntities.Privilegije.SingleOrDefault(pr => pr.Idprivilegije == clanPriznanica.Idprivilegije);
                priznanicaBO.ClanPriznanica = new ClanBO()
                {
                    Id = clanPriznanica.Idclana,
                    KorisnickoIme = clanPriznanica.KorisnickoIme,
                    Lozinka = clanPriznanica.Lozinka,
                    PrezimeIme = clanPriznanica.PrezimeIme,
                    Popust = clanPriznanica.Popust,

                    Placeno = new PlacenoBO()
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


                    },


                    Sekcije = new SekcijeBO()
                    {
                        Id = sekcije.Idsekcije,
                        Naziv = sekcije.Naziv
                    },


                    Privilegije = new PrivilegijeBO()
                    {
                        Id = privilegije.Idprivilegije,
                        Naziv = privilegije.Naziv
                    }
                };

                priznanice.Add(priznanicaBO);
            }
            return priznanice;
        }

        public IEnumerable<PriznanicaBO> GetPriznaniceByPriznanicaId(int priznanicaId)
        {
            List<PriznanicaBO> priznanice = new List<PriznanicaBO>();
            foreach (Priznanica priznanicaModel in kudEntities.Priznanica.Where(t => t.Idpriznanice == priznanicaId).ToList())
            {
                PriznanicaBO priznanicaBO = new PriznanicaBO();
                priznanicaBO.Id = priznanicaModel.Idpriznanice;
                priznanicaBO.Datum = priznanicaModel.Datum;
                priznanicaBO.Cena = priznanicaModel.Cena;
                priznanicaBO.NazivMeseca = priznanicaModel.NazivMeseca;
                Clan clanPriznanica = kudEntities.Clan.SingleOrDefault(t => t.Idclana == priznanicaModel.Idkorisnika);

                Placeno p = kudEntities.Placeno.SingleOrDefault(b => b.Idplaceno == clanPriznanica.Idplaceno);
                MesecnaClanarina mesecna = kudEntities.MesecnaClanarina.SingleOrDefault(m => m.Idmesecna == p.Idmesecna);
                GodisnjaClanarina godisnja = kudEntities.GodisnjaClanarina.SingleOrDefault(g => g.Idgodisnja == p.Idgodisnja);
                Sekcije sekcije = kudEntities.Sekcije.SingleOrDefault(s => s.Idsekcije == clanPriznanica.Idsekcije);
                Privilegije privilegije = kudEntities.Privilegije.SingleOrDefault(pr => pr.Idprivilegije == clanPriznanica.Idprivilegije);
                priznanicaBO.ClanPriznanica = new ClanBO()
                {
                    Id = clanPriznanica.Idclana,
                    KorisnickoIme = clanPriznanica.KorisnickoIme,
                    Lozinka = clanPriznanica.Lozinka,
                    PrezimeIme = clanPriznanica.PrezimeIme,
                    Popust = clanPriznanica.Popust,

                    Placeno = new PlacenoBO()
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


                    },


                    Sekcije = new SekcijeBO()
                    {
                        Id = sekcije.Idsekcije,
                        Naziv = sekcije.Naziv
                    },


                    Privilegije = new PrivilegijeBO()
                    {
                        Id = privilegije.Idprivilegije,
                        Naziv = privilegije.Naziv
                    }
                };

                priznanice.Add(priznanicaBO);
            }
            return priznanice;
        }

        

    }
}

