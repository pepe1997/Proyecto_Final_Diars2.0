using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entHabitacion;
using entCliente;
using entEstadoReserva;

namespace entReserva
{
    public class Reserva
    {
        public int idRserva { get; set; }
        public string fecIngReseva { get; set; }
        public int numPerReserva { get; set; }
        public string fecSalReserva { get; set; }
        public EstadoReserva idEstRserva { get; set; }
        public Cliente idCliente { get; set; }
        public Habitacion idHabitacion { get; set; }
    }
}
