using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MagisterWebSite.Models
{
    public class Discplina
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50,ErrorMessage = "A disciplina contém mais de 50 caracteres")]
        public string NomeDisciplina { get; set; }
        [Required]
        [Range(0,2, ErrorMessage = "A quantidade de créditos deve ter até duas unidades")]
        public int Creditos { get; set; }
        [Required]
        [StringLength(1, ErrorMessage = "O tipo da disciplina deve ter somente um caracter")]
        public string TipoDisciplina { get; set; }
        [Range(0, 2, ErrorMessage = "A quantidade de hora obrigatórias deve ter até duas unidades")]
        public int HoraObrigatorias { get; set; }
        [Range(0, 2, ErrorMessage = "O limite de faltas deve ter até duas unidades")]
        public int LimitesDeFaltas { get; set; }

        public virtual Matricula Matricula { get; set; }
        public virtual Turma Turma { get; set; }
        public virtual Matriz Matriz { get; set; }
        public virtual Historico Historico { get; set; }
    }
}