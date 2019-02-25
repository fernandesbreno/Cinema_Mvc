using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cinema_Mvc.DAL;
using Cinema_Mvc.Models;

namespace Cinema_Mvc.Controllers
{
    public class FilmeController : Controller
    {
        private CinemaContext db = new CinemaContext();

        // GET: Filme
        public ActionResult Index(string sortOrder, string searchString)
        {

            var filmes = from f in db.Filmes
                         select f;
            if (!String.IsNullOrEmpty(searchString))
            {
                filmes = filmes.Where(s => s.Nome.Contains(searchString));
            }

            ViewBag.NomeSortParm = sortOrder == "nome" ? "nome_desc" : "nome";
            ViewBag.GeneroSortParm = sortOrder == "genero" ? "genero_desc" : "genero";
            ViewBag.DuracaoSortParm = sortOrder == "duracao" ? "duracao_desc" : "duracao";
            ViewBag.ClassificacaoSortParm = sortOrder == "classificacao" ? "classificacao_desc" : "classificacao";

            if (!String.IsNullOrEmpty(sortOrder))
            {
                switch (sortOrder)
                {
                    case "nome":
                        filmes = filmes.OrderBy(x => x.Nome);
                        break;
                    case "nome_desc":
                        filmes = filmes.OrderByDescending(x => x.Nome);
                        break;
                    case "genero":
                        filmes = filmes.OrderBy(x => x.Genero);
                        break;
                    case "genero_desc":
                        filmes = filmes.OrderByDescending(x => x.Genero);
                        break;
                    case "duracao":
                        filmes = filmes.OrderBy(x => x.Duracao);
                        break;
                    case "duracao_desc":
                        filmes = filmes.OrderByDescending(x => x.Duracao);
                        break;
                    case "classificacao":
                        filmes = filmes.OrderBy(x => x.Classificacao);
                        break;
                    case "classificacao_desc":
                        filmes = filmes.OrderByDescending(x => x.Classificacao);
                        break;
                }
            }
            

            return View(filmes.ToList());
        }

        // GET: Filme/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        // GET: Filme/DetailsFilme/5
        public ActionResult DetailsFilme(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = db.Filmes.Find(id);
            List<Cinema> cinemas = filme.Sessoes.Select(x => x.Cinema)
                .Distinct()
                .ToList<Cinema>();

            var delete = new List<List<int>>();

            for (int i = 0; i < cinemas.Count; i++)
            {
                var del = new List<int>();
                for (int j = 0; j < cinemas.ElementAt(i).Sessoes.Count; j++)
                {
                    if (cinemas.ElementAt(i).Sessoes.ElementAt(j).FilmeID != filme.FilmeId)
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
                        cinemas.ElementAt(i).Sessoes.Remove(cinemas.ElementAt(i).Sessoes.ElementAt(j));
                    }
                }
            }

            if (cinemas == null)
            {
                return HttpNotFound();
            }
            return View(cinemas);
        }
        // GET: Filme/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Filme/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FilmeId,Nome,Genero,Duracao,Classificacao")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                db.Filmes.Add(filme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(filme);
        }

        // GET: Filme/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        // POST: Filme/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FilmeId,Nome,Genero,Duracao,Classificacao")] Filme filme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filme);
        }

        // GET: Filme/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = db.Filmes.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        // POST: Filme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Filme filme = db.Filmes.Find(id);
            db.Filmes.Remove(filme);
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
