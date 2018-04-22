using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MagisterWeb.Models
{
    [Table("PERIODOS_LETIVOS")]
    public class PeriodoLetivo
    {

        public List<Turma> listaTurma { get; set; }

        public List<Matricula> ListaMatricula { get; set; }

        public List<Historico> ListaHistorico { get; set; }
        [Key]
        [Column("ANO", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Ano { get; set; }

        [Key]
        [Column("SEMESTRE", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Semestre { get; set; }

        [Required]
        [Display(Name = "Data Inicial")]
        [Column("DAT_INI")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime DataIni { get; set; }

        [Required]
        [Display(Name = "Data Final")]
        [Column("DAT_FIM")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime DataFim { get; set; }

        public virtual Turma Turma { get; set; }
        public virtual Matricula Matricula { get; set; }
        public virtual Historico Historico { get; set; }
    }
}