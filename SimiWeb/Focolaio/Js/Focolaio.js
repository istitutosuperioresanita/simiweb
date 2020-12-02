function getAgenteByMalattia(source, target) {
    source = '#' + source;
    target = '#' + target;
    var malattia = $(source).val()
    $.ajax({
        type: "POST",
        //   url: "Addnotifica.aspx/GetComuni",
        url: "../WebServices/Geografiche.asmx/GetAgenteByIdMalattia",
        data: "{'idMalattia': '" + malattia + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            AjaxSucceeded(msg, source, target);
        },
        error: AjaxFailed
    });
}
function AjaxSucceeded(result, source, target) {
    var ddl = $(target);
    ddl.find('option').remove();

    ddl.append($('<option></option>').val('').html('Selezionare...'));
    var i;
    for (i = 0; i < result.d.length; i++) {

        ddl.append($('<option></option>').val(result.d[i].Codice).html(result.d[i].Descrizione));
    };
}
function AjaxFailed(result) {
    alert(result.status + ' ' + result.statusText);
}


//function CheckNotifica() {
//    var datanotifica = $('#datanotifica').val();
//    var statoScheda = $('#statoScheda').val();

//    if ((datanotifica != '') && (statoScheda != 'Notifica')) {
//        datanotifica = '';
//        return false
//    }
//}


function CheckNotifica() {
    var datanotifica = $('#datanotifica').val();
    var statoScheda = $('#stato').val();

    if ((datanotifica != '') && (statoScheda != 'Notifica')) {
        $('#datanotifica').val('');
        return false
    }

}



function CheckInfo() {
    var numerocasi = $('#numeroCasi').val();
    var personerischio = $('#PersoneRischio').val();
    var dataInizio = $('#dataInizio').val();
    var datasegnalazione = $('#datasegnalazione').val();
    var datanotifica = $('#datanotifica').val();
    var statoScheda = $('#stato').val();
    var today = autoDate;


    if ((datanotifica == '') && (statoScheda == 'Notifica')) {
        alert('Inserire la data di notifica');
        return false;
    }

    datanotifica = PrendiData(datanotifica);
    dataInizio = PrendiData(dataInizio);
    datasegnalazione = PrendiData(datasegnalazione);



    if (parseInt(numerocasi) > parseInt(personerischio)) {
        alert('Il numero dei casi non può essere maggiore delle persone a rischio');
        return false
    }


    if (dataInizio > datasegnalazione)
    {
        alert('Controllare la sequenza temporale delle date \n la data inizio  epidemia deve essere <= data segnalazione ');
        return false;
    }

    if ((dataInizio > datanotifica) && (statoScheda == 'Notifica')) {

        alert('Controllare la sequenza temporale delle date \n la data inizio  epidemia deve essere <= data notifica ');
        return false;
    }
   
    if ((datasegnalazione > datanotifica) && (statoScheda == 'Notifica')) {
        alert('Controllare la sequenza temporale delle date \n la data segnalazione deve essere <= data notifica');
        return false
    }

    if (datasegnalazione > today) {
        alert('Controllare la sequenza temporale delle date la data segnalazione <= Data Odierna');
        return false;
    }

    if ((datanotifica > today) && (statoScheda == 'Notifica')) {
        alert('Controllare la sequenza temporale delle date data notifica <= Data Odierna');
        return false;
    }
    return true
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
    if (tMonth < 10) tMonth = "0" + tMonth;
    if (tDate < 10) tDate = "0" + tDate;
    return parseInt(tDay.getFullYear() + tMonth + tDate);
}