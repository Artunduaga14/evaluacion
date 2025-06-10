using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ICursoService
    {
        Task<IEnumerable<Curso>> GetAllCursoAsync();
        Task<Curso?> GetCursoByIdAsync(int id);
        Task AddCursoAsync(Curso curso);
        Task<bool> DeleteCursoAsync(int id);
        Task UpdateCursoAsync(Curso curso); 
    }
}



