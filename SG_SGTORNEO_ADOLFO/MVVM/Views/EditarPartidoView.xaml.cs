using SG_SGTORNEO_ADOLFO.MVVM.ViewModels;

namespace SG_SGTORNEO_ADOLFO.MVVM.Views;

public partial class EditarPartidoView : ContentPage
{
	public EditarPartidoView()
	{
		InitializeComponent();
		BindingContext = new EditarPartidoViewModel();
    }
}