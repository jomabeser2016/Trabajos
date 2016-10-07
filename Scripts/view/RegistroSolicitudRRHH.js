$(document).ready(function () {
    init();

    function init() {

        $('#sCodPlanilla').attr('aria-hidden', 'true').hide();
        $('#sCodTrabajador  ').attr('aria-hidden', 'true').hide();
        cargarGrilla();
    }

    $(window).on("resize", function () {
        var $grid = $("#grdSolicitud"),
            newWidth = $grid.closest(".ui-jqgrid").parent().width();
        $grid.jqGrid("setGridWidth", newWidth, true);
    });

    function ShowModalAutenticacion() {
        var token = FuncionJS.GetToken();

        $("#modalnuevasolicitud").load(requrlModalAutenticacion + '?token=' + token,
            function () {
                $("#modalnuevasolicitud").modal("show");
            });
    }

    $("#btnAgregar").click(function (e) {
        var slPeriodoT = $('#slPeriodo');
        var slPeriodoTSel = slPeriodoT.val();
        if (slPeriodoTSel == "")
            alert("Seleccione un periodo para agregar una solicitud de vacaciones");
        else
            ShowModalAutenticacion();

        return false;
    });
   
    $("#slTrabajador").change(function () {
        var slTrabajadorB = $('#slTrabajador');
        var valorSel = slTrabajadorB.val();


        $.ajax({
            url: requrlDatosTrabajador,
            type: 'POST',
            async: false,
            contentType: 'application/json;charset=utf-8',
            data: "{'CODI_EMPL_PER':'" + valorSel + "'}",
            dataType: "json",
            success: function (response) {
                $.each(response, function (index, item) {                    
                    //$('#lsCodTrabajador').val(response[index].CODI_EMPL_PER)
                    $('#lsCodTrabajador').html(response[index].CODI_EMPL_PER)
                    $("#sCodPlanilla").val(response[index].TIPO_PLAN_TPL)   
                    $("#sCodTrabajador").val(response[index].CODI_EMPL_PER)
                    $("#lsTrabajador").html(response[index].NOMB_CORT_PER)
                    $("#lsDepencia").html(response[index].DESC_LARG_TDE)
                    $("#lsCargo").html(response[index].NOMB_PUES_TNI)
                })
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("error2");
            }
        });

        $("#slPeriodo").empty();
        var value = document.getElementById('sCodPlanilla').value;
        $.ajax({
            url: requrlPeriodo,
            type: 'POST',
            async: false,
            contentType: 'application/json;charset=utf-8',
            data: "{'TIPO_PLAN_TPL':'" + value + "','CODI_EMPL_PER':'" + valorSel + "'}",
            dataType: "json",
            success: function (response) {
                var slPeriodo = $("#slPeriodo");
                slPeriodo.empty();
                $.each(response, function (index, item) {
                    slPeriodo.append("<option value=" + response[index].Valor +
                            ">" + response[index].Texto + "</option>");
                })
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("error2");
            }
        });        
    });

    function pad(str, max) {
        str = str.toString();
        return str.length < max ? pad("0" + str, max) : str;
    }

    $("#slPeriodo").change(function () {
        var value = document.getElementById('sCodPlanilla').value;
        var codtrab = document.getElementById('sCodTrabajador').value;

        var slPeriodoT = $('#slPeriodo');
        var slPeriodoTSel = slPeriodoT.val();

        $("#lsFehIniGen").html("");
        $("#lsFehFinGen").html("");
        $("#lsFehIniGoc").html("");
        $("#lsFehFinGoc").html("");

        $("#lsDGozados").html('');
        $("#lsDProgram").html('');
        $("#lsDpProgramar").html('');
        $("#lsTotal").html('');

        $.ajax({
            url: requrlDatosPeriodo,
            type: 'POST',
            async: false,
            contentType: 'application/json;charset=utf-8',
            data: "{'TIPO_PLAN_TPL':'" + value + "','CODI_EMPL_PER':'" + codtrab + "','PERI_GENE_DFI':'" + slPeriodoTSel + "'}",
            dataType: "json",
            success: function (response) {                
                $.each(response, function (index, item) {
                    var sFIG = new Date(parseInt(response[index].INIC_GENE_DFI.substring(6)))
                    var sFFG = new Date(parseInt(response[index].FINA_GENE_DFI.substring(6)))
                    var sFIGo = new Date(parseInt(response[index].INIC_GOCE_DFI.substring(6)))
                    var sFFGo = new Date(parseInt(response[index].FINA_GOCE_DFI.substring(6)))

                    $("#lsFehIniGen").html(pad(sFIG.getDate(), 2) + "/" + pad((sFIG.getMonth() + 1), 2) + "/" + sFIG.getFullYear())
                    $("#lsFehFinGen").html(pad(sFFG.getDate(), 2) + "/" + pad((sFFG.getMonth() + 1), 2) + "/" + sFFG.getFullYear())
                    $("#lsFehIniGoc").html(pad(sFIGo.getDate(), 2) + "/" + pad((sFIGo.getMonth() + 1), 2) + "/" + sFIGo.getFullYear())
                    $("#lsFehFinGoc").html(pad(sFFGo.getDate(), 2) + "/" + pad((sFFGo.getMonth() + 1), 2) + "/" + sFFGo.getFullYear())

                    $("#lsDGozados").html(response[index].DIAS_GOZA_DFI)
                    $("#lsDProgram").html(response[index].DIAS_PROG_DFI)
                    $("#lsDpProgramar").html(response[index].DIAS_XPROG_DFI)
                    $("#lsTotal").html(response[index].DIAS_GENE_DFI)
                })
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("error");
            }
        });
    });

    function cargarGrilla() {
        $("#grdSolicitud").jqGrid({
            datatype: 'local',
            mtype: 'POST',
            jsonReader: {
                root: "rows",
                page: "page",
                total: "total",
                records: "records",
                repeatitems: true
            },
            colNames: ['Codigo', 'Fecha Inicio', 'Fecha Fin', 'Días', 'Observacion'],
            colModel: [
            { key: true, name: 'SECU_PROG_DDF', index: 'SECU_PROG_DDF', hidden: true, align: "center", width: 100, sortable: false },
            { name: 'INIC_PROG_DDF', index: 'INIC_PROG_DDF', width: 120, align: "center", sorttype: false, formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y' } },
            { name: 'FINA_PROG_DDF', index: 'FINA_PROG_DDF', width: 120, align: "center", sorttype: false, formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y' } },
            { name: 'DIAS_PROG_DDF', index: 'DIAS_PROG_DDF', width: 100, align: 'center', sorttype: false },
            { name: 'OBSE_REGI_DDF', index: 'OBSE_REGI_DDF', width: 350, align: "center", sortable: false }],
            rowNum: 5, rowList: [5, 10, 15, 20], pager: '#pageSolicitud', sortname: 'SECU_PROG_DDF', viewrecords: true, sortorder: "asc",
            height: 120,
            autowidth: true,
            shrinkToFit: false,
            caption: "Resultados - Lista de Solicitudes",
            rownumbers: true,
            reloadAfterEdit: false,
            reloadAfterSubmit: false,
            autoencode: false,
            loadonce: true,
            multiselect: true, onSelectRow: function (rowId, status, e) {
                if (status === false) {
                    delete selectedRows[rowId];
                } else {
                    selectedRows[rowId] = status;
                }
            },
            onSelectAll: function (rowIds, status) {
                if (status === true) {
                    for (var i = 0; i < rowIds.length; i++) {
                        selectedRows[rowIds[i]] = true;
                    }
                } else {
                }

            },
            gridComplete: function () {
                var nroreg = $("#grdSolicitud").getGridParam("records");
                if (nroreg <= 0) {

                } else {
                    //var rows = $("#grdSolicitud").getDataIDs();
                    ////LOGICA PARA PODER SETEAR NUEVAMENTE LOS VALORES AL PAGINAR
                    //for (var rowId in selectedRows) {
                    //    $("#grdSolicitud").setSelection(rowId, true);
                    //}

                }
            },
        }).navGrid('#pageSolicitud', {
            refresh: false,
            search: false,
            add: false,
            edit: false,
            del: true
        });
    }

    $("#btnGuardar").click(function (e) {

        var iRow = jQuery("#grdSolicitud").jqGrid('getGridParam', 'records');

        if (iRow == 0) {
            alert("Debe ingresar por lo menos una solicitud");
            return;
        }
        if (confirmar('la grabación de la información')) {
            $("#btnGuardar").addClass("disabled");
            $("#modalLoading").modal("show");
            var myIDs = jQuery("#grdSolicitud").jqGrid('getDataIDs');
            var value = document.getElementById('sCodPlanilla').value;
            var codtrab = document.getElementById('sCodTrabajador').value;

            var slPeriodoT = $('#slPeriodo');
            var slPeriodoTSel = slPeriodoT.val();
            var sJson = '';
            var iDpProgramar = parseInt($("#lsDpProgramar").html(), 10);
            var iResta = 0;

            for (var i = 0; i < myIDs.length; i++) {
                var rowData = $("#grdSolicitud").jqGrid('getRowData', myIDs[i]);

                var FehIni = rowData.INIC_PROG_DDF;
                var FehFin = rowData.FINA_PROG_DDF;
                var iDias = rowData.DIAS_PROG_DDF;
                var sObser = rowData.OBSE_REGI_DDF;
                var iFila = i + 1;

                iResta = parseInt(iResta, 10) + parseInt(rowData.DIAS_PROG_DDF, 10);

                FehIni = FehIni.split('/');
                FehFin = FehFin.split('/');
                var dato = JSON.stringify({
                    TIPO_PLAN_TPL: value,
                    CODI_EMPL_PER: codtrab,
                    ANIO_GENE_DFI: parseInt(slPeriodoTSel),
                    SECU_PROG_DDF: iFila,
                    INIC_PROG_DDF: new Date(FehIni[2], FehIni[1] - 1, FehIni[0]),
                    FINA_PROG_DDF: new Date(FehFin[2], FehFin[1] - 1, FehFin[0]),
                    DIAS_PROG_DDF: iDias,
                    OBSE_REGI_DDF: sObser
                });

                if (sJson == '') { sJson = '[' + dato + ','; }
                else { sJson = sJson + dato + ','; }
            }

            if (iResta > iDpProgramar) {
                alert('No puede programar mas de los dias que tiene pendiente(Dias por Programar)');
                $("#btnGuardar").removeClass("disabled");
                $("#modalLoading").modal("hide");
                return;
            }

            if (iResta > 30) {
                alert('No puede programar mas de 30 días');
                $("#btnGuardar").removeClass("disabled");
                $("#modalLoading").modal("hide");
                return;
            }

            if (iResta < 7) {
                if (iDpProgramar > 7) {
                    alert('No puede programar menos de 7 días calendarios');
                    $("#btnGuardar").removeClass("disabled");
                    $("#modalLoading").modal("hide");
                    return;
                }
            }

            sJson = sJson.substring(0, sJson.length - 1);
            sJson = sJson + ']';

            $.ajax({
                url: requrlDatos,
                dataType: "json",
                async: false,
                type: 'POST',
                contentType: 'application/json;charset=utf-8',
                data: "{'lst':'" + sJson + "'}",
                success: function (response) {
                    alert('Datos Guardados');
                    $("#btnGuardar").removeClass("disabled");
                    $("#modalLoading").modal("hide");
                    var url = requrlConsulta;
                    location.href = url;
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
})