using System.Collections.Generic;
using GestionServiciosUnitTest.Models;
using GestionServiciosUnitTest.Repository;
using NUnit.Framework;

namespace GestionServiciosUnitTest.Tests
{
    [TestFixture]
    public class RepositoryTest
    {
        private RepositoryInMemory<Servicio> _repositoryBase;

        [SetUp]
        public void SetUp()
        {
            _repositoryBase = new RepositoryInMemory<Servicio>(new List<Servicio>());
        }

        [Test]
        public void AddEntity()
        {
            _repositoryBase.Create(new Servicio());
        }
    }
}