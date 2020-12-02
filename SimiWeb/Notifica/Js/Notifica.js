$(function () {
    checkPermanenza();
});


function CopiaGeografiche(sourceA, sourceB, targetA1, targetB1, targetA2, targetB2) {
    // Carico Valori
    sourceA = '#' + sourceA;
    sourceB = '#' + sourceB;

   var sourceValueA = $(sourceA).val();
   var sourceValueB = $(sourceB).val();

    if (sourceValueA == '' || sourceValueB == '') {
        alert('Prima di copiare bisogna valorizzare entrambi i campi');
    return false;
    }
    sourceA =  sourceA + ' > option';
    sourceB =  sourceB + ' > option';
// Controllo Parametri
    if (targetA1 != '' && targetB1 != '') {
        targetA1 = '#' + targetA1;
        targetB1 = '#' + targetB1;

        $(targetA1).find('option').remove();
        $(targetB1).find('option').remove();

        $(sourceA).clone().appendTo(targetA1);
        $(targetA1).val(sourceValueA);

        $(sourceB).clone().appendTo(targetB1);
        $(targetB1).val(sourceValueB);
    }

    if (targetA2 != '' && targetB2 != '') {

        targetA2 = '#' + targetA2
        targetB2 = '#' + targetB2

        $(targetA2).find('option').remove();
        $(targetB2).find('option').remove();


        $(sourceA).clone().appendTo(targetA2);
        $(targetA1).val(sourceValueA);

        $(sourceB).clone().appendTo(targetB2);
        $(targetB2).val(sourceValueB);
        
    }
}

function AbilitaResidenza() {

    var stato = $('#SenzaFissaDimora').val();

    if (stato =='Si') {

        $('#ProvinciaResidenza').attr('disabled', true);
        $('#ComuneResidenza').attr('disabled', true);
        $('#IndirizzoResidenza').attr('disabled', true);

        $('#NazioneResidenza').attr('disabled', true);

        $('#ProvinciaResidenza').val('');
        $('#ComuneResidenza').val('');
        $('#IndirizzoResidenza').val('');
        $('#NazioneResidenza').val('');
        
        $('#ComuneResidenza').find('option').remove();
        $('#CopiaResidenza').attr('disabled', true);
        
    }
    else {
        $('#ProvinciaResidenza').removeAttr('disabled');
        $('#ComuneResidenza').removeAttr('disabled');
        $('#NazioneResidenza').removeAttr('disabled');

        $('#ComuneResidenza').find('option').remove();
        $('#IndirizzoResidenza').removeAttr('disabled');
        $('#ComuneResidenza').append($('<option></option>').val('').html('Selezionare...'));
        $('#CopiaResidenza').removeAttr('disabled');
    }
}

function AbilitaEstero() {

    var stato = $('#NatoEstero').val();

    if (stato == 'Si' || stato == 'ni' || stato =='') {

        $('#ComuneNascita').val('');
        $('#ProvinciaNascita').val('');
        $('#ProvinciaNascita').attr('disabled', true);
        $('#ComuneNascita').attr('disabled', true);
        $('#CopiaNascita').attr('disabled', true);
        $('#ComuneNascita').find('option').remove();


        $('#arrivoItalia').removeAttr('disabled');


        if (stato == 'ni' || stato == '') {
            $('#NazioneNascita').attr('disabled', true);
            $('#NazioneNascita').val('');
        }
        else {
            $('#NazioneNascita').removeAttr('disabled');
            $('#NazioneNascita').val('');

        }
        


    }
    else {
        $('#ProvinciaNascita').removeAttr('disabled');
        $('#ComuneNascita').removeAttr('disabled');
        $('#ComuneNascita').find('option').remove();
        $('#ComuneNascita').append($('<option></option>').val('').html('Selezionare...'));
        $('#CopiaNascita').removeAttr('disabled');

        $('#arrivoItalia').val('');
        $('#arrivoItalia').attr('disabled', true);

        $('#NazioneNascita').attr('disabled', true);
        $('#NazioneNascita').val('000');
    }
}
function checkProfessione() {
    var professione = $('#Professione').val();
    if (professione != '000025') {
        $('#altraProfessione').val('');
    }

}
function checkEstero() { 

    var stato = $('#NatoEstero').val();

    if (stato == 'Si') {
            $('#arrivoItalia').removeAttr('disabled');
    }
    else {
        $('#arrivoItalia').val('');
        $('#arrivoItalia').attr('disabled', true);
    }
}

function scorciatoia(sourceA,valore) {

    var a = valore;
    sourceA = '#' + sourceA;
    $(sourceA).val(a);
    $(document).scrollTop(1000);
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
function checkPermanenza()
{
    var centro = $('#centroPermanenza').val();
    
    if (centro != 'Si') {
        $('#NomeCentroPermanenza').attr('disabled', true);
        $('#NomeCentroPermanenza').val('');
        
    }
    else {

        
        $('#NomeCentroPermanenza').removeAttr('disabled');
    }
}

