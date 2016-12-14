var crypto = require('crypto');

module.exports = {
    encrypt: function (callback,plaintext, key,iv) {
        var ecb =  'des-ecb';
        var enkey = new Buffer(key);
        var eniv = new Buffer(iv ? iv : 0);
        var cipher = crypto.createCipheriv(ecb, enkey, eniv);
        cipher.setAutoPadding(true)  //default true
        var ciph = cipher.update(plaintext, 'utf8', 'base64');
        ciph += cipher.final('base64');
        callback(null /* error */, ciph);
    },

    decrypt: function (callback, encrypt_text,key, iv) {
      var ecb =  'des-ecb';
      var dekey = new Buffer(key);
        var deiv = new Buffer(iv ? iv : 0);
        var decipher = crypto.createDecipheriv(ecb, dekey, deiv);
        decipher.setAutoPadding(true);
        var txt = decipher.update(encrypt_text, 'base64', 'utf8');
        txt += decipher.final('utf8');
        callback(null, txt);
    }
};