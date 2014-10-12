var auth = require('./auth'),
    controllers = require('../controllers/index');

module.exports = function (app) {
    app.get('/', function (req, res) {
        res.render('index', {currentUser: req.user});
    });

    app.get('/register', controllers.users.getRegistrationForm);
    app.post('/register', controllers.users.createUser);

    app.get('/login', controllers.users.getLoginForm);
    app.post('/login', auth.login, controllers.users.postLogin);

    app.get('/logout', auth.logout);

    app.get('/footballers', controllers.footballers.displayFootballers);

    app.get('/footballers/add', controllers.footballers.getAddFootballerForm);
    app.post('/footballers/add', controllers.footballers.add);

//    app.get('/api/users', UsersController.getAllUsers);

    app.get('*', function (req, res) {
        res.render('index', {currentUser: req.user});
    });
};