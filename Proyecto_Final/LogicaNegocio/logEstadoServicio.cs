using AccesoDatos.DatServicio;
using entServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class logEstadoServicio
    {
        #region singleton
        private static readonly logEstadoServicio UnicaInstancia = new logEstadoServicio();
        public static logEstadoServicio Instancia
        {
            get
            {
                return logEstadoServicio.UnicaInstancia;
            }

        }
        #endregion singleton

        #region metodo
        public List<EstadoServicio> ListarEstadoServicio()
        {
            try
            {
                List<EstadoServicio> lista = datEstadoServicio.Instancia.ListarEstadoServicio();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion metodo
    }
}
