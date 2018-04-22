using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MagisterWebSite.Models
{
    public class Matricula
    {
        [Key]
        public int Ano { get; set; }
        [Required]
        public int Semestre { get; set; }
        [Required]
        public int MatAluno { get; set; }
        [Required]
        public int CodDisciplina { get; set; }
        public int Faltas_1 { get; set; }
        public int Faltas_2 { get; set; }
        public int Faltas_3 { get; set; }
        public double Nota_1 { get; set; }
        public double Nota_2 { get; set; }
        public double Nota_3 { get; set; }

        public virtual Periodo PeriodoLetivo { get; set; }

    }
}