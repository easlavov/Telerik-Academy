var mongoose = require('mongoose'),
    User = mongoose.model('User'),
    Event = mongoose.model('Event');

function getEventById(id, callback) {
    Event.findOne({_id: id}).exec(callback);
}

module.exports = {
    createUser: function (userData, callback) {
        User.create(userData, callback);
    },
    updateUser: function (userId, newData, callback) {
        User.update({_id: userId}, newData, callback);
    },
    createEvent: function (eventData, callback) {
        Event.create(eventData, callback);
    },
    addComment: function (eventId, comment, callback) {
        getEventById(eventId, function (err, event) {
            if (err) {
                callback(err);
            } else {
                var currentComments = event.comments;
                currentComments.push(comment);

                var update = {
                    comments: currentComments
                };
                Event.update({_id: eventId}, update, callback);
            }
        });
    },
    joinEvent: function (eventId, userId, callback) {
        getEventById(eventId, function (err, event) {
            if (err) {
                callback(err);
            } else {
                User.findOne({_id: userId}, function (err, user) {
                    if (err) {
                        callback(err);
                    } else {
                        var eventPublicity = event.publicity;
                        var userInits = user.initiatives;
                        var userSeasons = user.seasons;
                        var eventUsers = event.users;
                        var username = user.username;
                        if (eventPublicity === 'Initiative-and-season-based') {
                            if (userSeasons === event.type.season &&
                                userInits === event.type.initiative) {
                                if (eventUsers.indexOf(username) > -1) {
                                    callback("You're already part of this event!");
                                } else {
                                    eventUsers.push(username);
                                    var update = {
                                        users: eventUsers
                                    };
                                    Event.update({_id: eventId}, update, callback);
                                }
                            } else {
                                callback("Can't join this event because it is Initiative-and-season-based and you don't meet the requirements!");
                            }
                        } else if (eventPublicity === 'Initiative-based') {
                            if (userInits === event.type.initiative) {
                                if (eventUsers.indexOf(username) > -1) {
                                    callback("You're already part of this event!");
                                } else {
                                    eventUsers.push(username);
                                    var update = {
                                        users: eventUsers
                                    };
                                    Event.update({_id: eventId}, update, callback);
                                }
                            } else {
                                callback("Can't join this event because it is Initiative--based and you don't meet the requirements!");
                            }
                        } else if ('Public') {
                            if (eventUsers.indexOf(username) > -1) {
                                callback("You're already part of this event!");
                            } else {
                                eventUsers.push(username);
                                var update = {
                                    users: eventUsers
                                };
                                Event.update({_id: eventId}, update, callback);
                            }
                        }
                    }
                });
            }
        });
    },
    getUserCreatedEvents: function (username, callback) {
        var currentDate = new Date();
        console.log(currentDate);
        Event.where('creator', username)
            .where('date').gt(currentDate)
            .exec(callback);
    },
    getJoinedEvents: function (username, callback) {
        var currentDate = new Date();
        Event.where('users', username)
            .where('date').gt(currentDate)
            .exec(callback);
    },
    getPassedUserEvents: function (username, callback) {
        var currentDate = new Date();
        Event.where('creator', username)
            .where('date').lt(currentDate)
            .exec(callback);
    },
    getActiveEvents: function (callback) {
        var currentDate = new Date();
        Event.where('date').gt(currentDate)
            .exec(callback);
    },
    getPassedEvents: function (callback) {
        var currentDate = new Date();
        Event.where('date').lt(currentDate)
            .exec(callback);
    },
    evaluate: function (eventId, ratings, callback) {
        getEventById(eventId, function (err, event) {
            if (err) {
                callback(err);
            } else {
                var creator = event.creator;
                var currentOrgRat = event.organizationPoints;
                var currentVenRat = event.venuePoints;
                currentOrgRat += ratings.organizationPoints;
                currentVenRat += ratings.venuePoints;
                var newData = {
                    venuePoints: currentVenRat,
                    organizationPoints: currentOrgRat
                };
                User.update({username: creator}, newData, callback);
            }
        });
    },
    getEventById: getEventById
};