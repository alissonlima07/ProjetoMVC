using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MagisterWebSite.Models
{
    public class Curso
    {
        [Key]
        //[StringLength(3, ErrorMessage = "O código do curso só possui no máximo 3 digitos.")]
        public int Id { get; set; }

        [Required]
        [StringLength(100,ErrorMessage ="O nome do curso não pode possuir mais de 100 caracteres.")]
        [Display(Name ="Nome Curso")]
        public String NomeCurso { get; set; }

        [Required]
        [Display(Name = "Total Créditos")]
        //[StringLength(3, ErrorMessage = "Total de créditos do curso só possui no máximo 3 digitos.")]
        public int TotalCreditos { get; set; }

        public int ProfessorId { get; set; }
        public virtual Professor Professor { get; set; }

    }
}

