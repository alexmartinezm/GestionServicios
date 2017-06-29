﻿using System;
using System.Windows.Input;
using GestionServicios.Domain.MemoryContext;
using GestionServicios.Domain.Models;
using GestionServicios.Validators;

namespace GestionServicios.Commands
{
    public class SaveServicioCommand : ICommand
    {
        private readonly MemoryContext _context;

        public SaveServicioCommand(MemoryContext context)
        {
            _context = context;
        }

        #region ICommand implementation

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // Obtenemos el servicio con los datos introducidos
            var servicio = (Servicio)parameter;
            // Creamos el validator que aplicará las reglas definidas en el constructor
            var validator = new ServicioValidator();
            // Obtenemos el resultado del validator
            var result = validator.Validate(servicio);

            // Comprobamos si el vehículo es válido, en caso contrario mostramos el error
            // y enviamos un mensaje con el vehículo y el mensaje a mostrar
            //if (result.IsValid)
            //{
            //    MessagingCenter.Send(servicio, Subscribe.DisplayAlertSuccessful, GestorResources.VehiculoAnadido);
            //    _repositoryVehicle.Add(servicio);
            //    DependencyService.Get<IVibratorService>().Vibrate(1000);
            //}
            //else
            //{
            //    MessagingCenter.Send(servicio, Subscribe.DisplayAlertError, result.Errors.First().ErrorMessage);
            //}
        }

        public event EventHandler CanExecuteChanged;

        #endregion
    }
}
