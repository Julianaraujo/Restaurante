using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurante.Models
{
    public class Consumo
    {
        [Key]
        public int ConsumoId { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        public float SubTotal { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}