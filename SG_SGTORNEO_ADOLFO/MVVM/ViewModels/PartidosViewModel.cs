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
    public class PartidosViewModel
    {
        public ObservableCollection<Partido> Partidos { get; set; } = new();
        private int cargados = 0;
        private const int cantidad = 8;

        public ICommand CargarMasCommand { get; set; }
        public ICommand NuevoPartidoCommand { get; set; }
        public ICommand EditarPartidoCommand { get; set; }

        public PartidosViewModel()
        {
            CargarMasCommand = new Command(CargarMas);
            NuevoPartidoCommand = new Command(NuevoPartido);
            EditarPartidoCommand = new Command<Partido>(EditarPartido);

            //cargamos los 8 primeros
            CargarMas();
        }

        private void CargarMas()
        {
            var partidos = App.PartidosRepo.GetItems().Skip(cargados).Take(cantidad).ToList();

            foreach (var p in partidos)
            {
                Partidos.Add(p);
                cargados += cantidad;
            }
        }
        private void NuevoPartido()
        {
            App.Current.MainPage.Navigation.PushAsync(new EditarPartidoView());
        }
        private void EditarPartido(Partido partido)
        {
            App.Current.MainPage.Navigation.PushAsync(new EditarPartidoView(partido));
        }
    }
}