var Footballer = require('mongoose').model('Footballer');

var CONTROLLER_NAME = 'footballers';

module.exports = {
    displayFootballers: function (req, res, next) {
        Footballer.find().exec(function (err, result) {
            res.render(CONTROLLER_NAME + '/all', {allFootballers: result});
        });
    },
    getAddFootballerForm: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/add');
    },
    add: function (req, res, next) {
        var data = req.body;
        Footballer.create(data, function (err, footballer) {
            if (err) {
                console.log('Error registering user: ' + err);
                res.redirect('/footballers')
            } else {
                console.log('Player ' + footballer.name + ' added successfully!');
                res.redirect('/footballers');
            }
        });
    }
};