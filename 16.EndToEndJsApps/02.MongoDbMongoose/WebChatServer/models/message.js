'use strict';

var mongoose = require('mongoose');
var Schema = mongoose.Schema;
var messageSchema = new Schema({
    from: {
        type: Schema.ObjectId,
        ref: 'User',
        required: true
    },
    to: {
        type: Schema.ObjectId,
        ref: 'User',
        required: true
    },
    text: {
        type: String,
        required: true
    }
});

var Message = mongoose.model('Message', messageSchema);

module.exports = Message;