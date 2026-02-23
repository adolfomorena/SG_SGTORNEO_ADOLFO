using SG_SGTORNEO_ADOLFO.MVVM.Views;

namespace SG_SGTORNEO_ADOLFO
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginView());
        }

    }
}