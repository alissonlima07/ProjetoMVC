using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MagisterWeb.Models
{
    [Table("PROFESSOR")]
    public class Professor
    {

        public List<Curso> listaCurso { get; set; }
        public List<Turma> listaTurma { get; set; }


        [Key]
        [Column("IDT_PROF", Order = 0)]
        [Display(Name = "ID do Professor")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdtProf { get; set; }

        [Required]
        [Column("MAT_PROF")]
        [Display(Name = "Matricula do Professor")]
        public int MatProf { get; set; }

        [Required]
        [Column("NOM_PROF")]
        [Display(Name = "Nome do Professor")]
        public string NomProf { get; set; }

    }
}