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
        [IdValidator]
        [Required(ErrorMessage = "Este es un campo requerido")]
        [MaxLength(13)]
        [MinLength(9)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo se aceptan números")]
        public string cedulaORnc { get; set; }
        [Display(Name ="Balance")]
        [Required(ErrorMessage = "Este es un campo requerido")]
        [RegularExpression(@"^\-?\(?\$?\s*\-?\s*\(?(((\d{1,3}((\,\d{3})*|\d*))?(\.\d{1,4})?)|((\d{1,3}((\,\d{3})*|\d*))(\.\d{0,4})?))\)?$", ErrorMessage ="Favor de introducir un monto válido")]
        [Range(0, 99999999.99)]
        public double balance { get; set; }
        [Display(Name = "Cuenta Contable")]
        [Required(ErrorMessage = "Este es un campo requerido")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Solo se aceptan números")]
        public string cuentaProveedor { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Este es un campo requerido")]
        public ProveedoresEstado Estado { get; set; }

        public virtual ICollection<RegistroSolicitudCheque> RegistroSolicitudCheque { get; set; }



       //Declaración de variables a nivel de método o función.
            
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