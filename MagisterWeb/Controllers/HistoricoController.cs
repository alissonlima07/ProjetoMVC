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
    [RoutePrefix("historicos")]
    public class HistoricoController : Controller
    {
        private Context db = new Context();

        // GET: Historico
        [Route("listar")]
        public ActionResult Index(string ano, string semestre, string curso)
        {
            ViewBag.Ano = new SelectList(db.PeriodoLetivoes, "Ano", "Ano");
            ViewBag.Semestre = new SelectList(db.PeriodoLetivoes, "Semestre", "Semestre");
            ViewBag.Curso = new SelectList(db.Cursoes, "CodCurso", "NomeCurso");
            var historicoes = db.Historicoes.Include(h => h.Aluno).Include(h => h.Disciplina).Include(h => h.PeriodoLetivo).Include(h => h.Aluno.Curso);

            if (!String.IsNullOrEmpty(curso))
            {
                int CodCurso = Convert.ToInt32(curso);
                historicoes = historicoes.Where(a => a.Aluno.CodCurso == CodCurso);
            }

            if (!String.IsNullOrEmpty(ano))
            {
                int Ano = Convert.ToInt32(ano);
                historicoes = historicoes.Where(a => a.Ano == Ano);
            }
            if (!String.IsNullOrEmpty(semestre))
            {
                int Semestre = Convert.ToInt32(semestre);
                historicoes = historicoes.Where(a => a.Semestre == Semestre);
            }

            return View(historicoes.ToList());
        }

        // GET: Historico/Details/5
        [Route("detalhar/{ano:int}/{semestre:int}")]
        public ActionResult Details(int? ano, int? semestre)
        {
            if (ano == null || semestre == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var historico = db.Historicoes.Where(Mat => Mat.Ano == ano && Mat.Semestre == semestre);
            if (historico == null || historico.Count() == 0)
            {
                return HttpNotFound();
            }
            return View(historico.Single<Historico>());
        }

        // GET: Historico/Create
        [Route("cadastrar", Order = 0)]
        public ActionResult Create()
        {
            ViewBag.MatriculaAluno = new SelectList(db.Alunoes, "MatAluno", "Nome");
            ViewBag.CodDisciplina = new SelectList(db.Disciplinas, "CodDisc", "NomeDisc");
            ViewBag.Ano = new SelectList(db.PeriodoLetivoes, "Ano", "Ano");
            ViewBag.Semestre = new SelectList(db.PeriodoLetivoes, "Semestre", "Semestre");
            return View();
        }

        // POST: Historico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("cadastrar", Order = 1)]
        public ActionResult Create([Bind(Include = "Ano,Semestre,MatriculaAluno,CodDisciplina,Media,Faltas")] Historico historico)
        {
            if (ModelState.IsValid)
            {
                db.Historicoes.Add(historico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MatriculaAluno = new SelectList(db.Alunoes, "MatAluno", "Nome", historico.MatriculaAluno);
            ViewBag.CodDisciplina = new SelectList(db.Disciplinas, "CodDisc", "NomeDisc", historico.CodDisciplina);
            ViewBag.Ano = new SelectList(db.PeriodoLetivoes, "Ano", "Ano", historico.Ano);
            ViewBag.Semestre = new SelectList(db.PeriodoLetivoes, "Semestre", "Semestre", historico.Semestre);
            return View(historico);
        }

        // GET: Historico/Edit/5
        [Route("editar", Order = 0)]
        public ActionResult Edit(int? ano, int? semestre)
        {
            if (ano == null || semestre == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var historico = db.Historicoes.Where(Mat => Mat.Ano == ano && Mat.Semestre == semestre);
            if (historico == null)
            {
                return HttpNotFound();
            }
            ViewBag.MatriculaAluno = new SelectList(db.Alunoes, "MatAluno", "Nome");
            ViewBag.CodDisciplina = new SelectList(db.Disciplinas, "CodDisc", "NomeDisc");
            ViewBag.Ano = new SelectList(db.PeriodoLetivoes, "Ano", "Ano");
            return View(historico.Single<Historico>());
        }

        // POST: Historico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar", Order = 1)]
        public ActionResult Edit([Bind(Include = "Ano,Semestre,MatriculaAluno,CodDisciplina,Media,Faltas")] Historico historico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(historico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MatriculaAluno = new SelectList(db.Alunoes, "MatAluno", "Nome", historico.MatriculaAluno);
            ViewBag.CodDisciplina = new SelectList(db.Disciplinas, "CodDisc", "NomeDisc", historico.CodDisciplina);
            ViewBag.Ano = new SelectList(db.PeriodoLetivoes, "Ano", "Ano", historico.Ano);
            return View(historico);
        }

        // GET: Historico/Delete/5
        [Route("deletar", Order = 0)]
        public ActionResult Delete(int? ano, int? semestre, int? matAluno, int? codDisc)
        {
            if (ano == null || semestre == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var historico = db.Historicoes.Where(Mat => Mat.Ano == ano && Mat.Semestre == semestre && Mat.MatriculaAluno == matAluno && Mat.CodDisciplina == codDisc);
            if (historico == null || historico.Count() == 0)
            {
                return HttpNotFound();
            }
            return View(historico.Single<Historico>());
        }

        // POST: Historico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("deletar", Order = 1)]
        public ActionResult DeleteConfirmed(int ano, int semestre, int matAluno, int codDisc)
        {
            var historico = db.Historicoes.Where(hist => hist.Ano == ano && hist.Semestre == semestre && hist.MatriculaAluno == matAluno && hist.CodDisciplina == codDisc);
            if (historico == null || historico.Count() == 0)
            {
                return HttpNotFound();
            }
            else
            {
                db.Historicoes.Remove(historico.Single<Historico>());
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
