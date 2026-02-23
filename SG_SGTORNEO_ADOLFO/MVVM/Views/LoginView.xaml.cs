using SG_SGTORNEO_ADOLFO.MVVM.ViewModels;

namespace SG_SGTORNEO_ADOLFO.MVVM.Views;

public partial class LoginView : ContentPage
{
	public LoginView()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel();
    }
	private void Entry_TextChanged(object sender, TextChangedEventArgs e)
	{
		((LoginViewModel)BindingContext).NotificarCambio();
    }
}