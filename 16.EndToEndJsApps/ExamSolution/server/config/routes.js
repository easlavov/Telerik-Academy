var auth = require('./auth'),
    controllers = require('../controllers/index');

module.exports = function (app) {
    app.get('/', function (req, res) {
        res.render('index');
    });

    app.get('/register', controllers.users.getRegistrationForm);
    app.post('/register', controllers.users.createUser);

    app.get('/login', controllers.users.getLoginForm);
    app.post('/login', auth.login, controllers.users.postLogin);

    app.get('/profile', controllers.users.getProfilePage);
    app.post('/profile', controllers.users.updateUser);

    app.get('/logout', auth.logout);

    app.get('/events/create', auth.isAuthenticated, controllers.events.getEventCreationForm);
    app.post('/events/create', auth.isAuthenticated, controllers.events.create);
    app.get('/events', auth.isAuthenticated, controllers.events.active);
    app.get('/events/passed', auth.isAuthenticated, controllers.events.passed);
    app.get('/events/:id', auth.isAuthenticated, controllers.events.details);
    app.post('/events/:id', auth.isAuthenticated, controllers.events.comment);
    app.get('/events/join/:id', auth.isAuthenticated, controllers.events.join);
    app.put('/events/:id', auth.isAuthenticated, controllers.events.evaluate);

    app.get('*', function (req, res) {
        res.render('index');
    });
};