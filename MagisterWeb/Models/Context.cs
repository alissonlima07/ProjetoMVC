using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MagisterWeb.Models
{
    public class Context : IdentityDbContext<Usuario>
    {
        public Context() : base("name=Context")

        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static Context Create()
        {
            return new Context();
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
