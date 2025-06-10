using Entity.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
    class MateriaDto:BaseDto
    {
        public int EstudianteId { get; set; }
        public int CursoId { get; set; }
        public DateTime FechaMatricula { get; set; }

    }
}
