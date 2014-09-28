app.factory('gameData', ['$http', '$q', 'baseServiceUrl', 'authorization', function ($http, $q, baseServiceUrl, authorization) {
    var gamesApi = baseServiceUrl + '/game/status';

    function getAllGames() {
        var deferred = $q.defer();

        $http.get(gamesApi, {
            headers: authorization.getAuthorizationHeader()
        })
            .success(function (data) {
                deferred.resolve(data);
            }, function (response) {
                deferred.reject(response);
            });

        return deferred.promise;
    }

    return {
        getAllGames: getAllGames
    }
}]);