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
    [RoutePrefix("alunos")]
    public class AlunoController : Controller
    {
        private Context db = new Context();

        // GET: Aluno
        [Route("listar")]
        public ActionResult Index()
        {
            var alunoes = db.Alunoes.Include(a => a.Curso);
            return View(alunoes.ToList());
        }

        // GET: Aluno/Details/5
        [Route("detalhar/{matAlu:int}")]
        public ActionResult Details(int? matAlu)
        {
            if (matAlu == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aluno = db.Alunoes.Where(alu => alu.MatAluno == matAlu);
            if (aluno == null || aluno.Count() == 0)
            {
                return HttpNotFound();
            }
            return View(aluno.Single<Aluno>());
        }

        // GET: Aluno/Create
        [Route("cadastrar", Order = 0)]
        public ActionResult Create()
        {
            ViewBag.CodCurso = new SelectList(db.Cursoes, "CodCurso", "NomeCurso");
            return View();
        }

        // POST: Aluno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("cadastrar", Order = 1)]
        public ActionResult Create([Bind(Include = "MatAluno,Nome,TotalCredito,DataAniversario,MGP,CodCurso")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Alunoes.Add(aluno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodCurso = new SelectList(db.Cursoes, "CodCurso", "NomeCurso", aluno.CodCurso);
            return View(aluno);
        }

        // GET: Aluno/Edit/5
        [Route("editar", Order = 0)]
        public ActionResult Edit(int? matAlu)
        {
            if (matAlu == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aluno = db.Alunoes.Where(mat => mat.MatAluno == matAlu);
            if (aluno == null || aluno.Count() == 0)
            {
                return HttpNotFound();
            }
            ViewBag.CodCurso = new SelectList(db.Cursoes, "CodCurso", "NomeCurso");
            return View(aluno.Single<Aluno>());
        }

        // POST: Aluno/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar", Order = 1)]
        public ActionResult Edit([Bind(Include = "MatAluno,Nome,TotalCredito,DataAniversario,MGP,CodCurso")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodCurso = new SelectList(db.Cursoes, "CodCurso", "NomeCurso", aluno.CodCurso);
            return View(aluno);
        }

        // GET: Aluno/Delete/5
        [Route("deletar",Order = 0)]
        public ActionResult Delete(int? matAlu)
        {
            if (matAlu == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var aluno = db.Alunoes.Where(mat=> mat.MatAluno == matAlu);
            if (aluno == null || aluno.Count() == 0)
            {
                return HttpNotFound();
            }
            return View(aluno.Single<Aluno>());
        }

        // POST: Aluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("deletar", Order = 1)]
        public ActionResult DeleteConfirmed(int matAlu)
        {
            Aluno aluno = db.Alunoes.Find(matAlu);
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
