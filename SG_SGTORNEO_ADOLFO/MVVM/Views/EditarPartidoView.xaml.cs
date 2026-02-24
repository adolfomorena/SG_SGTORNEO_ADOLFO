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
}