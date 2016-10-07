$(document).ready(function () {

    $("#btnAceptar").click(function () {
        var dFehAct = new Date();
        var sJson = "";
        var dato = JSON.stringify({
            TIPO_PLAN_TPL: document.getElementById("sCodPlanilla").value,
            CODI_EMPL_PER: document.getElementById("sCodTrabajador").value,
            SECU_PROG_DDF: document.getElementById("sSecuencia").value,
            ANIO_GENE_DFI: document.getElementById("sPeriodo").value,
            OBSE_ACTU_DDF: document.getElementById("sMotivo").value,
            CODI_EST_DDF: "2",
            FECH_ACTU_DDF: dFehAct,
            USER_ACTU_DDF: document.getElementById("sCodTrabajador").value
        });
        sJson = "[" + dato + "]";
        $.ajax({
            url: requrlDatos,
            dataType: "json",
            async: false,
            type: "POST",
            contentType: "application/json;charset=utf-8",
            data: "{'lst':'" + sJson + "'}",
            success: function (response) {
                alert("Datos Guardados");
                $("#grdSolicitud").trigger("reloadGrid", { fromServer: true, page: 1 });
                $("#modalDesaprueba").modal("hide");
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("Error");
            }
        });
    });
});