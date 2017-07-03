using System.Collections.ObjectModel;
using GestionServicios.Domain.Models;
using GestionServicios.Mocks.Mocks;
using GestionServicios.ViewModels.Base;

namespace GestionServicios.ViewModels
{
    internal class CreateLugarViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<Calle> _callesList;
        private Lugar _selectedLugar;

        #endregion

        #region Properties

        public ObservableCollection<Calle> CallesList
        {
            get { return _callesList; }
            set { _callesList = value; RaiseOnPropertyChanged(); }
        }

        public Lugar SelectedLugar
        {
            get { return _selectedLugar; }
            set { _selectedLugar = value; RaiseOnPropertyChanged(); }
        }

        #endregion
        public CreateLugarViewModel()
        {
            CallesList = new ObservableCollection<Calle>(CallesMock.Calles);
        }

    }
}