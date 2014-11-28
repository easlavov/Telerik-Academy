var express = require('express');

var env = process.env.NODE_ENV || 'development';

var app = express();
var config = require('./config/config')[env];


require('./config/mongoose')(config);
require('./config/passport')();
require('./config/express')(app, config);
require('./config/routes')(app);

app.listen(config.port);
console.log('Server listening on port: ' + config.port);