using System;
using System.ComponentModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Models
{
    public class EdicionSolicitud
    {
        [DisplayName("Token")]
        public string token { get; set; }

        [DisplayName("Fecha Inicio")]
        [Required(ErrorMessage = "Ingrese la Fecha Inicio")]
        public string sFehIni { get; set; }

        [DisplayName("Fecha Fin")]
        [Required(ErrorMessage = "Ingrese la Fecha Fin")]
        public string sFehFin { get; set; }

        [DisplayName("Observaciones")]
        public string sObserv { get; set; }

        [DisplayName("Motivo")]
        public string sMotivo { get; set; }

        [DisplayName("Cod. Trabajador : ")]
        public String sCodTrabajador { get; set; }

        [DisplayName("Trabajador : ")]
        public String sTrabajador { get; set; }

        [DisplayName("Dependencia : ")]
        public String sDepencia { get; set; }

        [DisplayName("sCodDepencia")]
        public String sCodDepencia { get; set; }

        [DisplayName("Cargo : ")]
        public String sCargo { get; set; }

        [DisplayName("sCodCargo")]
        public String sCodCargo { get; set; }

        [DisplayName("Planilla : ")]
        public String sPlanilla { get; set; }

        [DisplayName("sCodPlanilla")]
        public String sCodPlanilla { get; set; }

        [DisplayName("Periodo Generación")]
        public String sPeriodo { get; set; }

        [DisplayName("Secuencia")]
        public int iSecPrograma { get; set; }

        [DisplayName("TipoUrl")]
        public String sTipoUrl { get; set; }

        [DisplayName("Días por Programar: ")]
        public String sDpProgramar { get; set; }
    }
}