using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entTipoHabitacion;
using AccesoDatos.DaoEntidades;

namespace LogicaNegocio
{
    public class logTipoHabitacion
    {
        #region singleton
        private static readonly logTipoHabitacion UnicaInstancia = new logTipoHabitacion();
        public static logTipoHabitacion Instancia
        {
            get
            {
                return logTipoHabitacion.UnicaInstancia;
            }
        }

        #endregion singleton
        #region metodos
        public List<TipoHabitacion> ListarTipoHabitacion()
        {
            try
            {
                List<TipoHabitacion> lista = datTipoHabitacion.Instancia.ListarTipoHabitacion();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public Boolean InsertarTipHabitacion(TipoHabitacion Ser)
        {
            try
            {
                return datTipoHabitacion.Instancia.InsertarTipoHabitaion(Ser);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EditaTipoHabitacion(TipoHabitacion Ser)
        {
            try
            {
                return datTipoHabitacion.Instancia.EditarTipoHabitacion(Ser);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public TipoHabitacion BuscarTipoHabitacion(int idTipoHabitacion)
        {
            try
            {
                return datTipoHabitacion.Instancia.BuscarTipoHabitacion(idTipoHabitacion);
            }
            catch (Exception e)
            { throw e; }

        }
        #endregion metodos
    }
}
