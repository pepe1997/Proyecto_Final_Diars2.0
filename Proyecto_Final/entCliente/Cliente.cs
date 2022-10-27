using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entCiudad;
using entEstadoCliente;
using entTipoCliente;

namespace entCliente
{
    public class Cliente
    {
        public int idCliente { get; set; }
        public string nombCliente { get; set; }
        public string apelCliente { get; set; }
        public string direcCliente { get; set; }
        public string celular { get; set; }
        public string dni { get; set; }
        public DateTime fecRegCliente { get; set; }
        public TipoCliente idTipoCliente { get; set; }
        public EstadoCliente idEstCliente { get; set; }
        public Ciudad idCiudad { get; set; }
    }
}
