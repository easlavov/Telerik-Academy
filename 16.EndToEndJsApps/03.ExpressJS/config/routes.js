var auth = require('./auth'),
    usersController = require('../controllers/usersController');

module.exports = function (app) {
    app.get('/api/users', usersController.getAllUsers);
    app.post('/api/users', usersController.createUser);

    app.post('/login', auth.login);
    app.post('/logout', auth.logout);
};