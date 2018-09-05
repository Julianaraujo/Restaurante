using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurante.Models
{
    public class Mesa
    {
        [Key]
        public int MesaId { get; set; }

        [Required]
        public Localizacao Localizacao{ get; set; }

        [Required]
        public int Lugares { get; set; }
    }
}