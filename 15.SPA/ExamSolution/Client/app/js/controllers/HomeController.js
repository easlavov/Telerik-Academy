'use strict';

app.controller('HomeController', ['$scope', 'notifier', 'tripsData', 'driversData', function($scope, notifier, tripsData, driversData) {
//    notifier.success('Partial 1!');
//    notifier.error('Partial 1');
    tripsData.getLastTenTrips()
        .then(function (data) {
            $scope.trips = data;
        });

    driversData.getLastTenDrivers()
        .then(function (data) {
            $scope.drivers = data;
        });
}]);