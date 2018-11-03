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
        [Display(Name ="ID")]
        public int conceptoId { get; set; }
        [Display(Name = "DESCRIPCIÓN")]
        [Required]
        public string descripcion { get; set; }

        [Display(Name = "ESTADO")]
        [Required]
        public ConceptoEstado estado { get; set; }
    }

    public enum ConceptoEstado
    {
        ACTIVO,
        INACTIVO
    }
}