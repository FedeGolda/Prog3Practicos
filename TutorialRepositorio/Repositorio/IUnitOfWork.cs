using TutorialRepositorio.Models;
using System;


namespace TutorialRepositorio.Repositorio
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Curso> Cursos { get; }
        IGenericRepository<Estudiante> Estudiantes { get; }
        void Save();
    }

}
