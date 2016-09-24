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
    public class FrequenciaAlimentarController : Controller
    {
        private NutriPocketEntities db = new NutriPocketEntities();

        // GET: /FrequenciaAlimentar/
        public ActionResult Index()
        {
            var freq_alimentar = db.FREQ_ALIMENTAR.Include(f => f.PERIODICIDADE).Include(f => f.PACIENTE);
            return View(freq_alimentar.ToList());
        }

        // GET: /FrequenciaAlimentar/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FREQ_ALIMENTAR freq_alimentar = db.FREQ_ALIMENTAR.Find(id);
            if (freq_alimentar == null)
            {
                return HttpNotFound();
            }
            return View(freq_alimentar);
        }

        // GET: /FrequenciaAlimentar/Create
        public ActionResult Create()
        {
            ViewBag.ID_PERIODO = new SelectList(db.PERIODICIDADE, "ID_PERIODO", "DESC_PERIODO");
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME");
            return View();
        }

        // POST: /FrequenciaAlimentar/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_FREQUENCIA,ID_PERIODO,ID_PACIENTE,DESC_ALIMENTO,QTD_ALIMENTO")] FREQ_ALIMENTAR freq_alimentar)
        {
            if (ModelState.IsValid)
            {
                db.FREQ_ALIMENTAR.Add(freq_alimentar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PERIODO = new SelectList(db.PERIODICIDADE, "ID_PERIODO", "DESC_PERIODO", freq_alimentar.ID_PERIODO);
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", freq_alimentar.ID_PACIENTE);
            return View(freq_alimentar);
        }

        // GET: /FrequenciaAlimentar/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FREQ_ALIMENTAR freq_alimentar = db.FREQ_ALIMENTAR.Find(id);
            if (freq_alimentar == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PERIODO = new SelectList(db.PERIODICIDADE, "ID_PERIODO", "DESC_PERIODO", freq_alimentar.ID_PERIODO);
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", freq_alimentar.ID_PACIENTE);
            return View(freq_alimentar);
        }

        // POST: /FrequenciaAlimentar/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_FREQUENCIA,ID_PERIODO,ID_PACIENTE,DESC_ALIMENTO,QTD_ALIMENTO")] FREQ_ALIMENTAR freq_alimentar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(freq_alimentar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PERIODO = new SelectList(db.PERIODICIDADE, "ID_PERIODO", "DESC_PERIODO", freq_alimentar.ID_PERIODO);
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", freq_alimentar.ID_PACIENTE);
            return View(freq_alimentar);
        }

        // GET: /FrequenciaAlimentar/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FREQ_ALIMENTAR freq_alimentar = db.FREQ_ALIMENTAR.Find(id);
            if (freq_alimentar == null)
            {
                return HttpNotFound();
            }
            return View(freq_alimentar);
        }

        // POST: /FrequenciaAlimentar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            FREQ_ALIMENTAR freq_alimentar = db.FREQ_ALIMENTAR.Find(id);
            db.FREQ_ALIMENTAR.Remove(freq_alimentar);
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
