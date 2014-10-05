var http = require('http');
var listeningPort = require('./config').listeningPort;

var requestHandler = require('./modules/requestHandler');

var server = http.createServer(function(req, res) {
    requestHandler.handleRequest(req, res);
});
server.listen(listeningPort);

console.log('Server listening on port ' + listeningPort);

// MongoDb test
var mongo = require('./modules/data/filesDatabase');
