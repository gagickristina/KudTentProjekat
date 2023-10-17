using KudTentProjekat.Models;
using KudTentProjekat.Models.EFRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace KudTentProjekat.Controllers
{
    public class PretragaClanovaController : Controller
    {
        private PretragaClanovaRepository _pretragaClanovaRepository;
        private KulturnoUmetnickoDrustvoContext kudEntities = new KulturnoUmetnickoDrustvoContext();
        public PretragaClanovaController()
        {
            _pretragaClanovaRepository = new PretragaClanovaRepository();
        }


        public IActionResult Index(string korisnickoIme)
        {
            if (HttpContext.Session.GetString("KorisnickoIme") == null)
            {

                return RedirectToAction("Login", "Account");
            }
            ViewBag.Clanovi = _pretragaClanovaRepository.GetAllClanovi();
            ViewBag.Clan = _pretragaClanovaRepository.GetUserName(korisnickoIme);
            return View();
        }
        public IActionResult KorisnikIndex(string korisnickoIme)
        {
            if (HttpContext.Session.GetString("KorisnickoIme") == null)
            {

                return RedirectToAction("Login", "Account");
            }
            return View(_pretragaClanovaRepository.GetUserName(korisnickoIme));

        }

        public IActionResult AsistentIndex(string korisnickoIme)
        {
            if (HttpContext.Session.GetString("KorisnickoIme") == null)
            {

                return RedirectToAction("Login", "Account");
            }
            ViewBag.Clanovi = _pretragaClanovaRepository.GetAllClanovi();
            ViewBag.Clan = _pretragaClanovaRepository.GetUserName(korisnickoIme);
            return View();

        }

        public IActionResult AdminInfo()
        {
            string korisnickoIme = HttpContext.Session.GetString("KorisnickoIme");
            ClanBO clanBO = _pretragaClanovaRepository.GetUserName(korisnickoIme);

            if (clanBO == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(clanBO);

        }

        public IActionResult AsistentInfo()
        {
            string korisnickoIme = HttpContext.Session.GetString("KorisnickoIme");
            ClanBO clanBO = _pretragaClanovaRepository.GetUserName(korisnickoIme);

            if (clanBO == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(clanBO);

        }


        public IActionResult GetClanBySekcijaId(int id)
        {
            if (id == 0)
            {
                return PartialView("ListaClanova", _pretragaClanovaRepository.GetAllClanovi());
            }
            return PartialView("ListaClanova", _pretragaClanovaRepository.GetBySekcijaId(id));
        }

        public IActionResult GetClanByClanId(int id)
        {

            string korisnickoIme = HttpContext.Session.GetString("KorisnickoIme");

            // Pretraga člana po korisničkom imenu
            ClanBO clan = _pretragaClanovaRepository.GetUserName(korisnickoIme);

            if (clan != null)
            {
                if (clan.Privilegije.Id == 3) // Privilegije.ID koji odgovaraju asistentima
                {
                    if (id != 0)
                    {
                        // Prikaz parcijalnog pogleda za asistente
                        return PartialView("ListaClanovaAsistent", _pretragaClanovaRepository.GetByClanId(id));
                    }
                    else
                    {
                        return PartialView("ListaClanovaAsistent", _pretragaClanovaRepository.GetAllClanovi());
                    }

                }
                else
                {
                    if (id != 0)
                    {

                        return PartialView("ListaClanova", _pretragaClanovaRepository.GetByClanId(id));
                    }
                    else
                    {
                        return PartialView("ListaClanova", _pretragaClanovaRepository.GetAllClanovi());
                    }
                }
            }

            return View("Login", "Account");
        }


        
        public IActionResult Create(ClanBO dodajClana)
        {
            if (!kudEntities.Clan.Any(m => m.KorisnickoIme == dodajClana.KorisnickoIme))
            {
                if (ModelState.IsValid)
                {
                    _pretragaClanovaRepository.Add(dodajClana);
                    TempData["SuccessMessage"] = "Uspešno je ubačen novi član.";
                    return RedirectToAction("Index");
                }
                else
                {
                    
                    ViewBag.Clanovi = _pretragaClanovaRepository.GetAllClanovi();
                    ViewBag.Sekcije = _pretragaClanovaRepository.GetAllSekcije();
                    ViewBag.Pricilegije = _pretragaClanovaRepository.GetAllPrivilegije();
                    ViewBag.Placeno = _pretragaClanovaRepository.GetAllPlaceno();
                    ViewBag.Mesecna = _pretragaClanovaRepository.GetAllMesecna();
                    ViewBag.Godisnja = _pretragaClanovaRepository.GetAllGodisnja();

                    return View(dodajClana);
                }
            }
            else
            {

                ViewBag.ErrorMessage = "Korisničko ime već postoji.";
                ViewBag.Clanovi = _pretragaClanovaRepository.GetAllClanovi();
                ViewBag.Sekcije = _pretragaClanovaRepository.GetAllSekcije();
                ViewBag.Pricilegije = _pretragaClanovaRepository.GetAllPrivilegije();
                ViewBag.Placeno = _pretragaClanovaRepository.GetAllPlaceno();
                ViewBag.Mesecna = _pretragaClanovaRepository.GetAllMesecna();
                ViewBag.Godisnja = _pretragaClanovaRepository.GetAllGodisnja();

                return View(dodajClana);
            }
        }

        /*
        [HttpPost]
        public IActionResult ProveriKorisnickoIme(string korisnickoIme)
        {
            bool exists = _pretragaClanovaRepository.CheckIfUsernameExists(korisnickoIme);

            if (exists)
            {
                ViewBag.ErrorMessage = "Korisničko ime već postoji.";
            }
            else
            {
                ViewBag.SuccessMessage = "Korisničko ime je dostupno.";
            }

            // Vratite se na isti view gde je forma za unos korisničkog imena
            return View("Create");
        }
        */

        public ActionResult EditKorisnik(int id)
        {
            ClanBO clanBO = _pretragaClanovaRepository.GetIDClan(id);
            ViewBag.Sekcije = _pretragaClanovaRepository.GetAllSekcije();
            ViewBag.Pricilegije = _pretragaClanovaRepository.GetAllPrivilegije();
            ViewBag.Placeno = _pretragaClanovaRepository.GetAllPlaceno();
            ViewBag.Mesecna = _pretragaClanovaRepository.GetAllMesecna();
            ViewBag.Godisnja = _pretragaClanovaRepository.GetAllGodisnja();

            return View("EditKorisnik", clanBO);
        }

        [HttpPost]
        public IActionResult EditKorisnik(ClanBO azurirajClana)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Sekcije = _pretragaClanovaRepository.GetAllSekcije();
                ViewBag.Pricilegije = _pretragaClanovaRepository.GetAllPrivilegije();
                ViewBag.Placeno = _pretragaClanovaRepository.GetAllPlaceno();
                ViewBag.Mesecna = _pretragaClanovaRepository.GetAllMesecna();
                ViewBag.Godisnja = _pretragaClanovaRepository.GetAllGodisnja();
                return View(azurirajClana);
            }
            else
            {
                _pretragaClanovaRepository.Edit(azurirajClana);
                TempData["SuccessMessage"] = "Uspešno izmenjeni podaci.";

                return RedirectToAction("KorisnikIndex", new { korisnickoIme = azurirajClana.KorisnickoIme });
            }


        }


        public ActionResult EditAdmin(int id)
        {
            ClanBO clanBO = _pretragaClanovaRepository.GetIDClan(id);
            ViewBag.Sekcije = _pretragaClanovaRepository.GetAllSekcije();
            ViewBag.Pricilegije = _pretragaClanovaRepository.GetAllPrivilegije();
            ViewBag.Placeno = _pretragaClanovaRepository.GetAllPlaceno();
            ViewBag.Mesecna = _pretragaClanovaRepository.GetAllMesecna();
            ViewBag.Godisnja = _pretragaClanovaRepository.GetAllGodisnja();

            return View("EditAdmin", clanBO);
        }

        [HttpPost]
        public IActionResult EditAdmin(ClanBO azurirajClana)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Sekcije = _pretragaClanovaRepository.GetAllSekcije();
                ViewBag.Pricilegije = _pretragaClanovaRepository.GetAllPrivilegije();
                ViewBag.Placeno = _pretragaClanovaRepository.GetAllPlaceno();
                ViewBag.Mesecna = _pretragaClanovaRepository.GetAllMesecna();
                ViewBag.Godisnja = _pretragaClanovaRepository.GetAllGodisnja();
                return View(azurirajClana);
            }
            else
            {

                _pretragaClanovaRepository.Edit(azurirajClana);
                TempData["SuccessMessage"] = "Uspešno izmenjeni podaci.";

                return RedirectToAction("AdminInfo", new { korisnickoIme = azurirajClana.KorisnickoIme });
            }


        }

        public ActionResult EditAsistent(int id)
        {
            ClanBO clanBO = _pretragaClanovaRepository.GetIDClan(id);
            ViewBag.Sekcije = _pretragaClanovaRepository.GetAllSekcije();
            ViewBag.Pricilegije = _pretragaClanovaRepository.GetAllPrivilegije();
            ViewBag.Placeno = _pretragaClanovaRepository.GetAllPlaceno();
            ViewBag.Mesecna = _pretragaClanovaRepository.GetAllMesecna();
            ViewBag.Godisnja = _pretragaClanovaRepository.GetAllGodisnja();

            return View("EditAsistent", clanBO);
        }

        [HttpPost]
        public IActionResult EditAsistent(ClanBO azurirajClana)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Sekcije = _pretragaClanovaRepository.GetAllSekcije();
                ViewBag.Pricilegije = _pretragaClanovaRepository.GetAllPrivilegije();
                ViewBag.Placeno = _pretragaClanovaRepository.GetAllPlaceno();
                ViewBag.Mesecna = _pretragaClanovaRepository.GetAllMesecna();
                ViewBag.Godisnja = _pretragaClanovaRepository.GetAllGodisnja();
                return View(azurirajClana);
            }
            else
            {

                _pretragaClanovaRepository.Edit(azurirajClana);

                TempData["SuccessMessage"] = "Uspešno izmenjeni podaci.";


                return RedirectToAction("AsistentInfo", new { korisnickoIme = azurirajClana.KorisnickoIme });
            }


        }



        public ActionResult Edit(int id)
        {
            ClanBO clanBO = _pretragaClanovaRepository.GetIDClan(id);
            ViewBag.Sekcije = _pretragaClanovaRepository.GetAllSekcije();
            ViewBag.Pricilegije = _pretragaClanovaRepository.GetAllPrivilegije();
            ViewBag.Placeno = _pretragaClanovaRepository.GetAllPlaceno();
            ViewBag.Mesecna = _pretragaClanovaRepository.GetAllMesecna();
            ViewBag.Godisnja = _pretragaClanovaRepository.GetAllGodisnja();

            return View("Edit", clanBO);
        }

        [HttpPost]
        public IActionResult Edit(ClanBO azurirajClana)
        {

            if (!ModelState.IsValid)
            {
               
                ViewBag.Sekcije = _pretragaClanovaRepository.GetAllSekcije();
                ViewBag.Pricilegije = _pretragaClanovaRepository.GetAllPrivilegije();
                ViewBag.Placeno = _pretragaClanovaRepository.GetAllPlaceno();
                ViewBag.Mesecna = _pretragaClanovaRepository.GetAllMesecna();
                ViewBag.Godisnja = _pretragaClanovaRepository.GetAllGodisnja();
                return View(azurirajClana);
            }
            else
            {
                _pretragaClanovaRepository.Edit(azurirajClana);
                ViewBag.Clanovi = _pretragaClanovaRepository.GetAllClanovi();

                TempData["SuccessMessage"] = "Uspešno izmenjeni podaci.";

                return View("Index");
            }
        }


        public ActionResult EditKorisnikaAsistent(int id)
        {
            ClanBO clanBO = _pretragaClanovaRepository.GetIDClan(id);
            ViewBag.Sekcije = _pretragaClanovaRepository.GetAllSekcije();
            ViewBag.Pricilegije = _pretragaClanovaRepository.GetAllPrivilegije();
            ViewBag.Placeno = _pretragaClanovaRepository.GetAllPlaceno();
            ViewBag.Mesecna = _pretragaClanovaRepository.GetAllMesecna();
            ViewBag.Godisnja = _pretragaClanovaRepository.GetAllGodisnja();

            return View("EditKorisnikaAsistent", clanBO);
        }

        [HttpPost]
        public IActionResult EditKorisnikaAsistent(ClanBO azurirajClana)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Sekcije = _pretragaClanovaRepository.GetAllSekcije();
                ViewBag.Pricilegije = _pretragaClanovaRepository.GetAllPrivilegije();
                ViewBag.Placeno = _pretragaClanovaRepository.GetAllPlaceno();
                ViewBag.Mesecna = _pretragaClanovaRepository.GetAllMesecna();
                ViewBag.Godisnja = _pretragaClanovaRepository.GetAllGodisnja();
                return View(azurirajClana);
            }
            else
            {
                _pretragaClanovaRepository.Edit(azurirajClana);
                ViewBag.Clanovi = _pretragaClanovaRepository.GetAllClanovi();
                TempData["SuccessMessage"] = "Uspešno izmenjeni podaci.";

                return View("AsistentIndex");
            }
        }




        public IActionResult Delete(int id)
        {

            Clan clan = kudEntities.Clan.FirstOrDefault(t => t.Idclana == id);

            return View("Delete", clan);


        }//Delete()

        [HttpPost]
        public ActionResult Delete(ClanBO clanBO)
        {
            Clan clanZaBrisanje = kudEntities.Clan.FirstOrDefault(t => t.Idclana == clanBO.Id);
            foreach (Priznanica priznanica in kudEntities.Priznanica.Where(t => t.Idkorisnika == clanBO.Id).ToList())
            {

                kudEntities.Priznanica.Remove(priznanica);
            }

            kudEntities.Clan.Remove(clanZaBrisanje);


            kudEntities.SaveChanges();
            ViewBag.Clanovi = _pretragaClanovaRepository.GetAllClanovi();
            TempData["SuccessMessage"] = "Uspešno izbrisan član.";

            return View("Index");
        }


    }
}
