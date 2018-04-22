using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MagisterWeb.Models
{
    [Table("HISTORICO")]
    public class Historico
    {
        [Key]
        [Column("ANO", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Ano { get; set; }

        [Key]
        [Column("SEMESTRE", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Semestre { get; set; }

        [ForeignKey("Ano, Semestre")]
        public PeriodoLetivo PeriodoLetivo { get; set; }

        [Key]
        [ForeignKey("Aluno")]
        [Column("MAT_ALU", Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Matrícula")]
        public int MatriculaAluno { get; set; }

        public virtual Aluno Aluno { get; set; }

        [Key]
        [ForeignKey("Disciplina")]
        [Column("COD_DISC", Order = 3)]
        [Display(Name = "Disciplina")]
        public int CodDisciplina { get; set; }

        public virtual Disciplina Disciplina { get; set; }

        [Required]
        [Display(Name = "Situacao")]
        public char Situacao { get; set; }

        [Required]
        [Display(Name = "Media")]
        public double Media { get; set; }

        [Required]
        [Display(Name = "Faltas")]
        public int Faltas { get; set; }

    }
}