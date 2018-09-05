using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurante.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "É necessário preencher esse campo.")]
        [MaxLength(15)]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "É necessário preencher esse campo.")]
        [MinLength(3, ErrorMessage = "É necesário inserir 3 caracteres ou mais.")]
        [MaxLength(155, ErrorMessage = "Não pode ultrapassar  caracteres ou mais.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário preencher esse campo.")]
        [MaxLength(15)]
        public string Celular { get; set; }

        [Required(ErrorMessage = "É necessário preencher esse campo.")]
        [MaxLength(10)]
        public string Telefone { get; set; }

    }
}