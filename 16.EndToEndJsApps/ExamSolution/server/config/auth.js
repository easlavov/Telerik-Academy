var passport = require('passport');

module.exports = {
    login: function (req, res, next) {
        var auth = passport.authenticate('local', function (err, user) {
            if (err) {
                console.log('First error');
                return next(err);
            }

            if (!user) {
                req.session.error = 'No user found with these credentials!';
                res.redirect('/login');
            } else {
                req.logIn(user, function (err) {
                    if (err) {
                        req.session.error = err;
                        res.redirect('/login');
                    }

                    req.session.success = 'You have been logged in successfully!';
                    next();
                });
            }
        });

        auth(req, res, next);
    },
    logout: function (req, res, next) {
        req.logout();
        req.session.success = 'You have been logged out successfully!';
        res.redirect('/');
    },
    isAuthenticated: function (req, res, next) {
        if (!req.isAuthenticated()) {
            req.session.error = 'You must login to use this feature!';
            res.redirect('/login');
        } else {
            next();
        }
    },
    isInRole: function (role) {
        return function (req, res, next) {
            if (req.isAuthenticated() && req.user.roles.indexOf(role) > -1) {
                next();
            } else {
                res.status(403);
                res.end();
            }
        }
    }
};