using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading;
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
            string MySQLFormatDate = today.ToString("yyyy-MM-dd HH:mm:ss");
            var result = DateTime.Parse(today.ToString()).ToString("MMM");

            var registroSolicitudCheque = db.RegistroSolicitudCheque.Where(c => c.Estado == RegistroSolicitudChequeEstado.ChequeGenerado && c.fechaRegistro.Month == today.Month && c.fechaRegistro.Year == today.Year).GroupBy(c => c.CuentaContable).Select(t => new AsientoViewModel {
            
                IdAsiento = 1,
                Descripcion = "Asiento resumen cheques para "+result+" "+today.Year,
                DescripcionCuenta =  t.Key,
                TipoMovimiento = "CR",
                Monto = t.Sum(t2 => t2.monto)


            }).ToList();
           
            return View(registroSolicitudCheque);
        }
    }
}
