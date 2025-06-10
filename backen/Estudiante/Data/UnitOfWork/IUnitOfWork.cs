using Data.Interface;
using Entity.Model;


namespace Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Curso> Cursos { get; }
        IGenericRepository<Estudiante> Estudiantes { get; }
        IGenericRepository<Matricula> Matriculas { get; }
        Task SaveAsync();
    }
}
