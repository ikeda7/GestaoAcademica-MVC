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
    public class AlunosDisciplinasController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: AlunosDisciplinas
        public ActionResult Index()
        {
            var alunosDisciplinas = db.AlunosDisciplinas.Include(a => a.Alunos).Include(a => a.Disciplinas);
            return View(alunosDisciplinas.ToList());
        }

        // GET: AlunosDisciplinas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunosDisciplinas alunosDisciplinas = db.AlunosDisciplinas.Find(id);
            if (alunosDisciplinas == null)
            {
                return HttpNotFound();
            }
            return View(alunosDisciplinas);
        }

        // GET: AlunosDisciplinas/Create
        public ActionResult Create()
        {
            ViewBag.idAluno = new SelectList(db.Alunos, "idAluno", "nomeAluno");
            ViewBag.idDisc = new SelectList(db.Disciplinas, "idDisc", "nomeDisciplina");
            return View();
        }

        // POST: AlunosDisciplinas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAluno,idDisc,id")] AlunosDisciplinas alunosDisciplinas)
        {
            if (ModelState.IsValid)
            {
                db.AlunosDisciplinas.Add(alunosDisciplinas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAluno = new SelectList(db.Alunos, "idAluno", "nomeAluno", alunosDisciplinas.idAluno);
            ViewBag.idDisc = new SelectList(db.Disciplinas, "idDisc", "nomeDisciplina", alunosDisciplinas.idDisc);
            return View(alunosDisciplinas);
        }

        // GET: AlunosDisciplinas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunosDisciplinas alunosDisciplinas = db.AlunosDisciplinas.Find(id);
            if (alunosDisciplinas == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAluno = new SelectList(db.Alunos, "idAluno", "nomeAluno", alunosDisciplinas.idAluno);
            ViewBag.idDisc = new SelectList(db.Disciplinas, "idDisc", "nomeDisciplina", alunosDisciplinas.idDisc);
            return View(alunosDisciplinas);
        }

        // POST: AlunosDisciplinas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAluno,idDisc,id")] AlunosDisciplinas alunosDisciplinas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alunosDisciplinas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAluno = new SelectList(db.Alunos, "idAluno", "nomeAluno", alunosDisciplinas.idAluno);
            ViewBag.idDisc = new SelectList(db.Disciplinas, "idDisc", "nomeDisciplina", alunosDisciplinas.idDisc);
            return View(alunosDisciplinas);
        }

        // GET: AlunosDisciplinas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlunosDisciplinas alunosDisciplinas = db.AlunosDisciplinas.Find(id);
            if (alunosDisciplinas == null)
            {
                return HttpNotFound();
            }
            return View(alunosDisciplinas);
        }

        // POST: AlunosDisciplinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlunosDisciplinas alunosDisciplinas = db.AlunosDisciplinas.Find(id);
            db.AlunosDisciplinas.Remove(alunosDisciplinas);
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
