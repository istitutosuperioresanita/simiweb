

//var e = document.getElementById("malattia");
var idMalattia 

//var idMalattia = $('#malattia').val();

$(function () {
    idMalattia = $('#malattia').val();
     $('#allerta').hide();
});

function CheckInfo() {
    var dataprimisintomi = $('#dataprimisintomi').val();
    var datasegnalazione = $('#datasegnalazione').val();
    var datanotifica = $('#datanotifica').val();
    var statoScheda = $('#statoScheda').val();
    if ((datanotifica == '') && (statoScheda == 'Notifica')) {
        alert('Inserire la data di notifica');
        return false;
    }


    datanotifica = PrendiData(datanotifica);
    datasegnalazione = PrendiData(datasegnalazione);
    dataprimisintomi = PrendiData(dataprimisintomi);

    
    var today = autoDate();


//    alert(today);
//    alert(datasegnalazione);
    if ((datanotifica == '') && (statoScheda == 'Notifica')) {
        alert('Inserire la data di notifica');
        return false;
    }


    if (dataprimisintomi > datasegnalazione)
  {
        alert('La data di segnalazione deve essere uguale o successiva a quella di primi sintomi  ' + $('#dataprimisintomi').val());
        return false
    }
    if ((datasegnalazione > datanotifica) && (statoScheda == 'Notifica')) {
        alert('La data di notifica deve essere uguale o successiva a quella di segnalazione');
        return false
    }
    if (datasegnalazione > today) {
        alert('La data di segnalazione deve essere <= Data Odierna');
        return false;
    }

    if ((datanotifica > today) && (statoScheda == 'Notifica')) {
        alert('La data di notifica deve essere <= Data Odierna');
        return false;
    }

}

function CheckNotifica() {
    var datanotifica = $('#datanotifica').val();
    var statoScheda = $('#statoScheda').val();


    if ((datanotifica !='') && (statoScheda == 'Segnalazione')) {
        $('#datanotifica').val('');
        return false
    }

}


function CheckMalattia() {
    var datanotifica = $('#datanotifica').val();
    var statoScheda = $('#statoScheda').val();
    var idMalattiaCorrente = $('#malattia').val();

    if (idMalattia != idMalattiaCorrente) {
        $('#allerta').show();        
    }
    else {
        $('#allerta').hide();    
    }
    
}


function PrendiData(cDate) {
    var aTmp = cDate.split('/');
    var nDAy = aTmp[0];
    var nMonth = aTmp[1];
    var nYear = aTmp[2];
    return parseInt(nYear + nMonth + nDAy)

}

function autoDate() {
    var tDay = new Date();
    var tMonth = tDay.getMonth() + 1;
    var tDate = tDay.getDate();
    var tYear = tDay.getFullYear();
    if (tMonth < 10) tMonth = "0" + tMonth;
    if (tDate < 10) tDate = "0" + tDate;
    var data = tYear.toString() + '' + tMonth.toString() + '' +tDate.toString();
    return data;
}
