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

namespace RecursosHumanos.Controllers
{
    public class NuevaSolicitudController : Controller
    {
        /*
        // GET: NuevaSolicitud
        public ActionResult NuevaSolicitud()
        {
            RegistroSolicitudRRHH obj = new RegistroSolicitudRRHH();

            obj.slTrabajador = (SelectList)JQuery.SelectListAddItem(new List<ComboSolicitud>(), "CODIGO_CAMPO", "NOMBRE_CAMPO", "", "Ingrese Trabajador...");
            obj.slPeriodo = (SelectList)JQuery.SelectListAddItem(new List<ComboSolicitud>(), "CODIGO_CAMPO", "NOMBRE_CAMPO", "", "Seleccione uno...");                       

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
        public JsonResult CDevolverSolicitudDescansoFisico(String TIPO_PLAN_TPL, String CODI_EMPL_PER)
        {
            FiltroSolicitud obj = new FiltroSolicitud();
            List<SolicitudDescansoFisico> lst = new List<SolicitudDescansoFisico>();
            List<ComboSolicitud> _DropDownList = new List<ComboSolicitud>();
            ComboSolicitud cbo = new ComboSolicitud();

            try
            {
                obj.TIPO_PLAN_TPL = TIPO_PLAN_TPL;
                obj.CODI_EMPL_PER = CODI_EMPL_PER;
                lst = new RecursosHumanosServicio().DevolverSolicitudDescansoFisico(obj);

                if (lst.Count > 0)
                {
                    cbo.CODIGO_CAMPO = "";
                    cbo.NOMBRE_CAMPO = "Seleccione uno...";
                    _DropDownList.Add(cbo);

                    foreach (SolicitudDescansoFisico Obj in lst)
                    {
                        ComboSolicitud objElementoGeneral = new ComboSolicitud();
                        objElementoGeneral.CODIGO_CAMPO = Obj.ANIO_GENE_DFI;
                        objElementoGeneral.NOMBRE_CAMPO = Obj.ANIO_GENE_DFI;
                        _DropDownList.Add(objElementoGeneral);
                    }
                }
            }
            catch (Exception ex)
            {

                return null;
            }

            return Json(_DropDownList);
        }



        [HttpPost]
        public JsonResult CObtenerDiasporAnio(String TIPO_PLAN_TPL, String CODI_EMPL_PER, String PERI_GENE_DFI)
        {
            FiltroSolicitud obj = new FiltroSolicitud();
            List<SolicitudDescansoFisico> lst = new List<SolicitudDescansoFisico>();
            MantenimientoSolicitud _obj = new MantenimientoSolicitud();

            try
            {
                obj.TIPO_PLAN_TPL = TIPO_PLAN_TPL;
                obj.CODI_EMPL_PER = CODI_EMPL_PER;
                obj.PERI_GENE_DFI = PERI_GENE_DFI;
                lst = new RecursosHumanosServicio().DevolverSolicitudDescansoFisico(obj);

            }
            catch (Exception ex)
            {
                return null;
            }

            return Json(lst);
        }

        [HttpPost]
        public JsonResult CDevolverDatosTrabajador(String CODI_EMPL_PER)
        {
            DatosTrabajador obj = new DatosTrabajador();
            List<DatosTrabajador> lst = new List<DatosTrabajador>();

            try
            {
                obj.CODI_EMPL_PER = CODI_EMPL_PER;
                lst = new RecursosHumanosServicio().DevolverDatosTrabajador(obj);
                //NuevaSolicitud objNuevaSolicitud = new NuevaSolicitud();
                //objNuevaSolicitud.sCodTrabajador = lst[0].CODI_EMPL_PER;
                //objNuevaSolicitud.sTrabajador = lst[0].NOMB_CORT_PER;      
              
            }
            catch (Exception ex)
            {

                return null;
            }

            return Json(lst);
        }

        [HttpGet]
        public ActionResult ModalNuevaSolicitud(string token)
        {
            ModalNuevaSolicitud ModalNuevaSolicitud = new ModalNuevaSolicitud();

            ModalNuevaSolicitud.token = token;

            return PartialView(ModalNuevaSolicitud);
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
                //OMAR: MODIFICACION FALTA PROBAR!!!! Y CAMBIAR PORQUE AHORA LOS REGISTRAR SON VOIDS
                //iResult = new RecursosHumanosServicio().RegistrarDetalleDescansoFisico(lstFiltroSolicitud);
            }
            catch (Exception ex)
            {

                return null;
            }

            return Json(iResult);
        }
    */
    }
     
}