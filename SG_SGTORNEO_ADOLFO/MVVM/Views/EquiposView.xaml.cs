using SG_SGTORNEO_ADOLFO.MVVM.ViewModels;

namespace SG_SGTORNEO_ADOLFO.MVVM.Views;

public partial class EquiposView : ContentPage
{
	public EquiposView()
	{
		InitializeComponent();
		BindingContext = new EquiposViewModel();
    }
}