using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nutripocket.Models;

namespace Nutripocket.Controllers
{
    public class RecorAlimentacaoController : Controller
    {
        private NutriPocketEntities db = new NutriPocketEntities();

        // GET: /RecorAlimentacao/
        public ActionResult Index()
        {
            var recor_alimentacao = db.RECOR_ALIMENTACAO.Include(r => r.PERIODICIDADE);
            return View(recor_alimentacao.ToList());
        }

        // GET: /RecorAlimentacao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECOR_ALIMENTACAO recor_alimentacao = db.RECOR_ALIMENTACAO.Find(id);
            if (recor_alimentacao == null)
            {
                return HttpNotFound();
            }
            return View(recor_alimentacao);
        }

        // GET: /RecorAlimentacao/Create
        public ActionResult Create()
        {
            ViewBag.ID_PERIODO = new SelectList(db.PERIODICIDADE, "ID_PERIODO", "DESC_PERIODO");
            return View();
        }

        // POST: /RecorAlimentacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_PERIODO,DESC_ALIMENTO,QTD_ALIMENTO,HORARIO")] RECOR_ALIMENTACAO recor_alimentacao)
        {
            if (ModelState.IsValid)
            {
                db.RECOR_ALIMENTACAO.Add(recor_alimentacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PERIODO = new SelectList(db.PERIODICIDADE, "ID_PERIODO", "DESC_PERIODO", recor_alimentacao.ID_PERIODO);
            return View(recor_alimentacao);
        }

        // GET: /RecorAlimentacao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECOR_ALIMENTACAO recor_alimentacao = db.RECOR_ALIMENTACAO.Find(id);
            if (recor_alimentacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PERIODO = new SelectList(db.PERIODICIDADE, "ID_PERIODO", "DESC_PERIODO", recor_alimentacao.ID_PERIODO);
            return View(recor_alimentacao);
        }

        // POST: /RecorAlimentacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_PERIODO,DESC_ALIMENTO,QTD_ALIMENTO,HORARIO")] RECOR_ALIMENTACAO recor_alimentacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recor_alimentacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PERIODO = new SelectList(db.PERIODICIDADE, "ID_PERIODO", "DESC_PERIODO", recor_alimentacao.ID_PERIODO);
            return View(recor_alimentacao);
        }

        // GET: /RecorAlimentacao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECOR_ALIMENTACAO recor_alimentacao = db.RECOR_ALIMENTACAO.Find(id);
            if (recor_alimentacao == null)
            {
                return HttpNotFound();
            }
            return View(recor_alimentacao);
        }

        // POST: /RecorAlimentacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RECOR_ALIMENTACAO recor_alimentacao = db.RECOR_ALIMENTACAO.Find(id);
            db.RECOR_ALIMENTACAO.Remove(recor_alimentacao);
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
