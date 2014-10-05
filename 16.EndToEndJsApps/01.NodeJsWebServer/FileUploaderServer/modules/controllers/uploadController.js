var formidable = require('formidable');
var badRequestHandler = require('../services/badRequestHandler');

function uploadFile(request, response) {
    var form = new formidable.IncomingForm();
    form.uploadDir = './downloads';
    form.encoding = 'utf-8';
    form.keepExtensions = true;
    form.on('error', function (error) {
        badRequestHandler.returnBadRequest(error, 'Error uploading file!');
    });
    form.parse(request, function (err, fields, files) {
        var fileName = files['file-name'].path.substr('/downloads'.length);
        response.writeHead(200, {
            'content-type': 'text/html'
        });
        response.write('<a href="http://localhost:1234/downloads?file=' + fileName + '" download="' +
            files['file-name'].name + '">Download link</a>');
        response.end();
    });
}

module.exports = {
    uploadFile: uploadFile
};