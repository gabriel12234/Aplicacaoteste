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
    public class AnamneseController : Controller
    {
        private NutriPocketEntities db = new NutriPocketEntities();

        // GET: /Anamnese/
        public ActionResult Index()
        {
            var anm_clinica = db.ANM_CLINICA.Include(a => a.PACIENTE);
            return View(anm_clinica.ToList());
        }

        // GET: /Anamnese/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ANM_CLINICA anm_clinica = db.ANM_CLINICA.Find(id);
            if (anm_clinica == null)
            {
                return HttpNotFound();
            }
            return View(anm_clinica);
        }

        // GET: /Anamnese/Create
        public ActionResult Create()
        {
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME");
            return View();
        }

        // POST: /Anamnese/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_CLINICA,ID_PACIENTE,DISFAGIA,CONSTIPACAO,VOMITOS,ANOREXIA,H_PILORI,PIROSE,ODINOFAGIA,DIARREIA,FLATULENCIA,NAUSEAS,PROB_RESP,GRIPES,HEPS,AFTA,FADIGA,VISAO_BORRADA,DORES_ARTICULACAO,MUDANCA_HUMOR")] ANM_CLINICA anm_clinica)
        {
            if (ModelState.IsValid)
            {
                db.ANM_CLINICA.Add(anm_clinica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", anm_clinica.ID_PACIENTE);
            return View(anm_clinica);
        }

        // GET: /Anamnese/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ANM_CLINICA anm_clinica = db.ANM_CLINICA.Find(id);
            if (anm_clinica == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", anm_clinica.ID_PACIENTE);
            return View(anm_clinica);
        }

        // POST: /Anamnese/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_CLINICA,ID_PACIENTE,DISFAGIA,CONSTIPACAO,VOMITOS,ANOREXIA,H_PILORI,PIROSE,ODINOFAGIA,DIARREIA,FLATULENCIA,NAUSEAS,PROB_RESP,GRIPES,HEPS,AFTA,FADIGA,VISAO_BORRADA,DORES_ARTICULACAO,MUDANCA_HUMOR")] ANM_CLINICA anm_clinica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anm_clinica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", anm_clinica.ID_PACIENTE);
            return View(anm_clinica);
        }

        // GET: /Anamnese/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ANM_CLINICA anm_clinica = db.ANM_CLINICA.Find(id);
            if (anm_clinica == null)
            {
                return HttpNotFound();
            }
            return View(anm_clinica);
        }

        // POST: /Anamnese/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ANM_CLINICA anm_clinica = db.ANM_CLINICA.Find(id);
            db.ANM_CLINICA.Remove(anm_clinica);
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
