using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MagisterWeb.Models
{
    [Table("TURMA")]
    public class Turma
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
        public virtual PeriodoLetivo PeriodoLetivo { get; set; }

        [Key]
        [Column("COD_DISC", Order = 2)]
        [ForeignKey("Disciplina")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CodDisciplina { get; set; }
        public virtual Disciplina Disciplina { get; set; }

        [Key]
        [Column("COD_TURMA", Order = 3)]
        public int CodTurma { get; set; }

        [Required]
        [Column("VAGAS")]
        public int Vagas { get; set; }


        [Column("IDT_PROF")]
        [ForeignKey("Professor")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdtProf { get; set; }
        public virtual Professor Professor { get; set; }

    }
}