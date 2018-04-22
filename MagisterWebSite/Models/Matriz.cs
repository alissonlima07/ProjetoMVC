using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MagisterWebSite.Models
{
    public class Matriz
    {
        private int  codDisciplina, codCurso, periodo;

        public int CodDisciplina { get { return codDisciplina; } set { codDisciplina = value; } }
        public int CodCurso { get { return codCurso; } set { codCurso = value; } }
        public int Periodo { get { return periodo; } set { periodo = value; } }
    }
}