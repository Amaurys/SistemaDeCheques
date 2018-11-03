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
        [Display(Name ="ID")]
        public int ProveedoresId { get; set; }
        [Display(Name = "NOMBRE")]
        [Required]
        public string nombre { get; set; }

        [Display(Name = "TIPO DE PERSONA")]
        [Required]
        public ProveedoresTipoPersona TipoPerona { get; set; } 
   
        [Display(Name ="CÉDULA O RNC")]
        [Required]
        [MaxLength(13)]
        [MinLength(9)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "SOLO SE ACEPTAN NÚMEROS")]
        public string cedulaORnc { get; set; }
        [Display(Name ="BALANCE")]
        [Required]
        [RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 99999999.99)]
        public double balance { get; set; }
        [Display(Name = "CUENTA CONTABLE")]
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "SOLO SE ACEPTAN NÚMEROS")]
        public string cuentaProveedor { get; set; }

        [Display(Name = "ESTADO")]
        [Required]
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