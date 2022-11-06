using entHabitacion;
using entTipoHabitacion;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using entEstadoHabitacion;

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

            List<EstadoHabitacion> listaEstadoHabitacion = logEstadoHabitacion.Instancia.ListarEstHabitacion();
            var lsEstadoHabitacion = new SelectList(listaEstadoHabitacion, "idEstHabitacion", "desEsTHabitacion");
            ViewBag.listaEstadoHabitacion = lsEstadoHabitacion;

            return View();
        }
        [HttpPost]
        public ActionResult InsertarHabitacion(Habitacion Cli, FormCollection frm)
        {
            try
            {

                Cli.idTipoHabitacion = new TipoHabitacion();
                Cli.idTipoHabitacion.idTipoHabitacion = Convert.ToInt32(frm["cboTipoHabitacion"]);

                Cli.idEstHabitacion = new EstadoHabitacion();
                Cli.idEstHabitacion.idEstHabitacion = Convert.ToInt32(frm["cboEstadoHabitacion"]);

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
            var lsTipoHabitacion = new SelectList(listaTipoHabitacion, "idTipoHabitacion", "nombTipoHabitacion", Cli.idTipoHabitacion.idTipoHabitacion);
            ViewBag.listaTipoHabitacion = lsTipoHabitacion;

            List<EstadoHabitacion> listaEstadoHabitacion = logEstadoHabitacion.Instancia.ListarEstHabitacion();
            var lsEstadoHabitacion = new SelectList(listaEstadoHabitacion, "idEstHabitacion", "desEsTHabitacion", Cli.idEstHabitacion.idEstHabitacion);
            ViewBag.listaEstadoHabitacion = lsEstadoHabitacion;

            return View(Cli);
        }
        [HttpPost]
        public ActionResult EditarHabitacion(Habitacion Cli, FormCollection frm)
        {


            Cli.idTipoHabitacion = new TipoHabitacion();
            Cli.idTipoHabitacion.idTipoHabitacion = Convert.ToInt32(frm["cboTipoHabitacion"]);

            Cli.idEstHabitacion = new EstadoHabitacion();
            Cli.idEstHabitacion.idEstHabitacion = Convert.ToInt32(frm["cboEstadoHabitacion"]);

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
        public ActionResult CambiarEstadoHabitacion(Habitacion Cli)
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
                return RedirectToAction("CambiarEstadoHabitacion", new { mesjExceptio = ex.Message });
            }

        }
    }
}