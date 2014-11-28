var mongoose = require('mongoose'),
    // Loading all schemas and models
    user = require('../models/User'),
    event = require('../models/Event');

module.exports = function (config) {
    mongoose.connect(config.db);
    var db = mongoose.connection;
    
    db.once('open', function (err) {
        if (err) {
            console.log(err);
        }

        console.log('Database running on : ' + config.db);
        seedDb();
    });

    db.on('error', function (err) {
        console.log('Database error: ' + err);
    });

    function seedDb() {
        // seed 1
        // seed 2 ...
    }
};