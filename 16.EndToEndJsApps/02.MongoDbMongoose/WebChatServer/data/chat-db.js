var User = require('../models/user');
var Message = require('../models/message');

function registerUser(userInfo, callback) {
    var userName,
        pass;

    if (!checkParameter(userInfo)) {
        callback('No parameter specified!');
        return;
    }

    userName = userInfo.user;
    pass = userInfo.pass;
    if (userName === undefined ||
            pass === undefined) {
        callback('User name and/or password incorrectly specified!');
        return;
    }

    // User name must be unique
    registerUniqueUser(userName, pass, callback);
}

function sendMessage(messageInfo, callback) {
    if (!checkParameter(messageInfo)) {
        callback('No parameter specified!');
        return;
    }

    var from = messageInfo.from;
    var to = messageInfo.to;
    var text = messageInfo.text;

    User.findOne({name: from})
        .exec(function (err, userFrom) {
            // Validating users existence in the database
            if (err) {
                callback(err);
            } else {
                if (userFrom === undefined) {
                    callback('From User not found!');
                    return;
                }
                User.findOne({name: to})
                    .exec(function (err, userTo) {
                        if (err) {
                            callback(err);
                        } else {
                            if (userTo === undefined) {
                                callback('To User not found!');
                                return;
                            }

                            // Now we have validated the users
                            var newMessage = new Message({
                                from: userFrom,
                                to: userTo,
                                text: text
                            });
                            newMessage.save();
                            callback(undefined, newMessage);
                        }
                    });
            }
        });
}

function getMessages(users, callback) {
    if (!checkParameter(users)) {
        callback('No parameter specified!');
        return;
    }

    var firstUser = users.with;
    var secondUser = users.and;
    if (firstUser === undefined ||
        secondUser === undefined) {
        callback('User names incorrectly specified!');
        return;
    }

    User.findOne({name: firstUser})
        .exec(function (err, userFrom) {
            // Validating users existence in the database
            if (err) {
                callback(err);
            } else {
                if (userFrom === undefined) {
                    callback('First User not found!');
                    return;
                }
                User.findOne({name: secondUser})
                    .exec(function (err, userTo) {
                        if (err) {
                            callback(err);
                        } else {
                            if (userTo === undefined) {
                                callback('Second User not found!');
                                return;
                            }

                            // Now we have validated the users and can look for the messages between them
                            Message.find()
                                .where('from').in([userFrom, userTo])
                                .where('to').in([userFrom, userTo])
                                .exec(function (err, messages) {
                                if (err) {
                                    callback(err);
                                } else {
                                    callback(messages);
                                }
                            })
                        }
                    });
            }
        });
}

function getAllUsers(callback) {
    User.find({}).exec(function (err, result) {
        if (err) {
            callback(err);
        } else {
            callback(undefined, result);
        }
    });
}

function getAllMessages(callback) {
    Message.find({}).exec(function (err, messages) {
        if (err) {
            callback(err);
        } else {
            callback(undefined, messages);
        }
    })
}

function checkParameter(parameter) {
    if (parameter === undefined) {
        return false;
    }

    return true;
}

function registerUniqueUser(userName, pass, callback) {
    User.find({
        name: userName
    })
        .exec(function (error, result) {
            var user;
            if (error) {
                callback(error);
            }

            if (result[0] !== undefined) {
                callback('User with the name ' + userName + ' already exists!');
            } else {
                user = new User({
                    name: userName,
                    password: pass
                });
                user.save(function (err, newUser) {
                    if (err) {
                        callback(err);
                        return;
                    }

                    callback(undefined, newUser);
                });
            }
        });
}

function clearAllData() {
    clearMessages();
    clearUsers();
}

function clearMessages() {
    Message.find().exec(function (err, messages) {
        messages.forEach(function (message) {
            message.remove();
        });
    });
}

function clearUsers() {
    User.find().exec(function (err, users) {
        users.forEach(function (user) {
            user.remove();
        });
    });
}

module.exports = {
    registerUser: registerUser,
    sendMessage: sendMessage,
    getMessages: getMessages,
    getAllUsers: getAllUsers,
    getAllMessages: getAllMessages,
    clearAllData: clearAllData
};