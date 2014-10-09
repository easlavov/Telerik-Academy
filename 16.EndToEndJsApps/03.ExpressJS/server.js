var express = require('express');

var env = process.env.NODE_ENV || 'development';

var app = express();
var config = require('./config/config')[env];

