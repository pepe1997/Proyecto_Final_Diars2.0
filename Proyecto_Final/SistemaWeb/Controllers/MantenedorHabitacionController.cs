using entHabitacion;
using entTipoHabitacion;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SistemaWeb.Controllers
{
    public class MantenedorHabitacionController : Controller
    {
        // GET: MantenedorHabitacion
        public ActionResult ListarHabitacion()
        {
            List<Habitacion> listaHabitacion = logHabitacion.Instancia.ListarHabitacion();
            ViewBag.lista = listaHabitacion;
            return View(listaHabitacion);
        }

        [HttpGet]
        public ActionResult InsertarHabitacion()
        {

            List<TipoHabitacion> listaTipoHabitacion = logTipoHabitacion.Instancia.ListarTipoHabitacion();
            var lsTipoHabitacion = new SelectList(listaTipoHabitacion, "idTipoHabitacion", "nombTipoHabitacion");
            ViewBag.listaTipoHabitacion = lsTipoHabitacion;

            return View();
        }
        [HttpPost]
        public ActionResult InsertarHabitacion(Habitacion Cli, FormCollection frm)
        {
            try
            {

                Cli.idTipoHabitacion = new TipoHabitacion();
                Cli.idTipoHabitacion.idTipoHabitacion = Convert.ToInt32(frm["cboTipoHabitacion"]);

                Boolean inserta = logHabitacion.Instancia.InsertarHabitacion(Cli);
                if (inserta)
                {
                    return RedirectToAction("ListarHabitacion");
                }
                else
                {
                    return View(Cli);
                }
            }

            catch (ApplicationException ex)
            {
                return RedirectToAction("InsertarHabitacion", new { mesjExceptio = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult EditarHabitacion(int idHabitacion)
        {

            Habitacion Cli = new Habitacion();
            Cli = logHabitacion.Instancia.BuscarHabitacion(idHabitacion);

            List<TipoHabitacion> listaTipoHabitacion = logTipoHabitacion.Instancia.ListarTipoHabitacion();
            var lsTipoHabitacion = new SelectList(listaTipoHabitacion, "idTipCliente", "nombTipoHabitacion", Cli.idTipoHabitacion.idTipoHabitacion);
            ViewBag.listaTipoHabitacion = lsTipoHabitacion;

            return View(Cli);
        }
        [HttpPost]
        public ActionResult EditarHabitacion(Habitacion Cli, FormCollection frm)
        {


            Cli.idTipoHabitacion = new TipoHabitacion();
            Cli.idTipoHabitacion.idTipoHabitacion = Convert.ToInt32(frm["cboTipoHabitacion"]);

            try
            {
                Boolean edita = logHabitacion.Instancia.EditaHabitacion(Cli);
                if (edita)
                {
                    return RedirectToAction("ListarHabitacion");
                }
                else
                {
                    return View(Cli);
                }
            }

            catch (ApplicationException ex)
            {
                return RedirectToAction("EditarHabitacion", new { mesjExceptio = ex.Message });
            }

        }

        public ActionResult CambiarEstadoHabitacion(int idHabitacion)
        {

            Habitacion Cli = new Habitacion();
            Cli = logHabitacion.Instancia.BuscarHabitacion(idHabitacion);
            return View(Cli);
        }
        [HttpPost]
        public ActionResult EliminarHabitacion(Habitacion Cli)
        {

            try
            {
                Boolean elimina = logHabitacion.Instancia.CambiarEstado(Cli);
                if (elimina)
                {
                    return RedirectToAction("ListarHabitacion");
                }
                else
                {
                    return View(Cli);
                }
            }

            catch (ApplicationException ex)
            {
                return RedirectToAction("EliminarHabitacion", new { mesjExceptio = ex.Message });
            }

        }
    }
}