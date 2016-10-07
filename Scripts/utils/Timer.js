function show5() {
    if (!document.layers && !document.all && !document.getElementById)
        return

    var Digital = new Date()

    var months = new Array("Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Setiembre", "Octubre", "Noviembre", "Diciembre")
    var days = new Array("Domingo", "Lunes", "Martes", "Miercoles", "Jueves", "Viernes", "Sábado")

    var dia = Digital.getDate()
    var mes = Digital.getMonth()
    var anio = Digital.getFullYear()
    var hours = Digital.getHours()
    var minutes = Digital.getMinutes()
    var seconds = Digital.getSeconds()

    var dn = "PM"
    if (hours < 12)
        dn = "AM"

    if (hours > 12)
        hours = hours - 12

    if (hours == 0)
        hours = 12

    if (hours <= 9)
        hours = "0" + hours

    if (minutes <= 9)
        minutes = "0" + minutes

    if (seconds <= 9)
        seconds = "0" + seconds

    if (dia <= 9)
        dia = "0" + dia

    if (mes <= 9)
        mes = "0" + mes

    //change font size here to your desire
    //myclock= ""+days[dia]+", " + dia + " de " + months[mes] + " de "+anio+" " + hours+":"+minutes+":"+seconds+" "+dn

    myclock = "" + dia + "/" + mes + "/" + anio + " " + hours + ":" + minutes + ":" + seconds + " " + dn

    if (document.layers) {
        document.layers.liveclock.document.write(myclock)
        document.layers.liveclock.document.close()
    }
    else if (document.all)
        liveclock.innerHTML = myclock
    else if (document.getElementById)
        document.getElementById("liveclock").innerHTML = myclock

    setTimeout("show5()", 1000)
}

window.onload = show5