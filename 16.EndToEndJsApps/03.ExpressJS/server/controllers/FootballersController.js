var Footballer = require('mongoose').model('Footballer');

var CONTROLLER_NAME = 'footballers';

module.exports = {
    displayFootballers: function (req, res, next) {
        Footballer.find().exec(function (err, result) {
            res.render(CONTROLLER_NAME + '/all', {allFootballers: result});
        });
    },
    getAddFootballerForm: function (req, res, next) {
        if (!req.user) {
            req.session.error = 'You must be logged in to access this feature!';
            res.redirect('/');
        }
        res.render(CONTROLLER_NAME + '/add');
    },
    add: function (req, res, next) {
        var data = req.body;
        Footballer.create(data, function (err, footballer) {
            if (err) {
                req.session.error = 'Error registering user: ' + err;
                res.redirect('/footballers');
            } else {
                // CAN BREAK?
                req.session.success = 'Player ' + footballer.name + ' added successfully!';
                res.redirect('/footballers');
            }
        });
    }
};