function AbilitaSintomi() {

    var stato = $('#NazioneSintomi').val();

    if (stato != '000') {

        $('#ProvinciaSintomi').attr('disabled', true);
        $('#ComuneSintomi').attr('disabled', true);

        $('#ProvinciaSintomi').val('');
        $('#ComuneSintomi').val('');

        $('#ProvinciaSintomi').find('option').remove();
        $('#ComuneSintomi').find('option').remove();
    }
    else {
        $('#ProvinciaSintomi').removeAttr('disabled');
        $('#ComuneSintomi').removeAttr('disabled');

        $('#ComuneSintomi').find('option').remove();
        $('#ProvinciaSintomi').find('option').remove();
        getProvince('ProvinciaSintomi',stato);
       // $('#ProvinciaSintomi').append($('<option></option>').val('').html('Selezionare...'));
        //$('#ComuneSintomi').append($('<option></option>').val('').html('Selezionare...'));

    }
}
function AbilitaRicovero() {

    var stato = $('#Ricovero').val();

    if (stato != 'Si') {

        $('#LuogoRicovero').attr('disabled', true);
        $('#Reparto').attr('disabled', true);
        $('#MotivoRicovero').attr('disabled', true);
        $('#DataRicovero').attr('disabled', true);
        $('#DataDimissione').attr('disabled', true);
        $('#StrutturaRicovero').attr('disabled', true);
        $('#LuogoRicovero').val('');
        $('#Reparto').val('');
        $('#MotivoRicovero').val('');
        $('#DataRicovero').val('');
        $('#DataDimissione').val('');
        $('#StrutturaRicovero').val('');
    }
    else {

        $('#LuogoRicovero').removeAttr('disabled');
        $('#Reparto').removeAttr('disabled');
        $('#MotivoRicovero').removeAttr('disabled');
        $('#DataRicovero').removeAttr('disabled');
        $('#DataDimissione').removeAttr('disabled');
        $('#StrutturaRicovero').removeAttr('disabled');

    }
}

function abilitaContatto()
{
    var stato = $('#contagio').val();
    if (stato == 'No') {
        $('#contagioDove').attr('disabled', true);
        $('#contagioDove').val('');
    }
    else {
        $('#contagioDove').removeAttr('disabled');
    }
}
function abilitaFocolaio() {
    var stato = $('#focolaio').val();
    if (stato == 'No') {
        $('#focolaioDescrizione').attr('disabled', true);
        $('#focolaioDescrizione').val('');
    }
    else {
        $('#focolaioDescrizione').removeAttr('disabled');
    }
}
function AbilitaEsposizione() {

    var stato = $('#Viaggio').val();

    if (stato == 'Si') {

        CaricaNazioni('Nazione1');
        CaricaNazioni('Nazione2');
        CaricaNazioni('Nazione3');
//        var nazione1 = '#Nazione1';
//        var nazione2 = $('#Nazione2');
//        var nazione3 = $('#Nazione3');

//        $(nazione1).clone().appendTo(nazione2);
//        $(nazione1).clone().appendTo(nazione3);

    }
    else {
        $('#Nazione1').find('option').remove();
        $('#Nazione2').find('option').remove();
        $('#Nazione3').find('option').remove();
    }
    checkPeriodo();
}
function AbilitaVaccino() {
    var stato = $('#StatoVaccinale').val();
   
    if (stato != 'vaccinato') {
        $('#DoseVaccino').attr('disabled', true);
        $('#DataDoseVaccino').attr('disabled', true);        
        $('#DoseVaccino').val('');
        $('#DataDoseVaccino').val('');  
    }
    else {

        $('#DoseVaccino').removeAttr('disabled');
        $('#DataDoseVaccino').removeAttr('disabled');
    }

}
function AbilitaContagio() {

    var stato = $('#NazioneContagio').val();

    if (stato != '000') {

        $('#ProvinciaContagio').attr('disabled', true);
        $('#ComuneContagio').attr('disabled', true);

        $('#ProvinciaContagio').val('');
        $('#ComuneContagio').val('');

        $('#ProvinciaContagio').find('option').remove();
        $('#ComuneContagio').find('option').remove();
    }
    else {
        $('#ProvinciaContagio').removeAttr('disabled');
        $('#ComuneContagio').removeAttr('disabled');
        $('#ProvinciaContagio').find('option').remove();
        $('#ComuneContagio').find('option').remove();
        getProvince('ProvinciaContagio', stato);


    }
}

function ImpostaItalia(sourceA,tipo) {

    sourceA = '#' + sourceA;
    $(sourceA).val('000');
    if (tipo == 'sintomi') {
        AbilitaSintomi();
    }
    if (tipo == 'contagio') {
        AbilitaContagio();
    }
}


function CompareDate() {
    var datanascita = $('#DataNascita').val();
    var dataprimisintomi = $('#DataPrimiSintomi').val();
    var datasegnalazione = $('#datasegnalazione').val();

    datanascita = PrendiData(datanascita);
    dataprimisintomi = PrendiData(dataprimisintomi);
    datasegnalazione = PrendiData(datasegnalazione);


    if ((datanascita > dataprimisintomi) || (dataprimisintomi > datasegnalazione))
    {
        alert('Controllare la sequenza temporale delle date \n la data primi sintomi deve essere >= ' + $('#DataNascita').val() + '(data di nascita) \n la data primi sintomi deve essere <= ' + $('#datasegnalazione').val() + ' (data segnalazione)');
        return false;
    }
    return true;
}

function PrendiData(cDate) {
    var aTmp = cDate.split('/');
    var nDAy = aTmp[0];
    var nMonth = aTmp[1];
    var nYear = aTmp[2];
    return parseInt(nYear + nMonth + nDAy)

}
function AbilitaCollettivita() {
    var colettivita = $('#Collettivita').val();   
    if (colettivita != '999999') {
        $('#AltreColettivita').val('');
    }
}

function checkPeriodo() {
    var nazione1 = $('#Nazione1').val();
    var nazione2 = $('#Nazione2').val();
    var nazione3 = $('#Nazione3').val();

    if ((nazione1 =='')||(nazione1 ==null)) {
        $('#Nazione1Periodo').val('');
    }
    if ((nazione2 == '') || (nazione1 == null)) {
        $('#Nazione2Periodo').val('');
    }
    if ((nazione3 == '') || (nazione1 == null)) {
        $('#Nazione3Periodo').val('');
    }

}