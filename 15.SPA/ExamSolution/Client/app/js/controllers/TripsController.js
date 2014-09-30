'use strict';

app.controller('TripsController', ['$scope', 'identity', 'tripsData', 'citiesData', function($scope, identity, tripsData, citiesData) {
    var finalPage;
    $scope.currentPage = 1;
    $scope.prevPage = prevPage;
    $scope.nextPage = nextPage;
    $scope.filter = filter;
    $scope.emptyPage = false;

    citiesData.getCities()
        .then(function (data) {
            $scope.destinationsFrom = data;
            $scope.destinationsTo = data;
        });

    // Check if anonymous
    $scope.loggedIn = identity.isAuthenticated();

    // If anonymous
    if (!$scope.loggedIn) {
        tripsData.getLastTenTrips()
            .then(function (data) {
                $scope.trips = data;
            });
    }

    // If logged in
    if ($scope.loggedIn) {
        getPage();
    }

    // api/trips?page=1&orderBy=seats&orderType=asc&from=Sofia&finished=true&onlyMine=false

    function filter() {
        getPage(true);
    }

    function getPage(restart) {
        var options = getOptions(restart);

        tripsData.getAllTrips(options)
            .then(function (data) {
                $scope.trips = data;
                if (data.length === 0) {
                    $scope.emptyPage = true;
                } else {
                    $scope.emptyPage = false;
                    if (data.length < 10) {
                        finalPage = true;
                    } else {
                        finalPage = false;
                    }
                }
            });
    }

    function getOptions(restart) {
        var options;
        if (restart === true) {
            options = '?page=1';
            $scope.currentPage = 1;
        } else {
            options = '?page=' + $scope.currentPage.toString();
        }
        if ($scope.orderBy !== undefined) {
            options += '&orderBy=' + $scope.orderBy;
        }

        if ($scope.orderType !== undefined) {
            options += '&orderType=' + $scope.orderType;
        }

        if ($scope.from !== undefined) {
            options += '&from=' + $scope.from;
        }

        if ($scope.to !== undefined) {
            options += '&to=' + $scope.to;
        }

        if ($scope.finished !== undefined) {
            options += '&finished=' + $scope.finished;
        }

        if ($scope.onlyMine !== undefined) {
            options += '&onlyMine=' + $scope.onlyMine;
        }

        return options;
    }

    function prevPage() {
        if ($scope.currentPage > 1) {
            $scope.currentPage--;
        }

        getPage();
    }

    function nextPage() {
        if (!finalPage) {
            $scope.currentPage++;
        }

        getPage();
    }
}]);