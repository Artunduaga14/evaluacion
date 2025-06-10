using Data.Interface;
using Data.Repositories;
using Entity.Contexts;
using Entity.Model;


namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGenericRepository<Curso> Cursos { get; }
        public IGenericRepository<Estudiante> Estudiantes { get; }
        public IGenericRepository<Matricula> Matriculas { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Cursos = new GenericRepository<Curso>(context);
            Estudiantes = new GenericRepository<Estudiante>(context);
            Matriculas = new GenericRepository<Matricula>(context);
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
        public void Dispose() => _context.Dispose();
    }

}
