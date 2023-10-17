using KudTentProjekat.Models;
using KudTentProjekat.Models.EFRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace KudTentProjekat.Controllers
{
    public class PriznanicaController : Controller
    {
        private PriznanicaRepository _priznanicaRepository;
        private PretragaClanovaRepository _pretragaClanovaRepository;
        private KulturnoUmetnickoDrustvoContext kudEntities = new KulturnoUmetnickoDrustvoContext();

        public PriznanicaController()
        {
            _pretragaClanovaRepository = new PretragaClanovaRepository();
            _priznanicaRepository = new PriznanicaRepository();
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("KorisnickoIme") == null)
            {

                return RedirectToAction("Login", "Account");
            }
            ViewBag.Priznanice = _priznanicaRepository.GetAllPriznanice();
            ViewBag.Clanovi = _priznanicaRepository.GetAllClanovi();
            return View();
        }

        public IActionResult IndexAsistent()
        {
            if (HttpContext.Session.GetString("KorisnickoIme") == null)
            {

                return RedirectToAction("Login", "Account");
            }
            ViewBag.Priznanice = _priznanicaRepository.GetAllPriznanice();
            ViewBag.Clanovi = _priznanicaRepository.GetAllClanovi();
            return View();
        }
        public IActionResult GetPriznaniceByClanId(int id)
        {

            string korisnickoIme = HttpContext.Session.GetString("KorisnickoIme");

            // Pretraga člana po korisničkom imenu
            ClanBO clan = _pretragaClanovaRepository.GetUserName(korisnickoIme);

            if (clan != null)
            {
                if (id == 0)
                {
                    if (clan.Privilegije.Id == 3) // Privilegije.ID koji odgovaraju asistentima
                    {
                        return PartialView("ListaPriznanicaAsistent", _priznanicaRepository.GetAllPriznanice());
                    }
                    else
                    {
                        return PartialView("ListaPriznanica", _priznanicaRepository.GetAllPriznanice());
                    }
                }
                else
                {
                    if (clan.Privilegije.Id == 3) // Privilegije.ID koji odgovaraju asistentima
                    {
                        return PartialView("ListaPriznanicaAsistent", _priznanicaRepository.GetPriznaniceByClanId(id));
                    }
                    else
                    {
                        return PartialView("ListaPriznanica", _priznanicaRepository.GetPriznaniceByClanId(id));
                    }
                }

            }


            return View("Login", "Account");
        }


        public IActionResult GetPriznaniceByPriznanicaId(int id)
        {
            string korisnickoIme = HttpContext.Session.GetString("KorisnickoIme");

            // Pretraga člana po korisničkom imenu
            ClanBO clan = _pretragaClanovaRepository.GetUserName(korisnickoIme);

            if (clan != null)
            {
                if (id == 0)
                {
                    if (clan.Privilegije.Id == 3) // Privilegije.ID koji odgovaraju asistentima
                    {
                        return PartialView("ListaPriznanicaAsistent", _priznanicaRepository.GetAllPriznanice());
                    }
                    else
                    {
                        return PartialView("ListaPriznanica", _priznanicaRepository.GetAllPriznanice());
                    }
                }
                else
                {
                    if (clan.Privilegije.Id == 3) // Privilegije.ID koji odgovaraju asistentima
                    {
                        return PartialView("ListaPriznanicaAsistent", _priznanicaRepository.GetPriznaniceByPriznanicaId(id));
                    }
                    else
                    {
                        return PartialView("ListaPriznanica", _priznanicaRepository.GetPriznaniceByPriznanicaId(id));
                    }
                }
            }

            return View("Login", "Account");
        }

        public ActionResult Create()
        {

            ViewBag.Priznanice = _priznanicaRepository.GetAllPriznanice();
            ViewBag.Clanovi = _priznanicaRepository.GetAllClanovi();

            return View();
        }

        [HttpPost]
        public IActionResult Create(PriznanicaBO dodajPriznanicu)
        {

            if (dodajPriznanicu.Datum != null && dodajPriznanicu.Cena != 0 && dodajPriznanicu.ClanPriznanica.Id != 0 && dodajPriznanicu.NazivMeseca != null)
            {
                
                    _priznanicaRepository.Add(dodajPriznanicu);

                    ViewBag.Priznanice = _priznanicaRepository.GetAllPriznanice();
                    ViewBag.Clanovi = _priznanicaRepository.GetAllClanovi();
                    TempData["SuccessMessage"] = "Uspešno je kreirana priznanica.";
                    return View("Index");
                
              

            }
            else
            {

                ModelState.AddModelError("Error", "Morate popuniti sva polja");

                ViewBag.Priznanice = _priznanicaRepository.GetAllPriznanice();
                ViewBag.Clanovi = _priznanicaRepository.GetAllClanovi();
                return View(dodajPriznanicu);
            }




        }


        public ActionResult CreateAsistent()
        {

            ViewBag.Priznanice = _priznanicaRepository.GetAllPriznanice();
            ViewBag.Clanovi = _priznanicaRepository.GetAllClanovi();

            return View();
        }

        [HttpPost]
        public IActionResult CreateAsistent(PriznanicaBO dodajPriznanicu)
        {

            if (dodajPriznanicu.Datum != null && dodajPriznanicu.Cena != 0 && dodajPriznanicu.ClanPriznanica.Id != 0 && dodajPriznanicu.NazivMeseca != null)
            {
                    _priznanicaRepository.Add(dodajPriznanicu);

                    ViewBag.Priznanice = _priznanicaRepository.GetAllPriznanice();
                    ViewBag.Clanovi = _priznanicaRepository.GetAllClanovi();
                    TempData["SuccessMessage"] = "Uspešno je kreirana priznanica.";
                    return View("IndexAsistent");
            


            }
            else
            {

                ModelState.AddModelError("Error", "Morate popuniti sva polja");

                ViewBag.Priznanice = _priznanicaRepository.GetAllPriznanice();
                ViewBag.Clanovi = _priznanicaRepository.GetAllClanovi();
                return View(dodajPriznanicu);
            }





        }

        public ActionResult Edit(int id)
        {
            PriznanicaBO priznanicaBO = _priznanicaRepository.GetIDPriznanice(id);
            ViewBag.Priznanice = _priznanicaRepository.GetAllPriznanice();
            ViewBag.Clanovi = _priznanicaRepository.GetAllClanovi();
            ViewBag.Placeno = _pretragaClanovaRepository.GetAllPlaceno();
            ViewBag.Mesecna = _pretragaClanovaRepository.GetAllMesecna();
            ViewBag.Godisnja = _pretragaClanovaRepository.GetAllGodisnja();


            return View("Edit", priznanicaBO);
        }

        [HttpPost]
        public IActionResult Edit(PriznanicaBO azurirajPriznanicu)
        {


            _priznanicaRepository.Edit(azurirajPriznanicu);
            ViewBag.Clanovi = _priznanicaRepository.GetAllPriznanice();
            ViewBag.Clanovi = _priznanicaRepository.GetAllClanovi();
            return RedirectToAction("Index");



        }




        public IActionResult Delete(int id)
        {

            Priznanica priznanica = kudEntities.Priznanica.FirstOrDefault(t => t.Idpriznanice == id);



            return View("Delete", priznanica);


        }//Delete()

        [HttpPost]
        public ActionResult Delete(PriznanicaBO priznanicaBO)
        {
            Priznanica priznanicaZaBrisanje = kudEntities.Priznanica.FirstOrDefault(t => t.Idpriznanice == priznanicaBO.Id);


            kudEntities.Priznanica.Remove(priznanicaZaBrisanje);


            kudEntities.SaveChanges();

            ViewBag.Priznanice = _priznanicaRepository.GetAllPriznanice();
            ViewBag.Clanovi = _priznanicaRepository.GetAllClanovi();

            TempData["SuccessMessage"] = "Uspešno je izbrisana priznanica.";

            return View("Index");
        }


        public IActionResult DeleteAsistent(int id)
        {

            Priznanica priznanica = kudEntities.Priznanica.FirstOrDefault(t => t.Idpriznanice == id);



            return View("DeleteAsistent", priznanica);


        }

        [HttpPost]
        public ActionResult DeleteAsistent(PriznanicaBO priznanicaBO)
        {
            Priznanica priznanicaZaBrisanje = kudEntities.Priznanica.FirstOrDefault(t => t.Idpriznanice == priznanicaBO.Id);


            kudEntities.Priznanica.Remove(priznanicaZaBrisanje);


            kudEntities.SaveChanges();

            ViewBag.Priznanice = _priznanicaRepository.GetAllPriznanice();
            ViewBag.Clanovi = _priznanicaRepository.GetAllClanovi();

            TempData["SuccessMessage"] = "Uspešno je izbrisana priznanica.";

            return RedirectToAction("IndexAsistent");
        }



    }
}
