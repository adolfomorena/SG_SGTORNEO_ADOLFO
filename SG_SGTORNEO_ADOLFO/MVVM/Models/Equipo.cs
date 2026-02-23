using PropertyChanged;
using SG_SGTORNEO_ADOLFO.Abstractions;
using SQLiteNetExtensions.Attributes;
using System.Collections.ObjectModel;
using SQLite;


namespace SG_SGTORNEO_ADOLFO.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    [Table("Equipos")]
    public class Equipo: TableData
    {
        [Unique]
        public string Nombre { get; set; }
        public byte[] Escudo { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Partido> PartidosLocal { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public ObservableCollection<Partido> PartidosVisitante { get; set; }

    }
}
