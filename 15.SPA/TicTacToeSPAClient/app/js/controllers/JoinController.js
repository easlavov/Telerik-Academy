app.controller('JoinController',['$scope', 'joinGame', '$q', function ($scope, joinGame, $q) {
    joinGame.join()
        .then(function (data) {
            $scope.game = data;
        });
}]);