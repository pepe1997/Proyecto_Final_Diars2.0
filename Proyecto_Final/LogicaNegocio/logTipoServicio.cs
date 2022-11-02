using AccesoDatos.DatServicio;
using entServicio;
using System;
using System.Collections.Generic;

namespace LogicaNegocio
{
    public class logTipoServicio
    {
        #region singleton
        private static readonly logTipoServicio UnicaInstancia = new logTipoServicio();
        public static logTipoServicio Instancia
        {
            get
            {
                return logTipoServicio.UnicaInstancia;
            }

        }
        #endregion singleton
        #region metodo
        public List<TipoServicio> ListarTipoServicio()
        {
            try
            {
                List<TipoServicio> lista = datTipoServicio.Instancia.ListarTipoServicio();
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
