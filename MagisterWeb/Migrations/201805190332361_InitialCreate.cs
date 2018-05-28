namespace MagisterWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ALUNO",
                c => new
                    {
                        MatAluno = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150),
                        TotalCredito = c.Int(nullable: false),
                        DataAniversario = c.DateTime(nullable: false),
                        MGP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        COD_CURSO = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatAluno)
                .ForeignKey("dbo.CURSO", t => t.COD_CURSO, cascadeDelete: true)
                .Index(t => t.COD_CURSO);
            
            CreateTable(
                "dbo.CURSO",
                c => new
                    {
                        COD_CURSO = c.Int(nullable: false, identity: true),
                        NOM_CURSO = c.String(nullable: false, maxLength: 100),
                        TOT_CRED = c.Int(nullable: false),
                        IDT_PROF = c.Int(nullable: false),
                        Matriz_CodDisciplina = c.Int(),
                        Matriz_CodCurso = c.Int(),
                    })
                .PrimaryKey(t => t.COD_CURSO)
                .ForeignKey("dbo.MATRIZ", t => new { t.Matriz_CodDisciplina, t.Matriz_CodCurso })
                .ForeignKey("dbo.PROFESSOR", t => t.IDT_PROF, cascadeDelete: true)
                .Index(t => t.IDT_PROF)
                .Index(t => new { t.Matriz_CodDisciplina, t.Matriz_CodCurso });
            
            CreateTable(
                "dbo.MATRIZ",
                c => new
                    {
                        COD_DISC = c.Int(nullable: false),
                        COD_CURSO = c.Int(nullable: false),
                        PERIODO = c.Int(nullable: false),
                        Disciplina_CodDisc = c.Int(),
                        Curso_CodCurso = c.Int(),
                    })
                .PrimaryKey(t => new { t.COD_DISC, t.COD_CURSO })
                .ForeignKey("dbo.CURSO", t => t.COD_DISC, cascadeDelete: true)
                .ForeignKey("dbo.DISCIPLINA", t => t.Disciplina_CodDisc)
                .ForeignKey("dbo.DISCIPLINA", t => t.COD_CURSO, cascadeDelete: true)
                .ForeignKey("dbo.CURSO", t => t.Curso_CodCurso)
                .Index(t => t.COD_DISC)
                .Index(t => t.COD_CURSO)
                .Index(t => t.Disciplina_CodDisc)
                .Index(t => t.Curso_CodCurso);
            
            CreateTable(
                "dbo.DISCIPLINA",
                c => new
                    {
                        COD_DISC = c.Int(nullable: false, identity: true),
                        NOM_DISC = c.String(nullable: false, maxLength: 100),
                        CREDITOS = c.Int(nullable: false),
                        HORAS_OBRIG = c.Int(nullable: false),
                        LIMITE_FALTAS = c.Int(nullable: false),
                        Disciplina_CodDisc = c.Int(),
                        Historico_Ano = c.Int(),
                        Historico_Semestre = c.Int(),
                        Historico_MatriculaAluno = c.Int(),
                        Historico_CodDisciplina = c.Int(),
                        Matricula_Ano = c.Int(),
                        Matricula_Semestre = c.Int(),
                        Matricula_MatriculaAluno = c.Int(),
                        Matricula_CodDisciplina = c.Int(),
                        Matriz_CodDisciplina = c.Int(),
                        Matriz_CodCurso = c.Int(),
                        Turma_Ano = c.Int(),
                        Turma_Semestre = c.Int(),
                        Turma_CodDisciplina = c.Int(),
                        Turma_CodTurma = c.Int(),
                        Matriz_CodDisciplina1 = c.Int(),
                        Matriz_CodCurso1 = c.Int(),
                    })
                .PrimaryKey(t => t.COD_DISC)
                .ForeignKey("dbo.DISCIPLINA", t => t.Disciplina_CodDisc)
                .ForeignKey("dbo.HISTORICO", t => new { t.Historico_Ano, t.Historico_Semestre, t.Historico_MatriculaAluno, t.Historico_CodDisciplina })
                .ForeignKey("dbo.MATRICULA", t => new { t.Matricula_Ano, t.Matricula_Semestre, t.Matricula_MatriculaAluno, t.Matricula_CodDisciplina })
                .ForeignKey("dbo.MATRIZ", t => new { t.Matriz_CodDisciplina, t.Matriz_CodCurso })
                .ForeignKey("dbo.TURMA", t => new { t.Turma_Ano, t.Turma_Semestre, t.Turma_CodDisciplina, t.Turma_CodTurma })
                .ForeignKey("dbo.MATRIZ", t => new { t.Matriz_CodDisciplina1, t.Matriz_CodCurso1 })
                .Index(t => t.Disciplina_CodDisc)
                .Index(t => new { t.Historico_Ano, t.Historico_Semestre, t.Historico_MatriculaAluno, t.Historico_CodDisciplina })
                .Index(t => new { t.Matricula_Ano, t.Matricula_Semestre, t.Matricula_MatriculaAluno, t.Matricula_CodDisciplina })
                .Index(t => new { t.Matriz_CodDisciplina, t.Matriz_CodCurso })
                .Index(t => new { t.Turma_Ano, t.Turma_Semestre, t.Turma_CodDisciplina, t.Turma_CodTurma })
                .Index(t => new { t.Matriz_CodDisciplina1, t.Matriz_CodCurso1 });
            
            CreateTable(
                "dbo.HISTORICO",
                c => new
                    {
                        ANO = c.Int(nullable: false),
                        SEMESTRE = c.Int(nullable: false),
                        MAT_ALU = c.Int(nullable: false),
                        COD_DISC = c.Int(nullable: false),
                        Media = c.Double(nullable: false),
                        Faltas = c.Int(nullable: false),
                        Curso_CodCurso = c.Int(),
                        PeriodoLetivo_Ano = c.Int(),
                        PeriodoLetivo_Semestre = c.Int(),
                        Disciplina_CodDisc = c.Int(),
                    })
                .PrimaryKey(t => new { t.ANO, t.SEMESTRE, t.MAT_ALU, t.COD_DISC })
                .ForeignKey("dbo.ALUNO", t => t.MAT_ALU, cascadeDelete: true)
                .ForeignKey("dbo.CURSO", t => t.Curso_CodCurso)
                .ForeignKey("dbo.DISCIPLINA", t => t.COD_DISC, cascadeDelete: true)
                .ForeignKey("dbo.PERIODOS_LETIVOS", t => new { t.PeriodoLetivo_Ano, t.PeriodoLetivo_Semestre })
                .ForeignKey("dbo.PERIODOS_LETIVOS", t => new { t.ANO, t.SEMESTRE }, cascadeDelete: true)
                .ForeignKey("dbo.DISCIPLINA", t => t.Disciplina_CodDisc)
                .Index(t => new { t.ANO, t.SEMESTRE })
                .Index(t => t.MAT_ALU)
                .Index(t => t.COD_DISC)
                .Index(t => t.Curso_CodCurso)
                .Index(t => new { t.PeriodoLetivo_Ano, t.PeriodoLetivo_Semestre })
                .Index(t => t.Disciplina_CodDisc);
            
            CreateTable(
                "dbo.PERIODOS_LETIVOS",
                c => new
                    {
                        ANO = c.Int(nullable: false),
                        SEMESTRE = c.Int(nullable: false),
                        DAT_INI = c.DateTime(nullable: false),
                        DAT_FIM = c.DateTime(nullable: false),
                        Historico_Ano = c.Int(),
                        Historico_Semestre = c.Int(),
                        Historico_MatriculaAluno = c.Int(),
                        Historico_CodDisciplina = c.Int(),
                        Matricula_Ano = c.Int(),
                        Matricula_Semestre = c.Int(),
                        Matricula_MatriculaAluno = c.Int(),
                        Matricula_CodDisciplina = c.Int(),
                        Turma_Ano = c.Int(),
                        Turma_Semestre = c.Int(),
                        Turma_CodDisciplina = c.Int(),
                        Turma_CodTurma = c.Int(),
                    })
                .PrimaryKey(t => new { t.ANO, t.SEMESTRE })
                .ForeignKey("dbo.HISTORICO", t => new { t.Historico_Ano, t.Historico_Semestre, t.Historico_MatriculaAluno, t.Historico_CodDisciplina })
                .ForeignKey("dbo.MATRICULA", t => new { t.Matricula_Ano, t.Matricula_Semestre, t.Matricula_MatriculaAluno, t.Matricula_CodDisciplina })
                .ForeignKey("dbo.TURMA", t => new { t.Turma_Ano, t.Turma_Semestre, t.Turma_CodDisciplina, t.Turma_CodTurma })
                .Index(t => new { t.Historico_Ano, t.Historico_Semestre, t.Historico_MatriculaAluno, t.Historico_CodDisciplina })
                .Index(t => new { t.Matricula_Ano, t.Matricula_Semestre, t.Matricula_MatriculaAluno, t.Matricula_CodDisciplina })
                .Index(t => new { t.Turma_Ano, t.Turma_Semestre, t.Turma_CodDisciplina, t.Turma_CodTurma });
            
            CreateTable(
                "dbo.MATRICULA",
                c => new
                    {
                        ANO = c.Int(nullable: false),
                        SEMESTRE = c.Int(nullable: false),
                        MAT_ALU = c.Int(nullable: false),
                        COD_DISC = c.Int(nullable: false),
                        Nota1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Nota2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Nota3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Faltas1 = c.Int(nullable: false),
                        Faltas2 = c.Int(nullable: false),
                        Faltas3 = c.Int(nullable: false),
                        Matricula_Ano = c.Int(),
                        Matricula_Semestre = c.Int(),
                        Matricula_MatriculaAluno = c.Int(),
                        Matricula_CodDisciplina = c.Int(),
                        PeriodoLetivo_Ano = c.Int(),
                        PeriodoLetivo_Semestre = c.Int(),
                        Disciplina_CodDisc = c.Int(),
                    })
                .PrimaryKey(t => new { t.ANO, t.SEMESTRE, t.MAT_ALU, t.COD_DISC })
                .ForeignKey("dbo.ALUNO", t => t.MAT_ALU, cascadeDelete: true)
                .ForeignKey("dbo.DISCIPLINA", t => t.COD_DISC, cascadeDelete: true)
                .ForeignKey("dbo.MATRICULA", t => new { t.Matricula_Ano, t.Matricula_Semestre, t.Matricula_MatriculaAluno, t.Matricula_CodDisciplina })
                .ForeignKey("dbo.PERIODOS_LETIVOS", t => new { t.ANO, t.SEMESTRE }, cascadeDelete: true)
                .ForeignKey("dbo.PERIODOS_LETIVOS", t => new { t.PeriodoLetivo_Ano, t.PeriodoLetivo_Semestre })
                .ForeignKey("dbo.DISCIPLINA", t => t.Disciplina_CodDisc)
                .Index(t => new { t.ANO, t.SEMESTRE })
                .Index(t => t.MAT_ALU)
                .Index(t => t.COD_DISC)
                .Index(t => new { t.Matricula_Ano, t.Matricula_Semestre, t.Matricula_MatriculaAluno, t.Matricula_CodDisciplina })
                .Index(t => new { t.PeriodoLetivo_Ano, t.PeriodoLetivo_Semestre })
                .Index(t => t.Disciplina_CodDisc);
            
            CreateTable(
                "dbo.TURMA",
                c => new
                    {
                        ANO = c.Int(nullable: false),
                        SEMESTRE = c.Int(nullable: false),
                        COD_DISC = c.Int(nullable: false),
                        COD_TURMA = c.Int(nullable: false),
                        VAGAS = c.Int(nullable: false),
                        IDT_PROF = c.Int(nullable: false),
                        PeriodoLetivo_Ano = c.Int(),
                        PeriodoLetivo_Semestre = c.Int(),
                        Disciplina_CodDisc = c.Int(),
                    })
                .PrimaryKey(t => new { t.ANO, t.SEMESTRE, t.COD_DISC, t.COD_TURMA })
                .ForeignKey("dbo.DISCIPLINA", t => t.COD_DISC, cascadeDelete: true)
                .ForeignKey("dbo.PERIODOS_LETIVOS", t => new { t.ANO, t.SEMESTRE }, cascadeDelete: true)
                .ForeignKey("dbo.PROFESSOR", t => t.IDT_PROF, cascadeDelete: true)
                .ForeignKey("dbo.PERIODOS_LETIVOS", t => new { t.PeriodoLetivo_Ano, t.PeriodoLetivo_Semestre })
                .ForeignKey("dbo.DISCIPLINA", t => t.Disciplina_CodDisc)
                .Index(t => new { t.ANO, t.SEMESTRE })
                .Index(t => t.COD_DISC)
                .Index(t => t.IDT_PROF)
                .Index(t => new { t.PeriodoLetivo_Ano, t.PeriodoLetivo_Semestre })
                .Index(t => t.Disciplina_CodDisc);
            
            CreateTable(
                "dbo.PROFESSOR",
                c => new
                    {
                        IDT_PROF = c.Int(nullable: false, identity: true),
                        MAT_PROF = c.Int(nullable: false),
                        NOM_PROF = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IDT_PROF);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ALUNO", "COD_CURSO", "dbo.CURSO");
            DropForeignKey("dbo.CURSO", "IDT_PROF", "dbo.PROFESSOR");
            DropForeignKey("dbo.MATRIZ", "Curso_CodCurso", "dbo.CURSO");
            DropForeignKey("dbo.DISCIPLINA", new[] { "Matriz_CodDisciplina1", "Matriz_CodCurso1" }, "dbo.MATRIZ");
            DropForeignKey("dbo.CURSO", new[] { "Matriz_CodDisciplina", "Matriz_CodCurso" }, "dbo.MATRIZ");
            DropForeignKey("dbo.MATRIZ", "COD_CURSO", "dbo.DISCIPLINA");
            DropForeignKey("dbo.DISCIPLINA", new[] { "Turma_Ano", "Turma_Semestre", "Turma_CodDisciplina", "Turma_CodTurma" }, "dbo.TURMA");
            DropForeignKey("dbo.DISCIPLINA", new[] { "Matriz_CodDisciplina", "Matriz_CodCurso" }, "dbo.MATRIZ");
            DropForeignKey("dbo.DISCIPLINA", new[] { "Matricula_Ano", "Matricula_Semestre", "Matricula_MatriculaAluno", "Matricula_CodDisciplina" }, "dbo.MATRICULA");
            DropForeignKey("dbo.TURMA", "Disciplina_CodDisc", "dbo.DISCIPLINA");
            DropForeignKey("dbo.MATRIZ", "Disciplina_CodDisc", "dbo.DISCIPLINA");
            DropForeignKey("dbo.MATRICULA", "Disciplina_CodDisc", "dbo.DISCIPLINA");
            DropForeignKey("dbo.HISTORICO", "Disciplina_CodDisc", "dbo.DISCIPLINA");
            DropForeignKey("dbo.DISCIPLINA", new[] { "Historico_Ano", "Historico_Semestre", "Historico_MatriculaAluno", "Historico_CodDisciplina" }, "dbo.HISTORICO");
            DropForeignKey("dbo.HISTORICO", new[] { "ANO", "SEMESTRE" }, "dbo.PERIODOS_LETIVOS");
            DropForeignKey("dbo.PERIODOS_LETIVOS", new[] { "Turma_Ano", "Turma_Semestre", "Turma_CodDisciplina", "Turma_CodTurma" }, "dbo.TURMA");
            DropForeignKey("dbo.PERIODOS_LETIVOS", new[] { "Matricula_Ano", "Matricula_Semestre", "Matricula_MatriculaAluno", "Matricula_CodDisciplina" }, "dbo.MATRICULA");
            DropForeignKey("dbo.TURMA", new[] { "PeriodoLetivo_Ano", "PeriodoLetivo_Semestre" }, "dbo.PERIODOS_LETIVOS");
            DropForeignKey("dbo.TURMA", "IDT_PROF", "dbo.PROFESSOR");
            DropForeignKey("dbo.TURMA", new[] { "ANO", "SEMESTRE" }, "dbo.PERIODOS_LETIVOS");
            DropForeignKey("dbo.TURMA", "COD_DISC", "dbo.DISCIPLINA");
            DropForeignKey("dbo.MATRICULA", new[] { "PeriodoLetivo_Ano", "PeriodoLetivo_Semestre" }, "dbo.PERIODOS_LETIVOS");
            DropForeignKey("dbo.MATRICULA", new[] { "ANO", "SEMESTRE" }, "dbo.PERIODOS_LETIVOS");
            DropForeignKey("dbo.MATRICULA", new[] { "Matricula_Ano", "Matricula_Semestre", "Matricula_MatriculaAluno", "Matricula_CodDisciplina" }, "dbo.MATRICULA");
            DropForeignKey("dbo.MATRICULA", "COD_DISC", "dbo.DISCIPLINA");
            DropForeignKey("dbo.MATRICULA", "MAT_ALU", "dbo.ALUNO");
            DropForeignKey("dbo.HISTORICO", new[] { "PeriodoLetivo_Ano", "PeriodoLetivo_Semestre" }, "dbo.PERIODOS_LETIVOS");
            DropForeignKey("dbo.PERIODOS_LETIVOS", new[] { "Historico_Ano", "Historico_Semestre", "Historico_MatriculaAluno", "Historico_CodDisciplina" }, "dbo.HISTORICO");
            DropForeignKey("dbo.HISTORICO", "COD_DISC", "dbo.DISCIPLINA");
            DropForeignKey("dbo.HISTORICO", "Curso_CodCurso", "dbo.CURSO");
            DropForeignKey("dbo.HISTORICO", "MAT_ALU", "dbo.ALUNO");
            DropForeignKey("dbo.DISCIPLINA", "Disciplina_CodDisc", "dbo.DISCIPLINA");
            DropForeignKey("dbo.MATRIZ", "COD_DISC", "dbo.CURSO");
            DropIndex("dbo.TURMA", new[] { "Disciplina_CodDisc" });
            DropIndex("dbo.TURMA", new[] { "PeriodoLetivo_Ano", "PeriodoLetivo_Semestre" });
            DropIndex("dbo.TURMA", new[] { "IDT_PROF" });
            DropIndex("dbo.TURMA", new[] { "COD_DISC" });
            DropIndex("dbo.TURMA", new[] { "ANO", "SEMESTRE" });
            DropIndex("dbo.MATRICULA", new[] { "Disciplina_CodDisc" });
            DropIndex("dbo.MATRICULA", new[] { "PeriodoLetivo_Ano", "PeriodoLetivo_Semestre" });
            DropIndex("dbo.MATRICULA", new[] { "Matricula_Ano", "Matricula_Semestre", "Matricula_MatriculaAluno", "Matricula_CodDisciplina" });
            DropIndex("dbo.MATRICULA", new[] { "COD_DISC" });
            DropIndex("dbo.MATRICULA", new[] { "MAT_ALU" });
            DropIndex("dbo.MATRICULA", new[] { "ANO", "SEMESTRE" });
            DropIndex("dbo.PERIODOS_LETIVOS", new[] { "Turma_Ano", "Turma_Semestre", "Turma_CodDisciplina", "Turma_CodTurma" });
            DropIndex("dbo.PERIODOS_LETIVOS", new[] { "Matricula_Ano", "Matricula_Semestre", "Matricula_MatriculaAluno", "Matricula_CodDisciplina" });
            DropIndex("dbo.PERIODOS_LETIVOS", new[] { "Historico_Ano", "Historico_Semestre", "Historico_MatriculaAluno", "Historico_CodDisciplina" });
            DropIndex("dbo.HISTORICO", new[] { "Disciplina_CodDisc" });
            DropIndex("dbo.HISTORICO", new[] { "PeriodoLetivo_Ano", "PeriodoLetivo_Semestre" });
            DropIndex("dbo.HISTORICO", new[] { "Curso_CodCurso" });
            DropIndex("dbo.HISTORICO", new[] { "COD_DISC" });
            DropIndex("dbo.HISTORICO", new[] { "MAT_ALU" });
            DropIndex("dbo.HISTORICO", new[] { "ANO", "SEMESTRE" });
            DropIndex("dbo.DISCIPLINA", new[] { "Matriz_CodDisciplina1", "Matriz_CodCurso1" });
            DropIndex("dbo.DISCIPLINA", new[] { "Turma_Ano", "Turma_Semestre", "Turma_CodDisciplina", "Turma_CodTurma" });
            DropIndex("dbo.DISCIPLINA", new[] { "Matriz_CodDisciplina", "Matriz_CodCurso" });
            DropIndex("dbo.DISCIPLINA", new[] { "Matricula_Ano", "Matricula_Semestre", "Matricula_MatriculaAluno", "Matricula_CodDisciplina" });
            DropIndex("dbo.DISCIPLINA", new[] { "Historico_Ano", "Historico_Semestre", "Historico_MatriculaAluno", "Historico_CodDisciplina" });
            DropIndex("dbo.DISCIPLINA", new[] { "Disciplina_CodDisc" });
            DropIndex("dbo.MATRIZ", new[] { "Curso_CodCurso" });
            DropIndex("dbo.MATRIZ", new[] { "Disciplina_CodDisc" });
            DropIndex("dbo.MATRIZ", new[] { "COD_CURSO" });
            DropIndex("dbo.MATRIZ", new[] { "COD_DISC" });
            DropIndex("dbo.CURSO", new[] { "Matriz_CodDisciplina", "Matriz_CodCurso" });
            DropIndex("dbo.CURSO", new[] { "IDT_PROF" });
            DropIndex("dbo.ALUNO", new[] { "COD_CURSO" });
            DropTable("dbo.PROFESSOR");
            DropTable("dbo.TURMA");
            DropTable("dbo.MATRICULA");
            DropTable("dbo.PERIODOS_LETIVOS");
            DropTable("dbo.HISTORICO");
            DropTable("dbo.DISCIPLINA");
            DropTable("dbo.MATRIZ");
            DropTable("dbo.CURSO");
            DropTable("dbo.ALUNO");
        }
    }
}
