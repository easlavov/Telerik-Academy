'use strict';

app.controller('GamesListController', ['$scope', 'notifier', 'gamesData', function($scope, notifier, gamesData) {
    notifier.success('Games!');
    notifier.error('Games!');

    var allGames;
    gamesData.getAllGames()
        .then(function (data) {
            allGames = data;

            $scope.games = allGames;
        });
}]);