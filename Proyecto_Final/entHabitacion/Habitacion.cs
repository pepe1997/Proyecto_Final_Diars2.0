using entEstadoHabitacion;
using entTipoHabitacion;

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
