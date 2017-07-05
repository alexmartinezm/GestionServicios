using GestionServicios.Domain.MemoryContext;
using GestionServicios.Domain.Models;
using GestionServicios.Repository.Factories;
using GestionServicios.Repository.Repositories;

namespace GestionServiciosUnitTest.Tests
{
    [TestFixture]
    internal class FactoryTest
    {
        private MemoryContext _context;
        private RepositoryInMemory<Servicio> _servicioRepository;

        [SetUp]
        public void SetUp()
        {
            _context = new MemoryContext();
            _servicioRepository = new RepositoryInMemoryFactory<Servicio>(_context).Instance;
        }

        [Test]
        public void CreateTest()
        {
            var servicio = _servicioRepository.Create(new Servicio());

            Assert.AreEqual(typeof(Servicio), servicio.GetType());
        }
    }
}