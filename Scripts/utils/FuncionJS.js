$.fn.validByGroup = function (grupo) {
    /// <summary>
    /// Valida una vista en base a un grupo de controles
    /// </summary>
    /// <param name="grupo" type="String">Nombre del grupo de controles dentro de la vista</param>
    var valido = true;
    var form = this;
    $(form).find("[name^='" + grupo + "']").each(function (index) {
        if (!$(form).validate().element("#" + this.name))
            valido = false;
    });
    return valido;
}

var FuncionJS = {

    //ShowProgress: function () {        
    //    $("#SATDEMO_PleaseWaitDialog").modal("show");
    //},

    //HideProgress: function (modal, modalparent) {
    //    $("#SATDEMO_PleaseWaitDialog").modal("hide", true);
    //},

    GetToken: function (IdToken) {
        /// <summary>
        /// Obtiene Token de Pagina
        /// </summary>
        /// <param name="IdToken" type="String">(Opcional) Id tag token</param>
        if (IdToken) {
            return $('input[name=' + IdToken + ']').val();
        } else {
            return $('input[name=__RequestVerificationToken]').val();
        }
    },    

    UrlActionMethod: function (Controller, Method) {
        /// <summary>
        /// Devuelve el Url de un WebMethod (con relación a la página donde se ejecuta el script)
        /// </summary>
        /// <param name="Controller" type="String">Nombre del Controller</param>
        /// <param name="Method" type="String">Nombre del Method</param>
        if (Controller) {
            return Controller + "/" + Method;
        } else {
            return Method;
        }
    },

    isEmpty: function (str) {
            return typeof str == 'string' && !str.trim() || typeof str == 'undefined' || str === null;
    },

    isNumber: function (str){
        if (/^([0-9])*$/.test(str))
            return true
        else
            return false
    }


};