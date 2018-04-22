using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MagisterWebSite.Models;

namespace MagisterWebSite.Controllers
{
    public class AlunosController : Controller
    {
        private Context db = new Context();

        // GET: Alunos
        public ActionResult Index()
        {
            var alunoes = db.Alunoes.Include(a => a.Curso);
            return View(alunoes.ToList());
        }

        // GET: Alunos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunoes.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // GET: Alunos/Create
        public ActionResult Create()
        {
            ViewBag.CursoId = new SelectList(db.Cursoes, "Id", "NomeCurso");
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,TotalCredito,DataAniversario,MGP,Email,CPF,CursoId")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Alunoes.Add(aluno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursoId = new SelectList(db.Cursoes, "Id", "NomeCurso", aluno.CursoId);
            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunoes.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoId = new SelectList(db.Cursoes, "Id", "NomeCurso", aluno.CursoId);
            return View(aluno);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,TotalCredito,DataAniversario,MGP,Email,CPF,CursoId")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoId = new SelectList(db.Cursoes, "Id", "NomeCurso", aluno.CursoId);
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunoes.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluno aluno = db.Alunoes.Find(id);
            db.Alunoes.Remove(aluno);
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
