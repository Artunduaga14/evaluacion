using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IEstudianteService
    {
        Task<IEnumerable<Estudiante>> GetAllEstudianteAsync();
        Task<Estudiante?> GetEstudianteByIdAsync(int id);
        Task AddEstudianteAsync(Estudiante estudiante);
        Task<bool> DeleteEstudianteAsync(int id);
        Task UpdateEstudianteAsync(Estudiante estudiante); 
    }
}
