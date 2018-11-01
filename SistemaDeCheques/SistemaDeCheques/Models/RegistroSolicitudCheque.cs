using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaDeCheques.Models
{
    public class RegistroSolicitudCheque
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NumeroSolicitud { get; set; }
        [ForeignKey("Proveedores")]
        public int idProveedor { get; set; }
        public double monto { get; set; }
        public DateTime fechaRegistro { get; set; }
        public bool estado { get; set; }
        public string CuentaBanco { get; set; }
        [Required]
        public virtual Proveedores Proveedores { get; set; }
    }
}