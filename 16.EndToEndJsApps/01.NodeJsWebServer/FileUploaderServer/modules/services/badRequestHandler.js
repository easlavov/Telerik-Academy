function returnBadRequest(response, message) {
    var statusCode = 404;
    response.writeHead(statusCode);
    response.end(message);
}

module.exports = {
    returnBadRequest: returnBadRequest
};