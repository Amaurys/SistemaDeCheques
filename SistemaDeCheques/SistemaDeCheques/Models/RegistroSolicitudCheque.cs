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
        [Display(Name ="Numero de Solicitud")]
        public int NumeroSolicitud { get; set; }
        
      [Display(Name = "Proveedor")]
        [ForeignKey("Proveedores")]
        public int idProveedor { get; set; }
        [Display(Name = "Monto")]
        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 99999999.99)]
        public double monto { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        [Display(Name ="Fecha de Registro")]
        public DateTime fechaRegistro { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public RegistroSolicitudChequeEstado Estado { get; set; }

        [Display(Name = "Cuenta de Banco")]
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo se aceptan numeros")]
        public string CuentaCorrienteXCuentaContable { get; set; }

        [Display(Name = "Cuenta Contable")]
        [Required]
        public string CuentaContable { get; set; }

        public virtual Proveedores Proveedores { get; set; }
    }

    public enum RegistroSolicitudChequeEstado
    {
        Pendiente,
        Anulada,
        [Display(Name = "Cheque Generado")]
        ChequeGenerado
    }
}