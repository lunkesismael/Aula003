using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp005.Models
{
    public class MatriculaViewModels
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public Aluno Aluno { get; set; }
        public int AlunoId { get; set; }
        public Curso Curso { get; set; }
        public int CursoId { get; set; }
    }
}