using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MagisterWeb.Models
{
    [Table("DISCIPLINA")]
    public class Disciplina
    {
        [Key]
        [Column("COD_DISC", Order = 0)]
        [Display(Name = "Codigo da Disciplina")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodDisc { get; set; }

        [Required]
        [Column("NOM_DISC")]
        [StringLength(100, ErrorMessage = "O Nome pode conter no máximo 100")]
        [Display(Name = "Nome da Disciplina")]
        public string NomeDisc { get; set; }

        [Required]
        [Column("CREDITOS")]
        [Display(Name = "Créditos da Disciplina")]
        public int Creditos { get; set; }

        [Required]
        [Column("TPO_DISC")]
        [Display(Name = "Tipo da Disciplina")]
        public int TpoDisc { get; set; }

        [Column("HORAS_OBRIG")]
        [Display(Name = "Horas Obrigatórias")]
        public DateTime Horas_Obrig { get; set; }

        [Column("LIMITE_FALTAS")]
        [Display(Name = "Limite de faltas")]
        public int LimitFaltas { get; set; }

        [ForeignKey("Disciplina")]
        [Column("COD_DISC")]
        public List<int> CodDisciplinaPreReque { get; set; }      
        public virtual ICollection<Disciplina> DiscPreReq { get; set; }

        public virtual Matriz Matriz { get; set; }
        public virtual Turma Turma { get; set; }
        public virtual Matricula Matricula { get; set; }
        public virtual Historico Historico { get; set; }

        public List<Matriz> listaMatriz { get; set; }
        public List<Turma> listaTurma { get; set; }
        public List<Matricula> ListaMatricula { get; set; }
        public List<Historico> ListaHistorico { get; set; }
        public IEnumerable<SelectListItem> ListaDisciplinas { get; set; }

    }
}