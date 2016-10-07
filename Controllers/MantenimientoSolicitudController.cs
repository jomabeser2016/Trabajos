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
using SAT.Libreria.Seguridad.Encriptacion;


namespace RecursosHumanos.Controllers
{
    public class MantenimientoSolicitudController : Controller
    {
        // GET: MantenimientoSolicitud
        public ActionResult MantenimientoSolicitud(String CODI_EMPL_PER)
        {
            MantenimientoSolicitud obj = new MantenimientoSolicitud();
            try
            {
                CODI_EMPL_PER = AES.Desencriptar(CODI_EMPL_PER);

                List<DatosTrabajador> lst = CDevolverDatosTrabajador(CODI_EMPL_PER);
                obj.sCodTrabajador = lst[0].CODI_EMPL_PER;
                obj.sTrabajador = lst[0].NOMB_CORT_PER;
                obj.sPlanillaT = lst[0].DESC_TIPO_TPL;
                obj.sCodPlanilla = lst[0].TIPO_PLAN_TPL;
                obj.sCargo = lst[0].NOMB_PUES_TNI;                
                obj.sDepencia = lst[0].DESC_LARG_TDE; 
                obj.sModalidad = lst[0].ABRE_LABO_PER;
                obj.sFehIng = lst[0].FECH_INGR_PER.ToShortDateString();
                obj.slPeriodo = (SelectList)JQuery.SelectListAddItem(CDevolverSolicitudDescansoFisico(obj.sCodPlanilla, obj.sCodTrabajador), "valor", "texto", "", "Seleccione uno...");   
                


            }
            catch (Exception ex)
            {

                throw;
            }
            return View(obj);
        }

        [HttpGet]
        public ActionResult ModalSolicitud(string token,string sFehIniGoc,string sFehFinGoc)
        {
            ModalSolicitud modalSolicitud = new ModalSolicitud();

            modalSolicitud.token = token;
            modalSolicitud.sFehIniGoc = sFehIniGoc;
            modalSolicitud.sFehFinGoc = sFehFinGoc;

            return PartialView(modalSolicitud);
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
                }
            }
            catch (Exception ex)
            { }

            return File(strFile, "text/x-json");
        }

        [HttpPost]
        public JsonResult CalcularDias(string id,string FehIni, string FehFin, string Observa)
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

        //[HttpPost]
        //public JsonResult CDevolverDatosTrabajador(String CODI_EMPL_PER)
        //{
        //    DatosTrabajador obj = new DatosTrabajador();
        //    List<DatosTrabajador> lst = new List<DatosTrabajador>();

        //    try
        //    {
        //        obj.CODI_EMPL_PER = CODI_EMPL_PER;
        //        lst = new RecursosHumanosServicio().DevolverDatosTrabajador(obj);

        //    }
        //    catch (Exception ex)
        //    {

        //        return null;
        //    }

        //    return Json(lst);
        //}

        [HttpPost]
        public List<DatosTrabajador> CDevolverDatosTrabajador(String CODI_EMPL_PER)
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

            return lst;
        }

        //OMAR: MODIFICACION FALTA PROBAR!!!! SE CAMBIO LA CLASE COMBOSOLICITUD POR ITEMSELECTLIST
        [HttpPost]
        public List<ItemSelectList> CDevolverSolicitudDescansoFisico(String TIPO_PLAN_TPL, String CODI_EMPL_PER)
        {
            FiltroSolicitud obj = new FiltroSolicitud();
            List<SolicitudDescansoFisico> lst = new List<SolicitudDescansoFisico>();
            List<ItemSelectList> _DropDownList = new List<ItemSelectList>();
            

            try
            {
                obj.TIPO_PLAN_TPL = TIPO_PLAN_TPL;
                obj.CODI_EMPL_PER = CODI_EMPL_PER;
                lst = new RecursosHumanosServicio().DevolverSolicitudDescansoFisico(obj);
                
                if (lst.Count > 0)
                {
                    foreach (SolicitudDescansoFisico Obj in lst)
                    {
                        ItemSelectList objElementoGeneral = new ItemSelectList();
                        //objElementoGeneral.Valor = Convert.ToInt32(Obj.ANIO_GENE_DFI);
                        objElementoGeneral.Valor = Obj.ANIO_GENE_DFI;
                        objElementoGeneral.Texto = Obj.PERI_GENE_DFI;
                        _DropDownList.Add(objElementoGeneral);
                    }                    
                }
                
                

            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }

            return _DropDownList;
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
                    
                }                
                new RecursosHumanosServicio().RegistrarDetalleDescansoFisico(lstFiltroSolicitud);
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