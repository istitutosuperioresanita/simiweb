$(function () {
    CheckDiagnosi();
    CheckTipizzazione();
    CheckAltroAgente();
    checkPneumoAntibiotico();
    checkEsito();
    checkCondizioni();
    checkSequele();


});

function checkEsito() {
    var esito = $('#Esito').val();
    if (esito == 'deceduto') {
        $('#Esito14Giorni').val('deceduto');
        $('#Esito14Giorni').attr('disabled', true);
    }
    else {

        $('#Esito14Giorni').val('');
        $('#Esito14Giorni').removeAttr('disabled');
    }

}
function checkPneumoAntibiotico() {



    var tip = $('#antibioticoResistenza').val();
    if (tip=="No") {
        $('#antibioticoDIV :input').attr('disabled', true);
        $('#antibioticoDIV :input').val('');
    } else {
        $('#antibioticoDIV :input').removeAttr('disabled');
    }
}

function CheckDiagnosi() {
    //  if $('#altraDiagnosi').
    if ($('#altraDiagnosi').is(':checked')) {
        $('#altroDiagnosiDescr').removeAttr('disabled');
    }
    else {
        $('#altroDiagnosiDescr').val('');
        $('#altroDiagnosiDescr').attr('disabled', true);

    }

}

function CheckAltroAgente() {
    var agente = $('#agenteEziologico').val();
    if (agente == '999999') {
        $('#AltroAgente').removeAttr('disabled');
    }
    else {
        $('#AltroAgente').val('');
        $('#AltroAgente').attr('disabled', true);
    }

}


function CheckTipizzazione() {

    var tipizzazione = $('#Tipizzazione').val();

    if (tipizzazione == 'Si') {

        $('#LabTipizzazione').removeAttr('disabled');
        $('#labBatterio').removeAttr('disabled');
        $('#LabAltroBatterio').removeAttr('disabled');

        $('#AltroSierotipo').removeAttr('disabled');

    }
    else {
        $('#LabTipizzazione').attr('disabled', true);
        $('#labBatterio').attr('disabled', true);
        $('#LabAltroBatterio').attr('disabled', true);
        //    $('#LabSierogruppoMen').attr('disabled', true);
        //    $('#LabSierotipoPNU').attr('disabled', true);
        //    $('#LabSierotipoHI').attr('disabled', true);
        $('#AltroSierotipo').attr('disabled', true);


        $('#LabTipizzazione').val('');
        $('#labBatterio').val('');
        $('#LabAltroBatterio').val('');
        //    $('#LabSierogruppoMen').val('');
        //    $('#LabSierotipoPNU').val('');
        //    $('#LabSierotipoHI').val('');
        $('#AltroSierotipo').val('');
    }
    checkTipizzazione();
    
}

function checkTipizzazione() {


    var tip = $('#labBatterio').val();
    switch (tip) {

        case '1':

            $('#LabSierogruppoMen').removeAttr('disabled');
            $('#LabSierotipoPNU').val('');
            $('#LabSierotipoHI').val('');


            $('#LabSierotipoPNU').attr('disabled', true);
            $('#LabSierotipoHI').attr('disabled', true);
            $('#LabAltroBatterio').attr('disabled', true);
            $('#AltroSierotipo').attr('disabled', true);

            break;

        case '2':

            $('#LabSierotipoHI').removeAttr('disabled');
            $('#AltroSierotipo').removeAttr('disabled');


            $('#LabSierotipoPNU').val('');
            $('#LabSierogruppoMen').val('');


            $('#LabSierotipoPNU').attr('disabled', true);
            $('#LabSierogruppoMen').attr('disabled', true);
            $('#LabAltroBatterio').attr('disabled', true);

            break;

        case '3':

            $('#LabSierotipoPNU').removeAttr('disabled');
            $('#AltroSierotipo').removeAttr('disabled');

            $('#LabSierogruppoMen').val('');
            $('#LabSierotipoHI').val('');

            $('#LabSierogruppoMen').attr('disabled', true);
            $('#LabSierotipoHI').attr('disabled', true);
            $('#LabAltroBatterio').attr('disabled', true);
            break;

        default:
            $('#LabSierogruppoMen').val('');
            $('#LabSierotipoPNU').val('');
            $('#LabSierotipoHI').val('');
            $('#LabAltroBatterio').val('');
            $('#AltroSierotipo').val('');

            $('#AltroSierotipo').attr('disabled', true);
            $('#LabAltroBatterio').attr('disabled', true);
            $('#LabSierogruppoMen').attr('disabled', true);
            $('#LabSierotipoPNU').attr('disabled', true);
            $('#LabSierotipoHI').attr('disabled', true);
    }
    //checkPneumoAntibiotico();
}
function checkSequele()
{
    if ($('#sequele').val() != 'si')
    {
    $('#SequeleUdito').attr('disabled', true);
    $('#SequeleAmputazione').attr('disabled', true);
    $('#SequelVista').attr('disabled', true);
    $('#SequeleNecrosi').attr('disabled', true);
    $('#SequeleNeuro').attr('disabled', true);
    $('#SequeleAltro').attr('disabled', true);
    $('#SequeleAltroSpecificare').attr('disabled', true);

    $('#SequeleUdito').prop('checked', false)
    $('#SequeleAmputazione').prop('checked', false)
    $('#SequelVista').prop('checked', false)
    $('#SequeleNecrosi').prop('checked', false)
    $('#SequeleNeuro').prop('checked', false)
    $('#SequeleAltro').prop('checked', false)
    $('#SequeleAltroSpecificare').val('')
    
    }
    else
    {
    $('#SequeleUdito').removeAttr('disabled');
    $('#SequeleAmputazione').removeAttr('disabled');
    $('#SequelVista').removeAttr('disabled');
    $('#SequeleNecrosi').removeAttr('disabled');
    $('#SequeleNeuro').removeAttr('disabled');
    $('#SequeleAltro').removeAttr('disabled');
    $('#SequeleAltroSpecificare').removeAttr('disabled');
}
}


function checkCondizioni()  
  {
    if ($('#fattori').val() != 'si')
      {
          $('#Asplenia').attr('disabled', true);
          $('#Immunodeficienza').attr('disabled', true);
		
          $('#Leucemie').attr('disabled', true);
          $('#Neoplasie').attr('disabled', true);
          $('#TerapieImmuno').attr('disabled', true);
		
          $('#Altrocondizione').attr('disabled', true);
          $('#Trapianto').attr('disabled', true);
          $('#Cocleare').attr('disabled', true)
		
          $('#Fistole').attr('disabled', true);
          $('#Immunodeficienzaacquisita').attr('disabled', true);
          $('#Insufficenzarenale').attr('disabled', true);
		
          $('#Diabete').attr('disabled', true);
          $('#Epatopatia').attr('disabled', true);
          $('#Cardiopatie').attr('disabled', true);
		
          $('#Asma').attr('disabled', true);
          $('#Tossicodipendenza').attr('disabled', true);
          $('#Alcolismo').attr('disabled', true);
		
          $('#Tabagismo').attr('disabled', true);
		
          $('#Asplenia').attr('disabled', true);
          $('#Immunodeficienza').attr('disabled', true);
		
          $('#Leucemie').attr('disabled', true);
          $('#Neoplasie').attr('disabled', true);
          $('#TerapieImmuno').attr('disabled', true);
		
          $('#Altrocondizione').attr('disabled', true);
          $('#Trapianto').attr('disabled', true);
          $('#Cocleare').attr('disabled', true);
		
          $('#Fistole').attr('disabled', true);
          $('#Immunodeficienzaacquisita').attr('disabled', true);
          $('#Insufficenzarenale').attr('disabled', true);
		
          $('#Diabete').attr('disabled', true);
          $('#Epatopatia').attr('disabled', true);
          $('#Cardiopatie').attr('disabled', true);
		
          $('#Asma').attr('disabled', true);
          $('#Tossicodipendenza').attr('disabled', true);
          $('#Alcolismo').attr('disabled', true);
		
          $('#Tabagismo').attr('disabled', true);
          $('#Asplenia').prop('checked', false)
          $('#Immunodeficienza').prop('checked', false)

          $('#Leucemie').prop('checked', false)
          $('#Neoplasie').prop('checked', false)
          $('#TerapieImmuno').prop('checked', false)

          $('#Altrocondizione').prop('checked', false)
          $('#Trapianto').prop('checked', false)
          $('#Cocleare').attr('disabled', true)

          $('#Fistole').prop('checked', false)
          $('#Immunodeficienzaacquisita').prop('checked', false)
          $('#Insufficenzarenale').prop('checked', false)

          $('#Diabete').prop('checked', false)
          $('#Epatopatia').prop('checked', false)
          $('#Cardiopatie').prop('checked', false)

          $('#Asma').prop('checked', false)
          $('#Tossicodipendenza').prop('checked', false)
          $('#Alcolismo').prop('checked', false)

          $('#Tabagismo').prop('checked', false)

          $('#Asplenia').prop('checked', false)
          $('#Immunodeficienza').prop('checked', false)

          $('#Leucemie').prop('checked', false)
          $('#Neoplasie').prop('checked', false)
          $('#TerapieImmuno').prop('checked', false)

          $('#Altrocondizione').prop('checked', false)
          $('#Trapianto').prop('checked', false)
          $('#Cocleare').prop('checked', false)

          $('#Fistole').prop('checked', false)
          $('#Immunodeficienzaacquisita').prop('checked', false)
          $('#Insufficenzarenale').prop('checked', false)

          $('#Diabete').prop('checked', false)
          $('#Epatopatia').prop('checked', false)
          $('#Cardiopatie').prop('checked', false)

          $('#Asma').prop('checked', false)
          $('#Tossicodipendenza').prop('checked', false)
          $('#Alcolismo').prop('checked', false)

          $('#Tabagismo').prop('checked', false)
          $('#Tabagismo').prop('checked', false)
          $('#AltraCondizionedescrizione').attr('disabled', true);
          $('#AltraCondizionedescrizione').val('');
      }
      else
      {
          $('#Asplenia').removeAttr('disabled');
          $('#Immunodeficienza').removeAttr('disabled');
		
          $('#Leucemie').removeAttr('disabled');
          $('#neoplasie').removeAttr('disabled');
          $('#TerapieImmuno').removeAttr('disabled');
		
          $('#Altrocondizione').removeAttr('disabled');
          $('#Trapianto').removeAttr('disabled');
          $('#Cocleare').removeAttr('disabled');
		
          $('#Fistole').removeAttr('disabled');
          $('#Immunodeficienzaacquisita').removeAttr('disabled');
          $('#Insufficenzarenale').removeAttr('disabled');
		
          $('#Diabete').removeAttr('disabled');
          $('#Epatopatia').removeAttr('disabled');
          $('#Cardiopatie').removeAttr('disabled');
		
          $('#Asma').removeAttr('disabled');
          $('#Tossicodipendenza').removeAttr('disabled');
          $('#Alcolismo').removeAttr('disabled');
		
          $('#Tabagismo').removeAttr('disabled');
		
          $('#Asplenia').removeAttr('disabled');
          $('#Immunodeficienza').removeAttr('disabled');
		
          $('#Leucemie').removeAttr('disabled');
          $('#Neoplasie').removeAttr('disabled');
          $('#TerapieImmuno').removeAttr('disabled');
		
          $('#Altrocondizione').removeAttr('disabled');
          $('#Trapianto').removeAttr('disabled');
          $('#cocleare').removeAttr('disabled');
		
          $('#Fistole').removeAttr('disabled');
          $('#Immunodeficienzaacquisita').removeAttr('disabled');
          $('#Insufficenzarenale').removeAttr('disabled');
		
          $('#Diabete').removeAttr('disabled');
          $('#Epatopatia').removeAttr('disabled');
          $('#Cardiopatie').removeAttr('disabled');
		
          $('#Asma').removeAttr('disabled');
          $('#Tossicodipendenza').removeAttr('disabled');
          $('#Alcolismo').removeAttr('disabled');
		
          $('#Tabagismo').removeAttr('disabled');


          $('#AltraCondizionedescrizione').removeAttr('disabled');
          
      }

  }