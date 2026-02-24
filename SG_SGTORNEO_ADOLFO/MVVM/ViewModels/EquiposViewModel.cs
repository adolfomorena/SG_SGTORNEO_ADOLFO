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

        private async void NuevoEquipo()
        {
            await App.Current.MainPage.Navigation.PushAsync(new EditarEquipoView());
        }

        private async void EditarEquipo(Equipo equipo)
        {
            await App.Current.MainPage.Navigation.PushAsync(new EditarEquipoView(equipo));
        }

        private async void EliminarEquipo(Equipo equipo)
        {
            //comprueba si el equipo aparece en algun partidoo
            var partidos = App.PartidosRepo.GetItems();

            bool tienePartidos = partidos.Any(p => p.EquipoLocalId == equipo.Id || p.EquipoVisitanteId == equipo.Id);
            if (tienePartidos)
            {
                await App.Current.MainPage.DisplayAlert("Error",
                    "No se puede eliminar el equipo porque tiene partidos asociados.",
                    "OK");
                return;
            }

            App.EquiposRepo.DeleteItem(equipo);
            Equipos.Remove(equipo);
        }

        public void CargarEquipos()
        {
            var equipos = App.EquiposRepo.GetItems();
            Equipos.Clear();
            foreach (var e in equipos)
            {
                Equipos.Add(e);
            }
        }
    }
}
