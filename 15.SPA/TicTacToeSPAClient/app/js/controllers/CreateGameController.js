app.controller('CreateGameController', ['$http', 'baseServiceUrl', 'authorization', '$scope', function ($http, baseServiceUrl, authorization, $scope) {
    var createGameUrl = baseServiceUrl + '/game/create';
    var authHeader = authorization.getAuthorizationHeader();

    $scope.createGame = createGame;

    function createGame() {
        $http({
            method: "POST",
            url: createGameUrl,
            headers: authHeader
        });
    }
}]);