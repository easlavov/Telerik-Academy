'use strict';

app.controller('CreateTripController', ['$scope', 'identity', 'citiesData', '$location', 'notifier', 'tripsData',
    function($scope, identity, citiesData, $location, notifier, tripsData) {
    if (!identity.isAuthenticated()) {
        $location.path('/unauthorized');
    }

    citiesData.getCities()
        .then(function (data) {
            $scope.destinationsFrom = data;
            $scope.destinationsTo = data;
        });

    $scope.createTrip = createTrip;

    function createTrip() {
        var info = {
            "from": $scope.from,
            "to": $scope.to,
            "availableSeats": $scope.availableSeats,
            "departureTime": $scope.departureTime
        };
        tripsData.createTrip(info).
            then(function () {
                notifier.success('Trip creation successful!');
                $location.path('/trips/');
            })
    }
}]);