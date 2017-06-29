﻿using GestionServicios.Domain.MemoryContext;
using GestionServicios.Views.Base;
using Xamarin.Forms;

namespace GestionServicios.Views
{
    internal class CreateServicioView : ContentPage, IBaseView
    {
        public CreateServicioView(MemoryContext context)
        {
            InitControls();
            BuildView();
            BindingContext = new CreateServicioViewModel(context);
        }

        #region IBaseView implementation

        public void InitControls()
        {

        }

        public void BuildView()
        {
            Title = "Servicio";
        }

        #endregion
    }
}