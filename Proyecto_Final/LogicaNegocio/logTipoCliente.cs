using AccesoDatos.DaoEntidades;
using entTipoCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class logTipoCliente
    {
        #region singleton
        private static readonly logTipoCliente UnicaInstancia = new logTipoCliente();
        public static logTipoCliente Instancia
        {
            get
            {
                return logTipoCliente.UnicaInstancia;
            }
        }

        #endregion singleton
        #region metodos
        public List<TipoCliente> ListarTipoCliente()
        {
            try
            {
                List<TipoCliente> lista = datTipoCliente.Instancia.ListarTipoCliente();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public Boolean InsertarTipCliente(TipoCliente Ser)
        {
            try
            {
                return datTipoCliente.Instancia.InsertarTipoCliente(Ser);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EditaTipoCliente(TipoCliente Ser)
        {
            try
            {
                return datTipoCliente.Instancia.EditarTipoCliente(Ser);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public TipoCliente BuscarTipoCliente(int idTipoCliente)
        {
            try
            {
                return datTipoCliente.Instancia.BuscarTipoCliente(idTipoCliente);
            }
            catch (Exception e)
            { throw e; }

        }
        #endregion metodos
    }

}

