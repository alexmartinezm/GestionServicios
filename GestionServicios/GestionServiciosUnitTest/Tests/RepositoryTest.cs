using System.Collections.Generic;
using GestionServicios.Core.Repositories;
using GestionServicios.Domain.Models;
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
            _repositoryBase = new RepositoryInMemory<Servicio>(new MemoryContext());
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
            var updated = _repositoryBase.Update(servicio);

            Assert.IsTrue(updated);
        }

        [Test]
        public void CheckEntitiesPositionAfterUpdatingTest()
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
            var result = _repositoryBase.Update(servicio2);

            // Comprobamos si se ha actualizado
            Assert.IsTrue(result);

            // Comprobamos si la posición del objeto, dentro de la lista, ha cambiado
            Assert.AreEqual(1, _repositoryBase.Find(s => true).IndexOf(servicio2));
            Assert.AreEqual(3, _repositoryBase.Find(s => true).IndexOf(servicio4));
        }

        [Test]
        public void DeleteEntityTest()
        {
            var desc = "Primer servicio";
            // Creamos servicios
            var servicio = new Servicio()
            {
                Descripcion = desc
            };

            // Lo añadimos al repositorio
            _repositoryBase.Create(servicio);

            // Eliminamos el objeto del repositorio
            var result = _repositoryBase.Delete(s => s.Descripcion.Equals(desc));

            // Comprobamos la cantidad de elementos borrados
            Assert.AreEqual(1, result);
        }

        [Test]
        public void DeleteMultipleEntitiesTest()
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

            // Lo añadimos al repositorio
            _repositoryBase.Create(servicio1);
            _repositoryBase.Create(servicio2);

            // Eliminamos todos los objetos del repositorio
            var result = _repositoryBase.Delete(s => true);

            // Comprobamos la cantidad de elementos borrados
            Assert.AreEqual(2, result);
        }
    }
}