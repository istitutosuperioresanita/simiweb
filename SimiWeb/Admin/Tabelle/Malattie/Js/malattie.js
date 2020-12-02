function CheckEpidemiologico() {
    //  if $('#altraDiagnosi').
  //  alert($('#tinymce').tinymce().getContent());

    if ($('#epidemiologico').is(':checked')) {
        $('#Epidemiologico_help').removeAttr('disabled');
        //   $('#Epidemiologico_help').val('');
        //tinyMCE.get('Epidemiologico_help').show();
    }
    else {
        $('#Epidemiologico_help').val('');
        $('#Epidemiologico_help').attr('disabled', true);
        tinyMCE.get('Epidemiologico_help').setContent('');
        //tinyMCE.get('Epidemiologico_help').hide();
        
    }

}
function CheckClinico() {
    //  if $('#altraDiagnosi').
    if ($('#clinico').is(':checked')) {
        $('#Clinico_help').removeAttr('disabled');
      //  $('#Clinico_help').val('n.d.');
        //tinyMCE.get('Clinico_help').show();              
    }
    else {
        $('#Clinico_help').val('');
        $('#Clinico_help').attr('disabled', true);
        tinyMCE.get('Clinico_help').setContent('');
        //tinyMCE.get('Clinico_help').hide();
    }

}
function CheckLaboratorio() {
    //  if $('#altraDiagnosi').
    if ($('#laboratorio').is(':checked')) {
        $('#Laboratorio_help').removeAttr('disabled');
        //tinyMCE.get('Laboratorio_help').show();
    }
    else {
        $('#Laboratorio_help').val('');
        $('#Laboratorio_help').attr('disabled', true);
        tinyMCE.get('Laboratorio_help').setContent('');
//        tinyMCE.get('Laboratorio_help').hide();

    }

}