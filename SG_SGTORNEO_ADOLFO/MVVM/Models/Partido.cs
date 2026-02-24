using PropertyChanged;
using SG_SGTORNEO_ADOLFO.Abstractions;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SGTORNEO_ADOLFO.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    [Table("Partidos")]
    public class Partido : TableData
    {
        [ForeignKey(typeof(Equipo))]
        public int EquipoLocalId { get; set; }
        [ManyToOne]
        public Equipo EquipoLocal { get; set; }

        [ForeignKey(typeof(Equipo))]
        public int EquipoVisitanteId { get; set; }
        [ManyToOne]
        public Equipo EquipoVisitante { get; set; }

        public DateTime Fecha { get; set; }
        public int GolesLocal { get; set; }
        public int GolesVisitante { get; set; }
    }
}
