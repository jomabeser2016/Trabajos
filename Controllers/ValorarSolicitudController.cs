using RecursosHumanos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

using SAT.Libreria.JavaScript;
using SAT.Libreria.Model;
using SAT.Libreria.Web;
using SAT.SAF.App.Servicios.Bus;
using SAT.SAF.Model.GA.RecursosHumanos.DatosSolicitudDescansoFisico;
using SAT.SAF.Model.GA.RecursosHumanos.SolicitudDescansoFisico;
using System.IO;
using SAT.SAF.Model.GA.RecursosHumanos.Consultas;
using SAT.Libreria.Log;


namespace RecursosHumanos.Controllers
{
    public class ValorarSolicitudController : Controller
    {
        // GET: ValorarSolicitud
        public ActionResult ValorarSolicitud()
        {
            ValorarSolicitud obj = new ValorarSolicitud();

            try
            {
                obj.slDependencia = (SelectList)JQuery.SelectListAddItem(DevolverDatosFiltroDependencia(), "Valor", "Texto", "", "Seleccione uno...");
                obj.slPlanilla = (SelectList)JQuery.SelectListAddItem(DevolverDatosFiltroPlanilla(), "Valor", "Texto", "", "Seleccione uno...");
                obj.slCargo = (SelectList)JQuery.SelectListAddItem(DevolverDatosFiltroCargo(), "Valor", "Texto", "", "Seleccione uno...");
                obj.slPeriodo = (SelectList)JQuery.SelectListAddItem(new List<ItemSelectList>(), "Valor", "Texto", "", "Seleccione uno...");
                obj.slMes = (SelectList)JQuery.SelectListAddItem(new List<ItemSelectList>(), "Valor", "Texto", "", "Seleccione uno...");
                obj.slTrabajador = (SelectList)JQuery.SelectListAddItem(new List<ItemSelectList>(), "Valor", "Texto", "", "Ingrese Trabajador...");

                ViewBag.codDep = Session["codDep"].ToString();
                ViewBag.codNiv = Session["codNiv"].ToString();
                ViewBag.codEmp = Session["codEmp"].ToString();

                ViewBag.AntiForgeryToken = Sesion.NewToken(); 

            }
            catch (Exception ex)
            {

                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return RedirectToAction("Error400", "Error");
            }

            return View(obj);
        }

        public FilePathResult obtenerRutaJson(string nombreControl)
        {
            string strFile = "";
            try
            {
                switch (nombreControl)
                {
                    case "slPeriodo":
                        strFile = "/Json/Periodo.json";
                        break;
                    case "slPersonal":
                        strFile = "/Json/Personal.json";
                        break;
                }
            }
            catch (Exception ex)
            { }

            return File(strFile, "text/x-json");
        }

        [HttpPost]
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

        [HttpPost]
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

        [HttpPost]
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

        [HttpPost]
        public JsonResult DevolverDatosFiltroPeriodoGeneracion(string dato)
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
                
                lst = new RecursosHumanosServicio().DevolverDatosFiltroPeriodoGeneracion(obj);

                cbo.Valor = "";
                cbo.Texto = "Seleccione uno...";
                lstItemSelectList.Add(cbo);

                foreach (ItemSelectList _ItemSelectList in lst)
                {
                    ItemSelectList _Obj = new ItemSelectList();
                    _Obj.Valor = _ItemSelectList.Valor;
                    _Obj.Texto = _ItemSelectList.Texto;
                    lstItemSelectList.Add(_Obj);
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
        public JsonResult DevolverDatosFiltroPeriodoSolicitud(string dato)
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

                lst = new RecursosHumanosServicio().DevolverDatosFiltroPeriodoSolicitud(obj);

                cbo.Valor = "";
                cbo.Texto = "Seleccione uno...";
                lstItemSelectList.Add(cbo);

                foreach (ItemSelectList _ItemSelectList in lst)
                {
                    ItemSelectList _Obj = new ItemSelectList();
                    _Obj.Valor = _ItemSelectList.Valor;
                    _Obj.Texto = _ItemSelectList.Texto;
                    lstItemSelectList.Add(_Obj);
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
        public JsonResult CDevolverDetalleSolicitudDescansoFisico(string dato)
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
                    ItemSelectList _Obj = new ItemSelectList();
                    _Obj.Valor = _ItemSelectList.Valor;
                    _Obj.Texto = _ItemSelectList.Texto;
                    lstItemSelectList.Add(_Obj);
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

        [HttpGet]
        public ActionResult ModalDesapruebaSolicitud(string token, int flagPrimeraCarga,string sJson)
        {
            ModalDesapruebaSolicitud obj = new ModalDesapruebaSolicitud();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<ListaDetalleSolicitudDescansoFisico> oDetalleSolicitudDescansoFisico = new List<ListaDetalleSolicitudDescansoFisico>();
            try
            {
                if (flagPrimeraCarga == 0) {
                    oDetalleSolicitudDescansoFisico = jss.Deserialize<List<ListaDetalleSolicitudDescansoFisico>>(sJson);
                    obj.sCodTrabajador = oDetalleSolicitudDescansoFisico[0].CODI_EMPL_PER;
                    obj.sTrabajador = oDetalleSolicitudDescansoFisico[0].NOMB_EMPL_PER;
                    obj.sCodPlanilla = oDetalleSolicitudDescansoFisico[0].TIPO_PLAN_TPL;
                    obj.sPeriodo = oDetalleSolicitudDescansoFisico[0].ANIO_GENE_DFI;
                    obj.sFehIni = oDetalleSolicitudDescansoFisico[0].INIC_PROG_DDF.ToShortDateString();
                    obj.sFehFin = oDetalleSolicitudDescansoFisico[0].FINA_PROG_DDF.ToShortDateString();
                    obj.sDias = oDetalleSolicitudDescansoFisico[0].DIAS_PROG_DDF.ToString();
                    obj.sSecuencia = oDetalleSolicitudDescansoFisico[0].SECU_PROG_DDF.ToString();

                    obj.ErrorCarga = "0";
                }
                
            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                obj.ErrorCarga = "1";
            }

            return PartialView(obj);
        }
    }
}