using PropertyChanged;
using SG_SGTORNEO_ADOLFO.MVVM.Models;
using SG_SGTORNEO_ADOLFO.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SG_SGTORNEO_ADOLFO.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class EquiposViewModel
    {
        public ObservableCollection<Equipo> Equipos { get; set; }

        public ICommand NuevoEquipoCommand { get; set; }
        public ICommand EditarEquipoCommand { get; set; }
        public ICommand EliminarEquipoCommand { get; set; }

        public EquiposViewModel()
        {
            Equipos = new ObservableCollection<Equipo>(App.EquiposRepo.GetItems());

            NuevoEquipoCommand = new Command(NuevoEquipo);
            EditarEquipoCommand = new Command<Equipo>(EditarEquipo);
            EliminarEquipoCommand = new Command<Equipo>(EliminarEquipo);
        }

        private void NuevoEquipo()
        {
            App.Current.MainPage.Navigation.PushAsync(new EditarEquipoView());
        }

        private void EditarEquipo(Equipo equipo)
        {
            App.Current.MainPage.Navigation.PushAsync(new EditarEquipoView(equipo));
        }

        private void EliminarEquipo(Equipo equipo)
        {
            App.EquiposRepo.DeleteItem(equipo);
            Equipos.Remove(equipo);
        }
    }
}
