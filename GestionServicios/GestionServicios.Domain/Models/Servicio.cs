using System;
using System.Collections.Generic;
using GestionServicios.Domain.Models.Base;

namespace GestionServicios.Domain.Models
{
    public class Servicio : EntityBase
    {
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public Lugar Lugar { get; set; }
        public Agente Agente { get; set; }
        public IList<Vehiculo> Vehiculos { get; set; }
        public IList<Persona> Personas { get; set; }
    }
}