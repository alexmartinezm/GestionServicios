using System.Collections.Generic;
using System.Linq;
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
        public void AddEntityTest()
        {
            var servicio = new Servicio();
            _repositoryBase.Create(servicio);
            Assert.AreEqual(1, _repositoryBase.Find(s => s.Id == servicio.Id).Count);
        }

        [Test]
        public void FindEntityTest()
        {
            var num = 10;
            _repositoryBase.Create(new Servicio()
            {
                Lugar = new Lugar()
                {
                    Calle = new Calle()
                    {
                        Valor = "Piruleta"
                    },
                    Numero = num
                }
            });

            var serviciosNotFound = _repositoryBase.Find(s => s.Lugar.Calle.Valor.Equals("me lo invento"));
            var serviciosFound = _repositoryBase.Find(s => s.Lugar.Numero == num);

            Assert.AreEqual(0, serviciosNotFound.Count);
            Assert.AreEqual(1, serviciosFound.Count);
        }

        [Test]
        public void UdpateEntityTest()
        {
            // Creamos un servicio
            var servicio = new Servicio()
            {
                Descripcion = "Soy un nuevo servicio"
            };

            // Lo añadimos al repositorio
            _repositoryBase.Create(servicio);

            // Lo modificamos
            servicio.Descripcion = "Me he actualizado";
            _repositoryBase.Update(servicio);

            var servicioUpdated = _repositoryBase.Find(s => true).First();
            Assert.AreEqual(servicio.Descripcion, servicioUpdated.Descripcion);
        }

        [Test]
        public void CheckEntitiesPositionAfterUpdatingOk()
        {
            // Creamos servicios
            var servicio1 = new Servicio()
            {
                Descripcion = "Primer servicio"
            };
            var servicio2 = new Servicio()
            {
                Descripcion = "Segundo servicio"
            };
            var servicio3 = new Servicio()
            {
                Descripcion = "Tercer servicio"
            };
            var servicio4 = new Servicio()
            {
                Descripcion = "Cuarto servicio"
            };

            // Los añadimos al repositorio
            _repositoryBase.Create(servicio1);
            _repositoryBase.Create(servicio2);
            _repositoryBase.Create(servicio3);
            _repositoryBase.Create(servicio4);

            // Actualizamos el objeto servicio2
            servicio2.Descripcion = "Segundo servicio, actualizado!";
            _repositoryBase.Update(servicio2);
            
            // Comprobamos la posición
            Assert.AreEqual(1, _repositoryBase.Find(s => true).IndexOf(servicio2));
            Assert.AreEqual(3, _repositoryBase.Find(s => true).IndexOf(servicio4));
        }

        [Test]
        public void DeleteEntityTest()
        {

            // Creamos servicios
            var servicio = new Servicio()
            {
                Descripcion = "Primer servicio"
            };

            // Lo añadimos al repositorio
            _repositoryBase.Create(servicio);

            //_repositoryBase.Delete()
        }
    }
}