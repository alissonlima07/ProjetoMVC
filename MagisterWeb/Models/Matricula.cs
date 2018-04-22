using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MagisterWeb.Models
{
    [Table("MATRICULA")]
    public class Matricula

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

        [Display(Name = "Primeira Nota")]
        public decimal Nota1 { get; set; }

        [Display(Name = "Segunda Nota")]
        public decimal Nota2 { get; set; }

        [Display(Name = "Terceira Nota")]
        public decimal Nota3 { get; set; }

        [Display(Name = "Nº Faltas 1ª Unidade")]
        public int Faltas1 { get; set; }

        [Display(Name = "Nº Faltas 2ª Unidade")]
        public int Faltas2 { get; set; }

        [Display(Name = "Nº Faltas 3ª Unidade")]
        public int Faltas3 { get; set; }

        public virtual List<Matricula> listaMatriculas { get; set; }
       
    }
}