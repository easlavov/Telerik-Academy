var mongoose = require('mongoose'),
    encryption = require('../utilities/encryption');

// TODO: Validate fields
var userSchema = new mongoose.Schema({
    username: {type: String, required: true, unique: true },
    salt: String,
    hashPass: {type: String},
    firstName: {type: String, required: true},
    lastName: {type: String, required: true},
    email: {type: String, required: true},
    phone: String,
    organizationPoints: {type: Number, required: true, default: 0, min: 0, max: 5},
    venuePoints: {type: Number, required: true, default: 0, min: 0, max: 5},
    initiatives: {type: [String], required: true},
    seasons: {type: [String], required: true},
    otherProfiles: [String]
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