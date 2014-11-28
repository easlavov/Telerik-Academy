var User = require('mongoose').model('User'),
    encryption = require('../utilities/encryption'),
    eventsData = require('../data/eventsData'),
    enums = require('../data/enums');

var CONTROLLER_NAME = 'users';

function getInitiatives(userData) {
    var inits = [];
    var allInits = enums.initiatives;
    for (var init in allInits) {
        var current = allInits[init];
        if (userData[current]) {
            inits.push(current);
        }
    }

    return inits;
}

function getSeasons(userData) {
    var seasons = [];
    var allSeasons = enums.seasons;
    for (var season in allSeasons) {
        var current = allSeasons[season];
        if (userData[current]) {
            seasons.push(current);
        }
    }

    return seasons;
}

function getOtherProfilesLinks(userData) {
    var links;
    if (userData.otherProfiles) {
        links = userData.otherProfiles.split(';');
    }

    return links;
}

module.exports = {
    getRegistrationForm: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/register', {
            initiatives: enums.initiatives,
            seasons: enums.seasons
        });
    },
    getLoginForm: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/login');
    },
    getProfilePage: function (req, res, next) {
        var username = req.user.username;
        eventsData.getUserCreatedEvents(username, function (err, createdEvents) {
            if (err) {
                req.session.error = err;
                res.redirect('/');
            } else {
                console.log(req.username);
                eventsData.getJoinedEvents(username, function (err, joinedEvents) {
                    if (err) {
                        req.session.error = err;
                        res.redirect('/');
                    } else {
                        eventsData.getPassedUserEvents(username, function (err, passedEvents) {
                            if (err) {
                                req.session.error = err;
                                res.redirect('/');
                            } else {
                                console.log(createdEvents);
                                console.log(joinedEvents);
                                console.log(passedEvents);
                                res.render(CONTROLLER_NAME + '/profile', {
                                    user: req.user,
                                    createdEvents: createdEvents,
                                    joinedEvents: joinedEvents,
                                    passedEvents: passedEvents
                                });
                            }
                        });
                    }
                });
            }
        });
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
        if (userData.password !== userData.confirmPassword) {
            req.session.error = "Passwords don't match!";
            res.redirect('/register');
        } else {
            userData.salt = encryption.generateSalt();
            userData.hashPass = encryption.generateHashedPassword(userData.salt, userData.password);

            var initiatives = getInitiatives(userData);
            var seasons = getSeasons(userData);
            userData.initiatives = initiatives;
            userData.seasons = seasons;

            var otherProfiles = getOtherProfilesLinks(userData);
            if (otherProfiles) {
                userData.otherProfiles = otherProfiles;
            }

            eventsData.createUser(userData, function (err, user) {
                if (err) {
                    req.session.error = err;
                    res.redirect('/register');
                }

                console.log('User ' + userData.username + ' registered successfully!');
                req.logIn(user, function (err) {
                    if (err) {
                        res.status(400);
                        return res.send({reason: err.toString()});
                    }

                    req.session.success = 'User ' + user.username + ' registered successfully';
                    res.redirect('/');
                });
            });
        }
    },
    updateUser: function (req, res, next) {
        var userId = req.user._id;
        var newInfo = req.body;

        console.log(newInfo);

        if (newInfo.otherProfiles !== '') {
            var oldLinks = req.user.otherProfiles;
            var newLinks = getOtherProfilesLinks(newInfo);
            var oldAndNewLinks = oldLinks.concat(newLinks);
            newInfo.otherProfiles = oldAndNewLinks;
        }

        eventsData.updateUser(userId, newInfo, function (err, user) {
            if (err) {
                req.session.error = err;
                res.redirect('/profile');
            } else {
                req.session.success = 'Profile updated successfully';
                res.redirect('/profile');
            }
        });


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