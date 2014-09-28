'use strict';

var app = angular.module('myApp', ['ngRoute', 'ngResource', 'ngCookies']).
    config(['$routeProvider', function($routeProvider) {
        $routeProvider
            .when('/register', {
                templateUrl: 'views/partials/register.html',
                controller: 'SignUpCtrl'
            })
            .when('/games', {
                templateUrl: 'views/partials/games.html',
                controller: 'GamesListController'
            })
            .when('/create', {
                templateUrl: 'views/partials/create.html',
                controller: 'CreateGameController'
            })
            .when('/games/join/', {
                controller: 'JoinController'
            })
            .when('/games/play/:id', {
                templateUrl: 'views/partials/play.html',
                controller: 'PlayController'
            })
            .otherwise({ redirectTo: '/games' });
    }])
    .value('toastr', toastr)
    .constant('baseServiceUrl', 'http://localhost:55713');