using System;

namespace entServicio
{
    public class Servicio
    {
        public int idServicio { get; set; }
        public String nombre_servicio { get; set; }
        public int precio { get; set; }
        public String descripcion { get; set; }
        public TipoServicio idTipoServicio { get; set; }
        public EstadoServicio idEstServicio { get; set; }
    }
}
