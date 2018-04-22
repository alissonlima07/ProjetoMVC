using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MagisterWebSite.Models
{
    public class Aluno
    {
        [Key]        
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O Nome de conter no máximo 50")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Total crédito")]
        public int TotalCredito { get; set; }

        [Required]
        [Display(Name = "Data Aniversário")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime DataAniversario { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "Média geral inválida")]
        public decimal MGP { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido")]
        public string CPF { get; set; }

        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }

    }
}