var mongoose = require('mongoose'),
    Schema = mongoose.Schema,
    footballerSchema = mongoose.model('Footballer');

var clubSchema = new Schema({
    name: {type: String, required: true},
    nationality: String,
    footballers: [footballerSchema]
});