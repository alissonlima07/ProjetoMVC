using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MagisterWeb.Models
{
    [Table("ALUNO")]
    public class Aluno
    {

        public List<Matricula> ListaMatricula { get; set; }

        public List<Historico> ListaHistorico { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatAluno { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "O Nome pode conter no máximo 150")]
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

        public Decimal MGP { get; set; }

        [ForeignKey("Curso")]
        [Column("COD_CURSO")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Codigo do Curso")]
        public int CodCurso { get; set; }

        public virtual Curso Curso { get; set; }

    }
}