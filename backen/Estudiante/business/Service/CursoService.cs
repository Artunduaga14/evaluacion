using Business.Interface;
using Data.UnitOfWork;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    public class CursoService : ICursoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CursoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Curso>> GetAllCursoAsync()
        {
            return await _unitOfWork.Cursos.GetAllAsync();
        }

        public async Task<Curso?> GetCursoByIdAsync(int id)
        {
            return await _unitOfWork.Cursos.GetByIdAsync(id);
        }

        public async Task AddCursoAsync(Curso curso)
        {
            await _unitOfWork.Cursos.AddAsync(curso);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> DeleteCursoAsync(int id)
        {
            var curso = await _unitOfWork.Cursos.GetByIdAsync(id);
            if (curso == null) return false;

            _unitOfWork.Cursos.Delete(curso);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task UpdateCursoAsync(Curso curso) 
        {
            _unitOfWork.Cursos.Update(curso);
            await _unitOfWork.SaveAsync();
        }
    }
}





