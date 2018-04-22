using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagisterWebSite.Models
{
    public class Historico
    {
        private int ano, semestre, matAluno, codDisciplina, faltas;
        private char situacao;
        private double media;

        public int Ano { get { return ano; } set { ano = value; } }
        public int Semestre { get { return semestre; } set { semestre = value; } }
        public int MatAluno { get { return matAluno; } set { matAluno = value; } }
        public int CodDisciplina { get { return codDisciplina; } set { codDisciplina = value; } }
        public int Faltas { get { return faltas; } set { faltas = value; } }
        public char Situacao { get { return situacao; } set { situacao = value; } }
        private double Media { get { return media; } set { media = value; } }
    }
}