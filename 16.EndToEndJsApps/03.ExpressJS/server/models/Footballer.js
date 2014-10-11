var mongoose = require('mongoose'),
    Schema = mongoose.Schema;

var footballerSchema = new mongoose.Schema({
    name: {type: String, required: true},
    age: {type: Number, required: true},
    position: String,
    club: String
});

var Footballer = mongoose.model('Footballer', footballerSchema);

module.exports = Footballer;