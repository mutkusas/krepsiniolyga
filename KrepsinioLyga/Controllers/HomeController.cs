using KrepsinioLyga.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;


namespace KrepsinioLyga.Controllers
{
    public class HomeController : Controller
    {
        private LygaEntities _entities = new LygaEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Komandos()
        {
            ViewBag.Message = "Informacija apie komandas.";

            return View(_entities.Komanda.ToList());
        }

        public ActionResult Arenos()
        {
            ViewBag.Message = "Informacija apie arenas.";

            return View(_entities.Arena.ToList());
        }

        public ActionResult Zaidejai()
        {
            ViewBag.Message = "Informacija apie žaidėjus.";

            return View(_entities.Žaidėjas.ToList());
        }

        public ActionResult Rungtynes()
        {
            ViewBag.Message = "Informacija apie rungtynes.";

            return View(_entities.Rungtynės.ToList());
        }

        public ActionResult CreateArena()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateArena([Bind(Exclude = "Id")]Arena arenaToCreate)
        {
            _entities.Arena.Add(arenaToCreate);
            _entities.SaveChanges();
            return RedirectToAction("Arenos");
        }

        public ActionResult DeleteArena(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arena arena = _entities.Arena.Find(Id);
            if (arena == null)
            {
                _entities.Entry(arena).State = EntityState.Deleted;
                return RedirectToAction("Arenos");
            }
            return View(arena);
        }

        public ActionResult DeleteGame(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rungtynės game = _entities.Rungtynės.Find(Id);
            if (game == null)
            {
                _entities.Entry(game).State = EntityState.Deleted;
                return RedirectToAction("Rungtynes");
            }
            return View(game);
        }

        public ActionResult DeletePlayer(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Žaidėjas player = _entities.Žaidėjas.Find(Id);
            if (player == null)
            {
                _entities.Entry(player).State = EntityState.Deleted;
                return RedirectToAction("Zaidejai");
            }
            return View(player);
        }

        public ActionResult DeleteTeam(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komanda team = _entities.Komanda.Find(Id);
            if (team == null)
            {
                _entities.Entry(team).State = EntityState.Deleted;
                return RedirectToAction("Komandos");
            }
            return View(team);
        }

        public ActionResult EditArena(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arena arena = _entities.Arena.Find(id);
            if (arena == null)
            {
                return HttpNotFound();
            }
            return View(arena);
        }

        public ActionResult EditTeam(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Komanda team = _entities.Komanda.Find(id);
            if (team == null)
            {
                return HttpNotFound();
            }
            return View(team);
        }

        public ActionResult EditGame(int? id)
        {
            List<SelectListItem> teamsToShow = new List<SelectListItem>();
            List<SelectListItem> arenasToShow = new List<SelectListItem>();

            foreach (var t in _entities.Komanda)
            {
                teamsToShow.Add(new SelectListItem
                {
                    Text = t.Pavadinimas,
                    Value = t.Id + ""
                });
            }

            foreach (var a in _entities.Arena)
            {
                arenasToShow.Add(new SelectListItem
                {
                    Text = a.Pavadinimas,
                    Value = a.Id + ""
                });
            }
            ViewBag.Teams = teamsToShow;
            ViewBag.Arenas = arenasToShow;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rungtynės game = _entities.Rungtynės.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        public ActionResult EditPlayer(int? id)
        {
            List<SelectListItem> teamsToShow = new List<SelectListItem>();

            foreach (var t in _entities.Komanda)
            {
                teamsToShow.Add(new SelectListItem
                {
                    Text = t.Pavadinimas,
                    Value = t.Id + ""
                });
            }

            ViewBag.Teams = teamsToShow;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Žaidėjas player = _entities.Žaidėjas.Find(id);
            if (player== null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        public ActionResult CreateTeam()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateTeam([Bind(Exclude = "Id")]Komanda komandaToCreate)
        {
            _entities.Komanda.Add(komandaToCreate);
            _entities.SaveChanges();
            return RedirectToAction("Komandos");
        }

        public ActionResult CreatePlayer()
        {
            List<SelectListItem> teamsToShow = new List<SelectListItem>();

            teamsToShow.Add(new SelectListItem
            {
                Text = "Laisvasis agentas",
                Value = 0+""
            });

            foreach (var t in _entities.Komanda)
            {
                teamsToShow.Add(new SelectListItem
                {
                    Text = t.Pavadinimas,
                    Value = t.Id+""
                });
            }
            ViewBag.Teams = teamsToShow;

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreatePlayer([Bind(Exclude = "Id")]Žaidėjas zaidejasToCreate)
        {

            _entities.Žaidėjas.Add(zaidejasToCreate);
            _entities.SaveChanges();
            return RedirectToAction("Zaidejai");
        }

        public ActionResult CreateGame()
        {
            List<SelectListItem> teamsToShow = new List<SelectListItem>();
            List<SelectListItem> arenasToShow = new List<SelectListItem>();

            foreach (var t in _entities.Komanda)
            {
                teamsToShow.Add(new SelectListItem
                {
                    Text = t.Pavadinimas,
                    Value = t.Id + ""
                });
            }

            foreach (var a in _entities.Arena)
            {
                arenasToShow.Add(new SelectListItem
                {
                    Text = a.Pavadinimas,
                    Value = a.Id + ""
                });
            }
            ViewBag.Teams = teamsToShow;
            ViewBag.Arenas = arenasToShow;

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateGame([Bind(Exclude = "Id")]Rungtynės rungtynesToCreate)
        {
            _entities.Rungtynės.Add(rungtynesToCreate);
            _entities.SaveChanges();
            ViewData["Arena"] = new SelectList(_entities.Arena, "Pavadinimas");
            return RedirectToAction("Rungtynes");
        }
    }
}