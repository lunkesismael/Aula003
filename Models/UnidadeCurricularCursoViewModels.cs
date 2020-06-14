using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp005.Models
{
    public class UnidadeCurricularCursoViewModels
    {
        public int Id { get; set; }
        public Curso Curso { get; set; }
        public int CursoId { get; set; }
        public UnidadeCurricular UnidadeCurricular { get; set; }
        public int UnidadeCurricularId { get; set; }
    }
}