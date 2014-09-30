app.factory('driversData', ['$http', '$q', 'baseServiceUrl', 'authorization', function ($http, $q, baseServiceUrl, authorization) {

    function getLastTenDrivers() {
        var deferred = $q.defer();

        $http({method: 'GET', url: baseServiceUrl + '/api/drivers'})
            .success(function(data) {
                deferred.resolve(data);
            })
            .error(function(data) {
                deferred.reject(data);
            });

        return deferred.promise;
    }

    function getAllDrivers(options) {
        var deferred = $q.defer();
        var url = baseServiceUrl + '/api/drivers' + options;
        var headers = authorization.getAuthorizationHeader();
        $http({method: 'GET', url: url, headers: headers})
            .success(function(data) {
                deferred.resolve(data);
            })
            .error(function(data) {
                deferred.reject(data);
            });

        return deferred.promise;
    }

    function getUserById(id) {
        var deferred = $q.defer();
        var url = baseServiceUrl + '/api/drivers/' + id;
        var headers = authorization.getAuthorizationHeader();
        $http({method: 'GET', url: url, headers: headers})
            .success(function(data) {
                deferred.resolve(data);
            })
            .error(function(data) {
                deferred.reject(data);
            });

        return deferred.promise;
    }

    return {
        getLastTenDrivers: getLastTenDrivers,
        getAllDrivers: getAllDrivers,
        getUserById: getUserById
    }
}]);