function multiEmail(obje) {
    var email_field = obje.value; 
    var email = email_field.split(',');
    for (var i = 0; i < email.length; i++) {
        if (!validateEmail(email[i], 1, 0)) {
            alert('una o più email non sono corrette');
            return false;
        }
    }
    return true;
}


function validateEmail(addr, man, db) {
    if (addr == '' && man) {
        if (db) alert('email address is mandatory');
        return false;
    }
    if (addr == '') return true;
    var invalidChars = '\/\'\\ ";:?!()[]\{\}^|';
    for (i = 0; i < invalidChars.length; i++) {
        if (addr.indexOf(invalidChars.charAt(i), 0) > -1) {
            if (db) alert('email non corretta');
            return false;
        }
    }
    for (i = 0; i < addr.length; i++) {
        if (addr.charCodeAt(i) > 127) {
            if (db) alert("email non corretta");
            return false;
        }
    }

    var atPos = addr.indexOf('@', 0);
    if (atPos == -1) {
        if (db) alert('email deve contenere  @');
        return false;
    }
    if (atPos == 0) {
        if (db) alert('email non può iniziare con un  @');
        return false;
    }
    if (addr.indexOf('@', atPos + 1) > -1) {
        if (db) alert('email deve contenere un solo @');
        return false;
    }
    if (addr.indexOf('.', atPos) == -1) {
        if (db) alert('email dee contenere un punto prima del dominio');
        return false;
    }
    if (addr.indexOf('@.', 0) != -1) {
        if (db) alert('il punto non può essere subito successivo al @');
        return false;
    }
    if (addr.indexOf('.@', 0) != -1) {
        if (db) alert('il punto non può precedere @');
        return false;
    }
    if (addr.indexOf('..', 0) != -1) {
        if (db) alert('due punti non possono essere consecutivi nella mail');
        return false;
    }
//    var suffix = addr.substring(addr.lastIndexOf('.') + 1);
//    if (suffix.length != 2 && suffix != 'com' && suffix != 'net' && suffix != 'org' && suffix != 'edu' && suffix != 'int' && suffix != 'mil' && suffix != 'gov' & suffix != 'arpa' && suffix != 'biz' && suffix != 'aero' && suffix != 'name' && suffix != 'coop' && suffix != 'info' && suffix != 'pro' && suffix != 'museum') {
//        if (db) alert('invalid primary domain in email address');
//        return false;
//    }
    return true;
}