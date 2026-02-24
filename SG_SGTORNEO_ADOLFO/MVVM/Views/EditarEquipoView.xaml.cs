using SG_SGTORNEO_ADOLFO.MVVM.Models;
using SG_SGTORNEO_ADOLFO.MVVM.ViewModels;

namespace SG_SGTORNEO_ADOLFO.MVVM.Views;

public partial class EditarEquipoView : ContentPage
{
	public EditarEquipoView(Equipo equipo = null)
	{
		InitializeComponent();
		BindingContext = new EditarEquipoViewModel(equipo);
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        ((EditarEquipoViewModel)BindingContext).NotificarCambio();
    }
}