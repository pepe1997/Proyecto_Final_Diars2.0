using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entTipoHabitacion;
using entEstadoHabitacion;

namespace entHabitacion
{
    public class Habitacion
    {
        public int idHabitacion { get; set; }
        public int numHabitacion { get; set; }
        public int numPisoHabitacion { get; set; }
        public TipoHabitacion idTipoHabitacion { get; set; }
        public EstadoHabitacion idEstHabitacion { get; set; }
        

    }
}
