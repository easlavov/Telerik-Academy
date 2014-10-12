var express = require('express'),
    bodyParser = require('body-parser'),
    cookieParser = require('cookie-parser'),
    session = require('express-session'),
    passport = require('passport');

module.exports = function (app, config) {
    app.set('view engine', 'jade');
    app.set('views', config.rootPath + '/server/views');
    app.use(cookieParser());
    app.use(bodyParser.json());
    app.use(bodyParser.urlencoded({
        extended: true
    }));
    app.use(session({
            secret: 'en taro adun!',
            saveUninitialized: true,
            resave: true}
    ));
    app.use(passport.initialize());
    app.use(passport.session());
    app.use(express.static(config.rootPath + '/public'));
    app.use(function(req, res, next) {
        if (req.session.error) {
            var msg = req.session.error;
            req.session.error = undefined;
            app.locals.errorMessage = msg;
        }
        else {
            app.locals.errorMessage = undefined;
        }

        next();
    });
    app.use(function(req, res, next) {
        if (req.session.success) {
            var msg = req.session.success;
            req.session.success = undefined;
            app.locals.successMessage = msg;
        }
        else {
            app.locals.successMessage = undefined;
        }

        next();
    });
    app.use(function(req, res, next) {
        if (req.user) {
            app.locals.currentUser = req.user;
        }

        next();
    });
};
