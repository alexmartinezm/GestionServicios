using System;
using GestionServicios.Domain.Models.Base;

namespace GestionServicios.Domain.Models
{
    public class Servicio : BaseModel
    {
        #region Fields

        private DateTime _fecha;
        private string _descripcion;
        private Lugar _lugar;
        private Agente _agente;
        private Vehiculo _vehiculo;
        private Persona _persona;
        private bool _isValid;

        #endregion

        #region Properties

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; RaiseOnPropertyChanged(); }
        }

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; RaiseOnPropertyChanged(); }
        }

        public Lugar Lugar
        {
            get { return _lugar; }
            set { _lugar = value; RaiseOnPropertyChanged(); }
        }

        public Agente Agente
        {
            get { return _agente; }
            set { _agente = value; RaiseOnPropertyChanged(); }
        }

        public Vehiculo Vehiculo
        {
            get { return _vehiculo; }
            set { _vehiculo = value; RaiseOnPropertyChanged(); }
        }

        public Persona Persona
        {
            get { return _persona; }
            set { _persona = value; RaiseOnPropertyChanged(); }
        }

        public bool IsValid
        {
            get { return _isValid; }
            set { _isValid = value; RaiseOnPropertyChanged(); }
        }

        #endregion
    }
}