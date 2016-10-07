using System;
using System.ComponentModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Models
{
    public class RegistroConcepto
    {
        [DisplayName("Código Concepto")]
        public String sCodConcepto { get; set; }

        [DisplayName("Tipo Concepto")]
        public String sTipoConcepto { get; set; }

        [DisplayName("Nombre Concepto")]
        public String sConcepto { get; set; }

        [DisplayName("Mensaje")]
        public String sMensajeConcepto { get; set; }

        [DisplayName("Query")]
        public String sQueryConcepto { get; set; }

        [DisplayName("Usuario Registro: ")]
        public String sUsuRegistro { get; set; }

        [DisplayName("Fecha Registro: ")]
        public String sFehRegistro { get; set; }

        [DisplayName("Usuario Actualización: ")]
        public String sUsuActualizar { get; set; }

        [DisplayName("Fecha Actualización: ")]
        public String sFehActualizar { get; set; }

        [DisplayName("Estado")]
        public String sEstado { get; set; }

        [DisplayName("Accion")]
        public String sAccion { get; set; }

    }
}