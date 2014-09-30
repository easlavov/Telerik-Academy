app.factory('userInfo', ['$http', '$q', 'baseServiceUrl', 'authorization', function ($http, $q, baseServiceUrl, authorization) {

    function getUserInfo() {
        var deferred = $q.defer();
        var headers = authorization.getAuthorizationHeader();
        $http({method: 'GET', url: baseServiceUrl + 'api/users/userInfo', headers: headers})
            .success(function(data) {
                deferred.resolve(data);
            })
            .error(function(data) {
                deferred.reject(data);
            });

        return deferred.promise;
    }

    return {
        getUserInfo: getUserInfo
    }
}]);