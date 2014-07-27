var httpRequest = (function () {
    var getHttpRequest, makeRequest, getJson, postJson;
    getHttpRequest = (function () {
        var xmlHttpFactories;
        xmlHttpFactories = [
            function () {
                return new XMLHttpRequest();
            },
            function () {
                return new ActiveXObject("Msxml3.XMLHTTP");
            },
            function () {
                return new ActiveXObject("Msxml2.XMLHTTP.6.0");
            },
            function () {
                return new ActiveXObject("Msxml2.XMLHTTP.3.0");
            },
            function () {
                return new ActiveXObject("Msxml2.XMLHTTP");
            },
            function () {
                return new ActiveXObject("Microsoft.XMLHTTP");
            }
        ];
        return function () {
            var xmlFactory, _i, _len;
            for (_i = 0, _len = xmlHttpFactories.length; _i < _len; _i++) {
                xmlFactory = xmlHttpFactories[_i];
                try {
                    return xmlFactory();
                } catch (_error) {

                }
            }
            return null;
        };
    })();

    makeRequest = function (options) {
        var httpRequest, requestUrl, type, success, error, contentType, accept, data;
        httpRequest = getHttpRequest();
        options = options || {};
        //extract the values from the options and provide default values for the missing arguments
        requestUrl = options.url;
        type = options.type || 'GET';
        success = options.success || function () {
        };
        error = options.error || function () {
        };
        contentType = options.contentType || '';
        accept = options.accept || '';
        data = options.data || null;

        httpRequest.onreadystatechange = function () {
            if (httpRequest.readyState === 4) {
                switch (Math.floor(httpRequest.status / 100)) {
                    case 2:
                        success(httpRequest.responseText);
                        break;
                    default:
                        error(httpRequest.responseText);
                        break;
                }
            }
        };
        httpRequest.open(type, requestUrl, true);
        httpRequest.setRequestHeader('Content-Type', contentType);
        httpRequest.setRequestHeader('Accept', accept);
        return httpRequest.send(data);
    };

    getJson = function (url) {
        var deferred = Q.defer();
        makeRequest({
            url: url,
            contentType: 'application/json',
            success: parseJson,
            error: deferred.reject
        });
        function parseJson(string) {
            var json = JSON.parse(string);
            deferred.resolve(json);
        }

        return deferred.promise;
    };

    postJson = function (url, json) {
        var deferred = Q.defer();
        makeRequest({
            url: url,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(json),
            success: deferred.resolve,
            error: deferred.reject
        });
        return deferred.promise;
    };

    return {
        getJson: getJson,
        postJson: postJson
    }
})();

function addStudent(name, grade) {
    var deferred = Q.defer();
    var newStudentData = {
        name: name,
        grade: grade
    };
    var url = 'http://localhost:3000/students';
    httpRequest.postJson(url, newStudentData);
    deferred.resolve();
    return deferred.promise;
}

function getStudents() {
    var deferred = Q.defer();
    var url = 'http://localhost:3000/students';
    var studs = httpRequest.getJson(url);
    deferred.resolve(studs);
    return deferred.promise;
}

function printStudents(students) {
    students = students.students;
    var $list = $('<ul>');
    for (var i in students) {
        $list.append($('<li>').html(students[i].name));
    }

    $list.appendTo($('body'));
}