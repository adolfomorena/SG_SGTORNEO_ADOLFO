using SG_SGTORNEO_ADOLFO.MVVM.ViewModels;

namespace SG_SGTORNEO_ADOLFO.MVVM.Views;

public partial class EquiposView : ContentPage
{
	public EquiposView()
	{
		InitializeComponent();
		BindingContext = new EquiposViewModel();
    }

	protected override void OnAppearing()
	{
		base.OnAppearing();

		var vm = (EquiposViewModel)BindingContext;
		vm.CargarEquipos();
    }
}