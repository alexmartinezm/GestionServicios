using System;
using System.Collections.Generic;
using System.Linq;
using GestionServicios.Domain.Models;

namespace GestionServicios.Mocks.Mocks
{
    public class ServiciosMock
    {
        public static IList<Servicio> Servicios = new List<Servicio>
        {
            new Servicio
            {
                Agente = AgentesMock.Agentes.ElementAt(0),
                Descripcion = "Accidente m�ltiple en la ronda.",
                Fecha = DateTime.UtcNow,
                Lugar = new Lugar
                {
                    Calle = CallesMock.Calles.ElementAt(0),
                    Numero = 3
                }
            },
            new Servicio
            {
                Agente = AgentesMock.Agentes.ElementAt(1),
                Descripcion = "Estacionamiento incorrecto",
                Fecha = DateTime.UtcNow,
                Lugar = new Lugar
                {
                    Calle = CallesMock.Calles.ElementAt(2),
                    Numero = 91
                },
                Vehiculo = new Vehiculo
                {
                    Matricula = "8872-DWD",
                    Propietario = new Persona
                    {
                        Dni = "35627213K"
                    }
                }
            }
        };
    }
}