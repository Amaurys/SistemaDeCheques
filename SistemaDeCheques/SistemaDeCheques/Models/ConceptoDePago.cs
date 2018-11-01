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
        public int conceptoId { get; set; }
        public string descripcion { get; set; }
        public bool estado { get; set; }
    }
}