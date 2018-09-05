using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurante.Models
{
    public class Cardapio
    {
        [Key]
        public int CardapioId { get; set; }

        [Required(ErrorMessage = "É necessário preencher esse campo.")]
        [MaxLength(50,ErrorMessage = "Não pode ultrapassar 155 caracteres.")]
        [MinLength(3,ErrorMessage = "É necesário inserir 3 caracteres ou mais.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário preencher esse campo.")]
        [MaxLength(255, ErrorMessage = "Não pode ultrapassar 255 caracteres.")]
        [MinLength(3, ErrorMessage = "É necesário inserir 3 caracteres ou mais.")]
        public String Descricao { get; set; }

        [Required(ErrorMessage = "É necessário preencher esse campo.")]
        [Range(1,1000,ErrorMessage = "O Valor deve estar entre 1 e 1000")]
        public float Valor{ get; set; }
    }
}