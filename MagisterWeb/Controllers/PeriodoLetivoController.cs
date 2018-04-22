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
    [RoutePrefix("periodos")]
    public class PeriodoLetivoController : Controller
    {
        private Context db = new Context();

        // GET: PeriodoLetivo
        [Route("listar")]
        public ActionResult Index()
        {
            var periodoLetivoes = db.PeriodoLetivoes.Include(p => p.listaTurma);
            return View(periodoLetivoes.ToList());
        }

        // GET: PeriodoLetivo/Details/5
        [Route("detalhar/{ano:int}/{semestre:int}")]
        public ActionResult Details(int? ano, int? semestre)
        {
            if (ano == null || semestre == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var periodoLetivo = db.PeriodoLetivoes.Where(Pletivo => Pletivo.Ano == ano && Pletivo.Semestre == semestre);
            if (periodoLetivo == null || periodoLetivo.Count() == 0)
            {
                return HttpNotFound();
            }
            return View(periodoLetivo.Single<PeriodoLetivo>());
        }


        // GET: PeriodoLetivo/Create
        [Route("cadastrar", Order = 0)]
        public ActionResult Create()
        {
            ViewBag.Ano = new SelectList(db.Turmas, "Ano", "Ano");
            return View();
        }

        // POST: PeriodoLetivo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("cadastrar", Order = 1)]
        public ActionResult Create([Bind(Include = "Ano,Semestre,DataIni,DataFim")] PeriodoLetivo periodoLetivo)
        {
            if (ModelState.IsValid)
            {
                db.PeriodoLetivoes.Add(periodoLetivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ano = new SelectList(db.Turmas, "Ano", "Ano", periodoLetivo.Ano);
            return View(periodoLetivo);
        }

        // GET: PeriodoLetivo/Edit/5
        [Route("editar/{ano:int}/{semestre:int}", Order = 0)]
        public ActionResult Edit(int? ano, int? semestre)
        {
            if (ano == null || semestre == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var periodoLetivo = db.PeriodoLetivoes.Where(Pletivo => Pletivo.Ano == ano && Pletivo.Semestre == semestre);
            if (periodoLetivo == null || periodoLetivo.Count() == 0)
            {
                return HttpNotFound();
            }
            return View(periodoLetivo.Single<PeriodoLetivo>());
        }

        // POST: PeriodoLetivo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar/{ano:int}/{semestre:int}", Order = 1)]
        public ActionResult Edit([Bind(Include = "Ano,Semestre,DataIni,DataFim")] PeriodoLetivo periodoLetivo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(periodoLetivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ano = new SelectList(db.Turmas, "Ano", "Ano", periodoLetivo.Ano);
            return View(periodoLetivo);
        }

        // GET: PeriodoLetivo/Delete/5
        [Route("deletar", Order = 0)]
        public ActionResult Delete(int? ano, int? semestre)
        {
            if (ano == null || semestre == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var periodoLetivo = db.PeriodoLetivoes.Where(Pletivo => Pletivo.Ano == ano && Pletivo.Semestre == semestre);
            if (periodoLetivo == null || periodoLetivo.Count() == 0)
            {
                return HttpNotFound();
            }
            return View(periodoLetivo.Single<PeriodoLetivo>());
        }


        // POST: PeriodoLetivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("deletar", Order = 1)]
        public ActionResult DeleteConfirmed(int ano, int semestre)
        {
            var periodoLetivo = db.PeriodoLetivoes.Where(Pletivo => Pletivo.Ano == ano && Pletivo.Semestre == semestre);
            if (periodoLetivo == null || periodoLetivo.Count() == 0)
            {
                return HttpNotFound();
            }
            else
            {
                db.PeriodoLetivoes.Remove(periodoLetivo.Single<PeriodoLetivo>());
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
