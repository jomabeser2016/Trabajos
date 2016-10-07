using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.IO;

using SAT.Libreria.JavaScript;
using SAT.Libreria.Model;
using SAT.Libreria.Web;
using SAT.Libreria.Log;

using SAT.SAF.App.Servicios.Bus;
using SAT.SAF.Model.GA.RecursosHumanos.DatosSolicitudDescansoFisico;
using SAT.SAF.Model.GA.RecursosHumanos.SolicitudDescansoFisico;
using RecursosHumanos.Models;
using SAT.SAF.Model.SE.Seguridad;
using System.Configuration;
using RecursosHumanos.App_Start;

namespace RecursosHumanos.Controllers
{
    public class ConsultaSolicitudRRHHController : Controller
    {
        // GET: ConsultaSolicitudRRHH
        [Authorize]
        public ActionResult ConsultaSolicitudRRHH(string idOpcion)
        {
            ConsultaSolicitudRRHH obj = new ConsultaSolicitudRRHH();
            
            try
            {                
                obj.slDependencia = (SelectList)JQuery.SelectListAddItem(DevolverDatosFiltroDependencia(), "Valor", "Texto", "", "Seleccione una dependencia...");
                obj.slPlanilla = (SelectList)JQuery.SelectListAddItem(DevolverDatosFiltroPlanilla(), "Valor", "Texto", "", "Seleccione una tipo de planilla...");
                obj.slCargo = (SelectList)JQuery.SelectListAddItem(DevolverDatosFiltroCargo(), "Valor", "Texto", "", "Seleccione un cargo...");
                obj.slEstado = (SelectList)JQuery.SelectListAddItem(DevolverDatosFiltroEstadoSolicitud(), "Valor", "Texto", "", "Seleccione un estado...");
                obj.slPeriodo = (SelectList)JQuery.SelectListAddItem(new List<ItemSelectList>(), "Valor", "Texto", "", "Seleccione un periodo...");
                obj.slMes = (SelectList)JQuery.SelectListAddItem(new List<ItemSelectList>(), "Valor", "Texto", "", "Seleccione un mes...");
                obj.slTrabajador = (SelectList)JQuery.SelectListAddItem(new List<ItemSelectList>(), "Valor", "Texto", "", "Ingrese un Trabajador...");

                if (String.IsNullOrEmpty(idOpcion))
                    idOpcion = Session["idOpcion"].ToString();
                else
                    Session["idOpcion"] = idOpcion;
                
                ViewBag.idOpcion = idOpcion;
            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return RedirectToAction("Error400", "Error");
            }

            return View(obj);
        }
       
        public List<ItemSelectList> DevolverDatosFiltroPlanilla()
        {
            List<ItemSelectList> lst = new List<ItemSelectList>();

            try
            {
                lst = new RecursosHumanosServicio().DevolverDatosFiltroPlanilla();
            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }

            return lst;
        }

        public List<ItemSelectList> DevolverDatosFiltroCargo()
        {
            List<ItemSelectList> lst = new List<ItemSelectList>();

            try
            {
                lst = new RecursosHumanosServicio().DevolverDatosFiltroCargo();
            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }

            return lst;
        }

        public List<ItemSelectList> DevolverDatosFiltroDependencia()
        {
            List<ItemSelectList> lst = new List<ItemSelectList>();

            try
            {
                lst = new RecursosHumanosServicio().DevolverDatosFiltroDependencia();

            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }

            return lst;
        }

        public List<ItemSelectList> DevolverDatosFiltroEstadoSolicitud()
        {
            List<ItemSelectList> lst = new List<ItemSelectList>();

            try
            {
                lst = new RecursosHumanosServicio().DevolverDatosFiltroEstadoSolicitud();
            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }

            return lst;
        }

        [HttpPost]
        [Authorize]
        [ValidateJsonAntiForgeryToken]
        public JsonResult DevolverDatosFiltroPeriodoGeneracion(string dato)
        {
            List<ItemSelectList> lst = new List<ItemSelectList>();
            JavaScriptSerializer jss = new JavaScriptSerializer();

            List<FiltroSolicitud> lstFiltroSolicitud;
            FiltroSolicitud obj = new FiltroSolicitud();

            List<ItemSelectList> lstItemSelectList = new List<ItemSelectList>();
            ItemSelectList itemSelectList = new ItemSelectList();

            try
            {
                lstFiltroSolicitud = jss.Deserialize<List<FiltroSolicitud>>(dato);
                obj = lstFiltroSolicitud[0];

                lst = new RecursosHumanosServicio().DevolverDatosFiltroPeriodoGeneracion(obj);

                itemSelectList.Valor = "";
                itemSelectList.Texto = "Seleccione un periodo...";
                lstItemSelectList.Add(itemSelectList);

                foreach (ItemSelectList item in lst)
                {
                    //ItemSelectList objItemSelectList = new ItemSelectList();
                    itemSelectList = new ItemSelectList();
                    itemSelectList.Valor = item.Valor;
                    itemSelectList.Texto = item.Texto;
                    lstItemSelectList.Add(itemSelectList);
                }

            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }

            return Json(lstItemSelectList);
        }

        [HttpPost]
        [Authorize]
        [ValidateJsonAntiForgeryToken]
        public JsonResult DevolverDatosFiltroPeriodoSolicitud(string dato)
        {
            List<ItemSelectList> lst = new List<ItemSelectList>();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<FiltroSolicitud> lstFiltroSolicitud;
            FiltroSolicitud obj = new FiltroSolicitud();
            List<ItemSelectList> lstItemSelectList = new List<ItemSelectList>();
            ItemSelectList itemSelectList = new ItemSelectList();
            try
            {
                lstFiltroSolicitud = jss.Deserialize<List<FiltroSolicitud>>(dato);
                obj = lstFiltroSolicitud[0];

                lst = new RecursosHumanosServicio().DevolverDatosFiltroPeriodoSolicitud(obj);

                itemSelectList.Valor = "";
                itemSelectList.Texto = "Seleccione uno...";
                lstItemSelectList.Add(itemSelectList);

                foreach (ItemSelectList item in lst)
                {
                    //ItemSelectList _Obj = new ItemSelectList();
                    itemSelectList = new ItemSelectList();
                    itemSelectList.Valor = item.Valor;
                    itemSelectList.Texto = item.Texto;
                    lstItemSelectList.Add(itemSelectList);
                }

            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }

            return Json(lstItemSelectList);
        }

        [HttpPost]
        [Authorize]
        [ValidateJsonAntiForgeryToken]
        public JsonResult DevolverDetalleSolicitudDescansoFisico(string dato)
        {
            FiltroSolicitud obj = new FiltroSolicitud();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<FiltroSolicitud> lstFiltroSolicitud;
            JQGrid objGrid = new JQGrid();
            try
            {
                lstFiltroSolicitud = jss.Deserialize<List<FiltroSolicitud>>(dato);
                obj = lstFiltroSolicitud[0];

                objGrid = new RecursosHumanosServicio().DevolverDetalleSolicitudDescansoFisico(obj);                
            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }

            return Json(objGrid, JsonRequestBehavior.AllowGet);
        }
        
        [HttpPost]
        [Authorize]
        [ValidateJsonAntiForgeryToken]
        public JsonResult DevolverDatosFiltroTrabajador(string dato)
        {
            List<ItemSelectList> lst = new List<ItemSelectList>();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<FiltroSolicitud> lstFiltroSolicitud;
            FiltroSolicitud obj = new FiltroSolicitud();
            List<ItemSelectList> lstItemSelectList = new List<ItemSelectList>();
            ItemSelectList cbo = new ItemSelectList();
            try
            {
                lstFiltroSolicitud = jss.Deserialize<List<FiltroSolicitud>>(dato);
                obj = lstFiltroSolicitud[0];

                lst = new RecursosHumanosServicio().DevolverDatosFiltroTrabajador(obj);

                cbo.Valor = "";
                cbo.Texto = "Ingrese el trabajador...";
                lstItemSelectList.Add(cbo);

                foreach (ItemSelectList _ItemSelectList in lst)
                {
                    ItemSelectList ItemSelectList = new ItemSelectList();
                    ItemSelectList.Valor = _ItemSelectList.Valor;
                    ItemSelectList.Texto = _ItemSelectList.Texto;
                    lstItemSelectList.Add(ItemSelectList);
                }

            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }

            return Json(lstItemSelectList);
        }

        [HttpPost]
        [Authorize]
        [ValidateJsonAntiForgeryToken]
        public JsonResult ActualizarDetalleDescansoFisico(string lst)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<DetalleSolicitudDescansoFisico> lstDetalleSolicitudDescansoFisico;
            int iResult = 0;
            try
            {
                lstDetalleSolicitudDescansoFisico = jss.Deserialize<List<DetalleSolicitudDescansoFisico>>(lst);
                new RecursosHumanosServicio().ActualizarDetalleDescansoFisico(lstDetalleSolicitudDescansoFisico);
                iResult = 1;
            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }
            return Json(iResult);
        }

        [HttpPost]
        [Authorize]
        [ValidateJsonAntiForgeryToken]
        public JsonResult DevolverHistDetalleSolicitudDescansoFisico(string dato)
        {
            FiltroSolicitud obj = new FiltroSolicitud();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<FiltroSolicitud> lstFiltroSolicitud;
            JQGrid objGrid = new JQGrid();
            try
            {
                lstFiltroSolicitud = jss.Deserialize<List<FiltroSolicitud>>(dato);
                obj = lstFiltroSolicitud[0];

                objGrid = new RecursosHumanosServicio().DevolverHistDetalleSolicitudDescansoFisico(obj);
            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }

            return Json(objGrid, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        [ValidateJsonAntiForgeryToken]
        public JsonResult ListarAccesoOpcionMenu(string idOpcion)
        {
            List<Control> lstConntrol = new List<Control>();
            FiltroUsuario fil = new FiltroUsuario();

            try
            {
                fil.SISTEMAS_SIS = ConfigurationManager.AppSettings.Get("SistemaCodigo").ToString();
                fil.CODI_MOD = ConfigurationManager.AppSettings.Get("ModuloCodigo").ToString();
                fil.CODI_OPCI_OPC = idOpcion;
                fil.USUARIO_USU = Session["UserName"].ToString();

                lstConntrol = new SeguridadServicio().ListarOpcionMenu(fil);
            }
            catch
            {
                return null;
            }

            return Json(lstConntrol, JsonRequestBehavior.AllowGet);
        }
    }
}