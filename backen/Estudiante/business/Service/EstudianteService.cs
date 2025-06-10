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
    public class EstudianteService : IEstudianteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EstudianteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Estudiante>> GetAllEstudianteAsync()
        {
            return await _unitOfWork.Estudiantes.GetAllAsync();
        }

        public async Task<Estudiante?> GetEstudianteByIdAsync(int id)
        {
            return await _unitOfWork.Estudiantes.GetByIdAsync(id);
        }

        public async Task AddEstudianteAsync(Estudiante estudiante)
        {
            await _unitOfWork.Estudiantes.AddAsync(estudiante);
            await _unitOfWork.SaveAsync();
        }

        public async Task<bool> DeleteEstudianteAsync(int id)
        {
            var estudiante = await _unitOfWork.Estudiantes.GetByIdAsync(id);
            if (estudiante == null) return false;

            _unitOfWork.Estudiantes.Delete(estudiante);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task UpdateEstudianteAsync(Estudiante estudiante)
        {
            _unitOfWork.Estudiantes.Update(estudiante);
            await _unitOfWork.SaveAsync();
        }
    }
}
