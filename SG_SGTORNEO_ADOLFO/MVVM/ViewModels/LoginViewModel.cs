using PropertyChanged;
using SG_SGTORNEO_ADOLFO.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SG_SGTORNEO_ADOLFO.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class LoginViewModel
    {
        private Command _loginCommand;
        public ICommand LoginCommand => _loginCommand;

        public string Usuario { get; set; } = string.Empty;
        public string Contraseña { get; set; } = string.Empty;

        public LoginViewModel()
        {
            _loginCommand = new Command(
                execute: () =>
                {
                    App.Current.MainPage.Navigation.PushAsync(new PartidosView());
                },
                canExecute: () =>
                {
                    return !string.IsNullOrEmpty(Usuario) && !string.IsNullOrEmpty(Contraseña);
                });
        }
        public void NotificarCambio()
        {
            _loginCommand.ChangeCanExecute();
        }
    }
}
