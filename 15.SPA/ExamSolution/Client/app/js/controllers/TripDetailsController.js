'use strict';

app.controller('TripDetailsController', ['$scope', 'identity', 'tripsData', '$routeParams', '$location', function($scope, identity, tripsData, $routeParams, $location) {
    if (!identity.isAuthenticated()) {
        $location.path('/unauthorized');
    }

    var tripId = $routeParams.id;
    tripsData.getTripById(tripId)
        .then(function (data) {
            $scope.trip = data;
            $scope.canJoin = canJoin();
        });
    $scope.joinTrip = joinTrip;

    function joinTrip() {
        tripsData.joinTrip(tripId)
            .then(function (response) {
                $scope.trip = response;
                $scope.canJoin = canJoin();
            });
    }

    function canJoin() {
        return !($scope.trip.isMine);
    }
}]);