var mongoose, connectionString, db, test;

mongoose= require('mongoose');
test = require('./data/test');

connectionString = 'localhost:9876'; // change if needed
mongoose.connect(connectionString);
db = mongoose.connection;

db.once('open', function () {
    console.log('Mongoose connected to: ' + connectionString);
    console.log('Now running scripted test!');
    test();
});

db.on('error', function (err) {
    console.log(err);
});