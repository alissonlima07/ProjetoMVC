using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MagisterWebSite.Models
{
    public class Professor
    {
        [Key]
        //[StringLength(6, ErrorMessage = "O código do professor só possui no máximo 6 digitos.")]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Matricula Professor")]
        //[StringLength(6, ErrorMessage = "A matricula do professor só possui no máximo 6 digitos.")]
        public int MatriculaProf { get; set; }

        [Required]
        [StringLength(50,ErrorMessage ="O nome deve possuir no máximo 50 caracteres.")]
        [Display(Name ="Nome Professor")]
        public string NomeProf { get; set; }

    }
}