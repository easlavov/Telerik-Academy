var filesData = require('../services/filesData');
var guid = require('guid');
var badRequestHandler = require('../services/badRequestHandler');

function downloadFile(params, response) {
    var id = params[1];
    if (!guid.isGuid(id)) {
        var message = 'The ID of the file must be a GUID';
        badRequestHandler.returnBadRequest(response, message);
        return;
    }

    // TODO: check if file with such GUID exists

    // TODO: dispatch file

    response.end(id);
}

module.exports = {
    downloadFile: downloadFile
};