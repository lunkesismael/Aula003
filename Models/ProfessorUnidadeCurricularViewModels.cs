using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace WebApp005.Models
{
    public class ProfessorUnidadeCurricularViewModels
    {
        public int Id { get; set; }
        public UnidadeCurricular UnidadeCurricular { get; set; }
        public int UnidadeCurricularId { get; set; }
        public Professor Professor { get; set; }
        public int ProfessorId { get; set; }
    }
}