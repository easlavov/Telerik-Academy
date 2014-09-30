app.factory('tripsData', ['$http', '$q', 'baseServiceUrl', 'authorization', function ($http, $q, baseServiceUrl, authorization) {

    function getLastTenTrips() {
        var deferred = $q.defer();

        $http({method: 'GET', url: baseServiceUrl + '/api/trips'})
            .success(function(data) {
                deferred.resolve(data);
            })
            .error(function(data) {
                deferred.reject(data);
            });

        return deferred.promise;
    }

    function getAllTrips(options) {
        var deferred = $q.defer();
        var url = baseServiceUrl + '/api/trips' + options;
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

    function getTripById(id) {
        var deferred = $q.defer();
        var url = baseServiceUrl + '/api/trips/' + id;
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

    function joinTrip(id) {
        var deferred = $q.defer();
        var url = baseServiceUrl + '/api/trips/' + id;
        var headers = authorization.getAuthorizationHeader();
        $http({method: 'PUT', url: url, headers: headers})
            .success(function(data) {
                deferred.resolve(data);
            })
            .error(function(data) {
                deferred.reject(data);
            });

        return deferred.promise;
    }

    function createTrip(data) {
        var deferred = $q.defer();
        var url = baseServiceUrl + '/api/trips/';
        var headers = authorization.getAuthorizationHeader();
        $http({method: 'POST', url: url, headers: headers, data: data})
            .success(function(data) {
                deferred.resolve(data);
            })
            .error(function(data) {
                deferred.reject(data);
            });

        return deferred.promise;
    }
    
    return {
        getLastTenTrips: getLastTenTrips,
        getAllTrips: getAllTrips,
        getTripById: getTripById,
        joinTrip: joinTrip,
        createTrip: createTrip
    }
}]);