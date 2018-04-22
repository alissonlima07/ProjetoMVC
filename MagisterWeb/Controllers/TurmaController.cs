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
    [RoutePrefix("turmas")]
    public class TurmaController : Controller
    {
        private Context db = new Context();

        // GET: Turma
        [Route("listar")]
        public ActionResult Index()
        {
            var turmas = db.Turmas.Include(t => t.PeriodoLetivo);
            return View(turmas.ToList());
        }

        // GET: Turma/Details/5
        [Route("detalhar/{ano:int}/{semestre:int}")]
        public ActionResult Details(int? ano, int? semestre)
        {
            if (ano == null || semestre == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var turma = db.Turmas.Where(Turm => Turm.Ano == ano && Turm.Semestre == semestre);
            if (turma == null || turma.Count() == 0)
            {
                return HttpNotFound();
            }
            return View(turma.Single<Turma>());
        }


        // GET: Turma/Create
        [Route("cadastrar", Order = 0)]
        public ActionResult Create()
        {
            ViewBag.Ano = new SelectList(db.PeriodoLetivoes.Distinct(), "Ano", "Ano");
            ViewBag.Semestre = new SelectList(db.PeriodoLetivoes.Distinct(), "Semestre", "Semestre");
            ViewBag.CodDisciplina = new SelectList(db.Disciplinas, "CodDisc", "NomeDisc");
            ViewBag.IdtProf = new SelectList(db.Professors, "IdtProf", "NomProf");
            //ViewBag.CodTurma = new SelectList(db.Turmas, "CodTurma", "CodTurma");
            return View();
        }

        // POST: Turma/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("cadastrar", Order = 1)]
        public ActionResult Create([Bind(Include = "Ano,Semestre,Vagas,CodDisciplina,IdtProf,CodTurma")] Turma turma)
        {
            if (ModelState.IsValid)
            {
                db.Turmas.Add(turma);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ano = new SelectList(db.PeriodoLetivoes, "Ano", "Ano");
            ViewBag.Semestre = new SelectList(db.PeriodoLetivoes, "Semestre", "Semestre");
            ViewBag.CodDisciplina = new SelectList(db.Disciplinas, "CodDisc", "NomeDisc", turma.CodDisciplina);
            ViewBag.IdtProf = new SelectList(db.Professors, "IdtProf", "NomProf");
            //ViewBag.CodTurma = new SelectList(db.Turmas, "CodTurma", "CodTurma");
            return View(turma);
        }

        // GET: Turma/Edit/5
        [Route("editar", Order = 0)]
        public ActionResult Edit(int? ano, int? semestre)
        {
            if (ano == null || semestre == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var turma = db.Turmas.Where(Tur => Tur.Ano == ano && Tur.Semestre == semestre);
            if (turma == null || turma.Count() == 0)
            {
                return HttpNotFound();
            }
            return View(turma.Single<Turma>());
        }


        // POST: Turma/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar", Order = 1)]
        public ActionResult Edit([Bind(Include = "Ano,Semestre,Vagas,CodDisc,IdtProf,CodTurma")] Turma turma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ano = new SelectList(db.PeriodoLetivoes, "Ano", "Ano", turma.Ano);
            return View(turma);
        }

        // GET: Turma/Delete/5
        [Route("deletar", Order = 0)]
        public ActionResult Delete(int? ano, int? semestre)
        {
            if (ano == null || semestre == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var turma = db.Turmas.Where(Tur => Tur.Ano == ano && Tur.Semestre == semestre);
            if (turma == null || turma.Count() == 0)
            {
                return HttpNotFound();
            }
            return View(turma.Single<Turma>());
        }


        // POST: Turma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("deletar", Order = 1)]
        public ActionResult DeleteConfirmed(int ano, int semestre)
        {
            var turma = db.Turmas.Where(Tur => Tur.Ano == ano && Tur.Semestre == semestre);
            if (turma == null || turma.Count() == 0)
            {
                return HttpNotFound();
            }
            else
            {
                db.Turmas.Remove(turma.Single<Turma>());
                db.SaveChanges();
            }
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


