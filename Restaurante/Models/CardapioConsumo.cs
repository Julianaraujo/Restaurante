using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurante.Models
{
    public class CardapioConsumo
    {
        [Required]
        [ForeignKey("Cardapio")]
        [Key, Column(Order = 0)]
        public int CardapioId { get; set; }

        [Required]
        [ForeignKey("Consumo")]
        [Key, Column(Order = 1)]
        public int ConsumoId { get; set; }

        public virtual Cardapio Cardapio { get; set; }
        public virtual Consumo Consumo { get; set; }
    }
}