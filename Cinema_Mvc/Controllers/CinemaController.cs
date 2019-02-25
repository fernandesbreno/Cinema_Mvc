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
    public class CinemaController : Controller
    {
        private CinemaContext db = new CinemaContext();

        // GET: Cinema
        public ActionResult Index(string sortOrder, string searchString)
        {
           
            var cinemas = from f in db.Cinemas
                         select f;

            if (!String.IsNullOrEmpty(searchString))
            {
                cinemas = cinemas.Where(s => s.Nome.Contains(searchString));
            }

            ViewBag.NomeSortParm = sortOrder == "nome" ? "nome_desc" : "nome";
            ViewBag.EnderecoSortParm = sortOrder == "endereco" ? "endereco_desc" : "endereco";

            if (!String.IsNullOrEmpty(sortOrder))
            {
                switch (sortOrder)
                {
                    case "nome":
                        cinemas = cinemas.OrderBy(x => x.Nome);
                        break;
                    case "nome_desc":
                        cinemas = cinemas.OrderByDescending(x => x.Nome);
                        break;
                    case "endereco":
                        cinemas = cinemas.OrderBy(x => x.Endereco);
                        break;
                    case "endereco_desc":
                        cinemas = cinemas.OrderByDescending(x => x.Endereco);
                        break;
                }
            }
            return View(cinemas.ToList());
        }

        // GET: Cinema/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinema cinema = db.Cinemas.Find(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }
            return View(cinema);
        }

        // GET: Filme/DetailsFilme/5
        public ActionResult DetailsCinema(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinema cinema = db.Cinemas.Find(id);
            List<Filme> filmes = cinema.Sessoes.Select(x => x.Filme)
               .Distinct()
               .ToList<Filme>();

            var delete = new List<List<int>>();

            for (int i = 0; i < filmes.Count; i++)
            {
                var del = new List<int>();
                for (int j = 0; j < filmes.ElementAt(i).Sessoes.Count; j++)
                {
                    if(filmes.ElementAt(i).Sessoes.ElementAt(j).CinemaID != cinema.CinemaID)
                    {
                        del.Add(j);
                        
                    }
                }
                delete.Add(del);
            }

            for (int i = 0; i < delete.Count; i++)
            {
                for (int j = 0; j < delete.ElementAt(i).Count; j++)
                {
                    if (delete.ElementAt(i).Count > 0)
                    {
                        filmes.ElementAt(i).Sessoes.Remove(filmes.ElementAt(i).Sessoes.ElementAt(j));
                    }
                }
            }

            if (filmes == null)
            {
                return HttpNotFound();
            }
            return View(filmes);
        }

        // GET: Cinema/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cinema/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CinemaID,Nome,Endereco")] Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                db.Cinemas.Add(cinema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cinema);
        }

        // GET: Cinema/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinema cinema = db.Cinemas.Find(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }
            return View(cinema);
        }

        // POST: Cinema/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CinemaID,Nome,Endereco")] Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cinema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cinema);
        }

        // GET: Cinema/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinema cinema = db.Cinemas.Find(id);
            if (cinema == null)
            {
                return HttpNotFound();
            }
            return View(cinema);
        }

        // POST: Cinema/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cinema cinema = db.Cinemas.Find(id);
            db.Cinemas.Remove(cinema);
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
