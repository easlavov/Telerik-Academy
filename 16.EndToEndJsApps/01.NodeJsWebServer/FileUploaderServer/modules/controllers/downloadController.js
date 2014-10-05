var badRequestHandler = require('../services/badRequestHandler');
var fs = require('fs');
var url = require('url');

function downloadFile(request, response) {
    var query = url.parse(request.url, true);
    if (query.query.file) {
        var stream = fs.createReadStream('./downloads/' + query.query.file);
        stream.on('error', function (error) {
            badRequestHandler.returnBadRequest(error, 'Error parsing!');
        });

        response.writeHead(200);
        stream.pipe(response);
        stream.on('end', function(){
            response.end();
        });
    }
    else {
        badRequestHandler.returnBadRequest(response, 'Not a file!');
    }
}

module.exports = {
    downloadFile: downloadFile
};