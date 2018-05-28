using MagisterWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace MagisterWeb.Models
{
    public class MagisterDataBaseInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            using (Context contexto = new Context())
            {
                using (var dbContextTransaction = contexto.Database.BeginTransaction())
                {
                    try
                    {
                        //Professor
                        Professor professor = new Professor();
                        professor.NomProf = "Fabio Gomes";
                        professor.MatProf = 001;
                        context.Professors.Add(professor);
                        contexto.SaveChanges();

                        Professor professor2 = new Professor();
                        professor2.NomProf = "Igor Vasconcelos";
                        professor2.MatProf = 002;
                        context.Professors.Add(professor2);
                        contexto.SaveChanges();

                        Professor professor3 = new Professor();
                        professor3.NomProf = "Rafael Vasconcelos";
                        professor3.MatProf = 003;
                        context.Professors.Add(professor3);
                        contexto.SaveChanges();

                        //Curso
                        Curso curso = new Curso();
                        curso.NomeCurso = "Sistemas de Informação";
                        curso.TotalCreditos = 10;
                        curso.Professor = professor2;
                        context.Cursoes.Add(curso);
                        contexto.SaveChanges();

                        Curso curso2 = new Curso();
                        curso2.NomeCurso = "Ciencia da Computação";
                        curso2.TotalCreditos = 20;
                        curso2.Professor = professor;
                        context.Cursoes.Add(curso2);
                        contexto.SaveChanges();

                        Curso curso3 = new Curso();
                        curso3.NomeCurso = "Redes de Computadores";
                        curso3.TotalCreditos = 15;
                        curso3.Professor = professor3;
                        context.Cursoes.Add(curso3);
                        contexto.SaveChanges();

                        //Periodo Letivo
                        PeriodoLetivo periodoLetivo = new PeriodoLetivo();
                        periodoLetivo.Ano = DateTime.Now.Year;
                        periodoLetivo.DataIni = DateTime.Parse("01/02/2018");
                        periodoLetivo.DataFim = DateTime.Parse("01/06/2018"); ;
                        periodoLetivo.Semestre = 1;
                        context.PeriodoLetivoes.Add(periodoLetivo);
                        contexto.SaveChanges();

                        PeriodoLetivo periodoLetivo2 = new PeriodoLetivo();
                        periodoLetivo2.Ano = DateTime.Now.Year;
                        periodoLetivo2.DataIni = DateTime.Parse("01/07/2018");
                        periodoLetivo2.DataFim = DateTime.Parse("01/12/2018"); ;
                        periodoLetivo2.Semestre = 2;
                        context.PeriodoLetivoes.Add(periodoLetivo2);
                        contexto.SaveChanges();

                        //Disciplinas
                        Disciplina disciplina = new Disciplina();
                        disciplina.NomeDisc = "Programação WEB I";
                        disciplina.Creditos = 6;
                        disciplina.TpoDisc = 'O';
                        disciplina.Horas_Obrig = 50;
                        disciplina.LimitFaltas = 30;
                        context.Disciplinas.Add(disciplina);
                        contexto.SaveChanges();

                        Disciplina disciplina2 = new Disciplina();
                        disciplina2.NomeDisc = "Programação Orientada a Objetos";
                        disciplina2.Creditos = 4;
                        disciplina2.TpoDisc = 'O';
                        disciplina2.Horas_Obrig = 40;
                        disciplina2.LimitFaltas = 20;
                        context.Disciplinas.Add(disciplina2);
                        contexto.SaveChanges();

                        Disciplina disciplina3 = new Disciplina();
                        disciplina3.NomeDisc = "Criatividade e Inovação";
                        disciplina3.Creditos = 2;
                        disciplina3.TpoDisc = 'P';
                        disciplina3.Horas_Obrig = 25;
                        disciplina3.LimitFaltas = 10;
                        context.Disciplinas.Add(disciplina3);
                        contexto.SaveChanges();

                        //Turmas
                        Turma turma = new Turma();
                        turma.Ano = 2018;
                        turma.Semestre = 1;
                        turma.Vagas = 30;
                        turma.Disciplina = disciplina;
                        turma.Professor = professor;
                        turma.CodTurma = 1;
                        context.Turmas.Add(turma);
                        contexto.SaveChanges();

                        Turma turma2 = new Turma();
                        turma2.Ano = 2018;
                        turma2.Semestre = 2;
                        turma2.Vagas = 30;
                        turma2.Disciplina = disciplina2;
                        turma2.Professor = professor2;
                        turma2.CodTurma = 1;
                        context.Turmas.Add(turma2);
                        contexto.SaveChanges();

                        //Aluno
                        Aluno aluno = new Aluno();
                        aluno.Nome = "Carlos Vinicius";
                        aluno.TotalCredito = 10;
                        aluno.DataAniversario = DateTime.Parse("12/01/1994");
                        aluno.MGP = 8;
                        aluno.Curso = curso;
                        context.Alunoes.Add(aluno);
                        contexto.SaveChanges();

                        Aluno aluno2 = new Aluno();
                        aluno2.Nome = "Alisson Santos";
                        aluno2.TotalCredito = 6;
                        aluno2.DataAniversario = DateTime.Parse("20/05/1996");
                        aluno2.MGP = 6;
                        aluno2.Curso = curso2;
                        context.Alunoes.Add(aluno2);
                        contexto.SaveChanges();

                        Aluno aluno3 = new Aluno();
                        aluno3.Nome = "Filipe Bastos";
                        aluno3.TotalCredito = 16;
                        aluno3.DataAniversario = DateTime.Parse("25/11/1995");
                        aluno3.MGP = 7;
                        aluno3.Curso = curso3;
                        context.Alunoes.Add(aluno3);
                        contexto.SaveChanges();

                        //Historico
                        Historico historico = new Historico();
                        historico.Ano = periodoLetivo.Ano;
                        historico.Semestre = periodoLetivo.Semestre;
                        historico.Disciplina = disciplina;
                        historico.MatriculaAluno = aluno.MatAluno;
                        historico.Media = 6;
                        historico.Faltas = 10;
                        historico.Curso = curso;
                        historico.Situacao = 'A';
                        historico.Aluno = aluno;
                        context.Historicoes.Add(historico);
                        contexto.SaveChanges();

                        Historico historico2 = new Historico();
                        historico2.Ano = periodoLetivo2.Ano;
                        historico2.Semestre = periodoLetivo2.Semestre;
                        historico2.Disciplina = disciplina2;
                        historico2.MatriculaAluno = aluno2.MatAluno;
                        historico2.Media = 6;
                        historico2.Faltas = 10;
                        historico2.Curso = curso2;
                        historico2.Situacao = 'A';
                        historico2.Aluno = aluno;
                        context.Historicoes.Add(historico2);
                        contexto.SaveChanges();

                        //Matricula
                        Matricula matricula = new Matricula();
                        matricula.Ano = periodoLetivo.Ano;
                        matricula.Semestre = periodoLetivo.Semestre;
                        matricula.MatriculaAluno = aluno.MatAluno;
                        matricula.CodDisciplina = disciplina.CodDisc;
                        matricula.Nota1 = 5;
                        matricula.Nota2 = 6;
                        matricula.Nota3 = 7;
                        matricula.Faltas1 = 4;
                        matricula.Faltas1 = 9;
                        matricula.Faltas1 = 12;
                        matricula.Aluno = aluno;
                        matricula.Disciplina = disciplina;
                        context.Matriculas.Add(matricula);
                        contexto.SaveChanges();

                        Matricula matricula2 = new Matricula();
                        matricula2.Ano = periodoLetivo2.Ano;
                        matricula2.Semestre = periodoLetivo2.Semestre;
                        matricula2.MatriculaAluno = aluno2.MatAluno;
                        matricula2.CodDisciplina = disciplina2.CodDisc;
                        matricula2.Nota1 = 7;
                        matricula2.Nota2 = 10;
                        matricula2.Nota3 = 7;
                        matricula2.Faltas1 = 4;
                        matricula2.Faltas1 = 12;
                        matricula2.Faltas1 = 8;
                        matricula2.Aluno = aluno2;
                        matricula2.Disciplina = disciplina;
                        context.Matriculas.Add(matricula2);
                        contexto.SaveChanges();

                        //Matriz
                        Matriz matriz = new Matriz();
                        matriz.Disciplina = disciplina;
                        matriz.Curso = curso;
                        matriz.Periodo = 6;
                        context.Matrizs.Add(matriz);
                        contexto.SaveChanges();

                        Matriz matriz2 = new Matriz();
                        matriz2.Disciplina = disciplina2;
                        matriz2.Curso = curso2;
                        matriz2.Periodo = 7;
                        context.Matrizs.Add(matriz2);
                        contexto.SaveChanges();

                        Matriz matriz3 = new Matriz();
                        matriz3.Disciplina = disciplina3;
                        matriz3.Curso = curso3;
                        matriz3.Periodo = 8;
                        context.Matrizs.Add(matriz3);
                        contexto.SaveChanges();


                        dbContextTransaction.Commit();
                    }
                    catch
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
            base.Seed(context);
        }

    }
}
