using System;
using System.Collections.ObjectModel;
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
        private ObservableCollection<Vehiculo> _vehiculos;
        private ObservableCollection<Persona> _personas;
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

        public ObservableCollection<Vehiculo> Vehiculos
        {
            get { return _vehiculos; }
            set { _vehiculos = value; RaiseOnPropertyChanged(); }
        }

        public ObservableCollection<Persona> Personas
        {
            get { return _personas; }
            set { _personas = value; RaiseOnPropertyChanged(); }
        }

        public bool IsValid
        {
            get { return _isValid; }
            set { _isValid = value; RaiseOnPropertyChanged(); }
        }

        #endregion
    }
}