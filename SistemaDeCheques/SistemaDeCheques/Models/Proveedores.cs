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
        [Display(Name ="Id")]
        public int ProveedoresId { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este es un campo requerido")]
        public string nombre { get; set; }

        [Display(Name = "Tipo de persona")]
        [Required(ErrorMessage = "Este es un campo requerido")]
        public ProveedoresTipoPersona TipoPerona { get; set; } 
   
        [Display(Name ="Cédula o RNC")]
        [Required(ErrorMessage = "Este es un campo requerido")]
        [MaxLength(13)]
        [MinLength(9)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "SOLO SE ACEPTAN NÚMEROS")]
        public string cedulaORnc { get; set; }
        [Display(Name ="Balance")]
        [Required(ErrorMessage = "Este es un campo requerido")]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 99999999.99)]
        public double balance { get; set; }
        [Display(Name = "Cuenta Contable")]
        [Required(ErrorMessage = "Este es un campo requerido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "SOLO SE ACEPTAN NÚMEROS")]
        public string cuentaProveedor { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Este es un campo requerido")]
        public ProveedoresEstado Estado { get; set; }

        public virtual ICollection<RegistroSolicitudCheque> RegistroSolicitudCheque { get; set; }
    }

    public enum ProveedoresTipoPersona
    {
        FÍSICA,
        JURÍDICA
    }

    public enum ProveedoresEstado
    {
        ACTIVO,
        INACTIVO
    }
}