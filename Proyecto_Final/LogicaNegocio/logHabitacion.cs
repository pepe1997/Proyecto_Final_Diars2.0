using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entHabitacion;
using AccesoDatos.DaoEntidades;

namespace LogicaNegocio
{
    public class logHabitacion
    {
        #region singleton
        private static readonly logHabitacion UnicaInstancia = new logHabitacion();
        public static logHabitacion Instancia
        {
            get
            {
                return logHabitacion.UnicaInstancia;
            }
        }

        #endregion singleton

        #region metodos
        public List<Habitacion> ListarHabitacion()
        {
            try
            {
                List<Habitacion> listaHabitacion = datHabitacion.Instancia.Listarhabitacion();
                return listaHabitacion;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public Boolean InsertarHabitacion(Habitacion Cli)
        {
            try
            {
                return datHabitacion.Instancia.InsertarHabitacion(Cli);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EditaHabitacion(Habitacion Clie)
        {
            try
            {
                return datHabitacion.Instancia.EditarHabitacion(Clie);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Habitacion BuscarHabitacion(int idHabitacion)
        {
            try
            {
                return datHabitacion.Instancia.BuscarHabitacion(idHabitacion);
            }
            catch (Exception e)
            { throw e; }

        }
        public Boolean CambiarEstado(Habitacion c)
        {
            try
            {
                return datHabitacion.Instancia.CambiarEstDadoHabitacion(c);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion metodos
    }
}
