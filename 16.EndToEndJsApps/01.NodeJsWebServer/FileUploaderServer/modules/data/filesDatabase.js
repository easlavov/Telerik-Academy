var db;
var mongoose = require('mongoose');
var mongoDbUrl = require('../../config').mongoDbUrl;

mongoose.connect(mongoDbUrl);
db = mongoose.connection;

db.once('open', function () {
    console.log('Successfully connected to MongoDb!');
    initiateModels(db);
});

db.on('error', function (err) {
    console.log(err)
});

function initiateModels(database) {
    var fileSchema = new mongoose.Schema({
        id: {type: String, required: true},
        name: {type: String, required: true},
        data: {type: [], required: true},
        path: {type: String, required: true}
    });

    var File = mongoose.model('File', fileSchema);
}