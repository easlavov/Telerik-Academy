'use strict';

app.controller('DriverDetailsController', ['$scope', 'identity', 'driversData', '$routeParams', '$location',
    function($scope, identity, driversData, $routeParams, $location) {
        if (!identity.isAuthenticated()) {
            $location.path('/unauthorized');
        }

        var userId = $routeParams.id;
        driversData.getUserById(userId)
            .then(function (data) {
                $scope.user = data;
            });
}]);