'use strict';

app.controller('DriversController', ['$scope', 'identity', 'driversData', function($scope, identity, driversData) {
    $scope.currentPage = 1;
    $scope.prevPage = prevPage;
    $scope.nextPage = nextPage;
    $scope.filterByName = getPage;
    $scope.emptyPage = false;

    // Check if anonymous
    $scope.loggedIn = identity.isAuthenticated();

    // If anonymous
    if (!$scope.loggedIn) {
        driversData.getLastTenDrivers()
            .then(function (data) {
                $scope.drivers = data;
            });
    }

    // If logged in
    if ($scope.loggedIn) {
        getPage();
    }

    function getPage() {
        var options = '?page=' + $scope.currentPage.toString();
        if ($scope.usernameFilter != undefined) {
            options += '&username=' + $scope.usernameFilter;
        }
        driversData.getAllDrivers(options)
            .then(function (data) {
                $scope.drivers = data;
                if (data.length === 0) {
                    $scope.emptyPage = true;
                } else {
                    $scope.emptyPage = false;
                }
            });
    }

    function prevPage() {
        if ($scope.currentPage > 1) {
            $scope.currentPage--;
        }

        getPage();
    }

    function nextPage() {
        $scope.currentPage++;
        getPage();
    }
}]);