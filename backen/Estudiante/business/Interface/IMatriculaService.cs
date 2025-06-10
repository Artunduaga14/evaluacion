using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IMatriculaService
    {
        Task<IEnumerable<Matricula>> GetAllMatriculaAsync();
        Task<Matricula?> GetMatriculaByIdAsync(int id);
        Task AddMatriculaAsync(Matricula matricula);
        Task<bool> DeleteMatriculaAsync(int id);
        Task UpdateMatriculaAsync(Matricula matricula);
    }
}
