var User = require('mongoose').model('User'),
    encryption = require('../utilities/encryption');

var CONTROLLER_NAME = 'users';

module.exports = {
    getRegistrationForm: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/register');
    },
    getLoginForm: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/login');
    },
    postLogin: function (req, res, next) {
        if (req.user) {
            res.redirect('/');
        } else {
            res.redirect('/login');
        }
    },
    createUser: function (req, res, next) {
        var userData = req.body;
        console.log(userData);
        userData.salt = encryption.generateSalt();
        userData.hashPass = encryption.generateHashedPassword(userData.salt, userData.password);
        User.create(userData, function (err, user) {
            if (err) {
                console.log('Error registering user: ' + err);
                return;
            }

            console.log('User ' + userData.username + ' registered successfully!');
            req.logIn(user, function (err) {
                if (err) {
                    res.status(400);
                    return res.send({reason: err.toString()});
                }

                res.redirect('/');
            });
        });
    },
    updateUser: function (req, res, next) {
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