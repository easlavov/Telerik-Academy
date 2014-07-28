/// <reference path="_references.js" />
define(['jquery', 'q'], function ($, Q) {
    'use strict';
    var httpRequester;
    httpRequester = (function () {
        function getJson(url) {
            var deferred = Q.defer();

            $.ajax({
                type: 'GET',
                url: url,
                contentType: 'application/json',
                success: function (data) {
                    deferred.resolve(data);
                },
                error: function (data) {
                    deferred.reject(data);
                }
            });

            return deferred.promise;
        }

        function postJson(url, jsonObj) {
            var deferred = Q.defer();

            $.ajax({
                type: 'POST',
                url: url,
                contentType: 'application/json',
                data: JSON.stringify(jsonObj),
                success: function (data) {
                    deferred.resolve(data);
                },
                error: function (data) {
                    deferred.reject(data);
                }
            });

            return deferred.promise;
        }

        return {
            getJson: getJson,
            postJson: postJson
        };
    })();

    return httpRequester;
});