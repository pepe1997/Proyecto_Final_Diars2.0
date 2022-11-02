using entServicio;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SistemaWeb.Controllers
{
    public class MantenedorServicioController : Controller
    {
        // GET: MantenedorServicio
        public ActionResult ListarServicio()
        {
            List<Servicio> lista = logServicio.Instancia.ListarServicio();
            ViewBag.lista = lista;
            return View(lista);
        }

        [HttpGet]
        public ActionResult InsertarServicio()
        {
            List<TipoServicio> listaTipoServicio = logTipoServicio.Instancia.ListarTipoServicio();
            var lsTipoServicio = new SelectList(listaTipoServicio, "idTipoServicio", "nombreTipo");
            ViewBag.listaTipoServicio = lsTipoServicio;

            List<EstadoServicio> listaEstadoServicio = logEstadoServicio.Instancia.ListarEstadoServicio();
            var lsEstadoServicio = new SelectList(listaEstadoServicio, "idEstServicio", "nombreEst");
            ViewBag.listaEstadoServicio = lsEstadoServicio;
            return View();
        }
        [HttpPost]
        public ActionResult InsertarServicio(Servicio Ser, FormCollection frm)
        {
            try
            {
                Ser.idTipoServicio = new TipoServicio();
                Ser.idTipoServicio.idTipoServicio = Convert.ToInt32(frm["cboTipoServicio"]);
                Ser.idEstServicio = new EstadoServicio();
                Ser.idEstServicio.idEstServicio = Convert.ToInt32(frm["cboEstadoServicio"]);

                Boolean inserta = logServicio.Instancia.InsertarServicio(Ser);
                if (inserta)
                {
                    return RedirectToAction("ListarServicio");
                }
                else
                {
                    return View(Ser);
                }
            }

            catch (ApplicationException ex)
            {
                return RedirectToAction("InsertarServicio", new { mesjExceptio = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult EditarServicio(int idServicio)
        {

            Servicio Ser = new Servicio();
            Ser = logServicio.Instancia.BuscarServicio(idServicio);

            List<TipoServicio> listaTipoServicio = logTipoServicio.Instancia.ListarTipoServicio();
            var lsTipoServicio = new SelectList(listaTipoServicio, "idTipoServicio", "nombreTipo", Ser.idTipoServicio.idTipoServicio);
            ViewBag.listaTipoServicio = lsTipoServicio;
            List<EstadoServicio> listaEstadoServicio = logEstadoServicio.Instancia.ListarEstadoServicio();
            var lsEstadoServicio = new SelectList(listaEstadoServicio, "idEstServicio", "nombreEst", Ser.idEstServicio.idEstServicio);
            ViewBag.listaEstadoServicio = lsEstadoServicio;

            return View(Ser);
        }
        [HttpPost]
        public ActionResult EditarServicio(Servicio Ser, FormCollection frm)
        {
            Ser.idTipoServicio = new TipoServicio();
            Ser.idTipoServicio.idTipoServicio = Convert.ToInt32(frm["cboTipoServicio"]);

            Ser.idEstServicio = new EstadoServicio();
            Ser.idEstServicio.idEstServicio = Convert.ToInt32(frm["cboEstadoServicio"]);

            try
            {
                Boolean edita = logServicio.Instancia.EditaServicio(Ser);
                if (edita)
                {
                    return RedirectToAction("ListarServicio");
                }
                else
                {
                    return View(Ser);
                }
            }

            catch (ApplicationException ex)
            {
                return RedirectToAction("EditarServicio", new { mesjExceptio = ex.Message });
            }

        }

        public ActionResult EliminarServicio(int idServicio)
        {

            Servicio Ser = new Servicio();
            Ser = logServicio.Instancia.BuscarServicio(idServicio);
            return View(Ser);
        }
        [HttpPost]
        public ActionResult EliminarServicio(Servicio Ser)
        {

            try
            {
                Boolean elimina = logServicio.Instancia.EliminarServicio(Ser);
                if (elimina)
                {
                    return RedirectToAction("ListarServicio");
                }
                else
                {
                    return View(Ser);
                }
            }

            catch (ApplicationException ex)
            {
                return RedirectToAction("EliminarServicio", new { mesjExceptio = ex.Message });
            }

        }
    }
}