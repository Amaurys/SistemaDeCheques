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
    public class RegistroSolicitudChequesController : Controller
    {
        private SistemaDeChequesContext db = new SistemaDeChequesContext();
        
        // GET: RegistroSolicitudCheques
        public ActionResult Index()
        {
            var registroSolicitudCheque = db.RegistroSolicitudCheque.Include(r => r.Proveedores);
            return View(registroSolicitudCheque.ToList());
        }

        // GET: RegistroSolicitudCheques/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroSolicitudCheque registroSolicitudCheque = db.RegistroSolicitudCheque.Find(id);
            if (registroSolicitudCheque == null)
            {
                return HttpNotFound();
            }
            return View(registroSolicitudCheque);
        }

        // GET: RegistroSolicitudCheques/Create
        public ActionResult Create()
        {
            ViewBag.idProveedor = new SelectList(db.Proveedores, "ProveedoresId", "nombre");
            return View();
        }

        // POST: RegistroSolicitudCheques/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NumeroSolicitud,idProveedor,monto,fechaRegistro,Estado,CuentaCorrienteXCuentaContable,CuentaContable")] RegistroSolicitudCheque registroSolicitudCheque)
        {
            if (ModelState.IsValid)
            {
                db.RegistroSolicitudCheque.Add(registroSolicitudCheque);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProveedor = new SelectList(db.Proveedores, "ProveedoresId", "nombre", registroSolicitudCheque.idProveedor);
            return View(registroSolicitudCheque);
        }

        // GET: RegistroSolicitudCheques/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroSolicitudCheque registroSolicitudCheque = db.RegistroSolicitudCheque.Find(id);
            if (registroSolicitudCheque == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProveedor = new SelectList(db.Proveedores, "ProveedoresId", "nombre", registroSolicitudCheque.idProveedor);
            return View(registroSolicitudCheque);
        }

        // POST: RegistroSolicitudCheques/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NumeroSolicitud,idProveedor,monto,fechaRegistro,Estado,CuentaCorrienteXCuentaContable, CuentaContable")] RegistroSolicitudCheque registroSolicitudCheque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registroSolicitudCheque).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProveedor = new SelectList(db.Proveedores, "ProveedoresId", "nombre", registroSolicitudCheque.idProveedor);
            return View(registroSolicitudCheque);
        }

        // GET: RegistroSolicitudCheques/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegistroSolicitudCheque registroSolicitudCheque = db.RegistroSolicitudCheque.Find(id);
            if (registroSolicitudCheque == null)
            {
                return HttpNotFound();
            }
            return View(registroSolicitudCheque);
        }

        // POST: RegistroSolicitudCheques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegistroSolicitudCheque registroSolicitudCheque = db.RegistroSolicitudCheque.Find(id);
            db.RegistroSolicitudCheque.Remove(registroSolicitudCheque);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GenerarCheque()
        {
            var registroSolicitudCheque = db.RegistroSolicitudCheque.Include(r => r.Proveedores);
            return View(registroSolicitudCheque.ToList());
        }

        /*[HttpPost]
        public ActionResult GenerarCheque(string id)
        {
            char[] idCharArray = id.ToCharArray();
            int[] idIntArray = null;
            for (int i = 0; i < idCharArray.LongLength; i++)
            {
                idIntArray.SetValue(idCharArray[i], i);
                
            }
            //RegistroSolicitudCheque rsc = db.RegistroSolicitudCheque.FirstOrDefault(x => x.NumeroSolicitud = idIntArray[1]);

            var registroEntity = 

            /*  if (ModelState.IsValid)
              {
                  db.Entry(registroSolicitudCheque).State = EntityState.Modified;
                  db.SaveChanges();
                  return RedirectToAction("Index");
              }
              ViewBag.idProveedor = new SelectList(db.Proveedores, "ProveedoresId", "nombre", registroSolicitudCheque.idProveedor);*/
            /*return View(registroSolicitudCheque);
        }*/

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
