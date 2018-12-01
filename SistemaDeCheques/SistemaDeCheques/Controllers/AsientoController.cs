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
        private int cuentaCR = 83;
        // GET: Asiento
        public ActionResult Index()
        {
            DateTime today = DateTime.Today;
            
            var result = DateTime.Parse(today.ToString()).ToString("MMM");

            var registroSolicitudCheque = db.RegistroSolicitudCheque.Where(c => c.Estado == RegistroSolicitudChequeEstado.ChequeGenerado && c.fechaRegistro.Month == today.Month && c.fechaRegistro.Year == today.Year).GroupBy(c => c.CuentaContable).Select(t => new AsientoViewModel {

                IdAsiento = 9,
                Descripcion = "Asiento resumen cheques para " + result + " " + today.Year,
                DescripcionCuenta = t.Key,
                TipoMovimiento = "DB",
                Monto = t.Sum(t2 => t2.monto)
               

            }).ToList();

            Call_registrar_asiento_Method(registroSolicitudCheque);
            
            return View(registroSolicitudCheque);
        }
        private void Call_registrar_asiento_Method(IList<AsientoViewModel> asiento)
        {
            ServiceReference1.WSXContabilidadSoapClient wsClient = new ServiceReference1.WSXContabilidadSoapClient();
            ServiceReference1.registrarAsientoResponseBody reponse = new ServiceReference1.registrarAsientoResponseBody();
            foreach (var item in asiento)
            {
                wsClient.registrarAsiento(item.Descripcion,item.IdAsiento, item.Monto, Convert.ToInt32(item.DescripcionCuenta), cuentaCR);

                ViewBag.Result = reponse.registrarAsientoResult;
            }
        }
    }
}
