using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GestionServicios.Domain.Models;
using GestionServicios.Mocks.Mocks;
using NUnit.Framework;

namespace GestionServiciosUnitTest.Tests
{
    [TestFixture]
    public class DomainTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateEntitiesTest()
        {
            var callesMocked = CallesMock.Calles;
            var agentesMocked = AgentesMock.Agentes;
            var max = callesMocked.Count + agentesMocked.Count;

            var lugar = new Lugar
            {
                Calle = callesMocked.ElementAt(0),
                Numero = 2
            };
            max++;

            var agente = agentesMocked.ElementAt(0);
            max++;

            var vehiculosList = new ObservableCollection<Vehiculo>
            {
                new Vehiculo
                {
                    Matricula = "8972-DDD",
                    Propietario = new Persona
                    {
                        Dni = "32872317K"
                    }
                },
                new Vehiculo
                {
                    Matricula = "6623-BBJ",
                    Propietario = new Persona
                    {
                        Dni = "73827321S"
                    }
                }
            };
            max += vehiculosList.Count;

            var personasList = new ObservableCollection<Persona>
            {
                new Persona
                {
                    Dni = "54672812S"
                },
                new Persona
                {
                    Dni = "16728316J"
                }
            };
            max += personasList.Count;

            var servicio = new Servicio
            {
                Fecha = DateTime.Now,
                Descripcion = "Accidente múltiple en las inmediaciones de la rotonda de Sant Pepito.",
                Lugar = lugar,
                Agente = agente,
                //Vehiculo = vehiculosList,
                //Persona = personasList
            };
            max++;

            var serviciosList = new List<Servicio> {servicio};

            // Comprobación de instancias
            Assert.AreEqual(1, serviciosList.Count);
            Assert.AreSame(typeof(Persona), personasList.ElementAt(0).GetType());

            // Comprobación de IDs correctas
            Assert.AreEqual(3, callesMocked.Last().Id);
            Assert.AreEqual(max, servicio.Id);
        }
    }
}