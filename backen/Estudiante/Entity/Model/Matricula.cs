using Entity.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Matricula : BaseModel
    {
        public int EstudianteId { get; set; }
        public int CursoId { get; set; }
        public DateTime FechaMatricula { get; set; }

        public Estudiante Estudiante { get; set; }
        public Curso Curso { get; set; }

    }
}
