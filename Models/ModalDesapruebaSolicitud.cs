using RecursosHumanos.Models.ValidacionCustom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace RecursosHumanos.Models
{
    public class ModalDesapruebaSolicitud
    {
        [DisplayName("ErrorCarga")]
        public string ErrorCarga { get; set; }

        [DisplayName("Token")]
        public string token { get; set; }

        [DisplayName("Fecha Inicio: ")]
        public string sFehIni { get; set; }

        [DisplayName("Fecha Fin : ")]
        public string sFehFin { get; set; }

        [DisplayName("Observaciones")]
        public string sObserv { get; set; }

        [DisplayName("Motivo")]
        public string sMotivo { get; set; }

        [DisplayName("Codigo: ")]
        public String sCodTrabajador { get; set; }

        [DisplayName("Trabajador: ")]
        public String sTrabajador { get; set; }

        [DisplayName("Cargo: ")]
        public String sCargo { get; set; }

        [DisplayName("Planilla: ")]
        public String sPlanilla { get; set; }

        [DisplayName("sCodPlanilla")]        
        public String sCodPlanilla { get; set; }

        [DisplayName("sSecuencia")]       
        public String sSecuencia { get; set; }

        [DisplayName("Dias: ")]
        public String sDias { get; set; }

        [DisplayName("Periodo Generación: ")]
        public String sPeriodo { get; set; }
    }
}