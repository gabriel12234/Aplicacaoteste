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
    public class DadosGeraisController : Controller
    {
        private NutriPocketEntities db = new NutriPocketEntities();

        // GET: /DadosGerais/
        public ActionResult Index()
        {
            var anm_dadosgerais = db.ANM_DADOSGERAIS.Include(a => a.PACIENTE);
            return View(anm_dadosgerais.ToList());
        }

        // GET: /DadosGerais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ANM_DADOSGERAIS anm_dadosgerais = db.ANM_DADOSGERAIS.Find(id);
            if (anm_dadosgerais == null)
            {
                return HttpNotFound();
            }
            return View(anm_dadosgerais);
        }

        // GET: /DadosGerais/Create
        public ActionResult Create()
        {
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME");
            return View();
        }

        // POST: /DadosGerais/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_DADOSGERAIS,ID_PACIENTE,MASTIGACAO,DENTICAO,ALERGIA,AVERSOES,ALM_PREFERIDOS,TP_ACUCAR,OUTROS_ACUCAR,HR_MAIS_FOME,TABAGISMO,ETILISMO,FARMACOS,ATVD_FISICA,FREQ_ATVD_FISICA,ING_HIDRICA,HAB_INTESTINAL,ESCALA_BRISTOL,TRATAMENTOS,PROB_TRATAMENTO,TEMPERAMENTO,HR_SONO,CON_TRABALHO")] ANM_DADOSGERAIS anm_dadosgerais)
        {
            if (ModelState.IsValid)
            {
                db.ANM_DADOSGERAIS.Add(anm_dadosgerais);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", anm_dadosgerais.ID_PACIENTE);
            return View(anm_dadosgerais);
        }

        // GET: /DadosGerais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ANM_DADOSGERAIS anm_dadosgerais = db.ANM_DADOSGERAIS.Find(id);
            if (anm_dadosgerais == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", anm_dadosgerais.ID_PACIENTE);
            return View(anm_dadosgerais);
        }

        // POST: /DadosGerais/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_DADOSGERAIS,ID_PACIENTE,MASTIGACAO,DENTICAO,ALERGIA,AVERSOES,ALM_PREFERIDOS,TP_ACUCAR,OUTROS_ACUCAR,HR_MAIS_FOME,TABAGISMO,ETILISMO,FARMACOS,ATVD_FISICA,FREQ_ATVD_FISICA,ING_HIDRICA,HAB_INTESTINAL,ESCALA_BRISTOL,TRATAMENTOS,PROB_TRATAMENTO,TEMPERAMENTO,HR_SONO,CON_TRABALHO")] ANM_DADOSGERAIS anm_dadosgerais)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anm_dadosgerais).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", anm_dadosgerais.ID_PACIENTE);
            return View(anm_dadosgerais);
        }

        // GET: /DadosGerais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ANM_DADOSGERAIS anm_dadosgerais = db.ANM_DADOSGERAIS.Find(id);
            if (anm_dadosgerais == null)
            {
                return HttpNotFound();
            }
            return View(anm_dadosgerais);
        }

        // POST: /DadosGerais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ANM_DADOSGERAIS anm_dadosgerais = db.ANM_DADOSGERAIS.Find(id);
            db.ANM_DADOSGERAIS.Remove(anm_dadosgerais);
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
