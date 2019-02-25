using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cinema_Mvc.Models;

namespace Cinema_Mvc.DAL
{
    public class SessaoController : Controller
    {
        private CinemaContext db = new CinemaContext();

        // GET: Sessao
        public ActionResult Index(string sortOrder, string searchString)
        {
            var sessoes = db.Sessoes.Include(s => s.Cinema).Include(s => s.Filme);
            

            ViewBag.CinemaSortParm = sortOrder == "cinema" ? "cinema_desc" : "cinema";
            ViewBag.FilmeSortParm = sortOrder == "filme" ? "filme_desc" : "filme";
            ViewBag.HorarioSortParm = sortOrder == "horario" ? "horario_desc" : "horario";

            if (!String.IsNullOrEmpty(searchString))
            {
                sessoes = sessoes.Where(s => s.Cinema.Nome.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(sortOrder))
            {
                switch (sortOrder)
                {
                    case "cinema":
                        sessoes = sessoes.OrderBy(x => x.Cinema.Nome);
                        break;
                    case "cinema_desc":
                        sessoes = sessoes.OrderByDescending(x => x.Cinema.Nome);
                        break;
                    case "filme":
                        sessoes = sessoes.OrderBy(x => x.Filme.Nome);
                        break;
                    case "filme_desc":
                        sessoes = sessoes.OrderByDescending(x => x.Filme.Nome);
                        break;
                    case "horario":
                        sessoes = sessoes.OrderBy(x => x.Horario);
                        break;
                    case "horario_desc":
                        sessoes = sessoes.OrderByDescending(x => x.Horario);
                        break;

                }
            }

            return View(sessoes.ToList());
        }

        // GET: Sessao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sessao sessao = db.Sessoes.Find(id);
            if (sessao == null)
            {
                return HttpNotFound();
            }
            return View(sessao);
        }

        // GET: Sessao/Create
        public ActionResult Create()
        {
            ViewBag.CinemaID = new SelectList(db.Cinemas, "CinemaID", "Nome");
            ViewBag.FilmeID = new SelectList(db.Filmes, "FilmeId", "Nome");
            return View();
        }

        // POST: Sessao/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SessaoID,CinemaID,FilmeID,Horario")] Sessao sessao)
        {
            if (ModelState.IsValid)
            {
                db.Sessoes.Add(sessao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CinemaID = new SelectList(db.Cinemas, "CinemaID", "Nome", sessao.CinemaID);
            ViewBag.FilmeID = new SelectList(db.Filmes, "FilmeId", "Nome", sessao.FilmeID);
            return View(sessao);
        }

        // GET: Sessao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sessao sessao = db.Sessoes.Find(id);
            if (sessao == null)
            {
                return HttpNotFound();
            }
            ViewBag.CinemaID = new SelectList(db.Cinemas, "CinemaID", "Nome", sessao.CinemaID);
            ViewBag.FilmeID = new SelectList(db.Filmes, "FilmeId", "Nome", sessao.FilmeID);
            return View(sessao);
        }

        // POST: Sessao/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SessaoID,CinemaID,FilmeID,Horario")] Sessao sessao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sessao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CinemaID = new SelectList(db.Cinemas, "CinemaID", "Nome", sessao.CinemaID);
            ViewBag.FilmeID = new SelectList(db.Filmes, "FilmeId", "Nome", sessao.FilmeID);
            return View(sessao);
        }

        // GET: Sessao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sessao sessao = db.Sessoes.Find(id);
            if (sessao == null)
            {
                return HttpNotFound();
            }
            return View(sessao);
        }

        // POST: Sessao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sessao sessao = db.Sessoes.Find(id);
            db.Sessoes.Remove(sessao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
