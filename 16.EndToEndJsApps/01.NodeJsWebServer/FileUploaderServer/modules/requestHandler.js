var uploadController = require('./controllers/uploadController');
var downloadController = require('./controllers/downloadController');
var badRequestHandler = require('./services/badRequestHandler');

function handleRequest(request, response) {
    var route = request.url;
    var params = getRouteParams(route);
    var controller = params[0];
    switch (controller) {
        case 'upload':
            uploadController.uploadFile(request, response);
            break;
        case 'download':
            downloadController.downloadFile(params, response);
            break;
        default :
            var message = 'The requested resource could not be found!';
            badRequestHandler.returnBadRequest(response, message);
            break
    }
}

function getRouteParams(route) {
    var trimmedRoute = route.slice(1);
    var params = trimmedRoute.split('/');
    return params;
}

module.exports = {
    handleRequest: handleRequest
};