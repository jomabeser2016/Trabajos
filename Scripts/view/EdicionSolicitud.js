$(document).ready(function () {
    init();
    function init() {
        $('#sCodTrabajador').attr('aria-hidden', 'true').hide();
        $('#sCodPlanilla').attr('aria-hidden', 'true').hide();
        $('#sCodDepencia').attr('aria-hidden', 'true').hide();
        $('#sCodCargo').attr('aria-hidden', 'true').hide();
        $('#sCodPlanilla').attr('aria-hidden', 'true').hide();
        $('#sPeriodo').attr('aria-hidden', 'true').hide();
        $('#iSecPrograma').attr('aria-hidden', 'true').hide();
        $('#sDpProgramar').attr('aria-hidden', 'true').hide();
               
        $('#sMotivo').attr('disabled', 'disabled');
        $('#sTipoUrl').attr('aria-hidden', 'true').hide();
    }

    $("#btnGuardar").click(function (e) {
        
        if (confirmar('la Edición de la Solicitud'))
        {
            $("#btnGuardar").addClass("disabled");
            $("#modalLoading").modal("show");
            var sJson = '';
            var sTipPl = document.getElementById('sCodPlanilla').value;
            var sCodTra = document.getElementById('sCodTrabajador').value;
            var FehIni = document.getElementById('sFehIni').value;
            var FehFin = document.getElementById('sFehFin').value;
            var sObser = document.getElementById('sObserv').value;
            var iSec = document.getElementById('iSecPrograma').value;
            var iDp = document.getElementById('sDpProgramar').value;
            var sAnio = document.getElementById('sPeriodo').value;
            var sMot = document.getElementById('sMotivo').value;

            

            FehIni = FehIni.split('/');
            FehFin = FehFin.split('/');
            var iDias = (new Date(FehFin[2], FehFin[1] - 1, FehFin[0])) - (new Date(FehIni[2], FehIni[1] - 1, FehIni[0]));
            var dFehAct = new Date();
            var sUsuAct = sCodTra;
            var iDif = (((iDias / 1000) / 60) / 60) / 24;
            var iResta = 0;

            iResta = parseInt(iResta, 10) + parseInt(iDif, 10);

            var iDpProgramar = parseInt(iDp, 10);

            if (iResta > 30) {
                alert('No puede programar mas de 30 días');
                $("#btnGuardar").removeClass("disabled");
                $("#modalLoading").modal("hide");
                return;
            }

            //if (iResta < 7) {
            //    if (iDpProgramar > 7)
            //    {
            //        alert('No puede programar menos de 7 días calendarios');
            //        return;
            //    }                
            //}

            var datoV = JSON.stringify({
                TIPO_PLAN_TPL: sTipPl,
                CODI_EMPL_PER: sCodTra,
                ANIO_GENE_DFI: parseInt(sAnio),
                FECHA_INI: new Date(FehIni[2], FehIni[1] - 1, FehIni[0]),
                FECHA_FIN: new Date(FehFin[2], FehFin[1] - 1, FehFin[0])
            });

            var sJsonV = '[' + datoV + ']';

            var iCodError = "";
            var sMensaje = "";

            $.ajax({
                url: requrlValidaFechas,
                type: 'POST',
                async: false,
                contentType: 'application/json;charset=utf-8',
                data: "{'dato':'" + sJsonV + "'}",
                dataType: "json",
                success: function (response) {
                    //id = id + 1;
                    $.each(response, function (index, item) {
                        iCodError = response[index].RESULTADO_CONS
                        sMensaje = response[index].MENSAJE_CONS
                    })
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert("error");
                }
            });

            if (iCodError == "1") {
                $("#btnGuardar").removeClass("disabled");
                $("#modalLoading").modal("hide");
                alert(sMensaje);
                return;
            }

            var dato = JSON.stringify({
                TIPO_PLAN_TPL: sTipPl,
                CODI_EMPL_PER: sCodTra,
                ANIO_GENE_DFI: sAnio,
                SECU_PROG_DDF: iSec,
                INIC_PROG_DDF: new Date(FehIni[2], FehIni[1] - 1, FehIni[0]),
                FINA_PROG_DDF: new Date(FehFin[2], FehFin[1] - 1, FehFin[0]),
                DIAS_PROG_DDF: iDif,
                OBSE_REGI_DDF: sObser,
                OBSE_ACTU_DDF: sMot,
                CODI_EST_DDF: '3',
                FECH_ACTU_DDF: dFehAct,
                USER_ACTU_DDF: sUsuAct
            });

            sJson = '[' + dato + ']';

            $.ajax({
                url: requrlDatos,
                dataType: "json",
                async: false,
                type: 'POST',
                contentType: 'application/json;charset=utf-8',
                data: "{'lst':'" + sJson + "'}",
                success: function (response) {
                    alert('Datos Guardados');
                    var sTipUrl = document.getElementById('sTipoUrl').value;
                    $("#btnGuardar").removeClass("disabled");
                    $("#modalLoading").modal("hide");
                    if (sTipUrl == '1') {
                        var url = requrlConsulta;
                        location.href = url;
                    }
                    else {
                        var url = requrlConsultaT;
                        location.href = url;
                    }

                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert("Error");
                }
            });
        }
        
    });

    function confirmar(sMensaje) {
        if (confirm("¿Seguro que desea continuar con " + sMensaje + "?")) {
            return true;
        }
        else {
            return false;
        }
    }
});