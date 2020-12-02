$(function () {
    checkMalattia();
});

function checkMalattia() {
    var malattia = $('#malattia').val();

    if (malattia == '42' || malattia =='43')
    {
        $('#esito').removeAttr('disabled');
    }
    else {        
        $('#esito').attr('disabled', true);
        $('#esito').val('tutti');
    } 
}