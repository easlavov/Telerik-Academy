var Event = require('mongoose').model('Event'),
    eventsData = require('../data/eventsData'),
    enums = require('../data/enums');

var CONTROLLER_NAME = 'events';

function evaluate(req, res, next) {
    var id = req.params.id;
    var body = req.body;
    var orgRating = body.organizationPoints;
    var venRating = body.venuePoints;
    var info = {
        venuePoints: venRating,
        organizationPoints: orgRating
    };

    eventsData.evaluate(id, info, function (err) {
        if (err) {
            req.session.error = err;
            res.redirect('/');
        } else {
            req.session.success = 'Ratings added successfully!';
            res.render(CONTROLLER_NAME + '/events/' + id);
        }
    });
}

module.exports = {
    getEventCreationForm: function (req, res, next) {
        if (req.user.phone === '') {
            req.session.error = 'You must add a phone number to your profile in order to create events!';
            res.redirect('/');
        } else {
            res.render(CONTROLLER_NAME + '/create', {
                phone: req.user.phone,
                initiatives: enums.initiatives,
                seasons: enums.seasons,
                categories: enums.categories,
                publicity: enums.publicity
            });
        }
    },
    create: function (req, res, next) {
        var eventData = req.body;

        var creator = req.user.username;
        var type = {
            initiative: eventData.initiative,
            season: eventData.season
        };

        eventData.creator = creator;
        eventData.type = type;

        eventsData.createEvent(eventData, function (err, event) {
            if (err) {
                req.session.error = err;
                res.redirect('/events/create');
            } else {
                req.session.success = 'Event ' + event.title + ' created successfully';
                res.redirect('/'); // TODO: Redirect to a better place
            }
        });
    },
    details: function (req, res, next) {
        var id = req.params.id;
        eventsData.getEventById(id, function (err, event) {
            var currentDate = new Date();
            var passed = false;
            if (event.date < currentDate) {
                passed = true;
            }
            res.render(CONTROLLER_NAME + '/details', {event: event, passed: passed});
        });
    },
    active: function (req, res, next) {
        eventsData.getActiveEvents(function (err, events) {
            if (err) {
                req.session.error = err;
                res.redirect('/');
            } else {
                res.render(CONTROLLER_NAME + '/active', {events: events});
            }
        });
    },
    passed: function (req, res, next) {
        eventsData.getPassedEvents(function (err, events) {
            if (err) {
                req.session.error = err;
                res.redirect('/');
            } else {
                res.render(CONTROLLER_NAME + '/active', {events: events});
            }
        });
    },
    comment: function (req, res, next) {
        if (!req.body.comment) {
            evaluate(req,res, next);
        } else {

            var body = req.body;
            var id = body.id;
            var comment = body.comment;
            eventsData.addComment(id, comment, function (err, ev) {
                if (err) {
                    req.session.error = err;
                } else {
                    req.session.success = 'Comment posted successfully!';
                }

                res.redirect('/events/' + id);
            });
        }
    },
    join: function (req, res, next) {
        var eventId = req.params.id;
        var userId = req.user._id;
        console.log(eventId);
        eventsData.joinEvent(eventId, userId, function (err, ev) {
            if (err) {
                console.log(err);
                req.session.error = err;
            } else {
                req.session.success = 'Joined successfully!';
            }

            res.redirect('/events/' + eventId);
        });
    },
    evaluate: evaluate
};