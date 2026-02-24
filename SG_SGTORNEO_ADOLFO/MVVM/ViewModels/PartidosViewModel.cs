using PropertyChanged;
using SG_SGTORNEO_ADOLFO.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SGTORNEO_ADOLFO.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class PartidosViewModel
    {
        public ObservableCollection<Partido> Partidos { get; set; } = new();
    }
}
