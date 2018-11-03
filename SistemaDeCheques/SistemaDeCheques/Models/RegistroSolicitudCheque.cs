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
        [Display(Name ="NÚMERO DE SOLICITUD")]
        public int NumeroSolicitud { get; set; }
        
        [ForeignKey("Proveedores")]
        public int idProveedor { get; set; }
        [Display(Name = "MONTO")]
        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 99999999.99)]
        public double monto { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        [Display(Name ="FECHA DE REGISTRO")]
        public DateTime fechaRegistro { get; set; }

        [Required]
        [Display(Name = "ESTADO")]
        public RegistroSolicitudChequeEstado Estado { get; set; }

        [Display(Name = "CUENTA DE BANCO")]
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "SOLO SE ACEPTAN NÚMEROS")]
        public string CuentaCorrienteXCuentaContable { get; set; }

        [Required]
        public virtual Proveedores Proveedores { get; set; }
    }

    public enum RegistroSolicitudChequeEstado
    {
        ACTIVO,
        INACTIVO
    }
}