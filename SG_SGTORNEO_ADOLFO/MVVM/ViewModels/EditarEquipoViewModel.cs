using PropertyChanged;
using SG_SGTORNEO_ADOLFO.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SG_SGTORNEO_ADOLFO.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class EditarEquipoViewModel
    {
        public string Nombre { get; set; }
        public byte[] Escudo { get; set; }
        public Equipo EquipoActual { get; set; }

        public ICommand GuardarCommand { get; set; }
        public ICommand CancelarCommand { get; set; }
        public ICommand SeleccionarImagenCommand { get; set; }

        public EditarEquipoViewModel(Equipo equipo = null)
        {
            EquipoActual = equipo;
            if (equipo != null)
            {
                Nombre = equipo.Nombre;
                Escudo = equipo.Escudo;
            }

            GuardarCommand = new Command(Guardar, PuedeGuardar);
            CancelarCommand = new Command(Cancelar);
            SeleccionarImagenCommand = new Command(SeleccionarImagen);
        }

        private bool PuedeGuardar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                return false;

            return true;
        }

        public void NotificarCambio()
        {
            ((Command)GuardarCommand).ChangeCanExecute();
        }

        private async void Guardar()
        {
            if (EquipoActual == null)
            {
                EquipoActual = new Equipo();
            }
            EquipoActual.Nombre = Nombre;
            EquipoActual.Escudo = Escudo;

            App.EquiposRepo.SaveItem(EquipoActual);

            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async void Cancelar()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async void SeleccionarImagen()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Seleccionar imagen como escudo"
            });
            if (result != null)
            {
                using var stream = await result.OpenReadAsync();
                using var memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);
                Escudo = memoryStream.ToArray();
            }
        }
    }
}
