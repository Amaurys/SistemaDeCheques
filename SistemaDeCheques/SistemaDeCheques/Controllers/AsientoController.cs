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
    public class AsientoController : Controller
    {
        private SistemaDeChequesContext db = new SistemaDeChequesContext();

        // GET: Asiento
        public ActionResult Index()
        {
            DateTime today = DateTime.Today;
            var registroSolicitudCheque = db.RegistroSolicitudCheque.Where(c => c.Estado == RegistroSolicitudChequeEstado.ChequeGenerado && c.fechaRegistro.Month == today.Month && c.fechaRegistro.Year == today.Year).GroupBy(c => c.CuentaContable);//.Include(r => r.Proveedores);
            return View(registroSolicitudCheque.ToList());
        }

        
    }
}
