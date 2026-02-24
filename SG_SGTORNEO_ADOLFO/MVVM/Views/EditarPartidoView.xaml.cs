using SG_SGTORNEO_ADOLFO.MVVM.Models;
using SG_SGTORNEO_ADOLFO.MVVM.ViewModels;

namespace SG_SGTORNEO_ADOLFO.MVVM.Views;

public partial class EditarPartidoView : ContentPage
{
	public EditarPartidoView(Partido partido = null)
	{
		InitializeComponent();
		BindingContext = new EditarPartidoViewModel(partido);
    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        ((EditarPartidoViewModel)BindingContext).NotificarCambio();
    }

    private void Picker_SelectedIndexChanged_1(object sender, EventArgs e)
    {

    }

    private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        ((EditarPartidoViewModel)BindingContext).NotificarCambio();
    }
}