$(function () {
    AbilitaVaccino();
    AbilitaResidenza();
    AbilitaEstero();
    checkProfessione();
    checkLuogoRicovero();
});


function ValidatePage() {

    if (CompareDate() == false) {
        return false;
    }

//    var bro = $.browser.version

//    if ($.browser.msie)
//        {
//        if (bro == '6.0' || bro == '7.0' || bro == '8.0' || bro =='9.0') {        
//        $('#btn').prop('disabled', true);        
//        }
//        else
//        {
//        $('#btn').attr('disabled', 'disabled');        
//        }
//    }
//    else {
//        $('#btn').attr('disabled', 'disabled');        
//    }

    return true;
    
    
      
//    if (typeof (Page_ClientValidate) == 'function') {
//        Page_ClientValidate();
//    }

//    if (Page_IsValid) {
//        // do something
//        
//        return true;   
//     //   alert('Page is valid!');
//    }
//    else {
//        // do something else
//        alert('Page is not valid!');
//        return true;
//    }
}

function CompareDate() {


var datanascita = $('#DataNascita').val();
var dataprimisintomi =$('#DataPrimiSintomi').val();
var datasegnalazione= $('#datasegnalazione').val();
var datanotifica = $('#datanotifica').val();
var statoScheda = $('#statoScheda').val();



if ((datanotifica == '') && (statoScheda == 'Notifica')) {
    alert('Inserire la data di notifica');
    return false;
}


datanascita = PrendiData(datanascita);
dataprimisintomi = PrendiData(dataprimisintomi);
datasegnalazione = PrendiData(datasegnalazione);
datanotifica = PrendiData(datanotifica);
var today = autoDate();




//alert(datanascita+'-'+dataprimisintomi + '-' + datasegnalazione+ '-' + datanotifica)
if (
    (datanascita > dataprimisintomi)
 || (datanascita > datasegnalazione)
 || ((datanascita > datanotifica)  && (statoScheda == 'Notifica'))
 ) {
    alert('Controllare la sequenza temporale delle date \n data di nascita <= data primi sintomi <= data segnalazione <= data notifica(se presente)  <= Data Odierna');
    return false;
}
if ((dataprimisintomi > datasegnalazione)
 || ((dataprimisintomi > datanotifica) && (statoScheda == 'Notifica'))
 ) {
    alert('Controllare la sequenza temporale delle date \n data primi sintomi <= data segnalazione <= data notifica(se presente)  <= Data Odierna ');
    return false;
}
if ((datasegnalazione > datanotifica) && (statoScheda == 'Notifica')) {
    alert('Controllare la sequenza temporale delle date \n data segnalazione <= data notifica(se presente)  <= Data Odierna');

    return false;
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

function checkDataNotifica(){
var statoScheda = $('#statoScheda').val();
var datanotifica = $('#datanotifica').val()
if(statoScheda == 'Segnalazione') 
    {
      $('#datanotifica').val('');
    } 
}

function checkLuogoRicovero() {
    var stato = $('#Ricovero').val();
    if (stato != 'Si') {
        $('#LuogoRicovero').attr('disabled', true);
        $('#StrutturaRicovero').attr('disabled', true);
        $('#LuogoRicovero').val('');
        $('#StrutturaRicovero').val('');
    }
    else {

        $('#LuogoRicovero').removeAttr('disabled');
        $('#StrutturaRicovero').removeAttr('disabled');
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
    var data = tYear.toString() + '' + tMonth.toString() + '' + tDate.toString();
    return data;
}

function checkProfessione() {
    var professione = $('#Professione').val();
    if (professione != '000025') {
        $('#altraProfessione').val('');
    }

}

function Showgrid() {
    var nomeT = $('#Nome').val();
    var cognomeT = $('#Cognome').val();

    if (nomeT != '' && cognomeT != '') {
        $('#PersonTableContainer').jtable('load', {
            nome: $('#Nome').val(),
            cognome: $('#Cognome').val()
        });
        $('#PersonTableContainer').show();
    }


}
function chiudi() {
    $('#PersonTableContainer').hide();
}
       
