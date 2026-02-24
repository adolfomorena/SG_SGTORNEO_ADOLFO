using SG_SGTORNEO_ADOLFO.MVVM.ViewModels;

namespace SG_SGTORNEO_ADOLFO.MVVM.Views;

public partial class PartidosView : ContentPage
{
	public PartidosView()
	{
		InitializeComponent();
		BindingContext = new PartidosViewModel();
    }

	protected override void OnAppearing()
	{
		base.OnAppearing();

		var vm = (PartidosViewModel)BindingContext;
		vm.CargarPartidos();
    }
}