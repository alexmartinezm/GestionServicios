using System;
using System.Collections.Generic;
using System.Linq;
using GestionServiciosUnitTest.Mocks;
using GestionServiciosUnitTest.Models;
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
        public void CreateEntities()
        {
            var lugar = new Lugar()
            {
                Calle = new CallesMock().Calles.ElementAt(0),
                Numero = 2
            };

            var agente = new AgentesMock().Agentes.ElementAt(0);

            var vehiculosList = new List<Vehiculo>
            {
                new Vehiculo()
                {
                    Matricula = "8972-DDD",
                    Propietario = new Persona()
                    {
                        Dni = "32872317K"
                    }
                },
                new Vehiculo()
                {
                    Matricula = "6623-BBJ",
                    Propietario = new Persona()
                    {
                        Dni = "73827321S"
                    }
                }
            };

            var personasList = new List<Persona>()
            {
                new Persona()
                {
                    Dni = "54672812S"
                },
                new Persona()
                {
                    Dni = "16728316J"
                },
            };

            var servicio = new Servicio()
            {
                Fecha = DateTime.Now,
                Descripcion = "Accidente múltiple en las inmediaciones de la rotonda de Sant Pepito.",
                Lugar = lugar,
                Agente = agente,
                Vehiculos = vehiculosList,
                Personas = personasList
            };

            var serviciosList = new List<Servicio> {servicio};

            Assert.AreEqual(1, serviciosList.Count);
            Assert.AreSame(typeof(Persona), personasList.ElementAt(0).GetType());
        }
    }
}