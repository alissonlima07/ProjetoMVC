using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MagisterWeb.Models
{
    [Table("MATRIZ")]
    public class Matriz
    {
        public List<Curso> listaCursos { get; set; }
        public List<Disciplina> listaDisciplinas { get; set; }

        [Key]
        [ForeignKey("Curso")]
        [Column("COD_DISC", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Nome da Disciplina")]
        public int CodDisciplina { get; set; }
        public virtual Curso Curso { get; set; }

        [Key]
        [ForeignKey("Disciplina")]
        [Column("COD_CURSO", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Nome do Curso")]
        public int CodCurso { get; set; }
        public virtual Disciplina Disciplina { get; set; }

        [Required]
        [Column("PERIODO")]
        [Display(Name = "Periodo")]
        public int Periodo { get; set; }

    }

}