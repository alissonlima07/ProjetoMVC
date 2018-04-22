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
    [RoutePrefix("matrizes")]
    public class MatrizController : Controller
    {
        private Context db = new Context();

        // GET: Matriz
        [Route("listar")]
        public ActionResult Index()
        {
            var matrizs = db.Matrizs.Include(m => m.Curso).Include(m => m.Disciplina);
            return View(matrizs.ToList());
        }

        // GET: Matriz/Details/5
        [Route("detalhar/{codCurso:int}/{codDisc:int}")]
        public ActionResult Details(int? codCurso, int? codDisc)
        {
            if (codCurso == null || codDisc == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var matriz = db.Matrizs.Where(mat => mat.CodCurso == codCurso && mat.CodDisciplina == codDisc);
            if (matriz == null)
            {
                return HttpNotFound();
            }
            return View(matriz.Single<Matriz>());
        }

        // GET: Matriz/Create
        [Route("cadastrar", Order = 0)]
        public ActionResult Create()
        {
            ViewBag.CodCurso = new SelectList(db.Cursoes, "CodCurso", "NomeCurso");
            ViewBag.CodDisciplina = new SelectList(db.Disciplinas, "CodDisc", "NomeDisc");
            return View();
        }

        // POST: Matriz/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("cadastrar", Order = 1)]
        public ActionResult Create([Bind(Include = "CodDisciplina,CodCurso,Periodo")] Matriz matriz)
        {
            if (ModelState.IsValid)
            {
                db.Matrizs.Add(matriz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodCurso = new SelectList(db.Cursoes, "CodCurso", "NomeCurso", matriz.CodCurso);
            ViewBag.CodDisciplina = new SelectList(db.Disciplinas, "CodDisc", "NomeDisc", matriz.CodDisciplina);
            return View(matriz);
        }

        // GET: Matriz/Edit/5
        [Route("editar", Order = 0)]
        public ActionResult Edit(int? codCurso, int? codDisc)
        {
            if (codCurso == null || codDisc == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var matriz = db.Matrizs.Where(mat => mat.CodCurso == codCurso && mat.CodDisciplina == codDisc);
            if (matriz == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodCurso = new SelectList(db.Cursoes, "CodCurso", "NomeCurso");
            ViewBag.CodDisciplina = new SelectList(db.Disciplinas, "CodDisc", "NomeDisc");
            return View(matriz.Single<Matriz>());
        }

        // POST: Matriz/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar", Order = 1)]
        public ActionResult Edit([Bind(Include = "CodDisciplina,CodCurso,Periodo")] Matriz matriz)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matriz).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodCurso = new SelectList(db.Cursoes, "CodCurso", "NomeCurso", matriz.CodCurso);
            ViewBag.CodDisciplina = new SelectList(db.Disciplinas, "CodDisc", "NomeDisc", matriz.CodDisciplina);
            return View(matriz);
        }

        // GET: Matriz/Delete/5
        [Route("deletar", Order = 0)]
        public ActionResult Delete(int? codCurso, int? codDisc)
        {
            if (codCurso == null || codDisc == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var matriz = db.Matrizs.Where(mat => mat.CodCurso == codCurso && mat.CodDisciplina == codDisc);
            if (matriz == null || matriz.Count() == 0)
            {
                return HttpNotFound();
            }
            return View(matriz.Single<Matriz>());
        }

        // POST: Matriz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("deletar", Order = 1)]
        public ActionResult DeleteConfirmed(int codCurso, int codDisc)
        {
            var matriz = db.Matrizs.Where(mat => mat.CodCurso == codCurso && mat.CodDisciplina == codDisc);
            if (matriz == null || matriz.Count() == 0)
            {
                return HttpNotFound();
            }
            else
            {
                db.Matrizs.Remove(matriz.Single<Matriz>());
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
