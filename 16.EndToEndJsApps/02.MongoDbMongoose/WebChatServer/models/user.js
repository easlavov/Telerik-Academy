'use strict';

var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var userSchema = new Schema({
    name: {
        type: String,
        required: true
    },
    password: {
        type: String,
        required: true
    },
    messages: [{
        type: Schema.ObjectId,
        ref: 'Message'
    }]
});

var User = mongoose.model('User', userSchema);

module.exports = User;