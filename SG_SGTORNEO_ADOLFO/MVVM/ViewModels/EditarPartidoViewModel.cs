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
    public class EditarPartidoViewModel
    {
        public ObservableCollection<Equipo> Equipos { get; set; }
        public Equipo EquipoLocalSelec { get; set; }
        public Equipo EquipoVisitanteSelec { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Today;

        public int GolesLocal { get; set; }
        public int GolesVisitante { get; set; }

        public Partido PartidoActual { get; set; }

        public ICommand GuardarCommad { get; set; }
        public ICommand CancelarCommand { get; set; }

        public EditarPartidoViewModel(Partido partido = null)
        {
            Equipos = new ObservableCollection<Equipo>(App.EquiposRepo.GetItems());

            PartidoActual = partido;
            if (PartidoActual != null)
            {
                EquipoLocalSelec = partido.EquipoLocal;
                EquipoVisitanteSelec = partido.EquipoVisitante;
                Fecha = partido.Fecha;
                GolesLocal = partido.GolesLocal;
                GolesVisitante = partido.GolesVisitante;
            }

            GuardarCommad = new Command(Guardar, PuedeGuardar);
            CancelarCommand = new Command(Cancelar);
        }

        private bool PuedeGuardar()
        {
            if (EquipoLocalSelec == null)
                return false;

            if (EquipoVisitanteSelec == null)
                return false;

            if (EquipoLocalSelec.Id == EquipoVisitanteSelec.Id)
                return false;

            if (Fecha == null)
                return false;

            if (GolesLocal < 0)
                return false;

            if (GolesVisitante < 0)
                return false;

            return true;
        }


        private async void Guardar()
        {
            if (PartidoActual == null)
            {
                PartidoActual = new Partido();
            }

            PartidoActual.EquipoLocalId = EquipoLocalSelec.Id;
            PartidoActual.EquipoVisitanteId = EquipoVisitanteSelec.Id;
            PartidoActual.Fecha = Fecha;
            PartidoActual.GolesLocal = GolesLocal;
            PartidoActual.GolesVisitante = GolesVisitante;

            App.PartidosRepo.SaveItemCascada(PartidoActual);

            await App.Current.MainPage.Navigation.PopAsync();
        }

        private void Cancelar()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }

        private async void GestionarEquipos()
        {
            await App.Current.MainPage.Navigation.PushAsync(new EquiposView());
        }
    }
}
