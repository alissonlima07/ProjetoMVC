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
    [RoutePrefix("matriculas")]
    public class MatriculaController : Controller
    {
        private Context db = new Context();

        // GET: Matricula
        [Route("listar")]
        public ActionResult Index()
        {
            var matriculas = db.Matriculas.Include(m => m.Aluno).Include(m => m.Disciplina).Include(m => m.PeriodoLetivo);
            return View(matriculas.ToList());
        }

        [Route("listar2")]
        public ActionResult Index2()
        {

            var ls = db.PeriodoLetivoes.Select(x => new SelectPeriodoLetivo()
            {
                Valor = x.Ano + "/" + x.Semestre,
                Nome = x.Ano + "/" + x.Semestre
            }).ToList();
            
            var ld = db.Disciplinas.Select(x => new SelectDisciplinas() {
                Valor = x.CodDisc,
                Nome = x.NomeDisc
            }).ToList();

            ViewBag.Semestre = new SelectList(ls, "Valor", "Nome");
            ViewBag.Disciplinas = new SelectList(ld, "Valor", "Nome");
            var matriculas = db.Matriculas.Include(m => m.Aluno).Include(m => m.Disciplina).Include(m => m.PeriodoLetivo).ToList();


            Matricula mat = new Matricula();

            mat.listaMatriculas = matriculas;
            return View(mat);
        }

        // GET: Matricula/Details/5
        [Route("detalhar/{ano:int}/{semestre:int}")]
        public ActionResult Details(int? ano, int? semestre)
        {

            if (ano == null || semestre == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var matricula = db.Matriculas.Where(Mat => Mat.Ano == ano && Mat.Semestre == semestre);
            if (matricula == null || matricula.Count() == 0)
            {
                return HttpNotFound();
            }
            return View(matricula.Single<Matricula>());
        }

        // GET: Matricula/Create
        [Route("cadastrar", Order = 0)]
        public ActionResult Create()
        {
            ViewBag.MatriculaAluno = new SelectList(db.Alunoes, "MatAluno", "Nome");
            ViewBag.CodDisciplina = new SelectList(db.Disciplinas, "CodDisc", "NomeDisc");
            ViewBag.Ano = new SelectList(db.PeriodoLetivoes, "Ano", "Ano");
            ViewBag.Semestre = new SelectList(db.PeriodoLetivoes, "Semestre", "Semestre");
            return View();
        }

        // POST: Matricula/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("cadastrar", Order = 1)]
        public ActionResult Create([Bind(Include = "Ano,Semestre,MatriculaAluno,CodDisciplina,Nota1,Nota2,Nota3,Faltas1,Faltas2,Faltas3")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                db.Matriculas.Add(matricula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MatriculaAluno = new SelectList(db.Alunoes, "MatAluno", "Nome", matricula.MatriculaAluno);
            ViewBag.CodDisciplina = new SelectList(db.Disciplinas, "CodDisc", "NomeDisc", matricula.CodDisciplina);
            ViewBag.Ano = new SelectList(db.PeriodoLetivoes, "Ano", "Ano", matricula.Ano);
            ViewBag.Semestre = new SelectList(db.PeriodoLetivoes, "Semestre", "Semestre", matricula.Semestre);

            return View(matricula);
        }

        // GET: Matricula/Edit/5
        [Route("editar", Order = 0)]
        public ActionResult Edit(int? ano, int? semestre)
        {
            if (ano == null || semestre == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var matricula = db.Matriculas.Where(Mat => Mat.Ano == ano && Mat.Semestre == semestre);
            if (matricula == null || matricula.Count() == 0)
            {
                return HttpNotFound();
            }
            ViewBag.MatriculaAluno = new SelectList(db.Alunoes, "MatAluno", "Nome");
            ViewBag.CodDisciplina = new SelectList(db.Disciplinas, "CodDisc", "NomeDisc");
            ViewBag.Ano = new SelectList(db.PeriodoLetivoes, "Ano", "Ano");
            return View(matricula.Single<Matricula>());
        }

        // POST: Matricula/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar", Order = 1)]
        public ActionResult Edit([Bind(Include = "Ano,Semestre,MatriculaAluno,CodDisciplina,Nota1,Nota2,Nota3,Faltas1,Faltas2,Faltas3")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matricula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MatriculaAluno = new SelectList(db.Alunoes, "MatAluno", "Nome", matricula.MatriculaAluno);
            ViewBag.CodDisciplina = new SelectList(db.Disciplinas, "CodDisc", "NomeDisc", matricula.CodDisciplina);
            ViewBag.Ano = new SelectList(db.PeriodoLetivoes, "Ano", "Ano", matricula.Ano);
            return View(matricula);
        }

        // GET: Matricula/Delete/5
        [Route("deletar", Order = 0)]
        public ActionResult Delete(int? ano, int? semestre)
        {
            if (ano == null || semestre == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var matricula = db.Matriculas.Where(Mat => Mat.Ano == ano && Mat.Semestre == semestre);
            if (matricula == null || matricula.Count() == 0)
            {
                return HttpNotFound();
            }
            return View(matricula.Single<Matricula>());
        }

        // POST: Matricula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("deletar", Order = 1)]
        public ActionResult DeleteConfirmed(int ano, int semestre)
        {
            var matricula = db.Matriculas.Where(mat => mat.Ano == ano && mat.Semestre == semestre);
            if (matricula == null || matricula.Count() == 0)
            {
                return HttpNotFound();
            }
            else
            {
                db.Matriculas.Remove(matricula.Single<Matricula>());
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

