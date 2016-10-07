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
using SAT.Libreria.Log;
namespace RecursosHumanos.Controllers
{
    public class RegistroSolicitudRRHHController : Controller
    {
        // GET: RegistroSolicitudRRHH
        public ActionResult RegistroSolicitudRRHH()
        {
            try
            {
                RegistroSolicitudRRHH obj = new RegistroSolicitudRRHH();

                obj.slTrabajador = (SelectList)JQuery.SelectListAddItem(DevolverDatosFiltroTrabajador(), "Valor", "Texto", "", "Ingrese Trabajador...");
                obj.slPeriodo = (SelectList)JQuery.SelectListAddItem(new List<ItemSelectList>(), "Valor", "Texto", "", "Seleccione uno...");

                return View(obj);
            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return RedirectToAction("Error400", "Error");
            }
            
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
        public JsonResult DevolverSolicitudDescansoFisico(String TIPO_PLAN_TPL, String CODI_EMPL_PER)
        {
            FiltroSolicitud obj = new FiltroSolicitud();
            List<SolicitudDescansoFisico> lst = new List<SolicitudDescansoFisico>();
            List<ItemSelectList> lstItemSelectList = new List<ItemSelectList>();
            ItemSelectList itemSelectList = new ItemSelectList();

            try
            {
                obj.TIPO_PLAN_TPL = TIPO_PLAN_TPL;
                obj.CODI_EMPL_PER = CODI_EMPL_PER;
                lst = new RecursosHumanosServicio().DevolverSolicitudDescansoFisico(obj);

                if (lst.Count > 0)
                {
                    itemSelectList.Valor = "";
                    itemSelectList.Texto = "Seleccione uno...";
                    lstItemSelectList.Add(itemSelectList);

                    foreach (SolicitudDescansoFisico Obj in lst)
                    {
                        itemSelectList = new ItemSelectList();
                        itemSelectList.Valor = Obj.ANIO_GENE_DFI;
                        itemSelectList.Texto = Obj.PERI_GENE_DFI;
                        lstItemSelectList.Add(itemSelectList);
                    }
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
        public JsonResult ObtenerDiasporAnio(String TIPO_PLAN_TPL, String CODI_EMPL_PER, String PERI_GENE_DFI)
        {
            FiltroSolicitud obj = new FiltroSolicitud();
            List<SolicitudDescansoFisico> lst = new List<SolicitudDescansoFisico>();
            MantenimientoSolicitud _obj = new MantenimientoSolicitud();

            try
            {
                obj.TIPO_PLAN_TPL = TIPO_PLAN_TPL;
                obj.CODI_EMPL_PER = CODI_EMPL_PER;
                obj.PERI_GENE_DFI = PERI_GENE_DFI;
                lst = new RecursosHumanosServicio().ObtenerDiasporAnio(obj);

            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }

            return Json(lst);
        }

        [HttpPost]
        public JsonResult DevolverDatosTrabajador(String CODI_EMPL_PER)
        {
            DatosTrabajador obj = new DatosTrabajador();
            List<DatosTrabajador> lst = new List<DatosTrabajador>();

            try
            {
                obj.CODI_EMPL_PER = CODI_EMPL_PER;
                lst = new RecursosHumanosServicio().DevolverDatosTrabajador(obj);
            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }

            return Json(lst);
        }

        [HttpGet]
        public ActionResult ModalRegistroSolicitudRRHH(string token)
        {
            ModalRegistroSolicitudRRHH ModalRegistroSolicitudRRHH = new ModalRegistroSolicitudRRHH();

            ModalRegistroSolicitudRRHH.token = token;

            return PartialView(ModalRegistroSolicitudRRHH);
        }

        public JsonResult CalcularDias(string id, string FehIni, string FehFin, string Observa)
        {
            int iDias = 0;
            DateTime sdFehIni = new DateTime();
            DateTime sdFehFin = new DateTime();

            List<DetalleSolicitudDescansoFisico> lst = new List<DetalleSolicitudDescansoFisico>();

            try
            {
                sdFehIni = Convert.ToDateTime(FehIni).Date;
                sdFehFin = Convert.ToDateTime(FehFin).Date;

                while (sdFehIni <= sdFehFin)
                {
                    //if ((sdFehIni.DayOfWeek != DayOfWeek.Saturday) && (sdFehIni.DayOfWeek != DayOfWeek.Sunday))
                    //{ iDias++; }
                    iDias++;
                    sdFehIni = sdFehIni.AddDays(1);
                }

                DetalleSolicitudDescansoFisico obj = new DetalleSolicitudDescansoFisico();
                obj.SECU_PROG_DDF = Convert.ToInt32(id) + 1;
                obj.INIC_PROG_DDF = Convert.ToDateTime(FehIni).Date;
                obj.FINA_PROG_DDF = sdFehFin;
                obj.DIAS_PROG_DDF = iDias;
                obj.OBSE_REGI_DDF = Observa;

                lst.Add(obj);

            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }


            return Json(lst);
        }
        [HttpPost]
        public JsonResult RegistrarDetalleDescansoFisico(string lst)
        {
            int iResult = 0;
            String sXml = string.Empty;

            DetalleSolicitudDescansoFisico obj = new DetalleSolicitudDescansoFisico();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<DetalleSolicitudDescansoFisico> lstFiltroSolicitud;

            String CODI_EST_DDF = "3";
            try
            {
                lstFiltroSolicitud = jss.Deserialize<List<DetalleSolicitudDescansoFisico>>(lst);

                foreach (DetalleSolicitudDescansoFisico _objD in lstFiltroSolicitud)
                {
                    _objD.CODI_EST_DDF = CODI_EST_DDF;
                    _objD.FECH_REGI_DDF = DateTime.Today;
                    _objD.FECH_ACTU_DDF = DateTime.Today;
                    _objD.OBSE_ACTU_DDF = _objD.OBSE_REGI_DDF;

                }
                new RecursosHumanosServicio().RegistrarDetalleDescansoFisico(lstFiltroSolicitud);
            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }

            return Json(iResult);
        }

        [HttpPost]
        public List<ItemSelectList> DevolverDatosFiltroTrabajador()
        {
            List<ItemSelectList> lst = new List<ItemSelectList>();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            FiltroSolicitud obj = new FiltroSolicitud();
            List<ItemSelectList> lstItemSelectList = new List<ItemSelectList>();
            ItemSelectList cbo = new ItemSelectList();
            try
            {
                obj.TIPO_PLAN_TPL = string.Empty;
                obj.CODI_DEPE_TDE = string.Empty;
                obj.CODI_NIVE_TNI = string.Empty;
                obj.PERI_GENE_DFI = string.Empty;
                obj.PERI_GENE_DDF = string.Empty;
                obj.CODI_EST_DDF = string.Empty;
                
                lst = new RecursosHumanosServicio().DevolverDatosFiltroTrabajador(obj);


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

            return lstItemSelectList;
        }

        [HttpPost]
        public JsonResult ValidarFechasSolicitudDescansoFisico(string dato)
        {
            List<ValidaFecha> objValidaFecha = new List<ValidaFecha>();
            List<ValidaFecha> lst = new List<ValidaFecha>();
            ValidaFecha obj = new ValidaFecha();
            JavaScriptSerializer jss = new JavaScriptSerializer();

            try
            {
                objValidaFecha = jss.Deserialize<List<ValidaFecha>>(dato);
                obj = objValidaFecha[0];
                //obj.FECHA_INI = Convert.ToDateTime(obj.FECHA_INI);
                //obj.FECHA_FIN = Convert.ToDateTime(obj.FECHA_FIN);
                lst = new RecursosHumanosServicio().ValidarFechasSolicitudDescansoFisico(obj);
            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }
            return Json(lst);
        }
    }
}