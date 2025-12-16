using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class DisciplinasController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Disciplinas
        public ActionResult Index()
        {
            return View(db.Disciplinas.ToList());
        }

        // GET: Disciplinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disciplinas disciplinas = db.Disciplinas.Find(id);
            if (disciplinas == null)
            {
                return HttpNotFound();
            }
            return View(disciplinas);
        }

        // GET: Disciplinas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Disciplinas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDisc,nomeDisciplina")] Disciplinas disciplinas)
        {
            if (ModelState.IsValid)
            {
                db.Disciplinas.Add(disciplinas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(disciplinas);
        }

        // GET: Disciplinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disciplinas disciplinas = db.Disciplinas.Find(id);
            if (disciplinas == null)
            {
                return HttpNotFound();
            }
            return View(disciplinas);
        }

        // POST: Disciplinas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDisc,nomeDisciplina")] Disciplinas disciplinas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(disciplinas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(disciplinas);
        }

        // GET: Disciplinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disciplinas disciplinas = db.Disciplinas.Find(id);
            if (disciplinas == null)
            {
                return HttpNotFound();
            }
            return View(disciplinas);
        }

        // POST: Disciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Disciplinas disciplinas = db.Disciplinas.Find(id);
            db.Disciplinas.Remove(disciplinas);
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
