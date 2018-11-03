using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaDeCheques.Models;

namespace SistemaDeCheques.Controllers
{
    public class ConceptoDePagoesController : Controller
    {
        private SistemaDeChequesContext db = new SistemaDeChequesContext();

        // GET: ConceptoDePagoes
        public ActionResult Index()
        {
            return View(db.ConceptoDePagos.ToList());
        }

        // GET: ConceptoDePagoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConceptoDePago conceptoDePago = db.ConceptoDePagos.Find(id);
            if (conceptoDePago == null)
            {
                return HttpNotFound();
            }
            return View(conceptoDePago);
        }

        // GET: ConceptoDePagoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConceptoDePagoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "conceptoId,descripcion,estado")] ConceptoDePago conceptoDePago)
        {
            if (ModelState.IsValid)
            {
                db.ConceptoDePagos.Add(conceptoDePago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(conceptoDePago);
        }

        // GET: ConceptoDePagoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConceptoDePago conceptoDePago = db.ConceptoDePagos.Find(id);
            if (conceptoDePago == null)
            {
                return HttpNotFound();
            }
            return View(conceptoDePago);
        }

        // POST: ConceptoDePagoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "conceptoId,descripcion,estado")] ConceptoDePago conceptoDePago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conceptoDePago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conceptoDePago);
        }

        // GET: ConceptoDePagoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConceptoDePago conceptoDePago = db.ConceptoDePagos.Find(id);
            if (conceptoDePago == null)
            {
                return HttpNotFound();
            }
            return View(conceptoDePago);
        }

        // POST: ConceptoDePagoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConceptoDePago conceptoDePago = db.ConceptoDePagos.Find(id);
            db.ConceptoDePagos.Remove(conceptoDePago);
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
