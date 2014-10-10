var User = require('mongoose').model('User'),
    encryption = require('../utilities/encryption');

module.exports = {
    createUser: function (req, res) {
        var userData = req.body;
        console.log(req.logIn.toString());
        userData.salt = encryption.generateSalt();
        userData.hashPass = encryption.generateHashedPassword(userData.salt, userData.password);
        User.create(userData, function (err, user) {
            if (err) {
                console.log('Error registering user: ' + err);
                return;
            }

            req.logIn(user, function (err) {
                if (err) {
                    res.status(400);
                    return res.send({reason: err.toString()});
                }

                res.send(user);
            });
        });
    },
    updateUser: function (req, res) {
        if (req.user._id === req.body._id || req.user.roles.indexOf('admin') > -1) {
            var updatedUser = req.body;
            if (updatedUser.password && updatedUser.password.length > 0) {
                updatedUser.salt = encryption.generateSalt();
                updatedUser.hashPass = encryption.generateHashedPassword(updatedUser.salt, updatedUser.password);
            }

            User.update({_id: req.body._id}, updatedUser, function () {
                res.end();
            });
        }
    },
    getAllUsers: function (req, res) {
        User.find({}).exec(function (err, users) {
            if (err) {
                console.log('Loading users failed: ' + err);
            }

            res.send(users);
        });
    }
};