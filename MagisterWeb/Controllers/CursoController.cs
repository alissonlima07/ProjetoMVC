using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MagisterWeb.Models;

namespace MagisterWeb.Controllers
{
    [RoutePrefix ("cursos")]
    public class CursoController : Controller
    {
        private Context db = new Context();

        // GET: Curso
        [Route("listar")]
        public ActionResult Index()
        {
            var cursoes = db.Cursoes.Include(c => c.Professor);
            return View(cursoes.ToList());
        }

        // GET: Curso/Details/5
        [Route("detalhar/{id:int}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursoes.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // GET: Curso/Create
        [Route("cadastrar", Order = 0)]
        public ActionResult Create()
        {
            ViewBag.IdProf = new SelectList(db.Professors, "IdtProf", "NomProf");
            //ViewBag.CodDisciplina = new SelectList(db.Disciplinas, "Disciplina", "Disciplina");
            ViewBag.CodCurso = new SelectList(db.Cursoes, "CodCurso", "CodCurso");

            return View();
        }

        // POST: Curso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("cadastrar", Order = 1)]
        public ActionResult Create([Bind(Include = "CodCurso,NomeCurso,TotalCreditos,IdProf")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Cursoes.Add(curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProf = new SelectList(db.Professors, "IdtProf", "NomProf", curso.IdProf);
            return View(curso);
        }

        // GET: Curso/Edit/5
        [Route("editar", Order = 0)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursoes.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProf = new SelectList(db.Professors, "IdtProf", "NomProf", curso.IdProf);
            return View(curso);
        }

        // POST: Curso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar", Order = 1)]
        public ActionResult Edit([Bind(Include = "CodCurso,NomeCurso,TotalCreditos,IdProf")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProf = new SelectList(db.Professors, "IdtProf", "NomProf", curso.IdProf);
            return View(curso);
        }

        // GET: Curso/Delete/5
        [Route("deletar", Order = 0)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curso curso = db.Cursoes.Find(id);
            if (curso == null)
            {
                return HttpNotFound();
            }
            return View(curso);
        }

        // POST: Curso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("deletar", Order = 1)]
        public ActionResult DeleteConfirmed(int id)
        {
            Curso curso = db.Cursoes.Find(id);
            db.Cursoes.Remove(curso);
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
