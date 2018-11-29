using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaDeCheques.Models
{
    public class AsientoViewModel
    {
        [Display(Name = "Id Asiento: ")]
        public int IdAsiento { get; set; }
        [Display(Name = "Descripcion: ")]
        public string Descripcion { get; set; }
        [Display(Name = "Cuenta Contable")]
        public string DescripcionCuenta { get; set; }
        [Display(Name = "Tipo de Movimiento")]
        public string TipoMovimiento { get; set; }
        public double Monto { get; set; }
    }
}