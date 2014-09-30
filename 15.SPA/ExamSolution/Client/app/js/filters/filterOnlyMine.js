app.filter('filterOnlyMine', function () {
   return function (trip) {
       if (trip.isMine === true) {
            return false;
       }

       return false;
   }
});