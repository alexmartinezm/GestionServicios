using GestionServicios.Domain.MemoryContext;
using GestionServicios.Domain.Models.Base;
using GestionServicios.Repository.Repositories;

namespace GestionServicios.Repository.Factories
{
    /// <summary>
    /// Factory genérico para los repositorios InMemory.
    /// </summary>
    /// <typeparam name="TEntity">Entidad que hereda de BaseModel</typeparam>
    public class RepositoryInMemoryFactory<TEntity> where TEntity : BaseModel, new()
    {
        private readonly MemoryContext _context;

        public RepositoryInMemoryFactory(MemoryContext context)
        {
            _context = context;
        }

        // Crea la instancia del repositorio de la entidad TEntity
        public RepositoryInMemory<TEntity> Instance => new RepositoryInMemory<TEntity>(_context);
    }
}
