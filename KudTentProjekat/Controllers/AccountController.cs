using KudTentProjekat.Models;
using KudTentProjekat.Models.EFRepository;
using KudTentProjekat.Models.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;

namespace KudTentProjekat.Controllers
{
    public class AccountController : Controller
    {
        private AuthRepository _authRepository;
        private PretragaClanovaRepository _pretragaClanovaRepository;

        private KulturnoUmetnickoDrustvoContext kudEntities = new KulturnoUmetnickoDrustvoContext();

        public AccountController()
        {
            _authRepository = new AuthRepository();
            _pretragaClanovaRepository = new PretragaClanovaRepository();

        }
        // GET: Login
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login()
        {


            return View();

        }

        [HttpPost]
        public IActionResult Login(ClanBO clanBO)
        {


            if (_authRepository.IsValid(clanBO))
            {


                if (_authRepository.IsAdmin(_pretragaClanovaRepository.GetUserName(clanBO.KorisnickoIme)))
                {
                    HttpContext.Session.SetString("KorisnickoIme", clanBO.KorisnickoIme);

                    return RedirectToAction("Index", "PretragaClanova", new { korisnickoIme = clanBO.KorisnickoIme });
                }
                else if (_authRepository.IsKorisnik(_pretragaClanovaRepository.GetUserName(clanBO.KorisnickoIme)))
                {
                    HttpContext.Session.SetString("KorisnickoIme", clanBO.KorisnickoIme);

                    return RedirectToAction("KorisnikIndex", "PretragaClanova", new { korisnickoIme = clanBO.KorisnickoIme });
                }
                else if (_authRepository.IsAsistent(_pretragaClanovaRepository.GetUserName(clanBO.KorisnickoIme)))
                {
                    HttpContext.Session.SetString("KorisnickoIme", clanBO.KorisnickoIme);

                    return RedirectToAction("AsistentIndex", "PretragaClanova", new { korisnickoIme = clanBO.KorisnickoIme });
                }

                else
                {
                    return View();
                }
            }




            ModelState.AddModelError("", "Netacan username ili password");
            return View();

        }
        //Login()


        public IActionResult Logout()
        {
            HttpContext.Session.Remove("KorisnickoIme");
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Register()
        {
            ViewBag.Pricilegije = _pretragaClanovaRepository.GetAllPrivilegije();
            ViewBag.Placeno = _pretragaClanovaRepository.GetAllPlaceno();
            ViewBag.Mesecna = _pretragaClanovaRepository.GetAllMesecna();
            ViewBag.Godisnja = _pretragaClanovaRepository.GetAllGodisnja();
            ViewBag.Sekcije = _pretragaClanovaRepository.GetAllSekcije();
            return View();
        }


        [HttpPost]
        public IActionResult Register(ClanBO clanBO)
        {
            if (ModelState.IsValid)
            {
                if (!kudEntities.Clan.Any(m => m.KorisnickoIme == clanBO.KorisnickoIme))
                {
                    if (clanBO.KorisnickoIme != null && clanBO.Lozinka != null && clanBO.PrezimeIme != null && clanBO.Popust != null && clanBO.Sekcije != null)
                    {
                        _authRepository.Create(clanBO);


                        TempData["Success"] = "Uspešno ste se registrovali!";
                        // HttpContext.Session.SetString("KorisnickoIme", clanBO.KorisnickoIme);
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        ViewBag.Pricilegije = _pretragaClanovaRepository.GetAllPrivilegije();
                        ViewBag.Placeno = _pretragaClanovaRepository.GetAllPlaceno();
                        ViewBag.Mesecna = _pretragaClanovaRepository.GetAllMesecna();
                        ViewBag.Godisnja = _pretragaClanovaRepository.GetAllGodisnja();
                        ViewBag.Sekcije = _pretragaClanovaRepository.GetAllSekcije();

                        ModelState.AddModelError("", "Morate uneti sve podatke");
                        return View();
                    }

                }
                else
                {
                    ViewBag.Pricilegije = _pretragaClanovaRepository.GetAllPrivilegije();
                    ViewBag.Placeno = _pretragaClanovaRepository.GetAllPlaceno();
                    ViewBag.Mesecna = _pretragaClanovaRepository.GetAllMesecna();
                    ViewBag.Godisnja = _pretragaClanovaRepository.GetAllGodisnja();
                    ViewBag.Sekcije = _pretragaClanovaRepository.GetAllSekcije();
                    ModelState.AddModelError("", "Korisnik sa tim korisnickim imenom vec postoji");
                    return View();
                }
            }

            ViewBag.Pricilegije = _pretragaClanovaRepository.GetAllPrivilegije();
            ViewBag.Placeno = _pretragaClanovaRepository.GetAllPlaceno();
            ViewBag.Mesecna = _pretragaClanovaRepository.GetAllMesecna();
            ViewBag.Godisnja = _pretragaClanovaRepository.GetAllGodisnja();
            ViewBag.Sekcije = _pretragaClanovaRepository.GetAllSekcije();



            return View();




        }
    }
}
