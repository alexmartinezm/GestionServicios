using GestionServicios.Domain.MemoryContext;
using GestionServicios.Domain.Models;
using GestionServicios.Repository.Repositories;
using NUnit.Framework;

namespace GestionServiciosUnitTest.Tests
{
    [TestFixture]
    internal class RepositoryTest
    {
        private RepositoryInMemory<Servicio> _repositoryServicio;
        private RepositoryInMemory<Vehiculo> _repositoryVehiculo;
        private MemoryContext _context;

        [SetUp]
        public void SetUp()
        {
            _context = new MemoryContext();
            _repositoryServicio = new RepositoryInMemory<Servicio>(_context);
            _repositoryVehiculo = new RepositoryInMemory<Vehiculo>(_context);
        }

        [Test]
        public void AddEntityTest()
        {
            var servicio = new Servicio();
            _repositoryServicio.Create(servicio);
            Assert.AreEqual(1, _repositoryServicio.Find(s => s.Id == servicio.Id).Count);
        }

        [Test]
        public void FindEntityTest()
        {
            var num = 10;
            _repositoryServicio.Create(new Servicio
            {
                Lugar = new Lugar
                {
                    Calle = new Calle
                    {
                        Valor = "Piruleta"
                    },
                    Numero = num
                }
            });

            var serviciosNotFound = _repositoryServicio.Find(s => s.Lugar.Calle.Valor.Equals("me lo invento"));
            var serviciosFound = _repositoryServicio.Find(s => s.Lugar.Numero == num);

            Assert.AreEqual(0, serviciosNotFound.Count);
            Assert.AreEqual(1, serviciosFound.Count);
        }

        [Test]
        public void UdpateEntityTest()
        {
            // Creamos un servicio
            var servicio = new Servicio
            {
                Descripcion = "Soy un nuevo servicio"
            };

            // Lo añadimos al repositorio
            _repositoryServicio.Create(servicio);

            // Lo modificamos
            servicio.Descripcion = "Me he actualizado";
            var updated = _repositoryServicio.Update(servicio);

            Assert.IsTrue(updated);
        }

        [Test]
        public void CheckEntitiesPositionAfterUpdatingTest()
        {
            // Creamos servicios
            var servicio1 = new Servicio
            {
                Descripcion = "Primer servicio"
            };
            var servicio2 = new Servicio
            {
                Descripcion = "Segundo servicio"
            };
            var servicio3 = new Servicio
            {
                Descripcion = "Tercer servicio"
            };
            var servicio4 = new Servicio
            {
                Descripcion = "Cuarto servicio"
            };

            // Los añadimos al repositorio
            _repositoryServicio.Create(servicio1);
            _repositoryServicio.Create(servicio2);
            _repositoryServicio.Create(servicio3);
            _repositoryServicio.Create(servicio4);

            // Actualizamos el objeto servicio2
            servicio2.Descripcion = "Segundo servicio, actualizado!";
            var result = _repositoryServicio.Update(servicio2);

            // Comprobamos si se ha actualizado
            Assert.IsTrue(result);

            // Comprobamos si la posición del objeto, dentro de la lista, ha cambiado
            Assert.AreEqual(1, _repositoryServicio.Find(s => true).IndexOf(servicio2));
            Assert.AreEqual(3, _repositoryServicio.Find(s => true).IndexOf(servicio4));
        }

        [Test]
        public void DeleteEntityTest()
        {
            var desc = "Primer servicio";
            // Creamos servicios
            var servicio = new Servicio
            {
                Descripcion = desc
            };

            // Lo añadimos al repositorio
            _repositoryServicio.Create(servicio);

            // Eliminamos el objeto del repositorio
            var result = _repositoryServicio.Delete(s => s.Descripcion.Equals(desc));

            // Comprobamos la cantidad de elementos borrados
            Assert.AreEqual(1, result);
        }

        [Test]
        public void DeleteMultipleEntitiesTest()
        {
            // Creamos servicios
            var servicio1 = new Servicio
            {
                Descripcion = "Primer servicio"
            };
            var servicio2 = new Servicio
            {
                Descripcion = "Segundo servicio"
            };

            // Lo añadimos al repositorio
            _repositoryServicio.Create(servicio1);
            _repositoryServicio.Create(servicio2);

            // Eliminamos todos los objetos del repositorio
            var result = _repositoryServicio.Delete(s => true);

            // Comprobamos la cantidad de elementos borrados
            Assert.AreEqual(2, result);
        }

        [Test]
        public void InteractWithTwoRepositories()
        {
            // Creamos dos entidades
            var vehiculo = new Vehiculo
            {
                Matricula = "3376-DFF",
                Propietario = new Persona
                {
                    Dni = "53728312S"
                }
            };

            var servicio = new Servicio
            {
                Descripcion = "Robo de piruletas."
            };

            // Los añadimos al contexto
            _repositoryVehiculo.Create(vehiculo);
            _repositoryServicio.Create(servicio);

            // Comprobamos la inserción
            Assert.AreEqual(1, _context.Vehiculos.Count);
            Assert.AreEqual(1, _context.Servicios.Count);
        }
    }
}