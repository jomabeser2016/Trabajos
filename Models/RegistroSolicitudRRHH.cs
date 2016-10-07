using System;
using System.ComponentModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Models
{
    public class RegistroSolicitudRRHH
    {
        [DisplayName("Codigo: ")]
        public String sCodTrabajador { get; set; }

        [DisplayName("Trabajador: ")]
        public String sTrabajador { get; set; }

        [DisplayName("Cargo: ")]
        public String sCargo { get; set; }

        [DisplayName("Dependencia: ")]
        public String sDepencia { get; set; }

        [DisplayName("Periodo: ")]
        [Required(ErrorMessage = "Seleccione un criterio de búsqueda")]
        public SelectList slPeriodo { get; set; }

        [DisplayName("Días Gozados: ")]
        public String sDGozados { get; set; }

        [DisplayName("Días Programados: ")]
        public String sDProgram { get; set; }

        [DisplayName("Días por Programar: ")]
        public String sDpProgramar { get; set; }

        [DisplayName("Total Días: ")]
        public String sTotal { get; set; }

        [DisplayName("sCodPlanilla")]
        public String sCodPlanilla { get; set; }

        [DisplayName("Trabajador ")]
        public SelectList slTrabajador { get; set; }

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