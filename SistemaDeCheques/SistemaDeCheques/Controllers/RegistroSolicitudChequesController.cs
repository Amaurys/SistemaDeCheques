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

        [HttpPost]
        public ActionResult GenerarCheque(Array id)
        {
            //id = "4";
            // var idCharArray = id.
            int[] idIntArray = new int[id.Length];
            RegistroSolicitudCheque results = new RegistroSolicitudCheque();
            /*Esto lo hizo vanessa
             *for (int i = 0; i < id.Length; i++)
             {
                 idIntArray.SetValue((int)id.GetEnumerator().MoveNext(), i);

             }*/
            for (int i = 0; i < id.Length; i++)
            {
                idIntArray.SetValue(Convert.ToInt16(id.GetValue(i)), i);

            }
            var enums = Enum.GetValues(typeof(RegistroSolicitudChequeEstado)).GetEnumerator();
            RegistroSolicitudChequeEstado index = new RegistroSolicitudChequeEstado();
            while (enums.MoveNext())
            {
                index = (RegistroSolicitudChequeEstado)enums.Current;
            }

            /*esto lo hizo vanessa
            foreach (var item in idIntArray)
            {
                var ind = idIntArray[item];
                results = (from p in db.RegistroSolicitudCheque
                           where p.NumeroSolicitud == ind
                           select p).First();

                results.Estado = index;

                if (ModelState.IsValid)
                {
                    db.Entry(results).State = EntityState.Modified;
                    db.SaveChanges();

                }
            }*/

            for(int i = 0;i<idIntArray.Length;i++)
            {
                var ind = idIntArray[i];
                results = (from p in db.RegistroSolicitudCheque
                           where p.NumeroSolicitud == ind
                           select p).First();

                results.Estado = index;

                if (ModelState.IsValid)
                {
                    db.Entry(results).State = EntityState.Modified;
                    db.SaveChanges();

                }
            }


            /* esto lo hizo amaurys
            foreach (var item in id)
            {
                var ind = id[item];
                results = (from p in db.RegistroSolicitudCheque
                           where p.NumeroSolicitud == ind
                           select p).First();

                results.Estado = index;

                if (ModelState.IsValid)
                {
                    db.Entry(results).State = EntityState.Modified;
                    db.SaveChanges();

                }

            }*/

            //var registroSolicitudCheque = db.RegistroSolicitudCheque.Include(r => r.Proveedores);
            // ViewBag.idProveedor = new SelectList(db.Proveedores, "ProveedoresId", "nombre", registroSolicitudCheque.idProveedor);
             return RedirectToAction("Index");
            //return View(registroSolicitudCheque.ToList());
            //return View("Index");
            
        }

       
        [HttpPost]
        public ActionResult AnularCheque(Array id)
        {
            int[] idIntArray = new int[id.Length];
            RegistroSolicitudCheque results = new RegistroSolicitudCheque();
           
            for (int i = 0; i < id.Length; i++) 
            {
                idIntArray.SetValue(Convert.ToInt16(id.GetValue(i)), i);

            }
            var enums = Enum.GetValues(typeof(RegistroSolicitudChequeEstado)).GetEnumerator();
            RegistroSolicitudChequeEstado index = new RegistroSolicitudChequeEstado();

            enums.MoveNext();
            enums.MoveNext();
            index = (RegistroSolicitudChequeEstado)enums.Current;
            

            for (int i = 0; i < idIntArray.Length; i++)
            {
                var ind = idIntArray[i];
                results = (from p in db.RegistroSolicitudCheque
                           where p.NumeroSolicitud == ind
                           select p).First();

                results.Estado = index;

                if (ModelState.IsValid)
                {
                    db.Entry(results).State = EntityState.Modified;
                    db.SaveChanges();

                }
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
