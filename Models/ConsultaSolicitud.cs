using System;
using System.ComponentModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Models
{
    public class ConsultaSolicitud
    {

        [DisplayName("Gerencia")]
        [Required(ErrorMessage = "Seleccione un criterio de búsqueda")]
        public SelectList slGerencia { get; set; }

        [DisplayName("Trabajador")]
        public SelectList slTrabajadorB { get; set; }

        [DisplayName("Estado Solicitud")]
        public SelectList slEstado { get; set; }

        [DisplayName("Planilla: ")]
        public String sPlanillaT { get; set; }

        [DisplayName("sCodPlanilla")]
        public String sCodPlanilla { get; set; }

        [DisplayName("Dependencia: ")]
        public String sDepenciaT { get; set; }

        [DisplayName("sCodDepencia")]
        public String sCodDepencia { get; set; }

        [DisplayName("Modalidad: ")]
        public String sModalidad { get; set; }

        [DisplayName("Cargo: ")]
        public String sCargoT { get; set; }

        [DisplayName("sCodCargo")]
        public String sCodCargo { get; set; }

        [DisplayName("Cod. Trabajador: ")]
        public String sCodTrabajador { get; set; }

        [DisplayName("Trabajador: ")]
        public String sTrabajador { get; set; }

        [DisplayName("Fecha de Ingreso: ")]
        public String sFehIng { get; set; }

        [DisplayName("Periodo Generación: ")]
        [Required(ErrorMessage = "Seleccione un criterio de búsqueda")]
        public SelectList slPeriodoT { get; set; }

        [DisplayName("Días Gozados")]
        public String sDGozados { get; set; }

        [DisplayName("Días Programados")]
        public String sDProgram { get; set; }

        [DisplayName("Días por Programar")]
        public String sDpProgramar { get; set; }

        [DisplayName("Total Días")]
        public String sTotal { get; set; }

        [DisplayName("Periodo Inicio")]
        public String sFehIniGen { get; set; }

        [DisplayName("Periodo Fin")]
        public String sFehFinGen { get; set; }

        [DisplayName("Goce Inicio")]
        public String sFehIniGoc { get; set; }

        [DisplayName("Goce Fin")]
        public String sFehFinGoc { get; set; }
    }
}