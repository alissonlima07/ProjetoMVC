using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MagisterWeb.Models
{

    [Table("CURSO")]
    public class Curso
    {

        public List<Aluno> listaAluno { get; set; }
        public List<Matriz> listaMatriz { get; set; }

        [Key]
        [Column("COD_CURSO")]
        [Display(Name = "Código do Curso")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CodCurso { get; set; }

        [Required]
        [Column("NOM_CURSO")]
        [Display(Name = "Nome do Curso")]
        [StringLength(100, ErrorMessage = "O Nome pode conter no máximo 150")]
        public string NomeCurso { get; set; }

        [Required]
        [Column("TOT_CRED")]
        [Display(Name = "Total de Créditos")]
        public int TotalCreditos { get; set; }

        [ForeignKey("Professor")]
        [Column("IDT_PROF")]
        [Display(Name = "Nome do Professor")]
        public int IdProf { get; set; }

        public virtual Professor Professor { get; set; }
    }
}