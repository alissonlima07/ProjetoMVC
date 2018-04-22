using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MagisterWebSite.Models
{
    public class Periodo
    {
        [Key]
        //[StringLength(4, ErrorMessage = "O ano só possui no máximo 4 digitos.")]
        public int Ano { get; set; }

        [Key]
        //[StringLength(1, ErrorMessage = "O semestre só possui no máximo 1 digito.")]
        public int Semestre { get; set; }

        [Required]
        [Display(Name ="Data Inicial")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime DataInicial { get; set; }

        [Required]
        [Display(Name = "Data Final")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime DataFinal { get; set; }
    }

}