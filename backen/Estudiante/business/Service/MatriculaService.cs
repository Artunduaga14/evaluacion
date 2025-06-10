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
    public class MatriculaService : IMatriculaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MatriculaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Matricula>> GetAllMatriculaAsync()
        {
            return await _unitOfWork.Matriculas.GetAllAsync();
        }

        public async Task<Matricula?> GetMatriculaByIdAsync(int id)
        {
            return await _unitOfWork.Matriculas.GetByIdAsync(id);
        }

        public async Task AddMatriculaAsync(Matricula matricula)
        {
            await _unitOfWork.Matriculas.AddAsync(matricula);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> DeleteMatriculaAsync(int id)
        {
            var matricula = await _unitOfWork.Matriculas.GetByIdAsync(id);
            if (matricula == null) return false;

            _unitOfWork.Matriculas.Delete(matricula);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task UpdateMatriculaAsync(Matricula matricula)
        {
            _unitOfWork.Matriculas.Update(matricula);
            await _unitOfWork.SaveAsync();
        }
    }
}





