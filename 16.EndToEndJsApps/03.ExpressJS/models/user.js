var mongoose = require('mongoose'),
    encryption = require('../utilities/encryption');

var userSchema = new mongoose.Schema({
    username: {type: String, require: '{PATH} is required', unique: true },
    firstName: {type: String, require: '{PATH} is required'},
    lastName: {type: String, require: '{PATH} is required'},
    salt: {type: String},
    hashPass: {type: String},
    roles: [String]
});

userSchema.method({
    authenticate: function (password) {
        if (encryption.generateHashedPassword(this.salt, password) === this.hashPass) {
            return true;
        } else {
            return false;
        }
    }
});

var User = mongoose.model('User', userSchema);

// TODO: Seeding of users?