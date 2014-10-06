var chatDb = require('./chat-db');
var globalDelay = 500;

function test() {
//    chatDb.clearAllData();
    addUsers();
}

function addUsers() {
    var newUsersData = [{
        user: 'Pesho',
        pass: 123456
    },{
        user: 'Gosho',
        pass: 123456
    },{
        user: 'Mincho',
        pass: 123456
    }];

    newUsersData.forEach(function (user) {
        chatDb.registerUser(user, function (err, newUser) {
            if (err) {
                console.log(err)
            } else {
                console.log('New user added: ' + newUser.name);
            }
        });
    });

    setTimeout(addMessages, globalDelay);
}

function addMessages() {
    var newMessagesData = [{
        from: 'Pesho',
        to: 'Gosho',
        text: 'Zdrasti!'
    },{
        from: 'Gosho',
        to: 'Pesho',
        text: 'Zdrasti! Kak si?'
    },{
        from: 'Pesho',
        to: 'Gosho',
        text: 'Ami biva!'
    },{
        from: 'Pesho',
        to: 'Mincho',
        text: 'Mincho, dai pari za bira!'
    }];

    newMessagesData.forEach(function (message) {
        chatDb.sendMessage(message, function (err, newMessage) {
            if (err) {
                console.log(err)
            } else {
                console.log('New message added: ' + newMessage)
            }
        });
    });

    setTimeout(displayMessages, globalDelay);
}

function displayMessages() {
    setTimeout(displayOne, globalDelay);

    function displayOne() {
        console.log('Displaying messages between Pesho and Gosho:');
        chatDb.getMessages({
            with: 'Pesho', and: 'Gosho'
        }, function (err, messages) {
            if (err) {
                console.log(err)
            } else {
                console.log(messages)
            }
        });


        setTimeout(displayTwo, globalDelay);
    }

    function displayTwo() {
        console.log('Displaying messages between Pesho and Mincho:');
        chatDb.getMessages({
            with: 'Pesho', and: 'Mincho'
        }, function (err, messages) {
            if (err) {
                console.log(err)
            } else {
                console.log(messages)
            }
        });
    }
}

module.exports = test;