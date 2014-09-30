app.factory('citiesData', ['$http', '$q', 'baseServiceUrl', 'authorization', function ($http, $q, baseServiceUrl, authorization) {

    function getCities() {
        var deferred = $q.defer();

        $http({method: 'GET', url: baseServiceUrl + '/api/cities'})
            .success(function(data) {
                deferred.resolve(data);
            })
            .error(function(data) {
                deferred.reject(data);
            });

        return deferred.promise;
    }

    return {
        getCities: getCities
    }
}]);