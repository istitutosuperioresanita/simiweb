$(function () {
//    CheckDiagnosi();
//    CheckTipizzazione();
//    CheckAltroAgente();


});

//function checkPneumoAntibiotico() {

//    var tip = $('#labBatterio').val();
//    if (tip!="3") {
//        $('#antibioticoDIV :input').attr('disabled', true);
//        $('#antibioticoDIV :input').val('');
//    } else {
//        $('#antibioticoDIV :input').removeAttr('disabled');
//    }
//}

//function CheckDiagnosi() {
//    //  if $('#altraDiagnosi').
//    if ($('#altraDiagnosi').is(':checked')) {
//        $('#altroDiagnosiDescr').removeAttr('disabled');
//    }
//    else {
//        $('#altroDiagnosiDescr').val('');
//        $('#altroDiagnosiDescr').attr('disabled', true);

//    }

//}

//function CheckAltroAgente() {
//    var agente = $('#agenteEziologico').val();
//    if (agente == '999999') {
//        $('#AltroAgente').removeAttr('disabled');
//    }
//    else {
//        $('#AltroAgente').val('');
//        $('#AltroAgente').attr('disabled', true);
//    }

//}


//function CheckTipizzazione() {

//    var tipizzazione = $('#Tipizzazione').val();

//    if (tipizzazione == 'Si') {

//        $('#LabTipizzazione').removeAttr('disabled');
//        $('#labBatterio').removeAttr('disabled');
//        $('#LabAltroBatterio').removeAttr('disabled');

//        $('#AltroSierotipo').removeAttr('disabled');

//    }
//    else {
//        $('#LabTipizzazione').attr('disabled', true);
//        $('#labBatterio').attr('disabled', true);
//        $('#LabAltroBatterio').attr('disabled', true);
//        //    $('#LabSierogruppoMen').attr('disabled', true);
//        //    $('#LabSierotipoPNU').attr('disabled', true);
//        //    $('#LabSierotipoHI').attr('disabled', true);
//        $('#AltroSierotipo').attr('disabled', true);


//        $('#LabTipizzazione').val('');
//        $('#labBatterio').val('');
//        $('#LabAltroBatterio').val('');
//        //    $('#LabSierogruppoMen').val('');
//        //    $('#LabSierotipoPNU').val('');
//        //    $('#LabSierotipoHI').val('');
//        $('#AltroSierotipo').val('');
//    }
//    checkTipizzazione();
//    
//}

//function checkTipizzazione() {


//    var tip = $('#labBatterio').val();
//    switch (tip) {

//        case '1':

//            $('#LabSierogruppoMen').removeAttr('disabled');
//            $('#LabSierotipoPNU').val('');
//            $('#LabSierotipoHI').val('');


//            $('#LabSierotipoPNU').attr('disabled', true);
//            $('#LabSierotipoHI').attr('disabled', true);
//            $('#LabAltroBatterio').attr('disabled', true);
//            $('#AltroSierotipo').attr('disabled', true);

//            break;

//        case '2':

//            $('#LabSierotipoHI').removeAttr('disabled');
//            $('#AltroSierotipo').removeAttr('disabled');


//            $('#LabSierotipoPNU').val('');
//            $('#LabSierogruppoMen').val('');


//            $('#LabSierotipoPNU').attr('disabled', true);
//            $('#LabSierogruppoMen').attr('disabled', true);
//            $('#LabAltroBatterio').attr('disabled', true);

//            break;

//        case '3':

//            $('#LabSierotipoPNU').removeAttr('disabled');
//            $('#AltroSierotipo').removeAttr('disabled');

//            $('#LabSierogruppoMen').val('');
//            $('#LabSierotipoHI').val('');

//            $('#LabSierogruppoMen').attr('disabled', true);
//            $('#LabSierotipoHI').attr('disabled', true);
//            $('#LabAltroBatterio').attr('disabled', true);
//            break;

//        default:
//            $('#LabSierogruppoMen').val('');
//            $('#LabSierotipoPNU').val('');
//            $('#LabSierotipoHI').val('');
//            $('#LabAltroBatterio').val('');
//            $('#AltroSierotipo').val('');

//            $('#AltroSierotipo').attr('disabled', true);
//            $('#LabAltroBatterio').attr('disabled', true);
//            $('#LabSierogruppoMen').attr('disabled', true);
//            $('#LabSierotipoPNU').attr('disabled', true);
//            $('#LabSierotipoHI').attr('disabled', true);
//    }
//    checkPneumoAntibiotico();
//}