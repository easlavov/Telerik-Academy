app.factory('joinGame', ['$http', '$q', 'authorization', 'baseServiceUrl', function ($http, $q, authorization, baseServiceUrl) {

    var url = baseServiceUrl + '/game/join';

    function join() {
        var deferred = $q.defer();

        $http.post(url, {}, {
                headers: authorization.getAuthorizationHeader()
            })
            .success(function(data) {
                deferred.resolve(data);
            }, function(response) {
                deferred.reject(response);
            });

        return deferred.promise;
    }

    return {
        join: join
    }
}]);