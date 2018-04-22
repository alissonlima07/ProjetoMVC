using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MagisterWeb.Models
{
    public class Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Context() : base("name=Context")
        {
        }

        public System.Data.Entity.DbSet<MagisterWeb.Models.Aluno> Alunoes { get; set; }

        public System.Data.Entity.DbSet<MagisterWeb.Models.Curso> Cursoes { get; set; }

        public System.Data.Entity.DbSet<MagisterWeb.Models.Professor> Professors { get; set; }

        public System.Data.Entity.DbSet<MagisterWeb.Models.Disciplina> Disciplinas { get; set; }

        public System.Data.Entity.DbSet<MagisterWeb.Models.Historico> Historicoes { get; set; }

        public System.Data.Entity.DbSet<MagisterWeb.Models.PeriodoLetivo> PeriodoLetivoes { get; set; }

        public System.Data.Entity.DbSet<MagisterWeb.Models.Matricula> Matriculas { get; set; }

        public System.Data.Entity.DbSet<MagisterWeb.Models.Matriz> Matrizs { get; set; }

        public System.Data.Entity.DbSet<MagisterWeb.Models.Turma> Turmas { get; set; }
    }
}
