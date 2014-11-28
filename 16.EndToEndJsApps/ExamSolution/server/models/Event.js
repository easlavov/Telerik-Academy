var mongoose = require('mongoose'),
    Schema = mongoose.Schema;
//    User = mongoose.model('User');

var eventSchema = new mongoose.Schema({
    title: {type: String, required: true},
    description: {type: String, required: true},
    location: String,
    date: Date,
    category: {type: String, required: true},
    type: {
        initiative: {type: String, required: true},
        season: {type: String, required: true}
    },
    publicity: String,
    phone: {type: String, required: true},
    creator: {type: String, required: true},
    comments: [String],
    users: [String]
});

var Event = mongoose.model('Event', eventSchema);

module.exports = Event;