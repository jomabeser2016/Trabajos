$(document).ready(function () {
    Init();

    function Init() {
        //var sTip = document.getElementById('sAccion').value;
        var sTip = $("#sAccion").val();
        if (sTip == "1") {
            $("#sCodConcepto").attr("disabled", "disabled");
            $("#sTipoConcepto").attr("disabled", "disabled");
        }
    }

    $("#btnGuardarTop").click(function (e) {
        $("#btnGuardarTop").addClass("disabled");
        $("#modalLoading").modal("show");
        var sTip = $("#sAccion").val();
        var FehReg;
        if (sTip == "1") {
            FehReg = $("#lblsFehRegistro").html();
            FehReg = FehReg.split("/");
            FehReg = new Date(FehReg[2], FehReg[1] - 1, FehReg[0]);
        }
        else { FehReg = new Date(); }
        var FehAct = new Date();

        var iCodEstado = 1;

        var sQRY_PARAM_DFI = document.getElementById("sQueryConcepto").value;

        var jsdato = JSON.stringify({
            TIPO_PARAM_DFI: parseInt(document.getElementById("sTipoConcepto").value, 10),
            CODI_PARAM_DFI: document.getElementById("sCodConcepto").value,
            NOM_PARAM_DFI: document.getElementById("sConcepto").value,
            ESTA_PARAM_DFI: iCodEstado,
            QRY_PARAM_DFI: sQRY_PARAM_DFI.replace(/'/gi, "\\\\u0027"),
            MSJ_PARAM_DFI: document.getElementById("sMensajeConcepto").value,
            USER_REG_PARAM_DFI: "00001795",
            FECH_REG_PARAM_DFI: FehReg,
            USER_ACT_PARAM_DFI: "00001795",
            FECH_ACT_PARAM_DFI: FehAct
        });

        jsdato = "[" + jsdato + "]";
        var sUrlProceso = "";       
        if (sTip == "1")
        { sUrlProceso = requrlEdit; }
        else
        { sUrlProceso = requrlSave; }

        $.ajax({
            url: sUrlProceso,
            dataType: "json",
            async: false,
            type: "POST",
            contentType: "application/json;charset=utf-8",
            data: "{'lsConcepto':'" + jsdato + "'}",
            //data: "{'lsConcepto':''}",
            success: function (response) {
                alert('Datos Guardados');
                $("#btnGuardarTop").removeClass("disabled");
                $("#modalLoading").modal("hide");
                var url = requrlConsulta;
                location.href = url;
            },
            error: function (xhr, ajaxOptions, thrownError) {
                window.location.href = requrlError;
            }
        });
    });

    //$("#btnGuardarBotton").click(function (e) {
    //    var sTip = document.getElementById('sAccion').value;
    //    var FehReg = '';
    //    if (sTip == "1") {
    //        FehReg = $("#lblsFehRegistro").html();
    //        FehReg = FehReg.split("/");
    //        FehReg = new Date(FehReg[2], FehReg[1] - 1, FehReg[0]);
    //    }
    //    else { FehReg = new Date(); }
    //    var FehAct = new Date();

    //    var iCodEstado = 1;

    //    var jsdato = JSON.stringify({
    //        TIPO_PARAM_DFI: parseInt(document.getElementById('sTipoConcepto').value, 10),
    //        CODI_PARAM_DFI: document.getElementById('sCodConcepto').value,
    //        NOM_PARAM_DFI: document.getElementById('sConcepto').value,
    //        ESTA_PARAM_DFI: iCodEstado,
    //        QRY_PARAM_DFI: document.getElementById('sQueryConcepto').value,
    //        MSJ_PARAM_DFI: document.getElementById('sMensajeConcepto').value,
    //        USER_REG_PARAM_DFI: '00001795',
    //        FECH_REG_PARAM_DFI: FehReg,
    //        USER_ACT_PARAM_DFI: '00001795',
    //        FECH_ACT_PARAM_DFI: FehAct
    //    });

    //    jsdato = "[" + jsdato + "]";

    //    var sUrlProceso = "";
    //    if (sTip == "1")
    //    { sUrlProceso = requrlEdit; }
    //    else
    //    { sUrlProceso = requrlSave; }

    //    $.ajax({
    //        url: sUrlProceso,
    //        dataType: "json",
    //        async: false,
    //        type: 'POST',
    //        contentType: 'application/json;charset=utf-8',
    //        data: "{'lsConcepto':'" + jsdato + "'}",
    //        success: function (response) {
    //            alert('Datos Guardados');
    //            //var url = requrlConsulta;
    //            //location.href = url;
    //        },
    //        error: function (xhr, ajaxOptions, thrownError) {
    //            alert(thrownError);
    //        }
    //    });
    //});
});