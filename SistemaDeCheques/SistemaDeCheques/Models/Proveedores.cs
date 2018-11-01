using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaDeCheques.Models
{
    public class Proveedores
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProveedoresId { get; set; }
        public string nombre { get; set; }
        public string tipoPersona { get; set; }
        public string cedulaORnc { get; set; }
        public double balance { get; set; }
        public string cuentaProveedor { get; set; }
        public bool estado { get; set; }
    }
}