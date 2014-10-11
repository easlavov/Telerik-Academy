var auth = require('./auth'),
    UsersController = require('../controllers/UsersController'),
    FootballersController = require('../controllers/FootballersController');

module.exports = function (app) {
    app.get('/', function (req, res) {
        res.render('index', {currentUser: req.user});
    });

    app.get('/register', UsersController.getRegistrationForm);
    app.post('/register', UsersController.createUser);

    app.get('/login', UsersController.getLoginForm);
    app.post('/login', auth.login, UsersController.postLogin);

    app.get('/logout', auth.logout);

    app.get('/footballers', FootballersController.displayFootballers);

    app.get('/footballers/add', FootballersController.getAddFootballerForm);
    app.post('/footballers/add', FootballersController.add);

//    app.get('/api/users', UsersController.getAllUsers);

    app.get('*', function (req, res) {
        res.render('index', {currentUser: req.user});
    });
};