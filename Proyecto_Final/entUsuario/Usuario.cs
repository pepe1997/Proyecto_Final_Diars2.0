using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entCliente;

namespace entUsuario
{
    public class Usuario
    {
        public int idUsuario { get; set; }
        public Cliente idCliente { get; set; }
        public DateTime fecCreacion { get; set; }
        public String userName { get; set; }
        public String password { get; set; }
        public Boolean estadoUsuario { get; set; }
        public tipoUsuario tipoUsuario { get; set; }

    }
}
