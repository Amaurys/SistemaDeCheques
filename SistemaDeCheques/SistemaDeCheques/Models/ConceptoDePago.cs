using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaDeCheques.Models
{
    public class ConceptoDePago
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Id")]
        public int conceptoId { get; set; }
        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "Este es un campo requerido")]
        public string descripcion { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Este es un campo requerido")]
        public ConceptoEstado estado { get; set; }
    }

    public enum ConceptoEstado
    {
        Activo,
        Inactivo
    }
}