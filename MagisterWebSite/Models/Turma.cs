using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MagisterWebSite.Models
{
    public class Turma
    {
        [Key]
        public Periodo PeriodoAno { get; set; }

        [Key]
        public Periodo PeriodoSemestre { get; set; }
        
        [Required]
        [StringLength(3, ErrorMessage = "Vagas só possui no máximo 3 digitos.")]
        public int Vagas { get; set; }

        [Required]
        public Professor ProfessorId { get; set; }

        public virtual Periodo Periodo { get; set; }
        public virtual Professor Professor { get; set; }
    }
}