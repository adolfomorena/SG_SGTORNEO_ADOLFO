using SG_SGTORNEO_ADOLFO.MVVM.Models;
using SG_SGTORNEO_ADOLFO.MVVM.Views;
using SG_SGTORNEO_ADOLFO.Repositories;

namespace SG_SGTORNEO_ADOLFO
{
    public partial class App : Application
    {
        public static BaseRepository<Equipo> EquiposRepo { get; private set; }
        public static BaseRepository<Partido> PartidosRepo { get; private set; }
        public App(
            BaseRepository<Equipo> equipoRepo,
            BaseRepository<Partido> partidoRepo)
        {
            InitializeComponent();

            EquiposRepo = equipoRepo;
            PartidosRepo = partidoRepo;

            MainPage = new NavigationPage(new LoginView());
        }

    }
}