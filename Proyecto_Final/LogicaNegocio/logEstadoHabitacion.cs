using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entEstadoHabitacion;
using AccesoDatos.DaoEntidades;
namespace LogicaNegocio
{
    public class logEstadoHabitacion
    {
        #region singleton
        private static readonly logEstadoHabitacion UnicaInstancia = new logEstadoHabitacion();
        public static logEstadoHabitacion Instancia
        {
            get
            {
                return logEstadoHabitacion.UnicaInstancia;
            }
        }

        #endregion singleton
        #region metodos
        public List<EstadoHabitacion> ListarEstHabitacion()
        {
            try
            {
                List<EstadoHabitacion> lista = datEstadoHabitacion.Instancia.ListarEstadoHabitacion();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public Boolean InsertarEstHabitacion(EstadoHabitacion Ser)
        {
            try
            {
                return datEstadoHabitacion.Instancia.InsertarEstadoHabitacion(Ser);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EditaEstadoHabitacion(EstadoHabitacion Ser)
        {
            try
            {
                return datEstadoHabitacion.Instancia.EditarEstadoHabitacion(Ser);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public EstadoHabitacion BuscarEstadoHabitacion(int idEstHabitacion)
        {
            try
            {
                return datEstadoHabitacion.Instancia.BuscarEstadoHabitacion(idEstHabitacion);
            }
            catch (Exception e)
            { throw e; }

        }
        #endregion metodos
    }
}
